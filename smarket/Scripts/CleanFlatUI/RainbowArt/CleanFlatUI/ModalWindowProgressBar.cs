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
	public class ModalWindowProgressBar : MonoBehaviour
	{
		[Serializable]
		public class ModalWindowEvent : UnityEvent
		{
		}

		[CompilerGenerated]
		private sealed class _003CDisableTransition_003Ed__30 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ModalWindowProgressBar _003C_003E4__this;

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
			public _003CDisableTransition_003Ed__30(int _003C_003E1__state)
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
		private Text description;

		[SerializeField]
		private Animator animator;

		[SerializeField]
		private ProgressBar progressBar;

		[SerializeField]
		private ModalWindowEvent onCancel;

		[SerializeField]
		private ModalWindowEvent onFinish;

		private IEnumerator diableCoroutine;

		private float disableTime;

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

		public ModalWindowEvent OnFinish
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

		public void SetProgress(float progress)
		{
		}

		public void FinishProgress()
		{
		}

		public void HideModalWindow()
		{
		}

		[IteratorStateMachine(typeof(_003CDisableTransition_003Ed__30))]
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

		private void OnProgressFinish()
		{
		}

		private void InitAnimation()
		{
		}

		private void PlayAnimation(bool bShow)
		{
		}
	}
}
