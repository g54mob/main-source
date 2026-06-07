using System.Runtime.CompilerServices;

public class Xoshiro256StarStar
{
	private static readonly Xoshiro256StarStar staticAlgorithm = new Xoshiro256StarStar();

	public ulong S0 { get; set; }

	public ulong S1 { get; set; }

	public ulong S2 { get; set; }

	public ulong S3 { get; set; }

	public Xoshiro256StarStar()
	{
	}

	public Xoshiro256StarStar(ulong s0, ulong s1, ulong s2, ulong s3)
	{
		InitState(s0, s1, s2, s3);
	}

	public void InitState(ulong s0, ulong s1, ulong s2, ulong s3)
	{
		S0 = s0;
		S1 = s1;
		S2 = s2;
		S3 = s3;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public ulong Next()
	{
		ulong s = S0;
		ulong s2 = S1;
		ulong s3 = S2;
		ulong s4 = S3;
		ulong result = RotateLeft(s2 * 5, 7) * 9;
		ulong num = s2 << 9;
		s3 ^= s;
		s4 ^= s2;
		s2 ^= s3;
		s ^= s4;
		s3 ^= num;
		s4 = RotateLeft(s4, 11);
		S0 = s;
		S1 = s2;
		S2 = s3;
		S3 = s4;
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Jump()
	{
		JumpCore(1733541517147835066uL, 15395012609548302636uL, 12202545078643706282uL, 4155657270789760540uL);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void LongJump()
	{
		JumpCore(8566230491382795199uL, 14195432079911694259uL, 8606660816089834049uL, 4111957640723818037uL);
	}

	private void JumpCore(ulong j0, ulong j1, ulong j2, ulong j3)
	{
		ulong num = 0uL;
		ulong num2 = 0uL;
		ulong num3 = 0uL;
		ulong num4 = 0uL;
		for (int i = 0; i < 4; i++)
		{
			for (int k = 0; k < 32; k++)
			{
				if (((i switch
				{
					0 => (long)j0, 
					1 => (long)j1, 
					2 => (long)j2, 
					3 => (long)j3, 
					_ => 0L, 
				}) & (1L << k)) != 0L)
				{
					num ^= S0;
					num2 ^= S1;
					num3 ^= S2;
					num4 ^= S3;
				}
				Next();
			}
		}
		S0 = num;
		S1 = num2;
		S2 = num3;
		S3 = num4;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ulong Next(ref ulong s0, ref ulong s1, ref ulong s2, ref ulong s3)
	{
		staticAlgorithm.InitState(s0, s1, s2, s3);
		ulong result = staticAlgorithm.Next();
		s0 = staticAlgorithm.S0;
		s1 = staticAlgorithm.S1;
		s2 = staticAlgorithm.S2;
		s3 = staticAlgorithm.S3;
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static ulong RotateLeft(ulong value, int offset)
	{
		return (value << offset) | (value >> 64 - offset);
	}
}
