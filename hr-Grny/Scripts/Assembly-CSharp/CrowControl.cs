using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CrowControl : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CcrowProtectItem_003Ed__24 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public CrowControl _003C_003E4__this;

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
		public _003CcrowProtectItem_003Ed__24(int _003C_003E1__state)
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
	private sealed class _003CcrowStartFly_003Ed__23 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public CrowControl _003C_003E4__this;

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
		public _003CcrowStartFly_003Ed__23(int _003C_003E1__state)
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
	private sealed class _003CcrowStartFlyShoot_003Ed__25 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public CrowControl _003C_003E4__this;

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
		public _003CcrowStartFlyShoot_003Ed__25(int _003C_003E1__state)
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

	public GameObject CrowBur;

	public GameObject CrowFlyAnim;

	public GameObject CrowFlyEat;

	public GameObject CrowFlyBack;

	public GameObject CrowEat;

	public GameObject BurDoor;

	public GameObject Seed;

	public GameObject seedPlate;

	public GameObject crowGone;

	public bool burdoorIsOpen;

	public Animator CrowAnimHolder;

	public bool CrowStartEat;

	public bool isFlying;

	public bool isAttacking;

	public bool playerSteal;

	public bool shootInBur;

	public bool crowGetShoot;

	public bool crowNotShotAgain;

	public GameObject GrannyHear;

	public Transform GrannyHearSP;

	public AudioClip crowShootLjud;

	private void Start()
	{
	}

	private void Update()
	{
	}

	[IteratorStateMachine(typeof(_003CcrowStartFly_003Ed__23))]
	public virtual IEnumerator crowStartFly()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CcrowProtectItem_003Ed__24))]
	public virtual IEnumerator crowProtectItem()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CcrowStartFlyShoot_003Ed__25))]
	public virtual IEnumerator crowStartFlyShoot()
	{
		return null;
	}
}
