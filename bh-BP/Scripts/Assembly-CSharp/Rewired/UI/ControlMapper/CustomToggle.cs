using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Rewired.UI.ControlMapper
{
	[AddComponentMenu(null)]
	public class CustomToggle : Toggle, ICustomSelectable, ICancelHandler, IEventSystemHandler
	{
		[SerializeField]
		private Sprite _disabledHighlightedSprite;

		[SerializeField]
		private Color _disabledHighlightedColor;

		[SerializeField]
		private string _disabledHighlightedTrigger;

		[SerializeField]
		private bool _autoNavUp;

		[SerializeField]
		private bool _autoNavDown;

		[SerializeField]
		private bool _autoNavLeft;

		[SerializeField]
		private bool _autoNavRight;

		private bool isHighlightDisabled;

		public Sprite disabledHighlightedSprite
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Color disabledHighlightedColor
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public string disabledHighlightedTrigger
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool autoNavUp
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool autoNavDown
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool autoNavLeft
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool autoNavRight
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		private bool isDisabled => false;

		private event UnityAction _CancelEvent
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

		public event UnityAction CancelEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		public override Selectable FindSelectableOnLeft()
		{
			return null;
		}

		public override Selectable FindSelectableOnRight()
		{
			return null;
		}

		public override Selectable FindSelectableOnUp()
		{
			return null;
		}

		public override Selectable FindSelectableOnDown()
		{
			return null;
		}

		protected override void OnCanvasGroupChanged()
		{
		}

		protected override void DoStateTransition(SelectionState state, bool instant)
		{
		}

		private void StartColorTween(Color targetColor, bool instant)
		{
		}

		private void DoSpriteSwap(Sprite newSprite)
		{
		}

		private void TriggerAnimation(string triggername)
		{
		}

		public override void OnSelect(BaseEventData eventData)
		{
		}

		public override void OnDeselect(BaseEventData eventData)
		{
		}

		private void EvaluateHightlightDisabled(bool isSelected)
		{
		}

		public void OnCancel(BaseEventData eventData)
		{
		}
	}
}
