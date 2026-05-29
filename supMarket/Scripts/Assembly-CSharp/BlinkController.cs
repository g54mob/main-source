using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BlinkController : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CResetBlink_003Ed__12 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public BlinkController _003C_003E4__this;

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
		public _003CResetBlink_003Ed__12(int _003C_003E1__state)
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

	public GameObject faceType;

	public SkinnedMeshRenderer skinnedMeshRenderer;

	public float timeBetweenBlinks;

	private float initialScoredTime;

	private float blendshapeWeight;

	private bool blinked;

	public bool isDead;

	private float blinkAcceleration;

	private float maxBlendshapeWeight;

	private CharacterCustomize customizeScript;

	private void Start()
	{
	}

	private void Update()
	{
	}

	[IteratorStateMachine(typeof(_003CResetBlink_003Ed__12))]
	private IEnumerator ResetBlink()
	{
		return null;
	}

	private void Blink()
	{
	}
}
