using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using FMODUnity;
using OUSystems.Basics.DataStructures;
using OUSystems.Basics.Effects;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class AmalgamationUrn : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CFadeRoutine_003Ed__26 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AmalgamationUrn _003C_003E4__this;

		public float targetAlpha;

		private float _003CstartSpriteAlpha_003E5__2;

		private float _003CstartLightAlpha_003E5__3;

		private float _003CtargetLightIntensity_003E5__4;

		private float _003Celapsed_003E5__5;

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
		public _003CFadeRoutine_003Ed__26(int _003C_003E1__state)
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

	public PaymentItemStackUI PaymentStackUI;

	public PaymentItemStack PaymentStack;

	public ShakeReceiver ShakeReceiver;

	public float InputShake;

	public GameObject FilledEffect;

	public BoolContainer Full;

	public EventReference CompleteSound;

	public Light2D FilledEffectLight;

	public SpriteRenderer FilledEffectRenderer;

	public float FilledEffectLightIntensity;

	public float FadeDuration;

	private Coroutine _fadeCoroutine;

	public Action AnnounceFuller;

	public float Fullness => 0f;

	public bool Valid => false;

	public void Initiate()
	{
	}

	public void SetNewPayment(CostStack cost, bool quiet = false)
	{
	}

	public void Clear()
	{
	}

	public bool CanTake(ItemType type)
	{
		return false;
	}

	public void TakeItem(ItemType type)
	{
	}

	public void ShowNotFull()
	{
	}

	public void SetFullInitial()
	{
	}

	public void ShowFull()
	{
	}

	private void StartFade(float targetAlpha)
	{
	}

	[IteratorStateMachine(typeof(_003CFadeRoutine_003Ed__26))]
	private IEnumerator FadeRoutine(float targetAlpha)
	{
		return null;
	}
}
