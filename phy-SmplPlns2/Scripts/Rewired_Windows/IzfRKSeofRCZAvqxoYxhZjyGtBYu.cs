using System;
using System.Runtime.CompilerServices;

internal struct IzfRKSeofRCZAvqxoYxhZjyGtBYu
{
	private uint EjTENObWpoUttLyDzxaValhLuyLS;

	private ulong clqLWBlBiuuADWGufDRFeRvoxpMs;

	private static readonly bool rcVaqrMvJgFmNXzLnZPKbldteyFc;

	public static readonly int XEMIkMEnmiseJNAcBsSeTdQNyUao;

	static IzfRKSeofRCZAvqxoYxhZjyGtBYu()
	{
		rcVaqrMvJgFmNXzLnZPKbldteyFc = IntPtr.Size == 8;
		XEMIkMEnmiseJNAcBsSeTdQNyUao = (rcVaqrMvJgFmNXzLnZPKbldteyFc ? 8 : 4);
	}

	public static IzfRKSeofRCZAvqxoYxhZjyGtBYu pmQJVzEFqhOMqdyQBxncSgiCDyMy(byte[] P_0, int P_1)
	{
		IzfRKSeofRCZAvqxoYxhZjyGtBYu result = default(IzfRKSeofRCZAvqxoYxhZjyGtBYu);
		if (rcVaqrMvJgFmNXzLnZPKbldteyFc)
		{
			result.clqLWBlBiuuADWGufDRFeRvoxpMs = BitConverter.ToUInt64(P_0, P_1);
		}
		else
		{
			result.EjTENObWpoUttLyDzxaValhLuyLS = BitConverter.ToUInt32(P_0, P_1);
		}
		return result;
	}

	[SpecialName]
	public static uint JEZIMqbOVZARkpUNGcvRvUozHgscA(IzfRKSeofRCZAvqxoYxhZjyGtBYu P_0)
	{
		if (rcVaqrMvJgFmNXzLnZPKbldteyFc)
		{
			return (uint)P_0.clqLWBlBiuuADWGufDRFeRvoxpMs;
		}
		return P_0.EjTENObWpoUttLyDzxaValhLuyLS;
	}

	[SpecialName]
	public static ulong JEZIMqbOVZARkpUNGcvRvUozHgscA(IzfRKSeofRCZAvqxoYxhZjyGtBYu P_0)
	{
		if (rcVaqrMvJgFmNXzLnZPKbldteyFc)
		{
			return P_0.clqLWBlBiuuADWGufDRFeRvoxpMs;
		}
		return P_0.EjTENObWpoUttLyDzxaValhLuyLS;
	}

	public string eEVckOVbScGxYwpacbdVeDqNAcNm()
	{
		if (rcVaqrMvJgFmNXzLnZPKbldteyFc)
		{
			return clqLWBlBiuuADWGufDRFeRvoxpMs.ToString();
		}
		return EjTENObWpoUttLyDzxaValhLuyLS.ToString();
	}
}
