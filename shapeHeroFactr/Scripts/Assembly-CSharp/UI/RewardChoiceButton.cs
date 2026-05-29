using System;
using System.Runtime.CompilerServices;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
	public abstract class RewardChoiceButton : MonoBehaviour
	{
		[Serializable]
		public struct TierSprite
		{
			public int tier;

			public Sprite tierSprite;
		}

		public bool isSelected;

		public Image rewardBackground;

		public Sprite unSelectedBackground;

		public Sprite selectedBackground;

		public CanvasGroup canvasGroup;

		public Image packBackground;

		public Image packIcon;

		public Image rewardIcon;

		public Image rewardIconMask;

		public GameObject getParticleObj;

		public TMP_Text rewardName;

		public TMP_Text rewardDiscription;

		public Button selectButton;

		public event UnityAction OnClickAction
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event UnityAction OnMouseOverAction
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event UnityAction OnMouseExitAction
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public abstract void InitComponent(string archiveId, string iconPath, string name, string desc);

		public virtual void SelectSetting(UnityAction selectMethod)
		{
		}

		public abstract void PlayAnimation(ref Sequence sequence);

		public virtual void CreateDetailDescription(RectTransform parent)
		{
		}

		public void OnMouseOver()
		{
		}

		public void OnMouseExit()
		{
		}
	}
}
