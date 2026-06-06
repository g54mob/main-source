using System;

public class SplitMix64Random
{
	private SplitMix64 _algorithm = new SplitMix64();

	public ref SplitMix64 State => ref _algorithm;

	public void InitState()
	{
		_algorithm.State = (ulong)DateTime.Now.Ticks;
	}

	public void InitState(SplitMix64 state)
	{
		_algorithm.State = state.State;
	}

	public void InitState(uint seed)
	{
		InitState((ulong)seed);
	}

	public void InitState(ulong seed)
	{
		_algorithm.State = seed;
	}

	public uint NextUInt()
	{
		return (uint)(_algorithm.Next() >> 32);
	}

	public ulong NextULong()
	{
		return _algorithm.Next();
	}
}
