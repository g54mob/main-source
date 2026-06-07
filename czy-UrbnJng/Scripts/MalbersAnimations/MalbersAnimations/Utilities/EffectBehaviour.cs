using System.Collections.Generic;
using UnityEngine;

namespace MalbersAnimations.Utilities
{
	[AddComponentMenu("Malbers/Effects")]
	public class EffectBehaviour : StateMachineBehaviour
	{
		[Tooltip("Re-check If there any new Effect Manager on the Character (Use this when the Weapons are added or Removed and you want to add effect to them")]
		public bool DynamicManagers;

		public List<EffectItem> effects = new List<EffectItem>();

		private EffectManager[] effectManagers;

		private bool HasEfM;

		public override void OnStateEnter(Animator anim, AnimatorStateInfo stateInfo, int layerIndex)
		{
			if (effectManagers == null || DynamicManagers)
			{
				HasEfM = false;
				effectManagers = anim.GetComponentsInChildren<EffectManager>();
				if (effectManagers != null && effectManagers.Length != 0)
				{
					HasEfM = true;
				}
			}
			if (!HasEfM)
			{
				return;
			}
			foreach (EffectItem effect in effects)
			{
				effect.sent = false;
				if (effect.IgnoreInTransitionHash != null)
				{
					continue;
				}
				effect.IgnoreInTransitionHash = new List<int>();
				if (effect.IgnoreInTransition == null || effect.IgnoreInTransition.Count <= 0)
				{
					continue;
				}
				foreach (string item in effect.IgnoreInTransition)
				{
					effect.IgnoreInTransitionHash.Add(Animator.StringToHash(item));
				}
			}
		}

		public override void OnStateUpdate(Animator anim, AnimatorStateInfo state, int layer)
		{
			if (!HasEfM)
			{
				return;
			}
			int shortNameHash = anim.GetNextAnimatorStateInfo(layer).shortNameHash;
			bool flag = anim.IsInTransition(layer) && state.shortNameHash != shortNameHash;
			float num = state.normalizedTime % 1f;
			foreach (EffectItem effect in effects)
			{
				if (effect.sent)
				{
					continue;
				}
				if (flag)
				{
					if (effect.IgnoreInTransitionHash.Contains(shortNameHash))
					{
						effect.sent = true;
					}
					else if (effect.Time == 1f && effect.ExitInTransition)
					{
						Execute(effect);
						break;
					}
				}
				if (num >= effect.Time)
				{
					Execute(effect);
				}
			}
		}

		public override void OnStateExit(Animator anim, AnimatorStateInfo state, int layer)
		{
			if (!HasEfM || anim.GetCurrentAnimatorStateInfo(layer).fullPathHash == state.fullPathHash)
			{
				return;
			}
			foreach (EffectItem effect in effects)
			{
				if (!effect.sent)
				{
					if (effect.IgnoreInTransitionHash.Contains(anim.GetCurrentAnimatorStateInfo(layer).shortNameHash))
					{
						break;
					}
					if (effect.Time == 1f || (effect.ExecuteOnExit && !effect.sent))
					{
						Execute(effect);
					}
				}
			}
		}

		private void Execute(EffectItem e)
		{
			EffectManager[] array = effectManagers;
			foreach (EffectManager effectManager in array)
			{
				if (e.action == EffectOption.Play)
				{
					effectManager.PlayEffect(e.ID);
				}
				else
				{
					effectManager.StopEffect(e.ID);
				}
			}
			e.sent = true;
		}

		private void OnValidate()
		{
			foreach (EffectItem effect in effects)
			{
				effect.name = $"{effect.action} Effect [{effect.ID}]";
				if (effect.Time == 0f)
				{
					effect.name += "  -  [On Enter]";
				}
				else if (effect.Time == 1f)
				{
					effect.name += "  -  [On Exit]";
				}
				else
				{
					effect.name += $"  -  [OnTime] ({effect.Time:F2})";
				}
				if (effect.ExitInTransition && effect.Time == 1f)
				{
					effect.name += " - [In Transition]";
				}
				if (effect.IgnoreInTransition.Count > 0)
				{
					effect.name += $" - [Ignore: {effect.IgnoreInTransition.Count}]";
				}
				effect.showExecute = effect.Time != 1f && effect.Time != 0f;
				effect.showExitInTransition = effect.Time == 1f;
			}
		}
	}
}
