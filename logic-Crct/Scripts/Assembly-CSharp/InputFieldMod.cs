using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[ExecuteInEditMode]
[RequireComponent(typeof(InputField))]
[RequireComponent(typeof(LayoutElement))]
public class InputFieldMod : UIBehaviour
{
	[CompilerGenerated]
	private sealed class _003CScrollMax_003Ed__36 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public InputFieldMod _003C_003E4__this;

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
		public _003CScrollMax_003Ed__36(int _003C_003E1__state)
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

	[Range(1f, 50f)]
	public int textRows;

	public ScrollRect scrollRect;

	private RectTransform scrollRectTransform;

	private CanvasScaler scaler;

	private HorizontalOrVerticalLayoutGroup parentLayout;

	private LayoutElement inputElement;

	private InputField inputField;

	private RectTransform rect;

	private CanvasRenderer caret;

	private Regex colorTags;

	private Regex keyWords;

	private Regex operators;

	private RectTransform ScrollRectTransform => null;

	private float ScaleFactor => 0f;

	private HorizontalOrVerticalLayoutGroup ParentLayout => null;

	private LayoutElement InputElement => null;

	private InputField InputField => null;

	private RectTransform Rect => null;

	public Regex definedTriggers { get; set; }

	private float VerticalOffset => 0f;

	protected override void Start()
	{
	}

	private void Update()
	{
	}

	public void Highlight(string text)
	{
	}

	private void RemoveTags(string text)
	{
	}

	private void ResizeInput()
	{
	}

	private void ResizeInput(string text)
	{
	}

	[IteratorStateMachine(typeof(_003CScrollMax_003Ed__36))]
	private IEnumerator ScrollMax()
	{
		return null;
	}
}
