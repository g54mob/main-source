using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class MomSpiderHead : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CmomSpiderEatPlayer_003Ed__53 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MomSpiderHead _003C_003E4__this;

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
		public _003CmomSpiderEatPlayer_003Ed__53(int _003C_003E1__state)
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

	public GameObject boneController;

	public GameObject Granny;

	public NavMeshAgent agent;

	public float spiderMomFollowSpeed;

	public float spiderSpeed;

	public bool seePlayer;

	public bool Hunting;

	public float seePlayerTimer;

	public Transform[] navigations;

	private int index;

	public float indexNumberTemp;

	public float indexNumber;

	public Transform target;

	public Transform player;

	public Transform playerHead;

	public Transform momLookAtPointPlayerEscape;

	public Transform standPointEndScene;

	public GameObject animations;

	public bool waiting;

	public float stuckTimer;

	public float animSpeed;

	public float SpeedChange;

	public bool startWait;

	public float NavWaitTime;

	public float NavwaitTimeNumber;

	public bool playerInHidingSpot;

	public bool keepGoing;

	public bool LookingAtPlayer;

	public Transform spiderMomEye;

	public float targetDistance;

	public float playerDistance;

	public bool playerCaught;

	public bool playerEscape;

	public Transform playerHeadEat;

	public GameObject momSpiderHuntingMusic;

	public GameObject momCatchSound;

	public GameObject momSee;

	public GameObject momGetShotSound;

	public bool momHaveScreamed;

	public bool getShot;

	public float getShotTimer;

	public bool playerClose;

	public GameObject backgroundMusic;

	public float startDest;

	public Transform dest1;

	public Transform dest2;

	public bool redEyeOn;

	public GameObject WitchHat;

	public GameObject WitchNose;

	public GameObject Reindeer_horns1;

	public GameObject Reindeer_horns2;

	private void Start()
	{
	}

	private void Update()
	{
	}

	[IteratorStateMachine(typeof(_003CmomSpiderEatPlayer_003Ed__53))]
	public virtual IEnumerator momSpiderEatPlayer()
	{
		return null;
	}

	public virtual void OnTriggerStay(Collider other)
	{
	}

	public virtual void newNav()
	{
	}
}
