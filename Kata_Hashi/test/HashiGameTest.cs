using FluentAssertions;
using Kata_Hashi;
using Xunit;

namespace Kata_Bowling;

public class HashiGameTest
{
    /*
     * 2
     * ‖
     * 3 - 1
     */
    private readonly Solution _solution1 = new(
        new() { new(113), new(211), new(122) },
        new() { new(113, 211, 1), new(113, 122, 2) });

    /*
     * 2 ----- 1
     * |
     * 5 = 2
     * ‖  
     * 4 ===== 2
     */
    private readonly Solution _solution2 = new(
        new()
        {
            new(114), new(312), new(125), new(222), new(132), new(331)
        },
        new()
        {
            new(114, 312, 2), new(114, 125, 2), new(125, 222, 2),
            new (125, 132, 1), new(132, 331, 1)
        });

    /*
     * https://jayisgames.com/images/conceptis-hashi/hashi8x8p10.jpg
     */
    private readonly Solution _solution3 = new(
        new()
        {
            new(113), new(315), new(513), new(813), new(133), new(332),
            new(155), new(454), new(423), new(621), new(472), new(271),
            new(184), new(383), new(583), new(781), new(565), new(762),
            new(533), new(731), new(854), new(651), new(874), new(672)
        },
        new()
        {
            new(113, 315, 2), new(315, 513, 1), new(513, 813, 2),
            new(113, 133, 1), new(315, 332, 2), new(133, 155, 2),
            new(155, 454, 1), new(454, 423, 2), new(423, 621, 1),
            new(454, 472, 1), new(472, 271, 1), new(155, 184, 2),
            new(184, 383, 2), new(383, 583, 1), new(583, 781, 1),
            new(583, 565, 1), new(565, 762, 2), new(565, 533, 2),
            new(533, 731, 1), new(813, 854, 1), new(854, 651, 1),
            new(854, 874, 2), new(874, 672, 2)

        }
    );

    [Fact]
    public void Test_bridge_values_check()
    {
        var game1 = new HashiGame(_solution1);
        var game2 = new HashiGame(_solution2);
        var game3 = new HashiGame(_solution3);

        game1.CheckBridgeValues().Should().BeTrue();
        game2.CheckBridgeValues().Should().BeTrue();
        game3.CheckBridgeValues().Should().BeTrue();
    }

    [Fact]
    public void Test_diagonal_bridges_check()
    {
        var game1 = new HashiGame(_solution1);
        var game2 = new HashiGame(_solution2);
        var game3 = new HashiGame(_solution3);

        game1.CheckForDiagonalBridges().Should().BeTrue();
        game2.CheckForDiagonalBridges().Should().BeTrue();
        game3.CheckForDiagonalBridges().Should().BeTrue();
    }

    [Fact]
    public void Test_two_bridges_crossing_each_other_check()
    {
        var game1 = new HashiGame(_solution1);
        var game2 = new HashiGame(_solution2);
        var game3 = new HashiGame(_solution3);

        game1.CheckIfAnyTwoBridgesCrossEachOther().Should().BeTrue();
        game2.CheckIfAnyTwoBridgesCrossEachOther().Should().BeTrue();
        game3.CheckIfAnyTwoBridgesCrossEachOther().Should().BeTrue();
    }

    [Fact]
    public void Test_if_any_bridges_crosses_an_island_check()
    {
        var game1 = new HashiGame(_solution1);
        var game2 = new HashiGame(_solution2);
        var game3 = new HashiGame(_solution3);

        game1.CheckIfAnyBridgesCrossesAnIsland().Should().BeTrue();
        game2.CheckIfAnyBridgesCrossesAnIsland().Should().BeTrue();
        game3.CheckIfAnyBridgesCrossesAnIsland().Should().BeTrue();
    }

    [Fact]
    public void Test_if_more_than_two_bridges_connect_any_two_islands_check()
    {
        var game1 = new HashiGame(_solution1);
        var game2 = new HashiGame(_solution2);
        var game3 = new HashiGame(_solution3);

        game1.CheckIfMoreThanTwoBridgesConnectAnyTwoIslands().Should().BeTrue();
        game2.CheckIfMoreThanTwoBridgesConnectAnyTwoIslands().Should().BeTrue();
        game3.CheckIfMoreThanTwoBridgesConnectAnyTwoIslands().Should().BeTrue();
    }

    [Fact]
    public void Test_if_the_number_of_bridges_connected_to_an_island_is_equal_to_the_island_value_check()
    {
        var game1 = new HashiGame(_solution1);
        var game2 = new HashiGame(_solution2);
        var game3 = new HashiGame(_solution3);

        game1.CheckIfTheNumberOfBridgesConnectedToAnIslandIsEqualToTheIslandValue().Should().BeTrue();
        game2.CheckIfTheNumberOfBridgesConnectedToAnIslandIsEqualToTheIslandValue().Should().BeTrue();
        game3.CheckIfTheNumberOfBridgesConnectedToAnIslandIsEqualToTheIslandValue().Should().BeTrue();
    }

    [Fact]
    public void Test_if_all_islands_are_connected_in_one_group_check()
    {
        var game1 = new HashiGame(_solution1);
        var game2 = new HashiGame(_solution2);
        var game3 = new HashiGame(_solution3);

        game1.CheckIfAllIslandsAreConnectedInOneGroup().Should().BeTrue();
        game2.CheckIfAllIslandsAreConnectedInOneGroup().Should().BeTrue();
        game3.CheckIfAllIslandsAreConnectedInOneGroup().Should().BeTrue();
    }
}