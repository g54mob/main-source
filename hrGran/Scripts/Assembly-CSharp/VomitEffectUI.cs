using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class VomitEffectUI : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CFadeSequence_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public VomitEffectUI _003C_003E4__this;

		private float _003Ctimer_003E5__2;

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
		public _003CFadeSequence_003Ed__10(int _003C_003E1__state)
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

	[Tooltip("The UI Image component to be used as the overlay. Must be placed on a Canvas.")]
	[SerializeField]
	private Image overlayImage;

	[Header("Timing Parameters")]
	[Tooltip("Delay before the fade-in starts (for syncing with the projectile hit).")]
	[SerializeField]
	private float preFadeDelay;

	[Tooltip("How long the overlay image stays fully visible.")]
	[SerializeField]
	private float holdDuration;

	[Tooltip("How quickly the overlay appears (short for impact).")]
	[SerializeField]
	private float fadeInDuration;

	[Tooltip("How slowly the overlay disappears (long for persistent effect).")]
	[SerializeField]
	private float fadeOutDuration;

	[Header("Audio")]
	[Tooltip("The AudioSource component used to play the impact sound.")]
	[SerializeField]
	private AudioSource audioSource;

	[Tooltip("The AudioClip played when the fade-in begins (the hit sound).")]
	[SerializeField]
	private AudioClip hitSound;

	private Coroutine fadeCoroutine;

	private void Start()
	{
	}

	public void ShowVomitOverlay()
	{
	}

	[IteratorStateMachine(typeof(_003CFadeSequence_003Ed__10))]
	private IEnumerator FadeSequence()
	{
		return null;
	}

	private void SetAlpha(float alpha)
	{
	}
}
