using System;
using Febucci.Numbers;
using Febucci.Parsing;
using Febucci.TextAnimatorCore.Text;

namespace Febucci.TextAnimatorCore.BuiltIn
{
	[Serializable]
	public struct RotationEffectState : IEffectState, IParameterUpdater
	{
		private readonly float defaultContinuousDegrees;

		private readonly float defaultSwingDegrees;

		public float continuousDegrees;

		public float swingDegrees;

		private Vector3 currentPivot;

		private Vector3 basePivot;

		private bool hasCustomPivot;

		public RotationEffectState(float continuousDegrees, float swingDegrees)
		{
			defaultContinuousDegrees = continuousDegrees;
			this.continuousDegrees = continuousDegrees;
			this.swingDegrees = swingDegrees;
			defaultSwingDegrees = swingDegrees;
			hasCustomPivot = false;
			currentPivot = Vector3.Zero;
			basePivot = Vector3.Zero;
		}

		public RotationEffectState(float continuousDegrees, float swingDegrees, Vector3 customPivot)
		{
			defaultContinuousDegrees = continuousDegrees;
			this.continuousDegrees = continuousDegrees;
			this.swingDegrees = swingDegrees;
			defaultSwingDegrees = swingDegrees;
			hasCustomPivot = true;
			basePivot = (currentPivot = customPivot);
		}

		public void UpdateParameters(RegionParameters parameters)
		{
			continuousDegrees = parameters.ModifyFloat("a1", defaultContinuousDegrees);
			swingDegrees = parameters.ModifyFloat("a2", defaultSwingDegrees);
			Vector3 vector = basePivot;
			currentPivot.X = parameters.ModifyFloat("x", vector.X);
			currentPivot.Y = parameters.ModifyFloat("y", vector.Y);
			currentPivot.Z = parameters.ModifyFloat("z", vector.Z);
			hasCustomPivot = basePivot != Vector3.Zero || currentPivot != basePivot;
		}

		public void Apply(ref CharacterData character, in ManagedEffectContext context)
		{
			if (hasCustomPivot)
			{
				character.RotateDegrees((context.progression01 * continuousDegrees + context.progressionRange * swingDegrees) * context.intensity, currentPivot, context.isUpPositive);
			}
			else
			{
				character.RotateDegrees((context.progression01 * continuousDegrees + context.progressionRange * swingDegrees) * context.intensity, context.isUpPositive);
			}
		}

		void IEffectState.Apply(ref CharacterData character, in ManagedEffectContext context)
		{
			Apply(ref character, in context);
		}
	}
}
