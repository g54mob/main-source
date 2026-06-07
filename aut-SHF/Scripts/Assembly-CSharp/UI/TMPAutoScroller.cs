using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	[RequireComponent(typeof(TextMeshProUGUI))]
	public class TMPAutoScroller : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CScrollRoutine_003Ed__30 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public TMPAutoScroller _003C_003E4__this;

			private Vector2 _003CtextSize_003E5__2;

			private Vector2 _003CmaskSize_003E5__3;

			private bool _003CneedsHorizontalScroll_003E5__4;

			private bool _003CneedsVerticalScroll_003E5__5;

			private float _003CscrollTime_003E5__6;

			private float _003CelapsedTime_003E5__7;

			private Vector2 _003CstartPosition_003E5__8;

			private Vector2 _003CtargetPosition_003E5__9;

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
			public _003CScrollRoutine_003Ed__30(int _003C_003E1__state)
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
		private sealed class _003CTextCheckRoutine_003Ed__24 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public TMPAutoScroller _003C_003E4__this;

			private WaitForSeconds _003Cwait_003E5__2;

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
			public _003CTextCheckRoutine_003Ed__24(int _003C_003E1__state)
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

		[Header("Scroll Settings")]
		[SerializeField]
		private float scrollSpeed;

		[SerializeField]
		private float pauseDuration;

		[SerializeField]
		private float resetDuration;

		[Header("Scroll Options")]
		[SerializeField]
		private bool enableHorizontalScroll;

		[SerializeField]
		private bool enableVerticalScroll;

		[SerializeField]
		private bool smoothReset;

		[Header("Text Change Detection")]
		[SerializeField]
		private bool autoDetectTextChange;

		[SerializeField]
		private float textCheckInterval;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugInfo;

		private TextMeshProUGUI textMesh;

		private RectTransform textRectTransform;

		private RectTransform maskRectTransform;

		private Vector2 originalPosition;

		private Coroutine scrollCoroutine;

		private Coroutine textCheckCoroutine;

		private RectMask2D rectMask;

		private Mask mask;

		private string previousText;

		private int previousTextLength;

		private void Awake()
		{
		}

		private void CheckTextMeshProSettings()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void Start()
		{
		}

		[IteratorStateMachine(typeof(_003CTextCheckRoutine_003Ed__24))]
		private IEnumerator TextCheckRoutine()
		{
			return null;
		}

		private void CheckTextChanged()
		{
		}

		private void OnTextChanged()
		{
		}

		public void ResetScroll()
		{
		}

		public void StartScrolling()
		{
		}

		public void StopScrolling()
		{
		}

		[IteratorStateMachine(typeof(_003CScrollRoutine_003Ed__30))]
		private IEnumerator ScrollRoutine()
		{
			return null;
		}

		private Vector2 GetTextSize()
		{
			return default(Vector2);
		}

		[ContextMenu("Force Start Scrolling")]
		private void ForceStartScrolling()
		{
		}

		[ContextMenu("Force Stop Scrolling")]
		private void ForceStopScrolling()
		{
		}

		[ContextMenu("Reset Scroll")]
		private void ForceResetScroll()
		{
		}

		[ContextMenu("Debug Text Info")]
		private void DebugTextInfo()
		{
		}
	}
}
