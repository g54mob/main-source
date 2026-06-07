using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class UI_Transition_V2 : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CCR_Transition_003Ed__20 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_Transition_V2 _003C_003E4__this;

		public bool isOn;

		private float _003Cstart_003E5__2;

		private float _003Cend_003E5__3;

		private float _003Cduration_003E5__4;

		private float _003Ctimer_003E5__5;

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
		public _003CCR_Transition_003Ed__20(int _003C_003E1__state)
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
	private Image image_Transition;

	[SerializeField]
	private float startShaderDissolveValue;

	[SerializeField]
	private float endShaderDissolveValue;

	[SerializeField]
	private float transitionTime_Show;

	[SerializeField]
	private float transitionTime_Hide;

	[SerializeField]
	private AnimationCurve curve_Transition;

	[SerializeField]
	private bool DEBUG_AutoTestOn;

	private Material material;

	private bool isUIOn;

	private float testTime;

	private Coroutine coroutine_Transition;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnTriggerTransitionShow()
	{
	}

	private void OnTriggerTransitionHide()
	{
	}

	private void Update()
	{
	}

	[ContextMenu("Test_Transition_Hide")]
	private void TEST_ON()
	{
	}

	[ContextMenu("Test_Transition_Show")]
	private void TEST_OFF()
	{
	}

	public void StartTransition(bool isOn)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_Transition_003Ed__20))]
	private IEnumerator CR_Transition(bool isOn)
	{
		return null;
	}
}
