using Cpp2ILInjected;

namespace Assets.Scripts.Inventory__Items__Pickups.Stats;

public static class StatScaling
{
	public static float HyperbolicScaling(float input, float maxValue = 1f, float scaling = 0.5f)
	{
		float num = input + scaling;
		float num2 = input / num;
		return num2 * maxValue;
	}

	private static float PowerScaling(float inputValue, float maxInputValue, float maxValue, float diminishingEffect)
	{
		//IL_0030: Invalid comparison between I4 and F4
		//IL_0042: Expected F4, but got I4
		float num = default(float);
		float num2;
		if (!(num > maxInputValue))
		{
			bool flag = !(0f < maxInputValue);
			num2 = 0f;
			if (flag)
			{
				goto IL_0050;
			}
		}
		num2 = maxInputValue;
		goto IL_0050;
		IL_0050:
		float num3 = num2 / maxInputValue;
		float num4 = 1f - num3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FF020");
		float num5 = 1f - num4;
		return num5 * maxValue;
	}
}
