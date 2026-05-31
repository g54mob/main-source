using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	public class DropdownTransition : Dropdown
	{
		[CompilerGenerated]
		private sealed class _003CDisableTransition_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public DropdownTransition _003C_003E4__this;

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
			public _003CDisableTransition_003Ed__8(int _003C_003E1__state)
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

		private Animator animatorList;

		private Toggle[] toggleList;

		private IEnumerator diableCoroutine;

		private float disableTime;

		public new void Show()
		{
		}

		private void OnSelectItemCustom(Toggle toggle)
		{
		}

		public new void Hide()
		{
		}

		public void HideDropdown()
		{
		}

		[IteratorStateMachine(typeof(_003CDisableTransition_003Ed__8))]
		private IEnumerator DisableTransition()
		{
			return null;
		}

		private void PlayAnimation(bool bShow)
		{
		}

		public override void OnPointerClick(PointerEventData eventData)
		{
		}

		public override void OnSubmit(BaseEventData eventData)
		{
		}

		public override void OnCancel(BaseEventData eventData)
		{
		}
	}
}
