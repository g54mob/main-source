using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CRunEnd_003Ed__18 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SliderController _003C_003E4__this;

		private bool _003CrunOnce_003E5__2;

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
		public _003CRunEnd_003Ed__18(int _003C_003E1__state)
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
	private sealed class _003CControllerQuickValueAlter_003Ed__19 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SliderController _003C_003E4__this;

		public int alterValue;

		private float _003CheldDown_003E5__2;

		private float _003CdelayModify_003E5__3;

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
		public _003CControllerQuickValueAlter_003Ed__19(int _003C_003E1__state)
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

	[Header("Components")]
	public Slider slider;

	public ButtonController prevButton;

	public ButtonController nextButton;

	public TextMeshProUGUI label;

	[Header("Configuration")]
	public string labelDictRef;

	public string playerPrefsID;

	public bool displayValue;

	public bool isPercentage;

	private bool clickThisFrame;

	public bool displayPasscodeFormat;

	public ButtonController heldButton;

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public void OnButtonsDown(ButtonController thisButton)
	{
	}

	public void OnButtonsUp(ButtonController thisButton)
	{
	}

	public void OnNextButton()
	{
	}

	public void OnPreviousButton()
	{
	}

	[IteratorStateMachine(typeof(_003CRunEnd_003Ed__18))]
	private IEnumerator RunEnd()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CControllerQuickValueAlter_003Ed__19))]
	private IEnumerator ControllerQuickValueAlter(int alterValue)
	{
		return null;
	}

	public void SetValueWithoutNotify(int newVal)
	{
	}

	public void OnValueChange()
	{
	}

	public void UpdateDisplayValue()
	{
	}
}
