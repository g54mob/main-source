using System;
using System.Collections.Generic;
using UnityEngine;

namespace MalbersAnimations.IK
{
	[Serializable]
	[AddTypeMenu("Animal/Weight State", 0)]
	public class WeightAnimalState : WeightProcessor
	{
		[Tooltip("States to check if the animal is on any of them Weight will be set to 1")]
		public List<StateID> States = new List<StateID>();

		private List<int> states = new List<int>();

		[Tooltip("Exclude these states. Meaning if the Character is NOT on these states then the weight is set to 1")]
		public bool exclude;

		private ICharacterAction character;

		private float StateWeight;

		public override void OnEnable(IKSet set, Animator anim)
		{
			states = States.ConvertAll((StateID x) => x.ID);
			if (anim.TryGetComponent<ICharacterAction>(out character))
			{
				ICharacterAction characterAction = character;
				characterAction.OnState = (Action<int>)Delegate.Combine(characterAction.OnState, new Action<int>(OnState));
			}
			else
			{
				Active = false;
				Debug.LogWarning("The State weight processor requires an Animal Controller. Disabling it");
			}
		}

		private void OnState(int newState)
		{
			StateWeight = (states.Contains(newState) ? 1 : 0);
			if (exclude)
			{
				StateWeight = 1f - StateWeight;
			}
		}

		public override void OnDisable(IKSet set, Animator anim)
		{
			if (character != null)
			{
				ICharacterAction characterAction = character;
				characterAction.OnState = (Action<int>)Delegate.Remove(characterAction.OnState, new Action<int>(OnState));
			}
		}

		public override float Process(IKSet set, float weight)
		{
			return weight * StateWeight;
		}
	}
}
