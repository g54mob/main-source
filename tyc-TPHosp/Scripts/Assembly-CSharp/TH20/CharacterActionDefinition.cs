using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class CharacterActionDefinition
	{
		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		private class Reaction
		{
			public float Weight = 10f;

			public SharedInstance<CharacterStatusEffectDefinition> Effect;
		}

		[InspectorHeader("Action")]
		[SerializeField]
		private ExternalBehavior BehaviourGraph;

		[SerializeField]
		private RuntimeAnimatorController[] AnimGraphs;

		[SerializeField]
		private bool _useHappyIdleAnimGraphsFromCostume;

		[SerializeField]
		private CharacterAttributeModifier[] AttributeModifiers;

		[InspectorHeader("Behaviour")]
		[SerializeField]
		private bool _restartPreviousBehaviour;

		[InspectorHeader("Reaction")]
		[SerializeField]
		private float _radiusOfEffect;

		[SerializeField]
		private bool TurnToFace;

		[SerializeField]
		private float LookAtDuration = 4f;

		[SerializeField]
		private List<Reaction> Reactions;

		public bool RestartPreviousBehaviour => _restartPreviousBehaviour;

		public float RadiusOfEffect => _radiusOfEffect;

		public bool GetBehaviour(Character character, out ExternalBehavior behaviour, out RuntimeAnimatorController animGraph)
		{
			if (BehaviourGraph != null)
			{
				animGraph = null;
				behaviour = BehaviourGraph;
				return true;
			}
			if (_useHappyIdleAnimGraphsFromCostume && character is Staff staff && staff.Visual.CustomisationOption != null && staff.Visual.CustomisationOption.HappyIdleAnimGraphs != null && staff.Visual.CustomisationOption.HappyIdleAnimGraphs.Length != 0)
			{
				behaviour = null;
				animGraph = character.FindAnimationGraph(ref staff.Visual.CustomisationOption.HappyIdleAnimGraphs);
				return true;
			}
			if (AnimGraphs != null && AnimGraphs.Length != 0)
			{
				behaviour = null;
				animGraph = character.FindAnimationGraph(ref AnimGraphs);
				return true;
			}
			animGraph = null;
			behaviour = null;
			return false;
		}

		public void ApplyAttributes(Character character)
		{
			if (AttributeModifiers != null)
			{
				CharacterAttributeModifier[] attributeModifiers = AttributeModifiers;
				for (int i = 0; i < attributeModifiers.Length; i++)
				{
					attributeModifiers[i].Apply(character);
				}
			}
		}

		public virtual void TriggerReaction(Character character, Character reactingTo)
		{
			if (!character.CanPlayReactions())
			{
				return;
			}
			if (Reactions != null)
			{
				Reaction reaction = Reactions.WeightedRandomItem((Reaction r) => r.Weight);
				if (reaction != null && reaction.Effect != null && character.ModifiersComponent != null)
				{
					character.ModifiersComponent.AddStatusEffect(reaction.Effect.Instance);
				}
			}
			if (reactingTo != null)
			{
				if (TurnToFace && character.Interaction == null && !character.NavPath.IsNavigating())
				{
					character.GetOrAddComponent<TurnToFaceComponent>().SetTarget(reactingTo.Position);
				}
				if (LookAtDuration > 0f)
				{
					character.GetOrAddComponent<LookAtComponent>().AddAndOwnPOI(new LookAtPOI(reactingTo.GetOrAddComponent<CharacterLookAtPOISourceComponent>(), _radiusOfEffect, 1f, LookAtDuration));
				}
			}
		}
	}
}
