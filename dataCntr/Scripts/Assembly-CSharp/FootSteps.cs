using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CcheckGroundMaterial_003Ed__21 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public FootSteps _003C_003E4__this;

		private RaycastHit _003Chit_003E5__2;

		private int _003CcurrentInstanceID_003E5__3;

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
		public _003CcheckGroundMaterial_003Ed__21(int _003C_003E1__state)
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
	private AudioClip[] metalClips;

	[SerializeField]
	private AudioClip[] stoneClips;

	[SerializeField]
	private AudioClip[] mudClips;

	[SerializeField]
	private AudioClip[] grassClips;

	[SerializeField]
	private AudioClip[] sandClips;

	[SerializeField]
	private AudioClip[] gravelClips;

	[SerializeField]
	private AudioClip[] pavementClips;

	[SerializeField]
	private AudioClip[] woodClips;

	[SerializeField]
	private AudioClip[] waterClips;

	private AudioSource audioSource;

	private TerrainDetector terrainDetector;

	private string coliderTag;

	private int terrainInstanceID;

	private int terrainTextureIndex;

	private WaitForSeconds wait02Sec;

	private void Awake()
	{
	}

	public void PlayRequestedStepSound(int _clipArray)
	{
	}

	private AudioClip GetRandomFromRequest(int _clipArray)
	{
		return null;
	}

	public void Step()
	{
	}

	private AudioClip GetRandomClip()
	{
		return null;
	}

	private void OnEnable()
	{
	}

	[IteratorStateMachine(typeof(_003CcheckGroundMaterial_003Ed__21))]
	private IEnumerator checkGroundMaterial()
	{
		return null;
	}
}
