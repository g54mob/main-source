using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

[Serializable]
public class openDoors : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CbastuBommenNere_003Ed__69 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public openDoors _003C_003E4__this;

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
		public _003CbastuBommenNere_003Ed__69(int _003C_003E1__state)
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
	private sealed class _003CbastuBommenUppe_003Ed__70 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public openDoors _003C_003E4__this;

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
		public _003CbastuBommenUppe_003Ed__70(int _003C_003E1__state)
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
	private sealed class _003CcrowAttackPlayer_003Ed__71 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public openDoors _003C_003E4__this;

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
		public _003CcrowAttackPlayer_003Ed__71(int _003C_003E1__state)
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

	public LayerMask layerMask;

	public GameObject granny;

	public GameObject gameController;

	public GameObject openDoorButton;

	public GameObject removeBTButton;

	public bool resetBTbutton;

	public GameObject doorRay;

	public bool openTheDoor;

	public bool playerTaken;

	public bool removeBeartrap;

	public GameObject footstepScriptHolder;

	public GameObject player;

	public GameObject joystick;

	public GameObject microSparks;

	public AudioClip doorLocked;

	public AudioClip microDoor;

	public AudioClip fingerFan;

	public AudioClip giljotinLjud;

	public AudioClip doorLockedLjud;

	public AudioClip secretDoorButton;

	public AudioClip garagePortSound;

	public AudioClip bakluckaLocked;

	public AudioClip brokenCarDoor;

	public AudioClip switchOnOff;

	public AudioClip bastuBomNer;

	public AudioClip bokhyllaLjud;

	public AudioClip crowAttack;

	public AudioClip burDoor;

	public AudioClip moveGaller;

	public AudioClip openIronDoors;

	public AudioClip openCoffin;

	public AudioClip openLockerDoor;

	public bool playSound;

	public GameObject bloodScreenHolder;

	public bool playerFanHurt;

	public bool garageportLock;

	public GameObject garageportAnimHolder;

	public GameObject carSensorFront;

	public GameObject needCarkeyText;

	public GameObject garageportLockedText;

	public bool textTimerOnOff;

	public float textTimer;

	public bool canJumpOut;

	public bool canJumpIn;

	public GameObject camOutToIn;

	public GameObject camInToOut;

	public GameObject winController;

	public GameObject checkPcrouch;

	public GameObject giljotin;

	public GameObject secretDoor;

	public GameObject secretDoorTrigger;

	public GameObject bastuSpak;

	public GameObject bastuSteam;

	public GameObject bastuBom;

	public GameObject bastuDoor;

	public NavMeshObstacle bastuDoorCarv;

	public GameObject noiceObjectBastu;

	public bool droppedNoiceObj;

	public GameObject tavelspak;

	public GameObject bokhylla;

	public bool playerTrySteal;

	public GameObject Crow;

	public GameObject baklucka;

	public GameObject elevatorController;

	public GameObject ironDoorsHolder;

	public GameObject bombCoffin_1;

	public GameObject bombCoffin_2;

	public virtual void Start()
	{
	}

	public virtual void Update()
	{
	}

	[IteratorStateMachine(typeof(_003CbastuBommenNere_003Ed__69))]
	public virtual IEnumerator bastuBommenNere()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CbastuBommenUppe_003Ed__70))]
	public virtual IEnumerator bastuBommenUppe()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CcrowAttackPlayer_003Ed__71))]
	public virtual IEnumerator crowAttackPlayer()
	{
		return null;
	}
}
