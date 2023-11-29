namespace Kata_Hashi;

public class HashiGame
{
    private readonly List<Island> _islands;
    private readonly List<Bridge> _bridges;

    public HashiGame(Solution solution)
    {
        _islands = solution.Islands;
        _bridges = solution.Bridges;

        Solve();
    }

    public bool IsCorrect { get; private set; }

    public void Solve()
    {
        IsCorrect = true;

        CheckIslandsAndBridgesForDuplicates();
        ValidateIslands();
        CheckIfBridgesConnectIslandsPresentInTheList();
        CheckBridgeValues();
        CheckIfAnyBridgesCrossesAnIsland();
        CheckIfAnyTwoBridgesCrossEachOther();
        CheckForDiagonalBridges();
        CheckIfMoreThanTwoBridgesConnectAnyTwoIslands();
        CheckIfTheNumberOfBridgesConnectedToAnIslandIsEqualToTheIslandValue();
        CheckIfAllIslandsAreConnectedInOneGroup();
    }

    public bool CheckIslandsAndBridgesForDuplicates()
    {
        if (_islands.Distinct().Count() == _islands.Count() && _bridges.Distinct().Count() == _bridges.Count())
            return true;

        return IsCorrect = false;
    }

    public bool ValidateIslands()
    {
        if (!(from island in _islands
              where island.X < 0 || island.X > 9 || island.Y < 0 || island.Y > 9
              select island).Any())
            return true;

        return IsCorrect = false;
    }

    public bool CheckIfBridgesConnectIslandsPresentInTheList()
    {
        if (!(from bridge in _bridges
              where !_islands.Contains(bridge.Island1) || !_islands.Contains(bridge.Island2)
              select bridge).Any())
            return true;

        return IsCorrect = false;
    }

    public bool CheckBridgeValues()
    {
        if (!(from island in _islands
              let bridges = _bridges.Where(b => b.Island1.Equals(island) || b.Island2.Equals(island))
              let sum = bridges.Sum(b => b.Value)
              where sum != island.Code % 10
              select island).Any())
            return true;

        return IsCorrect = false;
    }

    public bool CheckForDiagonalBridges()
    {
        if (!(from bridge in _bridges
              let island1 = bridge.Island1
              let island2 = bridge.Island2
              let isHorizontalOk = island1.X == island2.X
              let isVerticalOk = island1.Y == island2.Y
              where !isHorizontalOk && !isVerticalOk
              select isHorizontalOk).Any())
            return true;

        return IsCorrect = false;
    }

    public bool CheckIfAnyTwoBridgesCrossEachOther()
    {
        foreach (var bridge1 in _bridges)
        {
            foreach (var bridge2 in _bridges)
            {
                if (bridge1.Equals(bridge2))
                {
                    continue;
                }

                var isHorizontal1 = bridge1.Island1.X == bridge1.Island2.X;
                var isVertical1 = bridge1.Island1.Y == bridge1.Island2.Y;

                var isHorizontal2 = bridge2.Island1.X == bridge2.Island2.X;
                var isVertical2 = bridge2.Island1.Y == bridge2.Island2.Y;

                if (isHorizontal1 && isHorizontal2)
                {
                    if (bridge1.Island1.Y != bridge2.Island1.Y)
                        continue;

                    if (bridge1.Island1.X > bridge2.Island1.X && bridge1.Island1.X < bridge2.Island2.X)
                        return IsCorrect = false;

                    if (bridge1.Island1.X < bridge2.Island1.X && bridge1.Island1.X > bridge2.Island2.X)
                        return IsCorrect = false;
                }

                if (isVertical1 && isVertical2)
                {
                    if (bridge1.Island1.X != bridge2.Island1.X)
                        continue;

                    if (bridge1.Island1.Y > bridge2.Island1.Y && bridge1.Island1.Y < bridge2.Island2.Y)
                        return IsCorrect = false;

                    if (bridge1.Island1.Y < bridge2.Island1.Y && bridge1.Island1.Y > bridge2.Island2.Y)
                        return IsCorrect = false;
                }

                if (isHorizontal1 && isVertical2)
                {
                    if (bridge1.Island1.X > bridge2.Island1.X && bridge1.Island1.X < bridge2.Island2.X)
                    {
                        if (bridge2.Island1.Y > bridge1.Island1.Y && bridge2.Island1.Y < bridge1.Island2.Y)
                            return IsCorrect = false;

                        if (bridge2.Island1.Y < bridge1.Island1.Y && bridge2.Island1.Y > bridge1.Island2.Y)
                            return IsCorrect = false;
                    }
                }
            }
        }

        return true;
    }

    public bool CheckIfAnyBridgesCrossesAnIsland()
    {
        foreach (var bridge in _bridges)
        {
            var island1 = bridge.Island1;
            var island2 = bridge.Island2;

            foreach (var island in _islands)
            {
                if (island.Equals(island1) || island.Equals(island2))
                    continue;

                var isHorizontal = island1.X == island2.X;
                var isVertical = island1.Y == island2.Y;

                if (isHorizontal)
                {
                    if (island.X == island1.X && island.Y > island1.Y && island.Y < island2.Y)
                        return IsCorrect = false;
                }

                if (!isVertical)
                    continue;

                if (island.Y != island1.Y || island.X <= island1.X || island.X >= island2.X)
                    continue;

                return IsCorrect = false;
            }
        }

        return true;
    }

    public bool CheckIfMoreThanTwoBridgesConnectAnyTwoIslands()
    {
        if (!(from island1 in _islands
              from island2 in _islands
              where !island1.Equals(island2)
              select _bridges.Where(b => b.Island1.Equals(island1) && b.Island2.Equals(island2)))
            .Any(bridges => bridges.Count() > 2))
            return true;

        return IsCorrect = false;
    }

    public bool CheckIfTheNumberOfBridgesConnectedToAnIslandIsEqualToTheIslandValue()
    {
        if (!(from island in _islands
              let bridges = _bridges.Where(b => b.Island1.Equals(island) || b.Island2.Equals(island))
              where bridges.Sum(b => b.Value) != island.Code % 10
              select island).Any())
            return true;

        return IsCorrect = false;
    }

    public bool CheckIfAllIslandsAreConnectedInOneGroup()
    {
        var groups = new List<List<Island>>();

        foreach (var island in _islands)
        {
            var group = new List<Island> { island };

            foreach (var bridge in _bridges)
            {
                if (bridge.Island1.Equals(island))
                    group.Add(bridge.Island2);

                if (bridge.Island2.Equals(island))
                    group.Add(bridge.Island1);
            }

            groups.Add(group);
        }

        var allDistinctIslands = groups.SelectMany(group => group).Distinct();

        if (allDistinctIslands.Count() == _islands.Count())
            return true;

        return IsCorrect = false;
    }
}