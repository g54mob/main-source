using System;
using Cpp2ILInjected;

namespace VampireSurvivors;

public class Easings
{
	public class Quadratic
	{
		public static float In(float k)
		{
			return k * k;
		}

		public static float Out(float k)
		{
			float num = 2f - k;
			return num * k;
		}

		public static float InOut(float k)
		{
			float num = k + k;
			if (!(1f > num))
			{
				float num2 = num - 1f;
				float num3 = num2 - 2f;
				float num4 = num3 * num2;
				float num5 = num4 - 1f;
				return num5 * -0.5f;
			}
			float num6 = num * 0.5f;
			return num6 * num;
		}

		public static float Bezier(float k, float c)
		{
			float num = c + c;
			float num2 = 1f - k;
			float num3 = num * k;
			float num4 = k * k;
			float num5 = num3 * num2;
			return num5 + num4;
		}
	}

	public class Cubic
	{
		public static float In(float k)
		{
			float num = k * k;
			return num * k;
		}

		public static float Out(float k)
		{
			float num = k - 1f;
			float num2 = num * num;
			float num3 = num2 * num;
			return num3 + 1f;
		}

		public static float InOut(float k)
		{
			float num = k + k;
			if (!(1f > num))
			{
				float num2 = num - 2f;
				float num3 = num2 * num2;
				float num4 = num3 * num2;
				float num5 = num4 + 2f;
				return num5 * 0.5f;
			}
			float num6 = num * 0.5f;
			float num7 = num6 * num;
			return num7 * num;
		}
	}

	public class Quartic
	{
		public static float In(float k)
		{
			float num = k * k;
			float num2 = num * k;
			return num2 * k;
		}

		public static float Out(float k)
		{
			float num = k - 1f;
			float num2 = num * num;
			float num3 = num2 * num;
			float num4 = num3 * num;
			return 1f - num4;
		}

		public static float InOut(float k)
		{
			float num = k + k;
			if (!(1f > num))
			{
				float num2 = num - 2f;
				float num3 = num2 * num2;
				float num4 = num3 * num2;
				float num5 = num4 * num2;
				float num6 = num5 - 2f;
				return num6 * -0.5f;
			}
			float num7 = num * 0.5f;
			float num8 = num7 * num;
			float num9 = num8 * num;
			return num9 * num;
		}
	}

	public class Quintic
	{
		public static float In(float k)
		{
			float num = k * k;
			float num2 = num * k;
			float num3 = num2 * k;
			return num3 * k;
		}

		public static float Out(float k)
		{
			float num = k - 1f;
			float num2 = num * num;
			float num3 = num2 * num;
			float num4 = num3 * num;
			float num5 = num4 * num;
			return num5 + 1f;
		}

		public static float InOut(float k)
		{
			float num = k + k;
			if (!(1f > num))
			{
				float num2 = num - 2f;
				float num3 = num2 * num2;
				float num4 = num3 * num2;
				float num5 = num4 * num2;
				float num6 = num5 * num2;
				float num7 = num6 + 2f;
				return num7 * 0.5f;
			}
			float num8 = num * 0.5f;
			float num9 = num8 * num;
			float num10 = num9 * num;
			float num11 = num10 * num;
			return num11 * num;
		}
	}

	public static class Sinusoidal
	{
		public static float In(float k)
		{
			float num = k * (float)Math.PI;
			float num2 = num * 0.5f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F00");
			return 1f - num2;
		}

		public static float Out(float k)
		{
			float num = k * (float)Math.PI;
			float result = num * 0.5f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F60");
			return result;
		}

		public static float InOut(float k)
		{
			float num = k * (float)Math.PI;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F00");
			float num2 = 1f - num;
			return num2 * 0.5f;
		}
	}

	public class Exponential
	{
		public static float In(float k)
		{
			//IL_0013: Invalid comparison between F4 and I4
			//IL_0030: Expected F4, but got I4
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001871FA5DEh\"");
			if (k == 0f)
			{
				return 0f;
			}
			float num = k - 1f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185EC5330");
			return 1024f;
		}

		public static float Out(float k)
		{
			bool flag = k == 1f;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001871FA618h\"");
			float result = 1f;
			if (!flag)
			{
				float num = k * -10f;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185EC5330");
				result = 1f - 2f;
			}
			return result;
		}

		public static float InOut(float k)
		{
			//IL_0013: Invalid comparison between F4 and I4
			//IL_0030: Expected F4, but got I4
			//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cc: Expected O, but got Unknown
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001871FA666h\"");
			if (k == 0f)
			{
				return 0f;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001871FA67Dh\"");
			if (k == 1f)
			{
				return 1f;
			}
			float num = k + k;
			float num2 = num - 1f;
			if (!(1f > num))
			{
				float num3 = num2 * -10f;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185EC5330");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
				object obj = 2f ^ 0;
				float num4 = (float)obj + 2f;
				return num4 * 0.5f;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185EC5330");
			return 1024f * 0.5f;
		}
	}

	public class Circular
	{
		public static float In(float k)
		{
			float num = k * k;
			float num2 = 1f - num;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1850045F0");
			return 1f - num2;
		}

		public static float Out(float k)
		{
			float num = k - 1f;
			float num2 = num * num;
			float result = 1f - num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1850045F0");
			return result;
		}

		public static float InOut(float k)
		{
			float num = k + k;
			if (!(1f > num))
			{
				float num2 = num - 2f;
				float num3 = num2 * num2;
				float num4 = 1f - num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1850045F0");
				float num5 = num4 + 1f;
				return num5 * 0.5f;
			}
			float num6 = num * num;
			float num7 = 1f - num6;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1850045F0");
			float num8 = num7 - 1f;
			return num8 * -0.5f;
		}
	}

	public class Elastic
	{
		public static float In(float k)
		{
			//IL_0009: Invalid comparison between F4 and I4
			//IL_0022: Expected F4, but got I4
			//IL_00da: Unknown result type (might be due to invalid IL or missing references)
			//IL_00df: Expected O, but got Unknown
			bool flag = k == 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001871FA7C6h\"");
			float result = 0f;
			if (!flag)
			{
				bool flag2 = k == 1f;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001871FA7D5h\"");
				result = 1f;
				if (!flag2)
				{
					float num = k - 1f;
					float num2 = num * 10f;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185EC5330");
					float num3 = num - 0.1f;
					float num4 = num3 * ((float)Math.PI * 2f);
					float num5 = num4 / 0.4f;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F60");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
					object obj = 2f ^ 0;
					result = num5 * (float)obj;
				}
			}
			return result;
		}

		public static float Out(float k)
		{
			//IL_0009: Invalid comparison between F4 and I4
			//IL_0022: Expected F4, but got I4
			bool flag = k == 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001871FA856h\"");
			float result = 0f;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001871FA873h\"");
				if (k == 1f)
				{
					return 1f;
				}
				float num = k * -10f;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185EC5330");
				float num2 = k - 0.1f;
				float num3 = num2 * ((float)Math.PI * 2f);
				float num4 = num3 / 0.4f;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F60");
				float num5 = num4 * 2f;
				result = num5 + 1f;
			}
			return result;
		}

		public static float InOut(float k)
		{
			float num = k + k;
			float num2 = num - 1f;
			if (!(1f > num))
			{
				float num3 = num2 * -10f;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185EC5330");
				float num4 = num2 - 0.1f;
				float num5 = num4 * ((float)Math.PI * 2f);
				float num6 = num5 / 0.4f;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F60");
				float num7 = num6 * 2f;
				float num8 = num7 * 0.5f;
				return num8 + 1f;
			}
			float num9 = num2 * 10f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185EC5330");
			float num10 = num2 - 0.1f;
			float num11 = num10 * ((float)Math.PI * 2f);
			float num12 = num11 / 0.4f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F60");
			float num13 = 2f * -0.5f;
			return num12 * num13;
		}
	}

	public class Back
	{
		private static float s = 1.70158f;

		private static float s2 = 2.5949094f;

		public static float In(float k)
		{
			float num = s + 1f;
			float num2 = num * k;
			float num3 = k * k;
			float num4 = num2 - s;
			return num4 * num3;
		}

		public static float Out(float k)
		{
			float num = k - 1f;
			float num2 = s + 1f;
			float num3 = num2 * num;
			float num4 = num * num;
			float num5 = num3 + s;
			float num6 = num5 * num4;
			return num6 + 1f;
		}

		public static float InOut(float k)
		{
			float num = k + k;
			float num8;
			if (!(1f > num))
			{
				float num2 = num - 2f;
				float num3 = s2 + 1f;
				float num4 = num3 * num2;
				float num5 = num2 * num2;
				float num6 = num4 + s2;
				float num7 = num6 * num5;
				num8 = num7 + 2f;
			}
			else
			{
				float num9 = s2 + 1f;
				float num10 = num9 * num;
				float num11 = num * num;
				float num12 = num10 - s2;
				num8 = num12 * num11;
			}
			return num8 * 0.5f;
		}
	}

	public class Bounce
	{
		public static float In(float k)
		{
			float num = 1f - k;
			if (!(0.36363637f > num))
			{
				if (!(0.72727275f > num))
				{
					if (!(0.90909094f > num))
					{
						float num2 = num - 21f / 22f;
						float num3 = num2 * 7.5625f;
						float num4 = num3 * num2;
						float num5 = num4 + 63f / 64f;
						return 1f - num5;
					}
					float num6 = num - 0.8181818f;
					float num7 = num6 * 7.5625f;
					float num8 = num7 * num6;
					float num9 = num8 + 0.9375f;
					return 1f - num9;
				}
				float num10 = num - 0.54545456f;
				float num11 = num10 * 7.5625f;
				float num12 = num11 * num10;
				float num13 = num12 + 0.75f;
				return 1f - num13;
			}
			float num14 = num * 7.5625f;
			float num15 = num14 * num;
			return 1f - num15;
		}

		public static float Out(float k)
		{
			if (!(0.36363637f > k))
			{
				if (!(0.72727275f > k))
				{
					if (!(0.90909094f > k))
					{
						float num = k - 21f / 22f;
						float num2 = num * 7.5625f;
						float num3 = num2 * num;
						return num3 + 63f / 64f;
					}
					float num4 = k - 0.8181818f;
					float num5 = num4 * 7.5625f;
					float num6 = num5 * num4;
					return num6 + 0.9375f;
				}
				float num7 = k - 0.54545456f;
				float num8 = num7 * 7.5625f;
				float num9 = num8 * num7;
				return num9 + 0.75f;
			}
			float num10 = k * 7.5625f;
			return num10 * k;
		}

		public static float InOut(float k)
		{
			float num = k + k;
			if (!(0.5f > k))
			{
				float num2 = num - 1f;
				if (!(0.36363637f > num2))
				{
					if (!(0.72727275f > num2))
					{
						if (!(0.90909094f > num2))
						{
							float num3 = num2 - 21f / 22f;
							float num4 = num3 * 7.5625f;
							float num5 = num4 * num3;
							float num6 = num5 + 63f / 64f;
							float num7 = num6 * 0.5f;
							return num7 + 0.5f;
						}
						float num8 = num2 - 0.8181818f;
						float num9 = num8 * 7.5625f;
						float num10 = num9 * num8;
						float num11 = num10 + 0.9375f;
						float num12 = num11 * 0.5f;
						return num12 + 0.5f;
					}
					float num13 = num2 - 0.54545456f;
					float num14 = num13 * 7.5625f;
					float num15 = num14 * num13;
					float num16 = num15 + 0.75f;
					float num17 = num16 * 0.5f;
					return num17 + 0.5f;
				}
				float num18 = num2 * 7.5625f;
				float num19 = num18 * num2;
				float num20 = num19 * 0.5f;
				return num20 + 0.5f;
			}
			float num21 = 1f - num;
			if (!(0.36363637f > num21))
			{
				if (!(0.72727275f > num21))
				{
					if (!(0.90909094f > num21))
					{
						float num22 = num21 - 21f / 22f;
						float num23 = num22 * 7.5625f;
						float num24 = num23 * num22;
						float num25 = num24 + 63f / 64f;
						float num26 = 1f - num25;
						return num26 * 0.5f;
					}
					float num27 = num21 - 0.8181818f;
					float num28 = num27 * 7.5625f;
					float num29 = num28 * num27;
					float num30 = num29 + 0.9375f;
					float num31 = 1f - num30;
					return num31 * 0.5f;
				}
				float num32 = num21 - 0.54545456f;
				float num33 = num32 * 7.5625f;
				float num34 = num33 * num32;
				float num35 = num34 + 0.75f;
				float num36 = 1f - num35;
				return num36 * 0.5f;
			}
			float num37 = num21 * 7.5625f;
			float num38 = num37 * num21;
			float num39 = 1f - num38;
			return num39 * 0.5f;
		}
	}

	public class LucaBounce
	{
		public static float Out(float k)
		{
			float num = k * k;
			float num2 = num * -15.59f;
			float num3 = num * k;
			float num4 = k * 2.5f;
			float num5 = num2 * num;
			float num6 = num3 * 8.295f;
			float num7 = num3 * 7.795f;
			float num8 = num6 * num;
			float num9 = num * -2f;
			float num10 = num8 + num5;
			float num11 = num10 + num7;
			float num12 = num11 + num9;
			float num13 = num12 + num4;
			if (num13 > 1f)
			{
				float num14 = num13 - 1f;
				return 1f - num14;
			}
			return num13;
		}
	}

	public static float Linear(float k)
	{
		return k;
	}
}
