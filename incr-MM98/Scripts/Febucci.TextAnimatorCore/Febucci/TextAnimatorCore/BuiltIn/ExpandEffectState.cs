using System;
using Febucci.Numbers;
using Febucci.Parsing;
using Febucci.TextAnimatorCore.Text;

namespace Febucci.TextAnimatorCore.BuiltIn
{
	[Serializable]
	public struct ExpandEffectState : IEffectState, IParameterUpdater
	{
		private readonly ExpandType type;

		private readonly float baseAmplitude;

		private float currentAmplitude;

		public ExpandEffectState(float baseAmplitude, ExpandType type)
		{
			this.baseAmplitude = baseAmplitude;
			currentAmplitude = baseAmplitude;
			this.type = type;
		}

		public void UpdateParameters(RegionParameters parameters)
		{
			currentAmplitude = parameters.ModifyFloat("a", baseAmplitude);
		}

		public void Apply(ref CharacterData character, in ManagedEffectContext context)
		{
			float t = (context.isInsideBehavior ? (Mathf.RemapUnclamped(context.progressionRange, -1f, 1f, 0f, 1f) * context.intensity) : (1f - context.intensity)) * currentAmplitude;
			ref Vector3 reference = ref character.current.positions[0];
			ref Vector3 reference2 = ref character.current.positions[1];
			ref Vector3 reference3 = ref character.current.positions[2];
			ref Vector3 reference4 = ref character.current.positions[3];
			Vector3 current = (reference2 + reference3) / 2f;
			Vector3 current2 = (reference + reference4) / 2f;
			Vector3 current3 = (reference2 + reference) / 2f;
			Vector3 current4 = (reference3 + reference4) / 2f;
			switch (type)
			{
			case ExpandType.HorizontallyFromCenter:
				reference = current2.LerpUnclampedTo(reference, t);
				reference4 = current2.LerpUnclampedTo(reference4, t);
				reference2 = current.LerpUnclampedTo(reference2, t);
				reference3 = current.LerpUnclampedTo(reference3, t);
				break;
			case ExpandType.VerticallyFromCenter:
				reference = current3.LerpUnclampedTo(reference, t);
				reference2 = current3.LerpUnclampedTo(reference2, t);
				reference4 = current4.LerpUnclampedTo(reference4, t);
				reference3 = current4.LerpUnclampedTo(reference3, t);
				break;
			case ExpandType.BottomUp:
				reference2 = reference.LerpUnclampedTo(reference2, t);
				reference3 = reference4.LerpUnclampedTo(reference3, t);
				break;
			case ExpandType.TopDown:
				reference = reference2.LerpUnclampedTo(reference, t);
				reference4 = reference3.LerpUnclampedTo(reference4, t);
				break;
			case ExpandType.LeftToRight:
				reference4 = reference.LerpUnclampedTo(reference4, t);
				reference3 = reference2.LerpUnclampedTo(reference3, t);
				break;
			case ExpandType.RightToLeft:
				reference = reference4.LerpUnclampedTo(reference, t);
				reference2 = reference3.LerpUnclampedTo(reference2, t);
				break;
			}
		}

		void IEffectState.Apply(ref CharacterData character, in ManagedEffectContext context)
		{
			Apply(ref character, in context);
		}
	}
}
