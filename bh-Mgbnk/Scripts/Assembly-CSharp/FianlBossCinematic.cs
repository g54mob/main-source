using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MilkShake;
using UnityEngine;

public class FianlBossCinematic : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CAnimateCinematic_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public FianlBossCinematic _003C_003E4__this;

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
		public _003CAnimateCinematic_003Ed__14(int _003C_003E1__state)
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

	public bool skipIntro;

	public MapGenerationFinalBoss mapGeneration;

	public Transform cameraCircling;

	public Camera cameraCirclingCamera;

	public FinalFightController finalFightController;

	public GameObject meteor;

	public ShakePreset impactShake;

	public Shaker shaker;

	private float cameraRotationSpeed;

	private float fovSpeed;

	private float desiredFov;

	private Transform target;

	public GameObject finalPortal;

	public void Start()
	{
	}

	private void OnDestroy()
	{
	}

	[IteratorStateMachine(typeof(_003CAnimateCinematic_003Ed__14))]
	private IEnumerator AnimateCinematic()
	{
		return null;
	}

	public void Impact()
	{
	}

	private void OnStageBossDied(bool idk)
	{
	}

	private void SpawnPortal()
	{
	}

	private void Update()
	{
	}
}
