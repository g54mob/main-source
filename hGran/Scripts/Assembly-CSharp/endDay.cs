using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class endDay : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CEndDay_003Ed__85 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public endDay _003C_003E4__this;

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
		public _003CEndDay_003Ed__85(int _003C_003E1__state)
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

	public float fadeBlackSpeed;

	public float fadeBlackSpeed2;

	public GameObject daysCountHolder;

	public GameObject playerBedAnim;

	public GameObject playerInBedCam;

	public GameObject Granny;

	public GameObject momSpider;

	public GameObject boneController;

	public GameObject Player;

	public GameObject PlayerEyes;

	public GameObject PlayerHeadSpider;

	public Transform PlayerStartPos;

	public Transform playerCam;

	public Transform playerHead;

	public GameObject joystick;

	public GameObject crouchButton;

	public GameObject playerHukarSigButton;

	public GameObject optionButton;

	public GameObject mittPrick;

	public MonoBehaviour playerStopscript;

	public GameObject playerStop;

	public GameObject swipe;

	public GameObject furnitureHolder;

	public GameObject DoorHolder;

	public GameObject PickUpHolder;

	public GameObject[] beartraps;

	public GameObject bedButton1;

	public GameObject bedButton2;

	public GameObject bedButton3;

	public GameObject dropButtonHolder;

	public GameObject shootButtonHolder;

	public GameObject coffinButton1;

	public GameObject coffinButton2;

	public GameObject carButton;

	public GameObject hideCam1;

	public GameObject hideCam2;

	public GameObject hideCam3;

	public GameObject hideCam4;

	public GameObject hideCam5;

	public GameObject hideCam6;

	public Image trapButtonUI;

	public GameObject trapButton;

	public GameObject trapBar;

	public bool enDayStart;

	public GameObject soundHolder2;

	public GameObject Sound1;

	public GameObject Sound2;

	public GameObject Sound3;

	public GameObject cameraSee;

	public GameObject prisonDoor;

	public GameObject prisonGaller;

	public GameObject prisonGallerColliders;

	public GameObject camLampa;

	public GameObject teddyMusicHolder;

	public GameObject grannyHuntMusicHolderNightmare;

	public GameObject grannyHuntMusicHolderHalloween;

	public GameObject grannyHuntMusicHolderChristmas;

	public GameObject grannyHuntMusicHolder;

	public GameObject brunnsvevButton;

	public GameObject bastuSteamHolder;

	public GameObject Spider;

	public GameObject GrannyEyeLock;

	public GameObject GrannyBlindSensor;

	public GameObject spraySoundHolder;

	public GameObject sprayButton;

	public GameObject remoteButton;

	public GameObject remoteAndSprayButtonParent;

	public GameObject momSpiderHuntMusic;

	public GameObject mainMusicHolder;

	public GameObject nightMareMusicHolder;

	public GameObject halloweenMusicHolder;

	public GameObject christmasMusicHolder;

	public GameObject spiderCellarMusicHolder;

	public GameObject huntMusicHolder;

	public GameObject huntNightmareMusicHolder;

	public GameObject huntHalloweenMusicHolder;

	public GameObject huntChristmasMusicHolder;

	public GameObject elevator;

	public GameObject spiderMomScream;

	public GameObject spiderMomGetShotScream;

	public GameObject lanternAnimation;

	public virtual void Start()
	{
	}

	public virtual void Update()
	{
	}

	[IteratorStateMachine(typeof(_003CEndDay_003Ed__85))]
	public virtual IEnumerator EndDay()
	{
		return null;
	}

	public virtual void beartrapDestroy()
	{
	}
}
