namespace Kata_Hashi;

public class Island(int code)
{
    public readonly int X = code / 100;
    public readonly int Y = code % 100 / 10;
    public readonly int Value = code % 10;

    public int Code => X * 100 + Y * 10 + Value;

    public override bool Equals(object? obj)
    {
        if (obj is not Island)
            return false;

        return (this.Code == ((Island)obj).Code);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y, Value);
    }
}

