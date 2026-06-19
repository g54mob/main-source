using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using FMODUnity;
using UnityEngine;

public class FrogalDefeatedQuestPart : QuestPart
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass24_0
	{
		public bool finishedPanning;

		public bool finishedStory;

		internal void _003CCinematic_003Eb__0()
		{
		}

		internal void _003CCinematic_003Eb__1()
		{
		}

		internal void _003CCinematic_003Eb__2()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CCinematic_003Ed__24 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TurretTower turretTower;

		public FrogalDefeatedQuestPart _003C_003E4__this;

		private _003C_003Ec__DisplayClass24_0 _003C_003E8__1;

		private float _003Ctime_003E5__2;

		private Vector3 _003Cstart_003E5__3;

		private GameObject _003Cfireball_003E5__4;

		private Vector3 _003Cdirection_003E5__5;

		private Vector3 _003Cperpendicular_003E5__6;

		private float _003ChalfArc_003E5__7;

		private float _003Cradius_003E5__8;

		private Vector3 _003Ccenter_003E5__9;

		private float _003Cangle_003E5__10;

		private float _003Ctimer_003E5__11;

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
		public _003CCinematic_003Ed__24(int _003C_003E1__state)
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

	public static FrogalDefeatedQuestPart Instance;

	public bool AbleToTakeFireball;

	public float IntroPanDuration;

	public float StartBuffer;

	public GameObject FireballPrefab;

	public float FireballSpeed;

	[Range(0.1f, (float)Math.PI * 2f)]
	public float FireballArcAngle;

	public Transform FinalDestination;

	public Animator FrogalAnimator;

	public Transform FrogalFallingTransform;

	public float FallingDuration;

	public float BeggingZoomLevel;

	public float BeggingZoomDuration;

	public DialogueStory BeggingDialogue;

	public GameObject DruidInTower;

	public Checkpoint Checkpoint;

	public bool CounterClockwise;

	public EventReference TurretPanSound;

	public EventReference FrogalHitSound;

	private void Start()
	{
	}

	public override void ActivateQuestPart()
	{
	}

	public override void ApplyCompletedEffects()
	{
	}

	public override void ApplyFreshCompletedEffects()
	{
	}

	public void ShootFireballFrom(TurretTower turretTower)
	{
	}

	[IteratorStateMachine(typeof(_003CCinematic_003Ed__24))]
	public IEnumerator Cinematic(TurretTower turretTower)
	{
		return null;
	}
}
