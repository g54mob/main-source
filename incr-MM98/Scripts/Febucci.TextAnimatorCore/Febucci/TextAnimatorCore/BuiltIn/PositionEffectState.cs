using System;
using Febucci.Numbers;
using Febucci.Parsing;
using Febucci.TextAnimatorCore.Text;

namespace Febucci.TextAnimatorCore.BuiltIn
{
	[Serializable]
	public struct PositionEffectState : IEffectState, IParameterUpdater
	{
		private readonly Vector3 defaultDir;

		public Vector3 currentDir;

		public PositionEffectState(Vector3 direction)
		{
			defaultDir = direction;
			currentDir = direction;
		}

		public void UpdateParameters(RegionParameters parameters)
		{
			currentDir.X = parameters.ModifyFloat("x", defaultDir.X);
			currentDir.Y = parameters.ModifyFloat("y", defaultDir.Y);
			currentDir.Z = parameters.ModifyFloat("z", defaultDir.Z);
			currentDir *= parameters.ModifyFloat("a", 1f);
		}

		public void Apply(ref CharacterData character, in ManagedEffectContext context)
		{
			float num = context.progressionRange * context.intensity;
			character.MovePosition(currentDir.X * num, currentDir.Y * num, currentDir.Z * num, context.isUpPositive);
		}

		void IEffectState.Apply(ref CharacterData character, in ManagedEffectContext context)
		{
			Apply(ref character, in context);
		}
	}
}
