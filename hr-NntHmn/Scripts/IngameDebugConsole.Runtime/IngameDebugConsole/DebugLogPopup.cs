using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace IngameDebugConsole
{
	public class DebugLogPopup : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
	{
		[CompilerGenerated]
		private sealed class _003CMoveToPosAnimation_003Ed__25 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public DebugLogPopup _003C_003E4__this;

			public Vector2 targetPos;

			private float _003Cmodifier_003E5__2;

			private Vector2 _003CinitialPos_003E5__3;

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
			public _003CMoveToPosAnimation_003Ed__25(int _003C_003E1__state)
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

		private RectTransform popupTransform;

		private Vector2 halfSize;

		private Image backgroundImage;

		private CanvasGroup canvasGroup;

		[SerializeField]
		private DebugLogManager debugManager;

		[SerializeField]
		private TextMeshProUGUI newInfoCountText;

		[SerializeField]
		private TextMeshProUGUI newWarningCountText;

		[SerializeField]
		private TextMeshProUGUI newErrorCountText;

		[SerializeField]
		private Color alertColorInfo;

		[SerializeField]
		private Color alertColorWarning;

		[SerializeField]
		private Color alertColorError;

		private int newInfoCount;

		private int newWarningCount;

		private int newErrorCount;

		private Color normalColor;

		private bool isPopupBeingDragged;

		private Vector2 normalizedPosition;

		private IEnumerator moveToPosCoroutine;

		public bool IsVisible { get; private set; }

		private void Awake()
		{
		}

		public void NewLogsArrived(int newInfo, int newWarning, int newError)
		{
		}

		private void ResetValues()
		{
		}

		[IteratorStateMachine(typeof(_003CMoveToPosAnimation_003Ed__25))]
		private IEnumerator MoveToPosAnimation(Vector2 targetPos)
		{
			return null;
		}

		public void OnPointerClick(PointerEventData data)
		{
		}

		public void Show()
		{
		}

		public void Hide()
		{
		}

		public void OnBeginDrag(PointerEventData data)
		{
		}

		public void OnDrag(PointerEventData data)
		{
		}

		public void OnEndDrag(PointerEventData data)
		{
		}

		public void UpdatePosition(bool immediately)
		{
		}
	}
}
