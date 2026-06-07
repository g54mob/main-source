using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PackageDisappearController : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CFadeOutRoutine_003Ed__17 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PackageDisappearController _003C_003E4__this;

		private float _003CstartTime_003E5__2;

		private Color _003CcurrentColor_003E5__3;

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
		public _003CFadeOutRoutine_003Ed__17(int _003C_003E1__state)
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
	private bool isDisappeared;

	[SerializeField]
	private float fadeDuration;

	[SerializeField]
	private Renderer targetRenderer;

	[SerializeField]
	private ParticleSystem disappearParticles;

	[SerializeField]
	private GameObject objectToActivate;

	[SerializeField]
	private AudioSource audioSource;

	[SerializeField]
	private AudioClip disappearSound;

	private Material targetMaterial;

	private Color originalColor;

	private bool hasDisappeared;

	private bool isFading;

	public bool IsDisappeared
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private void Awake()
	{
	}

	private void Update()
	{
	}

	private void StartDisappearEffect()
	{
	}

	[IteratorStateMachine(typeof(_003CFadeOutRoutine_003Ed__17))]
	private IEnumerator FadeOutRoutine()
	{
		return null;
	}

	public void ResetPackage()
	{
	}
}
