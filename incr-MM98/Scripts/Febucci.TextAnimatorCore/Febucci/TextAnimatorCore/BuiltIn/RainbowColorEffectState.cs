using System;
using System.Runtime.InteropServices;
using Febucci.Numbers;
using Febucci.Parsing;
using Febucci.TextAnimatorCore.Text;

namespace Febucci.TextAnimatorCore.BuiltIn
{
	[Serializable]
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct RainbowColorEffectState : IEffectState, IParameterUpdater
	{
		public RainbowColorEffectState(bool temp)
		{
		}

		public void UpdateParameters(RegionParameters parameters)
		{
		}

		public void Apply(ref CharacterData character, in ManagedEffectContext context)
		{
			float progression = context.progression01;
			progression = Mathf.Clamp01(progression) * 6f;
			int num = (int)Math.Floor(progression);
			float num2 = progression - (float)num;
			float num3 = 1f - num2;
			float num4 = num2;
			float num5;
			float num6;
			float num7;
			switch (num % 6)
			{
			case 0:
				num5 = 1f;
				num6 = num4;
				num7 = 0f;
				break;
			case 1:
				num5 = num3;
				num6 = 1f;
				num7 = 0f;
				break;
			case 2:
				num5 = 0f;
				num6 = 1f;
				num7 = num4;
				break;
			case 3:
				num5 = 0f;
				num6 = num3;
				num7 = 1f;
				break;
			case 4:
				num5 = num4;
				num6 = 0f;
				num7 = 1f;
				break;
			default:
				num5 = 1f;
				num6 = 0f;
				num7 = num3;
				break;
			}
			float num8 = (float)(int)character.current.colors[0].R / 255f;
			float num9 = (float)(int)character.current.colors[0].G / 255f;
			float num10 = (float)(int)character.current.colors[0].B / 255f;
			float num11 = num8 + (num5 - num8);
			float num12 = num9 + (num6 - num9);
			float num13 = num10 + (num7 - num10);
			byte r = (byte)(num11 * 255f + 0.5f);
			byte g = (byte)(num12 * 255f + 0.5f);
			byte b = (byte)(num13 * 255f + 0.5f);
			CharacterDataExtensions.LerpColor(targetColor: new Color32(r, g, b, character.current.colors[0].A), character: character, t: context.intensity);
		}

		void IEffectState.Apply(ref CharacterData character, in ManagedEffectContext context)
		{
			Apply(ref character, in context);
		}
	}
}
