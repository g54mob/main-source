using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace RainbowArt.CleanFlatUI
{
	public class SwitchSimple : MonoBehaviour, IPointerDownHandler, IEventSystemHandler
	{
		[Serializable]
		public class SwitchSimpleEvent : UnityEvent<bool>
		{
		}

		[CompilerGenerated]
		private sealed class _003CStart_003Ed__18 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SwitchSimple _003C_003E4__this;

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
			public _003CStart_003Ed__18(int _003C_003E1__state)
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
		private bool isOn;

		[SerializeField]
		private RectTransform backgroundOn;

		[SerializeField]
		private RectTransform backgroundOff;

		[SerializeField]
		private RectTransform handleOn;

		[SerializeField]
		private RectTransform handleOff;

		[SerializeField]
		private RectTransform handleSlideArea;

		[SerializeField]
		private SwitchSimpleEvent onValueChanged;

		private CanvasGroup canvasGroupBGOn;

		private CanvasGroup canvasGroupBGOff;

		private CanvasGroup canvasGroupOn;

		private CanvasGroup canvasGroupOff;

		public bool IsOn
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public SwitchSimpleEvent OnValueChanged
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[IteratorStateMachine(typeof(_003CStart_003Ed__18))]
		private IEnumerator Start()
		{
			return null;
		}

		private void InitGUI()
		{
		}

		public void OnPointerDown(PointerEventData eventData)
		{
		}

		private void UpdateGUI()
		{
		}

		private void SetCanvasGroupAlpha(CanvasGroup obj, float alpha)
		{
		}
	}
}
