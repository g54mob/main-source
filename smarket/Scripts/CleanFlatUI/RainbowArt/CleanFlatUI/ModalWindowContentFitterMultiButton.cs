using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	[ExecuteAlways]
	public class ModalWindowContentFitterMultiButton : MonoBehaviour
	{
		[Serializable]
		public class ModalWindowEvent : UnityEvent
		{
		}

		[CompilerGenerated]
		private sealed class _003CDisableTransition_003Ed__43 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ModalWindowContentFitterMultiButton _003C_003E4__this;

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
			public _003CDisableTransition_003Ed__43(int _003C_003E1__state)
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
		private Image iconTitle;

		[SerializeField]
		private Text title;

		[SerializeField]
		private Button buttonClose;

		[SerializeField]
		private Button buttonFirst;

		[SerializeField]
		private Button buttonSecond;

		[SerializeField]
		private Button buttonThird;

		[SerializeField]
		private Animator animator;

		[SerializeField]
		private RectTransform view;

		[SerializeField]
		private Text description;

		[SerializeField]
		private RectTransform buttonBar;

		[SerializeField]
		private ModalWindowEvent onFirst;

		[SerializeField]
		private ModalWindowEvent onSecond;

		[SerializeField]
		private ModalWindowEvent onThird;

		[SerializeField]
		private ModalWindowEvent onCancel;

		private IEnumerator diableCoroutine;

		private float disableTime;

		private float spacing;

		private float elapsedTime;

		private bool bDelayedUpdate;

		public string DescriptionValue
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string TitleValue
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Sprite IconValue
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public ModalWindowEvent OnFirst
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public ModalWindowEvent OnSecond
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public ModalWindowEvent OnThird
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public ModalWindowEvent OnCancel
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public void ShowModalWindow()
		{
		}

		public void HideModalWindow()
		{
		}

		[IteratorStateMachine(typeof(_003CDisableTransition_003Ed__43))]
		private IEnumerator DisableTransition()
		{
			return null;
		}

		private void InitButtons()
		{
		}

		private void OnCloseClick()
		{
		}

		private void OnCancelClick()
		{
		}

		private void OnFirstClick()
		{
		}

		private void OnSecondClick()
		{
		}

		private void OnThirdClick()
		{
		}

		private void InitAnimation()
		{
		}

		private void PlayAnimation(bool bShow)
		{
		}

		private void Update()
		{
		}

		private void UpdateHeight()
		{
		}
	}
}
