using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

[Serializable]
public class spiderControll : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CspiderToStartPos_003Ed__44 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public spiderControll _003C_003E4__this;

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
		public _003CspiderToStartPos_003Ed__44(int _003C_003E1__state)
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

	public GameObject gameController;

	public bool playerCaught;

	public bool spiderDead;

	public GameObject spiderParent;

	public Transform spiderStartPosition;

	public Transform spiderPlayerPosition;

	public bool huntPlayer;

	public bool foodTime;

	public float spiderDeadTimer;

	public float spiderEatTimer;

	public float beforeBackToNestTimer;

	public bool spiderStartEat;

	public bool SpiderBitePlayer;

	public Transform PlayerPos;

	public GameObject Player;

	public GameObject Granny;

	public Transform FoodPlate;

	public float spiderSpeed;

	public Animator spider2AnimHolder;

	public GameObject foodCollider;

	public GameObject playerCollider;

	public float damping;

	public bool soundSeePlayed;

	public bool soundAttackPlayed;

	public bool spiderResetNow;

	public bool spiderRunToNest;

	public bool spiderBackoff;

	public bool spiderInNest;

	public GameObject soundEffectHolder;

	public GameObject playerHukaKnapp;

	public GameObject playerHukaKnappParent;

	public GameObject inactivateSpider;

	public GameObject inactivateSpiderTrigger;

	public GameObject spiderTrigger2;

	public GameObject meatOnPlate;

	public GameObject leavetrigger;

	public Transform spiderNestPosition;

	public Transform spiderNotHuntPosition;

	public virtual void Start()
	{
	}

	public virtual void Update()
	{
	}

	public virtual void running()
	{
	}

	public virtual void attack()
	{
	}

	public virtual void idle()
	{
	}

	public virtual void playerDead()
	{
	}

	[IteratorStateMachine(typeof(_003CspiderToStartPos_003Ed__44))]
	public virtual IEnumerator spiderToStartPos()
	{
		return null;
	}

	public virtual void grannyCaughtPlayer()
	{
	}

	public virtual void grannyCaughtPlayerReset()
	{
	}

	public virtual void spiderIsDead()
	{
	}
}
