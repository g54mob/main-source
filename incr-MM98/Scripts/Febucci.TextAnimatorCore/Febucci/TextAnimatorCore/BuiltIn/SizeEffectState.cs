using System;
using Febucci.Numbers;
using Febucci.Parsing;
using Febucci.TextAnimatorCore.Text;

namespace Febucci.TextAnimatorCore.BuiltIn
{
	[Serializable]
	public struct SizeEffectState : IEffectState, IParameterUpdater
	{
		private readonly Vector3 defaultScale;

		public Vector3 currentScale;

		public SizeEffectState(Vector3 scale)
		{
			defaultScale = scale;
			currentScale = scale;
		}

		public void UpdateParameters(RegionParameters parameters)
		{
			Vector3 a = defaultScale;
			a.X = parameters.ModifyFloat("x", defaultScale.X);
			a.Y = parameters.ModifyFloat("y", defaultScale.Y);
			a.Z = parameters.ModifyFloat("z", defaultScale.Z);
			currentScale = a * parameters.ModifyFloat("a", 1f);
		}

		public void Apply(ref CharacterData character, in ManagedEffectContext context)
		{
			float t = (context.isInsideBehavior ? (Mathf.RemapUnclamped(context.progressionRange, -1f, 1f, 0f, 1f) * context.intensity) : context.intensity);
			character.Scale(Vector3.One.LerpUnclampedTo(currentScale, t));
		}

		void IEffectState.Apply(ref CharacterData character, in ManagedEffectContext context)
		{
			Apply(ref character, in context);
		}
	}
}
