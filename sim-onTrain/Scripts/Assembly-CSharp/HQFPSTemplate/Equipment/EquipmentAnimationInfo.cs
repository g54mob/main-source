using System.Collections.Generic;
using UnityEngine;

namespace HQFPSTemplate.Equipment
{
	[CreateAssetMenu(fileName = "Equipment Animation", menuName = "HQ FPS Template/Equipment Component/Animation")]
	public class EquipmentAnimationInfo : ScriptableObject
	{
		[SerializeField]
		public AnimationOverrideClips m_EquipmentClips;

		[SerializeField]
		public AnimationOverrideClips m_FPArmsClips;

		public void AssignEquipmentAnimation(Animator animator)
		{
			AssignAnimations(animator, m_EquipmentClips);
		}

		public void AssignArmAnimations(Animator animator)
		{
			AssignAnimations(animator, m_FPArmsClips);
		}

		private void AssignAnimations(Animator animator, AnimationOverrideClips animationOverrideClips)
		{
			if (animator != null && animationOverrideClips.Controller != null)
			{
				AnimatorOverrideController animatorOverrideController = new AnimatorOverrideController(animationOverrideClips.Controller);
				List<KeyValuePair<AnimationClip, AnimationClip>> list = new List<KeyValuePair<AnimationClip, AnimationClip>>();
				AnimationOverrideClips.AnimationClipPair[] clips = animationOverrideClips.Clips;
				for (int i = 0; i < clips.Length; i++)
				{
					AnimationOverrideClips.AnimationClipPair animationClipPair = clips[i];
					list.Add(new KeyValuePair<AnimationClip, AnimationClip>(animationClipPair.Original, animationClipPair.Override));
				}
				animatorOverrideController.ApplyOverrides(list);
				animator.runtimeAnimatorController = animatorOverrideController;
			}
		}
	}
}
