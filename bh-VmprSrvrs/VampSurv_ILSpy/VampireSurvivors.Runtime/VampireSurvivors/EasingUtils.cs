using System;
using Cpp2ILInjected;

namespace VampireSurvivors;

public class EasingUtils
{
	public static Func<float, float> GetEasingMethod(Easing easeType)
	{
		//IL_0012: Expected O, but got I8
		//IL_002c: Expected O, but got I8
		if (easeType <= Easing.LucaBounceOut)
		{
			object obj = 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rdx_v1+71FA154+easeType @ rcx (VampireSurvivors.Easing)*4]");
			object obj2 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v50 @ rcx_v3 (should have been resolved before IL gen)");
		}
		return null;
	}

	public static float[] GetEasedValues(float start, float end, Easing ease, int points = 8)
	{
		//IL_0031: Expected F4, but got I4
		//IL_0042: Expected O, but got I4
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		Func<float, float> easingMethod = GetEasingMethod(ease);
		float[] array = new float[points];
		float num = (float)points - 1f;
		float num2 = end - start;
		float num3 = 1f / num;
		if (points > 0)
		{
			float num4 = 0f;
			float num5 = num;
			object obj = 0;
			bool flag;
			do
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v43 @ rax_v3 (System.Func`2<System.Single, System.Single>)+18] (should have been resolved before IL gen)");
				if ((nint)obj < array.Length)
				{
					num4 += num3;
					float num6 = num5 * num2;
					object obj2 = obj + 1;
					num5 = (array[obj] = num6 + start);
					flag = (nint)obj2 < points;
					obj = obj2;
					continue;
				}
				return (float[])(object)new IndexOutOfRangeException();
			}
			while (flag);
		}
		return array;
	}
}
