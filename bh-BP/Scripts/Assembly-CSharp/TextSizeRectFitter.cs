using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class TextSizeRectFitter : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_WaitAndResize_003Ed__15 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public TextSizeRectFitter _003C_003E4__this;

		float IEnumerator<float>.Current
		{
			[DebuggerHidden]
			get
			{
				return 0f;
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
		public _003C_WaitAndResize_003Ed__15(int _003C_003E1__state)
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

	public RectTransform TgtXfm;

	public TextMeshProUGUI TgtText;

	public float MinWidth;

	public float MaxWidth;

	public float PaddingTop;

	public float PaddingRight;

	public float PaddingBottom;

	public float PaddingLeft;

	[Header("Settings")]
	public bool AutoResize;

	public bool IgnoreY;

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnEnable()
	{
	}

	private void OnLanguageChanged()
	{
	}

	public void Resize()
	{
	}

	[IteratorStateMachine(typeof(_003C_WaitAndResize_003Ed__15))]
	public IEnumerator<float> _WaitAndResize()
	{
		return null;
	}
}
