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
	public class ModalWindowInputField : MonoBehaviour
	{
		[Serializable]
		public class ModalWindowEvent : UnityEvent<string>
		{
		}

		[CompilerGenerated]
		private sealed class _003CDisableTransition_003Ed__33 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ModalWindowInputField _003C_003E4__this;

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
			public _003CDisableTransition_003Ed__33(int _003C_003E1__state)
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
		private Button buttonConfirm;

		[SerializeField]
		private Button buttonCancel;

		[SerializeField]
		private Animator animator;

		[SerializeField]
		private Text description;

		[SerializeField]
		private InputField inputField;

		private string inputText;

		[SerializeField]
		private ModalWindowEvent onConfirm;

		[SerializeField]
		private ModalWindowEvent onCancel;

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

		public ModalWindowEvent OnConfirm
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

		public void SetInputField(string newText)
		{
		}

		private void InitInputField()
		{
		}

		public void HideModalWindow()
		{
		}

		[IteratorStateMachine(typeof(_003CDisableTransition_003Ed__33))]
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

		private void OnConfirmClick()
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
