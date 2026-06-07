using System;
using Febucci.Parsing;
using Febucci.TextAnimatorCore.Text;

namespace Febucci.TextAnimatorCore.BuiltIn
{
	[Serializable]
	public struct ShearEffectState : IEffectState, IParameterUpdater
	{
		private readonly VerticalShearType baseVerticalShearType;

		private readonly HorizontalShearType baseHorizontalShearType;

		private readonly float baseAmplitude;

		private float currentAmplitude;

		public ShearEffectState(float baseAmplitude, VerticalShearType baseVerticalShearType, HorizontalShearType baseHorizontalShearType)
		{
			this.baseAmplitude = baseAmplitude;
			currentAmplitude = baseAmplitude;
			this.baseVerticalShearType = baseVerticalShearType;
			this.baseHorizontalShearType = baseHorizontalShearType;
		}

		public void UpdateParameters(RegionParameters parameters)
		{
			currentAmplitude = parameters.ModifyFloat("a", baseAmplitude);
		}

		public void Apply(ref CharacterData character, in ManagedEffectContext context)
		{
			float num = context.progressionRange * context.intensity * currentAmplitude;
			switch (baseVerticalShearType)
			{
			case VerticalShearType.AnchoredRight:
				character.ShearVertically(num, 0f);
				break;
			case VerticalShearType.AnchoredLeft:
				character.ShearVertically(0f, num);
				break;
			case VerticalShearType.AllSides:
				character.ShearVertically(0f - num, num);
				break;
			}
			switch (baseHorizontalShearType)
			{
			case HorizontalShearType.AnchoredBottom:
				character.ShearHorizontally(num, 0f);
				break;
			case HorizontalShearType.AnchoredTop:
				character.ShearHorizontally(0f, num);
				break;
			case HorizontalShearType.AllSides:
				character.ShearHorizontally(num, 0f - num);
				break;
			}
		}

		void IEffectState.Apply(ref CharacterData character, in ManagedEffectContext context)
		{
			Apply(ref character, in context);
		}
	}
}
