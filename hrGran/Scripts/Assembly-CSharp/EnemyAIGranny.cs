using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

[Serializable]
public class EnemyAIGranny : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CPlayercaught_003Ed__202 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public EnemyAIGranny _003C_003E4__this;

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
		public _003CPlayercaught_003Ed__202(int _003C_003E1__state)
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

	[CompilerGenerated]
	private sealed class _003CdropBearTrap_003Ed__196 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public EnemyAIGranny _003C_003E4__this;

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
		public _003CdropBearTrap_003Ed__196(int _003C_003E1__state)
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

	[CompilerGenerated]
	private sealed class _003CgrannyFreeze_003Ed__195 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public EnemyAIGranny _003C_003E4__this;

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
		public _003CgrannyFreeze_003Ed__195(int _003C_003E1__state)
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

	[CompilerGenerated]
	private sealed class _003CgrannyHitByArrow_003Ed__192 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public EnemyAIGranny _003C_003E4__this;

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
		public _003CgrannyHitByArrow_003Ed__192(int _003C_003E1__state)
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

	[CompilerGenerated]
	private sealed class _003CresetLockedDoorSee_003Ed__206 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public EnemyAIGranny _003C_003E4__this;

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
		public _003CresetLockedDoorSee_003Ed__206(int _003C_003E1__state)
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

	public Transform myTransform;

	public Transform grannyEye;

	public GameObject grannyLock;

	public Transform target;

	public Transform bedtargetTemp1;

	public Transform bedtargetTemp2;

	public Transform bedtargetTemp3;

	public Transform coffintargetTemp4;

	public Transform coffintargetTempBY;

	public Transform cartargetTemp;

	public GameObject bedCam1;

	public GameObject bedCam2;

	public GameObject bedCam3;

	public GameObject coffinHead1;

	public GameObject coffinHead2;

	public GameObject carHead;

	public float walkSpeed;

	public float walkAnimSpeed;

	public float grannysFollowSpeed;

	public float grannysAnimFollowSpeed;

	public bool hidingUnderBed1;

	public bool hidingUnderBed2;

	public bool hidingUnderBed3;

	public bool hidingInCoffin4;

	public bool hidingInCoffinBY;

	public bool hidingInCar;

	public bool playerHiding;

	public bool playerInHole;

	public bool grannyInBastu;

	public bool bastuswitchOn;

	public bool bastuBomNere;

	public bool bastuTimeOff;

	public float bastuTimer;

	public float bastuDoorTimer;

	public GameObject bastuDoor;

	public NavMeshObstacle bastuDoorCarv;

	public GameObject bastuBom;

	public bool StartbastuSafeTimer;

	public float bastuSafeTimer;

	public Transform player;

	public GameObject Player;

	public Transform playerPos;

	public NavMeshAgent navComponent;

	public float number;

	public float speed;

	public Transform nav1;

	public Transform nav2;

	public Transform nav3;

	public Transform nav4;

	public Transform nav5;

	public Transform nav6;

	public Transform nav7;

	public Transform nav8;

	public Transform nav9;

	public Transform nav10;

	public Transform nav11;

	public Transform nav12;

	public Transform nav13;

	public Transform nav14;

	public Transform nav15;

	public Transform nav16;

	public bool seePlayer;

	public bool seePlayerTimer;

	public float offScreenDot;

	public bool waypointStop;

	public bool waypointStart;

	public float distanceWaypoint;

	public float distance;

	public float attackDistance;

	public bool waypointWaitTime;

	public bool timerOnOff;

	public float timer;

	public float timerSee;

	public float timerSearch;

	public float timerBed;

	public float safeTimer;

	public float safeTimerStandStill;

	public bool resetSafeTimer;

	public bool startTimerSearch;

	public bool GrannySearching;

	public bool GrannySearch;

	public bool GrannyMoving;

	public bool attackingPlayer;

	public bool huntPlayer;

	public bool grannyIsFollow;

	public GameObject animationHolder;

	public bool startWalk;

	public bool stopWalk;

	public bool startAttack;

	public bool grannyHearPlayer;

	public bool grannyHearObject;

	public bool playerHidingUnderBed;

	public bool playerHidingInCoffin;

	public bool playerHidingInCoffinBackyard;

	public bool playerHidingInCar;

	public bool grannyStandBesideCar;

	public bool grannyLookUnderBed;

	public GameObject allBedButtons;

	public bool playerGetCaught;

	public bool PlayerEscaped;

	public bool PlayerDead;

	public bool checkInstansName;

	public bool playerFallDeath;

	public bool dontHitPlayer;

	public GameObject doorRay;

	public GameObject checkGround;

	public float seeClosedDoorTimer;

	public bool grannySeeDoor;

	public bool grannySeeLockedDoor;

	public bool stopSeeLockedDoor;

	public bool grannyNOTSeeDoor;

	public GameObject gameController;

	public bool playerCaughtLastTime;

	public GameObject playerHukaKnapp;

	public GameObject playerHukaKnappParent;

	public GameObject optionButton;

	public Transform PlayerCoffinPos;

	public Transform PlayerCoffinBYPos;

	public Transform PlayerCarPos;

	public GameObject coffinLock;

	public GameObject coffinLockBY;

	public GameObject Spider;

	public GameObject bearTrap;

	public GameObject bearTrapOrganic;

	public Transform bearTrapSP;

	public bool droppingBeartrap;

	public bool soundPlaying;

	public GameObject soundHolder1;

	public GameObject soundHolder2;

	public GameObject soundHolder3;

	public GameObject playerSounds;

	public GameObject grannySounds;

	public GameObject[] NPoints;

	public bool seeStairs;

	public bool hitByArrow;

	public bool hitByGun;

	public bool hitByCar;

	public bool hitByPepper;

	public bool hitByPepperStart;

	public bool freeze;

	public bool bastuKilled;

	public bool ragdollSpawn;

	public Transform grannyRagdoll;

	public Transform grannyForceRagdoll;

	public Transform grannyFreezedoll;

	public GameObject grannyDisaper;

	public GameObject grannyGoneNormalText1;

	public GameObject grannyGoneEasyText1;

	public GameObject grannyGoneHardText1;

	public GameObject grannyGoneExtremeText1;

	public GameObject grannyGoneEasyShotText;

	public GameObject grannyGoneNormalShotText;

	public GameObject grannyGoneHardShotText;

	public GameObject grannyGoneExtremeShotText;

	public float grannysVarSpeed;

	public float grannysAnimSpeed;

	public bool turnFacePlayer;

	public bool playerInPrison;

	public bool prisondoorClosed;

	public bool playerNearGranny;

	public bool GrannyGonnaSmack;

	public bool playerHaveTeddy;

	public bool spiderIsDead;

	public bool playerStartCar;

	public bool grannyEyeColorTimerOn;

	public float grannyEyeColorTimer;

	public float blindTimer;

	public bool grannyPepperReact;

	public GameObject grannyEyeColor;

	public GameObject teddyMusicHolder;

	public GameObject GrannyHuntMusicHolderNightmare;

	public GameObject GrannyHuntMusicHolderHalloween;

	public GameObject GrannyHuntMusicHolderChristmas;

	public GameObject GrannyHuntMusicHolder;

	public GameObject startCarButton;

	public GameObject forwardButton;

	public GameObject reverseButton;

	public GameObject engineOnSound;

	public GameObject engineOffSound;

	public GameObject engineStartSound;

	public GameObject ObjectHolder;

	public GameObject grannyCloseTrigger;

	public float howLongFollow;

	public float beforeHitTimer;

	public bool playerStandBed;

	public bool grannySkrattarPlayed;

	public GameObject momSpiderHead;

	public virtual void Start()
	{
	}

	public virtual void FixedUpdate()
	{
	}

	public virtual void grannyHitByPepper()
	{
	}

	public virtual void pepperAnimDone()
	{
	}

	[IteratorStateMachine(typeof(_003CgrannyHitByArrow_003Ed__192))]
	public virtual IEnumerator grannyHitByArrow()
	{
		return null;
	}

	public virtual void grannyHitByCar()
	{
	}

	public virtual void grannyHitByGun()
	{
	}

	[IteratorStateMachine(typeof(_003CgrannyFreeze_003Ed__195))]
	public virtual IEnumerator grannyFreeze()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CdropBearTrap_003Ed__196))]
	public virtual IEnumerator dropBearTrap()
	{
		return null;
	}

	public virtual void OnTriggerStay(Collider other)
	{
	}

	public virtual void OnTriggerExit(Collider other)
	{
	}

	public virtual void GrannyDecisions()
	{
	}

	public virtual void facePlayer()
	{
	}

	public virtual void facePlayerBed()
	{
	}

	[IteratorStateMachine(typeof(_003CPlayercaught_003Ed__202))]
	public virtual IEnumerator Playercaught()
	{
		return null;
	}

	public virtual void followPlayer()
	{
	}

	public virtual void newNav()
	{
	}

	public void disableHeadFollow()
	{
	}

	[IteratorStateMachine(typeof(_003CresetLockedDoorSee_003Ed__206))]
	public virtual IEnumerator resetLockedDoorSee()
	{
		return null;
	}

	public virtual void cleaning()
	{
	}

	public void disableOnlyHeadFollow()
	{
	}
}
