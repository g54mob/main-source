using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class playerCaughtUnderBed : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CEndDayUnderBed_003Ed__42 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public playerCaughtUnderBed _003C_003E4__this;

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
		public _003CEndDayUnderBed_003Ed__42(int _003C_003E1__state)
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

	public Image blackScreenTexture;

	public float fadeBlackSpeed2;

	public GameObject daysCountHolder;

	public GameObject playerBedAnim;

	public GameObject playerInBedCam;

	public GameObject Granny;

	public GameObject boneController;

	public GameObject Player;

	public Transform PlayerStartPos;

	public Transform GrannyStartPos;

	public Transform playerCam;

	public Transform playerHead;

	public GameObject crouchButton;

	public GameObject optionButton;

	public GameObject mittPrick;

	public GameObject furnitureHolder;

	public GameObject[] beartraps;

	public GameObject allBedButtons;

	public GameObject bedCam1Holder;

	public GameObject bedCam2Holder;

	public GameObject bedCam3Holder;

	public GameObject bedCam1;

	public GameObject bedCam2;

	public GameObject bedCam3;

	public GameObject bedButton1;

	public GameObject bedButton2;

	public GameObject bedButton3;

	public GameObject DoorHolder;

	public GameObject PickUpHolder;

	public GameObject dropButtonHolder;

	public GameObject dropButton;

	public GameObject soundHolder2;

	public GameObject teddyMusicHolder;

	public GameObject grannyHuntMusicHolderNightmare;

	public GameObject grannyHuntMusicHolderHalloween;

	public GameObject grannyHuntMusicHolderChristmas;

	public GameObject grannyHuntMusicHolder;

	public GameObject bastuSteamHolder;

	public GameObject spraySoundholder;

	public virtual void Start()
	{
	}

	public virtual void Update()
	{
	}

	[IteratorStateMachine(typeof(_003CEndDayUnderBed_003Ed__42))]
	public virtual IEnumerator EndDayUnderBed()
	{
		return null;
	}

	public virtual void beartrapDestroy()
	{
	}
}
