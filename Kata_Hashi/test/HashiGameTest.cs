using FluentAssertions;
using Kata_Hashi;
using Xunit;

namespace Kata_Bowling;

public class HashiGameTest
{
    private readonly Solution _solution1 = new(
        new() { new(113), new(211), new(122) },
        new() { new(113, 211, 1), new(113, 122, 2) });

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

    // https://jayisgames.com/images/conceptis-hashi/hashi8x8p10.jpg
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
    public void Solution1_is_correct()
    {
        var game = new HashiGame(_solution1);
        game.IsCorrect.Should().BeTrue();
    }

    [Fact]
    public void Solution2_is_correct()
    {
        var game = new HashiGame(_solution2);
        game.IsCorrect.Should().BeTrue();
    }

    [Fact]
    public void Solution3_is_correct()
    {
        var game = new HashiGame(_solution3);
        game.IsCorrect.Should().BeTrue();
    }
}