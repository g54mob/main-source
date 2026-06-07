using Motorways.UI;
using UnityEngine;

namespace Motorways
{
	public class UpgradeButtonCount : UpgradeButtonStack
	{
		[SerializeField]
		private UpgradeButton _upgradeButton;

		[SerializeField]
		private NumberBubble _numberBubble;

		[SerializeField]
		private UpgradeIcon _baseIcon;

		[SerializeField]
		private UpgradeIcon _topIcon;

		[SerializeField]
		private Animator _animator;

		private static readonly int BounceTrigger = Animator.StringToHash("Bounce");

		public override bool IsUnlimited
		{
			get
			{
				return _isUnlimited;
			}
			set
			{
				if (_isUnlimited != value)
				{
					_isUnlimited = value;
					SetCountText();
				}
			}
		}

		private void Awake()
		{
			if (_topIcon != null)
			{
				_topIcon.iconRenderer.sprite = referenceImage.sprite;
				if (IsCircle)
				{
					_topIcon.SetToCircle();
				}
				else
				{
					_topIcon.SetToDiamond();
				}
			}
		}

		private void OnEnable()
		{
			SetCountText();
			SetCount(desiredStackCount);
		}

		public override void AddToStack(int count = 1, bool fromAnimation = false)
		{
			if (IsUnlimited && base.AccountedIconNumber >= 1)
			{
				SetCountText();
				return;
			}
			if (fromAnimation)
			{
				if (base.PendingAdditionCount >= count)
				{
					base.PendingAdditionCount -= count;
				}
				else
				{
					base.PendingAdditionCount = 0;
				}
			}
			desiredStackCount += count;
			SetCountText();
			if (base.AccountedIconNumber >= 1 && _topIcon != null && !fromAnimation)
			{
				_topIcon.Bounce();
			}
		}

		public void Bounce()
		{
			if (_animator != null)
			{
				_animator.SetTrigger(BounceTrigger);
			}
		}

		public override void RemoveFromStack(int count = 1, bool fromAnimation = false)
		{
			if (IsUnlimited && base.AccountedIconNumber >= 1)
			{
				SetCountText();
				return;
			}
			if (Diagnostics.Verify(desiredStackCount - count >= 0, "We tried to remove more icons from a stack than we have! Trying to remove {0} from {1} on {2}", count, desiredStackCount, base.name))
			{
				if (fromAnimation)
				{
					base.PendingAdditionCount += count;
				}
				desiredStackCount -= count;
			}
			SetCountText();
		}

		public override void SetCount(int count)
		{
			if (desiredStackCount != count)
			{
				desiredStackCount = count;
				SetCountText();
			}
		}

		private void SetCountText()
		{
			if (!ShowNumberCounter)
			{
				_numberBubble.Hide(instantly: true);
			}
			else if (IsUnlimited)
			{
				_numberBubble.SetValueUnlimited();
			}
			else
			{
				_numberBubble.SetValue(desiredStackCount);
			}
			if (_topIcon != null)
			{
				bool flag = desiredStackCount >= 1;
				_topIcon.SetVisible(flag, TransitionStyle.Tween);
				if (_baseIcon != null)
				{
					_baseIcon.iconRenderer.gameObject.SetActive(!flag);
					_baseIcon.outlineRenderer.gameObject.SetActive(!flag);
				}
			}
			if (_upgradeButton != null)
			{
				_upgradeButton.interactable = _upgradeButton.buttonType != GameUIButtonType.None && desiredStackCount > 0;
			}
		}

		public override UpgradeIcon GetTopIcon()
		{
			return _topIcon;
		}

		public override void DoStateTransition(ButtonAnimationState state, bool instant)
		{
		}

		private void Update()
		{
		}
	}
}
