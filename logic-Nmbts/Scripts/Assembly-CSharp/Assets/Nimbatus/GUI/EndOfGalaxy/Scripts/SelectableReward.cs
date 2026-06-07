using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Animations;
using Assets.Nimbatus.Scripts.Receivables;
using Assets.Nimbatus.Scripts.WorldObjects.Items;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons;
using Spine.Unity;
using UnityEngine;

namespace Assets.Nimbatus.GUI.EndOfGalaxy.Scripts
{
	public class SelectableReward : MonoBehaviour
	{
		public UITexture Icon;

		public UITexture ColoredIcon;

		public UILabel StackSizeLabel;

		public Transform IconPivot;

		public Transform ColoredIconPivot;

		public Transform StackSizeLabelPivot;

		public UILabel TitleLabel;

		public UILabel DescriptionLabel;

		public Transform PerkCapsulePivot;

		public SkeletonAnimation PerkCapsuleAnimation;

		public ParticleSystem ParticleSystem;

		public bool IsSmallCapsule;

		[HideInInspector]
		public BaseReceivable Reward;

		[HideInInspector]
		public RewardIcon RewardIcon;

		private EndOfGalaxyUi _manager;

		private bool _hover;

		public void Init(EndOfGalaxyUi manager, BaseReceivable reward)
		{
			_manager = manager;
			Reward = reward;
			if ((bool)RewardIcon)
			{
				Icon = RewardIcon.Icon;
				ColoredIcon = RewardIcon.ColoredIcon;
				StackSizeLabel = RewardIcon.StackSizeLabel;
			}
			Weapon weapon = null;
			Weapon weapon2;
			if (Reward.Type() == EReceivableType.DronePart && !(Reward is MultiPartReceivable) && (object)(weapon2 = Reward.GetReward<NimbatusItem>() as Weapon) != null)
			{
				weapon = weapon2;
			}
			if (Icon != null)
			{
				Texture2D mainTexture = null;
				if (Reward != null && weapon == null)
				{
					mainTexture = Reward.GetIcon();
				}
				else if (Reward != null && weapon != null)
				{
					mainTexture = weapon.GetIcon();
				}
				Icon.mainTexture = mainTexture;
				Icon.enabled = true;
			}
			if (Reward != null && weapon != null)
			{
				if (ColoredIcon != null)
				{
					ColoredIcon.mainTexture = weapon.Emitter.AmmunitionTexture;
					ColoredIcon.color = weapon.Ammunition.IconColorModifier;
					ColoredIcon.enabled = true;
				}
			}
			else if (ColoredIcon != null)
			{
				ColoredIcon.enabled = false;
			}
			if (Reward != null)
			{
				StackSizeLabel.text = LabelHelper.White + Reward.GetAmount();
				TitleLabel.text = LabelHelper.White + Reward.GetTitle();
				DescriptionLabel.text = LabelHelper.White + Reward.GetToolTip();
			}
		}

		public void Update()
		{
			Icon.transform.position = IconPivot.transform.position;
			ColoredIcon.transform.position = ColoredIconPivot.transform.position;
			StackSizeLabel.transform.position = StackSizeLabelPivot.transform.position;
			RewardIcon.Background.transform.position = Icon.transform.position;
			if ((!(_manager != null) || !(_manager.SelectedReward == this)) && !IsSmallCapsule)
			{
				if (PerkCapsuleAnimation.AnimationState.GetCurrent(0).animation.Name == "open")
				{
					PerkCapsuleAnimation.AnimationState.SetAnimation(0, "openToClosed", false);
					PerkCapsuleAnimation.AnimationState.AddAnimation(0, "closed", true, 0f);
				}
				else if (PerkCapsuleAnimation.AnimationState.GetCurrent(0).animation.Name == "closedToOpen")
				{
					PerkCapsuleAnimation.AnimationState.SetAnimation(0, "closed", true);
				}
				else if (PerkCapsuleAnimation.AnimationState.GetCurrent(0).animation.Name == "closed" && _hover)
				{
					PerkCapsuleAnimation.AnimationState.SetAnimation(0, "slightlyOpen", true);
					AudioController.Play("TravelEventPerkCapsuleHoverOnSFX");
				}
				else if (PerkCapsuleAnimation.AnimationState.GetCurrent(0).animation.Name == "slightlyOpen" && !_hover)
				{
					PerkCapsuleAnimation.AnimationState.SetAnimation(0, "closed", true);
					AudioController.Play("TravelEventPerkCapsuleHoverOffSFX");
				}
			}
		}

		public void HandleReward()
		{
			Reward.HandleReward();
			Reward = null;
		}

		public void OnClick()
		{
			_manager.SelectReward(this);
			OpenCapsule();
			AudioController.Play("TravelEventPerkCapsuleSelection2SFX");
		}

		public void OpenCapsule()
		{
			PerkCapsuleAnimation.AnimationState.SetAnimation(0, "closedToOpen", false);
			PerkCapsuleAnimation.AnimationState.AddAnimation(0, "open", true, 0f);
		}

		public void OnHover(bool isOver)
		{
			_hover = isOver;
		}

		public void PlayEndAnimation()
		{
			if (_manager != null && _manager.SelectedReward == this)
			{
				PerkCapsuleAnimation.AnimationState.SetAnimation(0, "disappearOpen", false);
			}
			else if (IsSmallCapsule)
			{
				PerkCapsuleAnimation.AnimationState.SetAnimation(0, "disappearCapsuleSmall", false);
			}
			else
			{
				PerkCapsuleAnimation.AnimationState.SetAnimation(0, "disappearClosed", false);
			}
		}

		public void TryPlayEffect()
		{
			if ((_manager != null && _manager.SelectedReward == this) || IsSmallCapsule)
			{
				RewardIcon.Background.gameObject.SetActive(false);
				RewardIcon.StackSizeLabel.gameObject.SetActive(false);
				RewardIcon.Icon.gameObject.AddComponent<GrowAndFadeOut>();
				RewardIcon.ColoredIcon.gameObject.AddComponent<GrowAndFadeOut>();
				ParticleSystem.Play();
				AudioController.Play("TravelEventPerkCapsuleOpenSFX");
			}
		}
	}
}
