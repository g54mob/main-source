using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

[Serializable]
public class AIfollow : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CafterFollow_003Ed__115 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

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
		public _003CafterFollow_003Ed__115(int _003C_003E1__state)
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
	private sealed class _003CattackPlayer_003Ed__111 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AIfollow _003C_003E4__this;

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
		public _003CattackPlayer_003Ed__111(int _003C_003E1__state)
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
	private sealed class _003CrandomNavAfterAttack_003Ed__112 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AIfollow _003C_003E4__this;

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
		public _003CrandomNavAfterAttack_003Ed__112(int _003C_003E1__state)
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
	private sealed class _003CstopAndAttack_003Ed__107 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AIfollow _003C_003E4__this;

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
		public _003CstopAndAttack_003Ed__107(int _003C_003E1__state)
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
	private sealed class _003CstopfollowPlayer_003Ed__110 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AIfollow _003C_003E4__this;

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
		public _003CstopfollowPlayer_003Ed__110(int _003C_003E1__state)
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

	public Transform myTransform;

	public GameObject slendrina;

	public GameObject slendrinaBody;

	public Transform target;

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

	public Transform nav17;

	public Transform nav18;

	public Transform nav19;

	public Transform player;

	public NavMeshAgent navComponent;

	public bool timerOnOff;

	public bool timerStop;

	public bool seePlayer;

	public bool attackingPlayer;

	public bool FollowPlayer;

	public bool stopFollow;

	public bool robotdead;

	public bool playerHiding;

	public bool monsterSearch;

	public bool waypointWaitTime;

	public bool breakDoor;

	public bool startHittingPlayer;

	public bool stopHittingPlayer;

	public bool PlayerVisible;

	public bool DoorOpenVisible;

	public bool DoorClosedVisible;

	public bool garderobVisible;

	public bool stopAndAttackPlayer;

	public bool slendrinaActive;

	public bool waypointStop;

	public bool huntingPlayer;

	public float timer;

	public float Stucktimer;

	public bool StucktimerOnOff;

	public float Huntingtimer;

	public bool HuntingtimerOn;

	public float number;

	public float numberRoar;

	public GameObject animationHolder;

	public float damping;

	public int damp;

	public float rotationSpeed;

	public float seeRange;

	public float attackRange;

	public float stopFollowRange;

	public float distance;

	public float distanceWaypoint;

	private bool soundEffectPlay;

	public float RobotRotatespeed;

	public GameObject robotEyes;

	public GameObject yellowRay1;

	public GameObject yellowRay2;

	public GameObject RedRay;

	public GameObject monsterAnimHandDoor;

	public GameObject roboteyeBack;

	public GameObject monsterHeadAnim;

	public GameObject followSoundHolder;

	public GameObject roarSoundHolder;

	public GameObject FootstepSoundHolder;

	public GameObject BreathingSoundHolder;

	public GameObject musicHolder;

	public GameObject HuntmusicHolder;

	public bool PlayerDead;

	public bool ManiacSeeLocker;

	public bool ManiacOpenLocker;

	public bool seeLockerDoor;

	public bool seeSmashDoor;

	public GameObject LockerButtons;

	public float playerVisibleTimer;

	public float yellowRayLenght;

	public GameObject maniacHandSmash;

	public bool reduseraTimerHiding;

	public GameObject soundeffectsHolder;

	public AudioClip maniacFootstepsWalk;

	public AudioClip maniacFootstepsFollow;

	public bool maniacSeePlayer;

	public GameObject breathSoundHolder;

	public GameObject screamSoundHolder;

	public bool maniacMoving;

	public bool footstepPlaying;

	public float seeOpenDoorTimer;

	public float seeClosedDoorTimer;

	public float seeClosedGarderobDoorTimer;

	public bool monsterHurt;

	public GameObject monsterHand;

	public float timerCount2;

	public bool monsterIsFreezed;

	public bool disableMonster;

	public GameObject gameController;

	public virtual void Start()
	{
	}

	public virtual void Update()
	{
	}

	public virtual void letMomSwing()
	{
	}

	[IteratorStateMachine(typeof(_003CstopAndAttack_003Ed__107))]
	public virtual IEnumerator stopAndAttack()
	{
		return null;
	}

	public virtual void playerStillHiding()
	{
	}

	public virtual void followPlayer()
	{
	}

	[IteratorStateMachine(typeof(_003CstopfollowPlayer_003Ed__110))]
	public virtual IEnumerator stopfollowPlayer()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CattackPlayer_003Ed__111))]
	public virtual IEnumerator attackPlayer()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CrandomNavAfterAttack_003Ed__112))]
	public virtual IEnumerator randomNavAfterAttack()
	{
		return null;
	}

	public virtual void randomNav()
	{
	}

	public virtual void newNav()
	{
	}

	[IteratorStateMachine(typeof(_003CafterFollow_003Ed__115))]
	public virtual IEnumerator afterFollow()
	{
		return null;
	}
}
