using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Rewired.UI.ControlMapper
{
	[AddComponentMenu(null)]
	public class CustomButton : Button, ICustomSelectable, ICancelHandler, IEventSystemHandler
	{
		[CompilerGenerated]
		private sealed class _003COnFinishSubmit_003Ed__51 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CustomButton _003C_003E4__this;

			private float _003CfadeTime_003E5__2;

			private float _003CelapsedTime_003E5__3;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003COnFinishSubmit_003Ed__51(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

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

		private void Press()
		{
		}

		public override void OnPointerClick(PointerEventData eventData)
		{
		}

		public override void OnSubmit(BaseEventData eventData)
		{
		}

		[IteratorStateMachine(typeof(_003COnFinishSubmit_003Ed__51))]
		private IEnumerator OnFinishSubmit()
		{
			return null;
		}

		private void EvaluateHightlightDisabled(bool isSelected)
		{
		}

		public void OnCancel(BaseEventData eventData)
		{
		}
	}
}
