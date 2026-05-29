using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

[Serializable]
public class carFrontSensor : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003COnTriggerEnter_003Ed__37 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Collider other;

		public carFrontSensor _003C_003E4__this;

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
		public _003COnTriggerEnter_003Ed__37(int _003C_003E1__state)
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

	public GameObject forwardButton;

	public GameObject ReverseButton;

	public GameObject outOffCarButton;

	public bool garagedoorOpen;

	public float hitGaragedoorCounter;

	public GameObject brickWallStart;

	public GameObject brickWallBroken;

	public GameObject mittPrick;

	public Texture2D brokenTextureMin;

	public Texture2D brokenTextureMax;

	public GameObject camInCar;

	public GameObject escapeCam;

	public GameObject escapeCamNoGranny;

	public GameObject granny;

	public GameObject dust1;

	public GameObject dust2;

	public GameObject headAnim;

	public GameObject carForwardSound;

	public GameObject engineOnSound;

	public GameObject crashSound;

	public GameObject crashSoundPort;

	public GameObject CarHitTriggers;

	public GameObject shouldOpenDoorFirstText;

	public GameObject optionButton;

	public bool textTimerOnOff;

	public float textTimer;

	public bool textShown;

	public GameObject mainMusic;

	public GameObject HalloweenMusic;

	public GameObject ChristmasMusic;

	public GameObject NightmareMusic;

	public GameObject mainMusicHunt;

	public GameObject HalloweenMusicHunt;

	public GameObject ChristmasMusicHunt;

	public GameObject NightmareMusicHunt;

	public virtual void Update()
	{
	}

	[IteratorStateMachine(typeof(_003COnTriggerEnter_003Ed__37))]
	public virtual IEnumerator OnTriggerEnter(Collider other)
	{
		return null;
	}
}
