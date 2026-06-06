using System;
using System.Collections.Generic;
using UnityEngine;

namespace MalbersAnimations.IK
{
	[Serializable]
	[AddTypeMenu("Animal/Weight Stance", 0)]
	public class WeightAnimalStance : WeightProcessor
	{
		[Tooltip("Stance to check if the animal is on. Weight will be set to 1")]
		public List<StanceID> Stances = new List<StanceID>();

		private List<int> stances = new List<int>();

		[Tooltip("Exclude these stances. Meaning if the Character is NOT on these stacnes then the weight is set to 1")]
		public bool exclude;

		private ICharacterAction character;

		private float StateWeight;

		public override void OnEnable(IKSet set, Animator anim)
		{
			stances = Stances.ConvertAll((StanceID x) => x.ID);
			if (anim.TryGetComponent<ICharacterAction>(out character))
			{
				ICharacterAction characterAction = character;
				characterAction.OnStance = (Action<int>)Delegate.Combine(characterAction.OnStance, new Action<int>(OnStance));
			}
			else
			{
				Active = false;
				Debug.LogWarning("The Stance weight processor requires an Animal Controller. Disabling it");
			}
		}

		private void OnStance(int newState)
		{
			StateWeight = (stances.Contains(newState) ? 1 : 0);
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
				characterAction.OnStance = (Action<int>)Delegate.Remove(characterAction.OnStance, new Action<int>(OnStance));
			}
		}

		public override float Process(IKSet set, float weight)
		{
			return weight * StateWeight;
		}
	}
}
