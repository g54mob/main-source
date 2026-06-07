using System;
using Febucci.Numbers;
using Febucci.Parsing;
using Febucci.TextAnimatorCore.Text;

namespace Febucci.TextAnimatorCore.BuiltIn
{
	[Serializable]
	public struct ColorEffectState : IEffectState, IParameterUpdater
	{
		private readonly ColorMode colorMode;

		private readonly Color32 baseColor;

		private Color32 currentColor;

		public ColorEffectState(Color baseColor, ColorMode colorMode)
		{
			this.baseColor = baseColor;
			currentColor = baseColor;
			this.colorMode = colorMode;
		}

		public void UpdateParameters(RegionParameters parameters)
		{
			currentColor.R = (byte)(255f * parameters.ModifyFloat("r", (float)(int)baseColor.R / 255f));
			currentColor.G = (byte)(255f * parameters.ModifyFloat("g", (float)(int)baseColor.G / 255f));
			currentColor.B = (byte)(255f * parameters.ModifyFloat("b", (float)(int)baseColor.B / 255f));
			currentColor.A = (byte)(255f * parameters.ModifyFloat("a", (float)(int)baseColor.A / 255f));
		}

		public void Apply(ref CharacterData character, in ManagedEffectContext context)
		{
			float num = context.intensity * Mathf.Remap(context.progressionRange, -1f, 1f, 0f, 1f);
			switch (colorMode)
			{
			case ColorMode.Full:
				character.LerpColor(currentColor, num);
				break;
			case ColorMode.AlphaOnly:
			{
				for (int j = 0; j < 4; j++)
				{
					ref Color32 reference2 = ref character.current.colors[j];
					reference2.A = (byte)((float)(int)reference2.A + (float)(currentColor.A - reference2.A) * num);
				}
				break;
			}
			case ColorMode.RGBOnly:
			{
				for (int i = 0; i < 4; i++)
				{
					ref Color32 reference = ref character.current.colors[i];
					reference.R = (byte)((float)(int)reference.R + (float)(currentColor.R - reference.R) * num);
					reference.G = (byte)((float)(int)reference.G + (float)(currentColor.G - reference.G) * num);
					reference.B = (byte)((float)(int)reference.B + (float)(currentColor.B - reference.B) * num);
				}
				break;
			}
			}
		}

		void IEffectState.Apply(ref CharacterData character, in ManagedEffectContext context)
		{
			Apply(ref character, in context);
		}
	}
}
