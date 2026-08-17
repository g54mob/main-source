using Cpp2ILInjected;

namespace Doozy.Engine.Soundy;

public static class SoundyUtils
{
	private static readonly float TwelfthRootOfTwo;

	public static float SemitonesToPitch(float semitones)
	{
		//IL_0058: Invalid comparison between I4 and F4
		//IL_0067: Expected F4, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B71D10");
		bool flag = 0f > TwelfthRootOfTwo;
		float result = 0f;
		if (!flag)
		{
			bool flag2 = TwelfthRootOfTwo > 4f;
			result = 4f;
			if (!flag2)
			{
				result = TwelfthRootOfTwo;
			}
		}
		return result;
	}

	public static float PitchToSemitones(float pitch)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C46650");
		return pitch;
	}

	public static float DecibelToLinear(float dB)
	{
		//IL_008e: Expected F4, but got I4
		//IL_0041: Invalid comparison between I4 and F4
		float result;
		if (!(-80f > dB))
		{
			float num = dB / 20f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B71D10");
			if (!(0f > 10f))
			{
				bool flag = !(10f > 1f);
				result = 10f;
				if (!flag)
				{
					return 1f;
				}
				goto IL_0093;
			}
		}
		result = 0f;
		goto IL_0093;
		IL_0093:
		return result;
	}

	public static float LinearToDecibel(float linear)
	{
		//IL_0009: Invalid comparison between F4 and I4
		//IL_0066: Invalid comparison between F4 and I4
		//IL_0083: Expected F4, but got I4
		if (linear > 0f)
		{
			return -80f;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FD90");
		float num = linear * 20f;
		if (!(-80f > num))
		{
			if (num > 0f)
			{
				return 0f;
			}
		}
		else
		{
			num = -80f;
		}
		return num;
	}

	static SoundyUtils()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B71D10");
		TwelfthRootOfTwo = 2f;
	}
}
