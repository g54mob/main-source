using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EditModeGridEffect : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CCR_SwitchMode_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public EditModeGridEffect _003C_003E4__this;

		public float from;

		public float to;

		private float _003Ctime_003E5__2;

		private float _003Cduration_003E5__3;

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
		public _003CCR_SwitchMode_003Ed__13(int _003C_003E1__state)
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
	private Renderer gridRenderer;

	[SerializeField]
	private AnimationCurve curve_Dissolve;

	private Coroutine coroutine;

	private Material runtimeMaterial;

	private eGameState curState;

	private bool isActivated;

	private Plane yZeroPlane;

	private Vector3 mousePos3D;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Update()
	{
	}

	private void OnGameStateChanged(eGameState fromState, eGameState toState)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_SwitchMode_003Ed__13))]
	private IEnumerator CR_SwitchMode(float from, float to)
	{
		return null;
	}
}
