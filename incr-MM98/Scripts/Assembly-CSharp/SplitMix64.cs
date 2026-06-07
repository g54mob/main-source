using System.Runtime.CompilerServices;

public class SplitMix64
{
	private static readonly SplitMix64 staticAlgorithm = new SplitMix64();

	public ulong State { get; set; }

	public SplitMix64()
	{
	}

	public SplitMix64(ulong state)
	{
		State = state;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public ulong Next()
	{
		ulong num = (State += 11400714819323198485uL);
		long num2 = (long)(num ^ (num >> 30)) * -4658895280553007687L;
		long num3 = (long)((ulong)num2 ^ ((ulong)num2 >> 27)) * -7723592293110705685L;
		return (ulong)num3 ^ ((ulong)num3 >> 31);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ulong Next(ref ulong state)
	{
		staticAlgorithm.State = state;
		ulong result = staticAlgorithm.Next();
		state = staticAlgorithm.State;
		return result;
	}
}
