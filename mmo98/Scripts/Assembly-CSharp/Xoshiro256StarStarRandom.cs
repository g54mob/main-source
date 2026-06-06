using System;

public class Xoshiro256StarStarRandom
{
	private Xoshiro256StarStar _algorithm = new Xoshiro256StarStar();

	public ref Xoshiro256StarStar State => ref _algorithm;

	public void InitState()
	{
		InitState((ulong)DateTime.Now.Ticks);
	}

	public void InitState(Xoshiro256StarStar state)
	{
		_algorithm.InitState(state.S0, state.S1, state.S2, state.S3);
	}

	public void InitState(ulong s0, ulong s1, ulong s2, ulong s3)
	{
		_algorithm.InitState(s0, s1, s2, s3);
	}

	public void InitState(uint seed)
	{
		InitState((ulong)seed);
	}

	public void InitState(ulong seed)
	{
		do
		{
			_algorithm.S0 = SplitMix64.Next(ref seed);
			_algorithm.S1 = SplitMix64.Next(ref seed);
			_algorithm.S2 = SplitMix64.Next(ref seed);
			_algorithm.S3 = SplitMix64.Next(ref seed);
		}
		while (_algorithm.S0 == 0L && _algorithm.S1 == 0L && _algorithm.S2 == 0L && _algorithm.S3 == 0L);
	}

	public uint NextUInt()
	{
		return (uint)(_algorithm.Next() >> 32);
	}

	public ulong NextULong()
	{
		return _algorithm.Next();
	}

	public void Jump()
	{
		_algorithm.Jump();
	}

	public void LongJump()
	{
		_algorithm.LongJump();
	}
}
