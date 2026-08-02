using System.Collections.Generic;
using UnityEngine;

namespace HQFPSTemplate.Equipment
{
	[RequireComponent(typeof(EquipmentItem))]
	public class EquipmentAnimationHandler : MonoBehaviour, IEquipmentComponent
	{
		[SerializeField]
		public AnimationOverrideClips m_EquipmentClips;

		[SerializeField]
		public AnimationOverrideClips m_FPArmsClips;

		private EquipmentItem m_EItem;

		public void Initialize(EquipmentItem equipmentItem)
		{
			m_EItem = equipmentItem;
			AssignAnimations(m_EItem.Animator, m_EquipmentClips);
		}

		public void OnSelected()
		{
			AssignAnimations(m_EItem.EHandler.FPArmsHandler.Animator, m_FPArmsClips);
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
