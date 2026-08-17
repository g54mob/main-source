using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;

public static class FalloffGenerator
{
	public static float[,] GenerateFalloffMap(int size)
	{
		//IL_000e: Expected O, but got I4
		//IL_001c: Expected I, but got O
		//IL_023b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0240: Expected I4, but got Unknown
		//IL_0249: Expected O, but got I4
		//IL_01b2: Expected O, but got I4
		//IL_01dd: Expected O, but got I4
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f2: Expected O, but got Unknown
		//IL_0212: Unknown result type (might be due to invalid IL or missing references)
		//IL_0217: Expected O, but got Unknown
		//IL_003e: Expected O, but got I
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Expected O, but got Unknown
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Expected O, but got Unknown
		//IL_010b: Expected I, but got O
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B10");
		if (size > 0)
		{
			object obj = 0;
			nint num = (nint)typeof(float[,]);
			do
			{
				int num2 = obj / size;
				object obj2 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,edi\"");
					object obj3 = num2 + num2;
					int num3 = 0 / size;
					float num4 = (float)obj3 - 1f;
					object obj4 = num3 + num3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
					object obj5 = num4 & 0;
					float num5 = (float)obj4 - 1f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
					object obj6 = num5 & 0;
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6))
					{
						obj5 = obj6;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rax_v2 (System.Single[2])+10]");
					object obj7 = 0;
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj7))
					{
						object obj8 = obj2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v275 @ rax_v10+10]");
						if ((nint)obj8 < 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FF020");
							float num6 = (float)obj5 * 2.2f;
							float num7 = 2.2f - num6;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FF020");
							float num8 = num7 + (float)obj5;
							object obj9 = obj2 + 1;
							object obj10 = obj;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v275 @ rax_v10+10]");
							object obj11 = obj10 * 0;
							float num9 = (float)obj5 / num8;
							num = (nint)(obj11 + obj2);
							bool flag = (nint)obj9 < size;
							obj2 = obj9;
							if (!flag)
							{
								break;
							}
							continue;
						}
					}
					return (float[,])(object)new IndexOutOfRangeException();
				}
				obj++;
			}
			while ((nint)obj < size);
		}
		float[,] result = default(float[,]);
		return result;
	}

	private static float Evaluate(float value)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FF020");
		float num = value * 2.2f;
		float num2 = 2.2f - num;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FF020");
		float num3 = num2 + value;
		return value / num3;
	}
}
