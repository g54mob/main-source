using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AppBarMenuAnimation : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
	[CompilerGenerated]
	private sealed class _003CScaleIcon_003Ed__20 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AppBarMenuAnimation _003C_003E4__this;

		public Vector3 targetScale;

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
		public _003CScaleIcon_003Ed__20(int _003C_003E1__state)
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

	public Image background;

	public Image Icon;

	public Color hoverColor;

	public Color defaultColor;

	public float colorChangeSpeed;

	public float scaleChangeSpeed;

	public bool RunStartFunction;

	public bool isActive;

	private Color targetColor;

	private bool wasActive;

	private Vector3 originalScale;

	private Vector3 pressedScale;

	public void Start()
	{
	}

	public void _Start()
	{
	}

	public void SetDeselect()
	{
	}

	private void Update()
	{
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}

	public void OnPointerDown(PointerEventData eventData)
	{
	}

	public void OnPointerUp(PointerEventData eventData)
	{
	}

	[IteratorStateMachine(typeof(_003CScaleIcon_003Ed__20))]
	private IEnumerator ScaleIcon(Vector3 targetScale)
	{
		return null;
	}
}
