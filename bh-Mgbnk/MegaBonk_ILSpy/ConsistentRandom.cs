using System;
using Cpp2ILInjected;

public class ConsistentRandom : Random
{
	private const int MBIG = 2147483647;

	private const int MSEED = 161803398;

	private const int MZ = 0;

	private int inext;

	private int inextp;

	private int[] SeedArray;

	public ConsistentRandom()
	{
		int tickCount = Environment.TickCount;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 12 Invalid \"Jump target not found in method: 0x1804F88F0\"");
	}

	public ConsistentRandom(int seed)
	{
		//IL_004b: Expected I, but got O
		//IL_00b7: Expected O, but got I4
		//IL_00c5: Expected O, but got I4
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Expected O, but got Unknown
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Expected O, but got Unknown
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Expected O, but got Unknown
		//IL_0159: Expected I4, but got O
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Expected O, but got Unknown
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Expected O, but got Unknown
		//IL_01c7: Expected O, but got I4
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01da: Expected O, but got Unknown
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Expected O, but got Unknown
		//IL_0231: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Expected O, but got Unknown
		//IL_0244: Unknown result type (might be due to invalid IL or missing references)
		//IL_0249: Expected O, but got Unknown
		//IL_070d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0712: Expected O, but got Unknown
		//IL_02d9: Expected O, but got I4
		//IL_02ea: Expected I4, but got O
		//IL_0300: Expected O, but got I4
		//IL_030e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0313: Expected O, but got Unknown
		//IL_034f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0354: Expected O, but got Unknown
		//IL_036a: Unknown result type (might be due to invalid IL or missing references)
		//IL_036f: Expected O, but got Unknown
		//IL_037d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0382: Expected O, but got Unknown
		//IL_0738: Unknown result type (might be due to invalid IL or missing references)
		//IL_073d: Expected O, but got Unknown
		//IL_0412: Expected O, but got I4
		//IL_0423: Expected I4, but got O
		//IL_0439: Expected O, but got I4
		//IL_0447: Unknown result type (might be due to invalid IL or missing references)
		//IL_044c: Expected O, but got Unknown
		//IL_0488: Unknown result type (might be due to invalid IL or missing references)
		//IL_048d: Expected O, but got Unknown
		//IL_04a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a8: Expected O, but got Unknown
		//IL_04b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bb: Expected O, but got Unknown
		//IL_0763: Unknown result type (might be due to invalid IL or missing references)
		//IL_0768: Expected O, but got Unknown
		//IL_0780: Expected O, but got I4
		//IL_054b: Expected O, but got I4
		//IL_055c: Expected I4, but got O
		//IL_0581: Unknown result type (might be due to invalid IL or missing references)
		//IL_0586: Expected O, but got Unknown
		//IL_05c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c7: Expected O, but got Unknown
		//IL_05dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e2: Expected O, but got Unknown
		//IL_05f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f5: Expected O, but got Unknown
		//IL_079f: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a4: Expected O, but got Unknown
		//IL_0685: Expected O, but got I4
		//IL_0696: Expected I4, but got O
		int[] seedArray = new int[56];
		SeedArray = seedArray;
		base._002Ector();
		int num;
		if (seed == 2147483648L)
		{
			num = 2147483647;
		}
		else
		{
			nint num2 = (nint)typeof(Math);
			num = -seed;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rcx_v50 (Il2CppClass<System.Math>)+E4]");
			if ((nint)0 < (nint)0)
			{
				num = seed;
			}
		}
		int[] seedArray2 = SeedArray;
		int num3 = (seedArray2[55] = 161803398 - num);
		object obj = 1;
		int[] array = null;
		object obj2 = 1;
		do
		{
			int[] seedArray3 = SeedArray;
			object obj3 = obj * 21;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul ecx\"");
			object obj4 = (object)array >> 1;
			object obj5 = obj4 >> 31;
			array = (int[])(object)(obj4 + obj5);
			object obj6 = array * 55;
			object obj7 = obj3 - obj6;
			bool flag = (nint)obj7 < seedArray3.Length;
			object obj8 = num3 - obj2;
			seedArray3[obj7] = (int)obj2;
			obj2 = obj8 + 2147483647;
			if (!flag)
			{
				obj2 = obj8;
			}
			int[] seedArray4 = SeedArray;
			obj++;
			num3 = seedArray4[obj7];
		}
		while ((nint)obj < 55);
		object obj9 = 1;
		do
		{
			int[] seedArray5 = SeedArray;
			object obj10 = obj9 + 30;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul ecx\"");
			object obj11 = (object)array >> 1;
			object obj12 = obj11 >> 31;
			object obj13 = obj11 + obj12;
			object obj14 = obj13 * 55;
			object obj15 = obj10 - obj14;
			object obj16 = obj15 + 1;
			object obj17 = obj9 * 4;
			array = (int[])(object)((object)SeedArray + obj17);
			int num4 = array[0] - seedArray5[obj16];
			array[0] = num4;
			int[] seedArray6 = SeedArray;
			if (seedArray6[obj9] < 0)
			{
				object obj18 = seedArray6[obj9] + 2147483647;
				seedArray6[obj9] = (int)obj18;
				array = seedArray6;
			}
			obj9++;
		}
		while ((nint)obj9 < 56);
		object obj19 = 1;
		do
		{
			int[] seedArray7 = SeedArray;
			object obj20 = obj19 + 30;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul ecx\"");
			object obj21 = (object)array >> 1;
			object obj22 = obj21 >> 31;
			object obj23 = obj21 + obj22;
			object obj24 = obj23 * 55;
			object obj25 = obj20 - obj24;
			object obj26 = obj25 + 1;
			object obj27 = obj19 * 4;
			array = (int[])(object)((object)SeedArray + obj27);
			int num5 = array[0] - seedArray7[obj26];
			array[0] = num5;
			int[] seedArray8 = SeedArray;
			if (seedArray8[obj19] < 0)
			{
				object obj28 = seedArray8[obj19] + 2147483647;
				seedArray8[obj19] = (int)obj28;
				array = seedArray8;
			}
			obj19++;
		}
		while ((nint)obj19 < 56);
		object obj29 = 1;
		int[] array2;
		bool flag2;
		object obj39;
		do
		{
			int[] seedArray9 = SeedArray;
			object obj30 = obj29 + 30;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul ecx\"");
			object obj31 = (object)array >> 1;
			object obj32 = obj31 >> 31;
			object obj33 = obj31 + obj32;
			object obj34 = obj33 * 55;
			object obj35 = obj30 - obj34;
			object obj36 = obj35 + 1;
			object obj37 = obj29 * 4;
			array2 = (int[])(object)((object)SeedArray + obj37);
			int num6 = array2[0] - seedArray9[obj36];
			array2[0] = num6;
			int[] seedArray10 = SeedArray;
			if (seedArray10[obj29] < 0)
			{
				object obj38 = seedArray10[obj29] + 2147483647;
				seedArray10[obj29] = (int)obj38;
				array2 = seedArray10;
			}
			obj29++;
			flag2 = (nint)obj29 < 56;
			obj39 = 1;
			array = array2;
		}
		while (flag2);
		do
		{
			int[] seedArray11 = SeedArray;
			object obj40 = obj39 + 30;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul ecx\"");
			object obj41 = (object)array2 >> 1;
			object obj42 = obj41 >> 31;
			object obj43 = obj41 + obj42;
			object obj44 = obj43 * 55;
			object obj45 = obj40 - obj44;
			object obj46 = obj45 + 1;
			object obj47 = obj39 * 4;
			array2 = (int[])(object)((object)SeedArray + obj47);
			int num7 = array2[0] - seedArray11[obj46];
			array2[0] = num7;
			int[] seedArray12 = SeedArray;
			if (seedArray12[obj39] < 0)
			{
				object obj48 = seedArray12[obj39] + 2147483647;
				seedArray12[obj39] = (int)obj48;
				array2 = seedArray12;
			}
			obj39++;
		}
		while ((nint)obj39 < 56);
		inext = 0;
		inextp = 21;
	}

	protected override double Sample()
	{
		//IL_0019: Expected F8, but got I4
		int num = InternalSample();
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm0,qword ptr [18262F0C8h]\"");
		return num;
	}

	private int InternalSample()
	{
		//IL_016f: Expected I4, but got O
		int num = inext + 1;
		bool flag = num >= 56;
		int num2 = 1;
		if (!flag)
		{
			num2 = num;
		}
		int num3 = inextp + 1;
		int[] seedArray = SeedArray;
		bool flag2 = num3 >= 56;
		int num4 = 1;
		if (!flag2)
		{
			num4 = num3;
		}
		if (num2 < seedArray.Length && num4 < seedArray.Length)
		{
			int num5 = seedArray[num2] - seedArray[num4];
			bool flag3 = num5 == 2147483647;
			int num6 = 2147483646;
			if (!flag3)
			{
				num6 = num5;
			}
			bool flag4 = num6 < 0;
			int num7 = num6 + 2147483647;
			if (!flag4)
			{
				num7 = num6;
			}
			seedArray[num2] = num7;
			inext = num2;
			inextp = num4;
			return num7;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		return (int)ex;
	}

	public override int Next()
	{
		return InternalSample();
	}

	private double GetSampleForLargeRange()
	{
		//IL_0073: Expected F8, but got I4
		int num = InternalSample();
		int num2 = InternalSample();
		int num3 = -num;
		if ((num2 & 1) != 0)
		{
			num3 = num;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm0,qword ptr [18262F0D8h]\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"divsd xmm0,qword ptr [18262F0E0h]\"");
		return num3;
	}

	public override int Next(int minValue, int maxValue)
	{
		//IL_0029: Expected O, but got I4
		if (minValue <= maxValue)
		{
			object obj = maxValue - minValue;
			int num5;
			if ((nint)obj > 2147483647)
			{
				int num = InternalSample();
				int num2 = InternalSample();
				int num3 = -num;
				int num4 = num2 & 1;
				bool flag = num4 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2sd xmm0,rdi\"");
				if (!flag)
				{
					num3 = num;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm1,qword ptr [18262F0D8h]\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"divsd xmm1,qword ptr [18262F0E0h]\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm1,xmm0\"");
				num5 = num3;
			}
			else
			{
				double num6 = Sample();
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2sd xmm1,rdi\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm0,xmm1\"");
				int num7 = default(int);
				num5 = num7;
			}
			return num5 + minValue;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
		ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException("minValue");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
		throw ex;
	}

	public override void NextBytes(byte[] buffer)
	{
		//IL_0022: Expected I, but got O
		//IL_0027: Expected I, but got O
		//IL_003c: Expected O, but got I4
		//IL_0057: Expected O, but got I4
		//IL_00de: Expected O, but got I
		//IL_00f6: Expected O, but got I4
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_023d: Expected O, but got Unknown
		//IL_029f: Expected I4, but got O
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Expected O, but got Unknown
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		//IL_016c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Expected O, but got Unknown
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Expected O, but got Unknown
		byte[] array = default(byte[]);
		if (array != null)
		{
			nint num = unchecked((nint)null);
			nint num2 = unchecked((nint)null);
			while (true)
			{
				if (num >= array.Length)
				{
					return;
				}
				byte[] array2 = (byte[])(inext + 1);
				bool flag = (nint)array2 >= 56;
				byte[] array3 = (byte[])1;
				if (!flag)
				{
					array3 = array2;
				}
				int num3 = inextp + 1;
				byte[] seedArray = (byte[])(object)SeedArray;
				bool flag2 = num3 >= 56;
				int num4 = 1;
				if (!flag2)
				{
					num4 = num3;
				}
				if (seedArray == null)
				{
					break;
				}
				if ((nint)array3 < seedArray.Length && num4 < seedArray.Length)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ rdx_v7 (System.Byte[])+20+v32 @ r9_v1 (System.Byte[])*4]");
					nint num5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ rdx_v7 (System.Byte[])+20+v27 @ r11_v4 (System.Int32)*4]");
					object obj = num5 - 0;
					bool flag3 = (nint)obj == 2147483647;
					object obj2 = 2147483646;
					if (!flag3)
					{
						obj2 = obj;
					}
					bool flag4 = (nint)obj2 < 0;
					object obj3 = obj2 + 2147483647;
					if (!flag4)
					{
						obj3 = obj2;
					}
					inext = (int)array3;
					inextp = num4;
					bool flag5 = num2 >= array.Length;
					seedArray = array3;
					if (!flag5)
					{
						object obj4 = obj3 & 0x800000FFL;
						if (num2 < array.Length)
						{
							object obj5 = obj4 - 1;
							object obj6 = obj5 | 0xFFFFFF00L;
							obj4 = obj6 + 1;
						}
						nint num6 = num2 + 1;
						num = num6;
						num2 = num6;
						continue;
					}
				}
				throw new IndexOutOfRangeException();
			}
			throw new NullReferenceException();
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
		ArgumentNullException ex = new ArgumentNullException("buffer");
		ex._002Ector("buffer");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
		throw ex;
	}
}
