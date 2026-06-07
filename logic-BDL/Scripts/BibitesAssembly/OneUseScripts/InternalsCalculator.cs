using System;
using SimulationScripts.BibiteScripts;
using UnityEngine;

namespace OneUseScripts
{
	public static class InternalsCalculator
	{
		private static float ArmorPortion;

		private static float ThroatPortion;

		private static float WombPortion;

		private static float StomachPortion;

		private static float JawPortion;

		private static float MusclesPortion;

		private static int width = 61;

		private static int height = 39;

		public static Vector2 bodyOffset;

		public static Vector2 wombOffset;

		public static Vector2 stomachOffset;

		public static float stomach_r;

		public static float stomach_w;

		public static float stomach_h;

		public static float womb_r;

		public static float womb_h;

		public static float womb_R;

		public static float womb_theta;

		public static void FromGenes(float[] genes)
		{
			WombPortion = BibiteGenes.WombAreaPortion(genes);
			ArmorPortion = BibiteGenes.ArmorOrganAreaPortion(genes);
			StomachPortion = BibiteGenes.StomachAreaPortion(genes);
			ThroatPortion = BibiteGenes.ThroatAreaPortion(genes);
			MusclesPortion = BibiteGenes.MoveMusclesAreaPortion(genes);
			bodyOffset = new Vector2((float)width - (float)height / 2f, (float)height / 2f);
			float num = Mathf.Round(bodyOffset.y);
			float num2 = (float)width - num + 1f;
			float f = MathF.PI / 2f - 2f * Mathf.Atan(num / num2);
			float num3 = num2 / Mathf.Sin(f);
			float num4 = Mathf.Sqrt(1f - ArmorPortion);
			float num5 = Mathf.Max(1f, Mathf.Round(num * (1f - num4)));
			float num6 = num - num5;
			float num7 = num3 - num5;
			float num8 = Mathf.Acos(1f - num6 / num7);
			float num9 = num7 * Mathf.Sin(num8);
			float num10 = MathF.PI / 2f * num6 * num6 + num7 * num7 * num8 - num9 * (num7 - num6);
			float num11 = Mathf.Sqrt(Mathf.Max(WombPortion, 0.02f));
			womb_r = Mathf.Round(num * num11) - 2.5f;
			womb_h = Mathf.Round(num2 * num11) - 5f;
			womb_theta = MathF.PI - 2f * Mathf.Atan(womb_h / womb_r);
			womb_R = womb_h / Mathf.Sin(womb_theta);
			float num12 = 1f + 2f * Mathf.Floor(Mathf.Sqrt(num10 * ThroatPortion) / 2f);
			wombOffset = new Vector2(Mathf.Round(num5 / Mathf.Cos(num8) + womb_h + 1f), bodyOffset.y);
			float num13 = Mathf.Sqrt(MusclesPortion);
			float num14 = Mathf.Round((num6 - 2f) * num13);
			float num15 = num10 * (StomachPortion - 0.1f);
			float num16 = 3f;
			stomach_r = Mathf.Round(2f + Mathf.Max(Mathf.Sqrt(num15 / (-0.85840726f + 2f * num16)), (num12 - 1f) / 2f));
			float num17 = Mathf.Round(stomach_r - Mathf.Sqrt(stomach_r * stomach_r - num12 * num12 / 4f));
			stomach_w = Mathf.Round(Mathf.Max((num15 / stomach_r + 0.85840726f * stomach_r) / 2f, num12));
			if (stomach_w + womb_h + womb_r > (float)width - (num12 - 1f) / 2f)
			{
				stomach_w = (float)width - (num12 - 1f) / 2f - womb_h - womb_r;
				stomach_r = Mathf.Floor((0f - stomach_w + Mathf.Sqrt(stomach_w * stomach_w + num15 * -0.85840726f)) / -0.85840726f);
				if (stomach_r > (float)width / 2f - num5 - num14 + 1.5f)
				{
					stomach_r = (float)width / 2f - num5 - num14 + 1.5f;
					stomach_w = Mathf.Floor(Mathf.Max((num15 / stomach_r + 0.85840726f * stomach_r) / 2f, num12));
				}
			}
			stomach_r = Mathf.Floor(stomach_r) + 0.5f;
			stomach_w = Mathf.Floor(stomach_w) + 3f;
			if (num17 < wombOffset.x + womb_r + stomach_w + num12 + 1f - (float)width)
			{
				num17 = Mathf.Floor(wombOffset.x + womb_r + stomach_w + num12 + 1f - (float)width);
				if (num17 > num12 / 2f)
				{
					num17 = Mathf.Floor(num17 - (num17 - num12 / 2f) / 1.5f);
				}
			}
			stomachOffset = new Vector2(Mathf.Floor((float)width - num12 + num17 - stomach_w / 2f), bodyOffset.y);
		}
	}
}
