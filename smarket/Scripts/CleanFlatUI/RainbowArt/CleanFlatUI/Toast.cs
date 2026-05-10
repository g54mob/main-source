using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	public class Toast : MonoBehaviour
	{
		public enum Origin
		{
			Top = 0,
			Center = 1,
			Bottom = 2
		}

		[CompilerGenerated]
		private sealed class _003CDisableTransition_003Ed__44 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Toast _003C_003E4__this;

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
			public _003CDisableTransition_003Ed__44(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CUpdateTransition_003Ed__43 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Toast _003C_003E4__this;

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
			public _003CUpdateTransition_003Ed__43(int _003C_003E1__state)
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
		private Image icon;

		[SerializeField]
		private Text title;

		[SerializeField]
		private Text description;

		[SerializeField]
		private Animator animator;

		[SerializeField]
		private float showTime;

		[SerializeField]
		private float offsetX;

		[SerializeField]
		private float offsetY;

		[SerializeField]
		private Origin origin;

		private float disableTime;

		private List<Canvas> tempCanvasList;

		private IEnumerator transitionCoroutine;

		private IEnumerator diableCoroutine;

		private Vector3? initAnchoredPosition;

		private Vector3 InitPosition => default(Vector3);

		public float ShowTime
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public Origin CurOrigin
		{
			get
			{
				return default(Origin);
			}
			set
			{
			}
		}

		public float OffsetX
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float OffsetY
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

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

		public void ShowToast()
		{
		}

		public void HideToast()
		{
		}

		private void UpdatePosition()
		{
		}

		private void InitAnimation()
		{
		}

		private void PlayAnimation(bool bShow)
		{
		}

		private void StartTransition(bool bShow)
		{
		}

		[IteratorStateMachine(typeof(_003CUpdateTransition_003Ed__43))]
		private IEnumerator UpdateTransition()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CDisableTransition_003Ed__44))]
		private IEnumerator DisableTransition()
		{
			return null;
		}
	}
}
