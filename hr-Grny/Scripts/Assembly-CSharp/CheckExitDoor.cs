using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class CheckExitDoor : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CopenExitdoor_003Ed__47 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public CheckExitDoor _003C_003E4__this;

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
		public _003CopenExitdoor_003Ed__47(int _003C_003E1__state)
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

	public Image blackScreenTexture;

	public GameObject Granny;

	public GameObject GrannySkin;

	public GameObject GrannyBone;

	public GameObject OldMom;

	public Transform OldMomSP;

	public GameObject player;

	public GameObject footstepScriptHolder;

	public GameObject crouchButton;

	public Image removeBar;

	public GameObject trapButton;

	public GameObject trapBar;

	public GameObject dooropener;

	public GameObject seeHolder;

	public GameObject soundHolder;

	public float fadeBlackSpeed;

	public bool lampa1ok;

	public bool lampa2ok;

	public bool planka1Bort;

	public bool planka2Bort;

	public bool hangLockBort;

	public bool DpadlockBort;

	public bool batteryLockOk;

	public bool extremeLockOk;

	public GameObject CantopenDoorYetText;

	public GameObject gameController;

	public float counter;

	public float ELtimer;

	public bool startTimer;

	public GameObject extraLock;

	public GameObject extraLockHard;

	public GameObject extraLockExtreme;

	public bool extraLockOK;

	public bool extraLockPlaced;

	public GameObject padlockCodePL1;

	public GameObject padlockCodePL2;

	public GameObject padlockCodePL3;

	public GameObject padlockCodePL4;

	public GameObject padlockCodePL5;

	public GameObject battery1;

	public GameObject battery2;

	public GameObject battery3;

	public GameObject battery4;

	public GameObject battery5;

	public GameObject GallerHole;

	public virtual void Start()
	{
	}

	public virtual void Update()
	{
	}

	[IteratorStateMachine(typeof(_003CopenExitdoor_003Ed__47))]
	public virtual IEnumerator openExitdoor()
	{
		return null;
	}

	public virtual void ExtralockTimer()
	{
	}

	public virtual void ExtralockTimerHard()
	{
	}
}
