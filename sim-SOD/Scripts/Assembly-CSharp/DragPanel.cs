using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragPanel : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IEndDragHandler, IDragHandler, IBeginDragHandler, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
	public delegate void DragEnd(GameObject dragObj, string tag);

	[CompilerGenerated]
	private sealed class _003CDrag_003Ed__21 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public DragPanel _003C_003E4__this;

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
		public _003CDrag_003Ed__21(int _003C_003E1__state)
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

	public Vector2 pointerOffset;

	public RectTransform parentRect;

	public InfoWindow parentWindow;

	public bool draggableComponent;

	public string dragTag;

	public bool isDragging;

	private float lastLeftClick;

	private float lastRightClick;

	private List<Image> rayTargets;

	public event DragEnd OnDragEnd
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

	private void Start()
	{
	}

	public virtual void OnPointerEnter(PointerEventData eventData)
	{
	}

	public virtual void OnPointerExit(PointerEventData eventData)
	{
	}

	private void OnDestroy()
	{
	}

	public virtual void OnPointerDown(PointerEventData data)
	{
	}

	public virtual void OnBeginDrag(PointerEventData data)
	{
	}

	public virtual void OnEndDrag(PointerEventData data)
	{
	}

	public virtual void OnDrag(PointerEventData data)
	{
	}

	[IteratorStateMachine(typeof(_003CDrag_003Ed__21))]
	private IEnumerator Drag(PointerEventData data)
	{
		return null;
	}

	public virtual void EndDrag()
	{
	}

	public Vector2 ClampToWindow(PointerEventData data)
	{
		return default(Vector2);
	}

	public virtual void OnPointerClick(PointerEventData eventData)
	{
	}

	public virtual void OnLeftClick()
	{
	}

	public virtual void OnRightClick()
	{
	}

	public virtual void OnLeftDoubleClick()
	{
	}

	public virtual void OnRightDoubleClick()
	{
	}
}
