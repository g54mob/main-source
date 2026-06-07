using System;
using System.Collections.Generic;
using UnityEngine;

namespace MalbersAnimations.IK
{
	[Serializable]
	[AddTypeMenu("Animal/Weight Mode", 0)]
	public class WeightAnimalMode : WeightProcessor
	{
		[Tooltip("Exclude these modes. Meaning if the Character is NOT on these modes then the weight is set to 1")]
		public bool exclude;

		[Tooltip("Modes to check if the animal is on. Weight will be set to 1")]
		public List<ModeID> Modes = new List<ModeID>();

		[Tooltip("Exclude these abilities. Meaning if the Character is NOT on these abilities then the weight is set to 1")]
		public bool excludeAbilities;

		[Tooltip("Abilities to check if the animal is on. Weight will be set to 1")]
		public List<int> Abilities = new List<int>();

		private List<int> modes = new List<int>();

		private ICharacterAction character;

		private float modeWeight;

		public override void OnEnable(IKSet set, Animator anim)
		{
			modes = Modes.ConvertAll((ModeID x) => x.ID);
			if (anim.TryGetComponent<ICharacterAction>(out character))
			{
				ICharacterAction characterAction = character;
				characterAction.ModeStart = (Action<int, int>)Delegate.Combine(characterAction.ModeStart, new Action<int, int>(OnModeStart));
				ICharacterAction characterAction2 = character;
				characterAction2.ModeEnd = (Action<int, int>)Delegate.Combine(characterAction2.ModeEnd, new Action<int, int>(OnModeEnd));
			}
			else
			{
				Active = false;
				Debug.LogWarning("The Mode weight processor requires an Animal Controller. Disabling it");
			}
		}

		private void OnModeEnd(int mode, int ability)
		{
			Debug.Log($"mode {mode} ability {ability}");
			modeWeight = 0f;
		}

		private void OnModeStart(int mode, int ability)
		{
			Debug.Log($"mode {mode} ability {ability}");
			modeWeight = (modes.Contains(mode) ? 1 : 0);
			if (exclude)
			{
				modeWeight = 1f - modeWeight;
			}
			if (Abilities.Count > 0)
			{
				modeWeight *= (Abilities.Contains(ability) ? 1 : 0);
				if (excludeAbilities)
				{
					modeWeight = 1f - modeWeight;
				}
			}
		}

		public override void OnDisable(IKSet set, Animator anim)
		{
			if (character != null)
			{
				ICharacterAction characterAction = character;
				characterAction.ModeStart = (Action<int, int>)Delegate.Remove(characterAction.ModeStart, new Action<int, int>(OnModeStart));
			}
		}

		public override float Process(IKSet set, float weight)
		{
			return weight * modeWeight;
		}
	}
}
