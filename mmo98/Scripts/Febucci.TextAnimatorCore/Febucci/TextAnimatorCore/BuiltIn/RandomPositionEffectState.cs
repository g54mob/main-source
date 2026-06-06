using System;
using Febucci.Numbers;
using Febucci.Parsing;
using Febucci.TextAnimatorCore.Text;

namespace Febucci.TextAnimatorCore.BuiltIn
{
	[Serializable]
	public struct RandomPositionEffectState : IEffectState, IParameterUpdater
	{
		private readonly float baseAmplitude;

		private float calculatedAmplitude;

		private readonly bool progressIndexWithTime;

		public RandomPositionEffectState(float calculatedAmplitude, bool progressIndexWithTime)
		{
			baseAmplitude = calculatedAmplitude;
			this.calculatedAmplitude = calculatedAmplitude;
			this.progressIndexWithTime = progressIndexWithTime;
		}

		public void UpdateParameters(RegionParameters parameters)
		{
			calculatedAmplitude = parameters.ModifyFloat("a", baseAmplitude);
		}

		public void Apply(ref CharacterData character, in ManagedEffectContext context)
		{
			int num = ((!progressIndexWithTime) ? ((int)MathF.Round(character.index + character.wordIndex) % 25) : ((int)MathF.Round((context.animatorTime + (context.isInsideBehavior ? context.progressionRange : context.progression01) * 20f) / 0.19f) % 25));
			if (num < 0)
			{
				num = -num;
			}
			ref Vector3 reference = ref AnimUtils.FakeRandoms[num];
			float num2 = calculatedAmplitude * context.progressionRange * context.intensity;
			character.MovePosition(reference.X * num2, reference.Y * num2, reference.Z * num2, context.isUpPositive);
		}

		void IEffectState.Apply(ref CharacterData character, in ManagedEffectContext context)
		{
			Apply(ref character, in context);
		}
	}
}
