using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class escapeSpiderCellarTrigger : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CescapeCam_003Ed__22 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public escapeSpiderCellarTrigger _003C_003E4__this;

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
		public _003CescapeCam_003Ed__22(int _003C_003E1__state)
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

	public GameObject GameController;

	public Image blackScreenTexture;

	public GameObject Granny;

	public GameObject player;

	public GameObject spiderMom;

	public GameObject footstepScriptHolder;

	public GameObject crouchButton;

	public GameObject trapButton;

	public GameObject dooropener;

	public GameObject seeHolder;

	public GameObject mainMusicHolder;

	public GameObject nightMareMusicHolder;

	public GameObject halloweenMusicHolder;

	public GameObject christmasMusicHolder;

	public GameObject spiderCellarMusicHolder;

	public GameObject teddyMusicHolder;

	public GameObject escapeScene;

	public GameObject theEndText;

	public GameObject MerryChristmasText;

	public GameObject music;

	public GameObject GrannyLookEnd;

	public virtual void OnTriggerEnter(Collider other)
	{
	}

	[IteratorStateMachine(typeof(_003CescapeCam_003Ed__22))]
	public virtual IEnumerator escapeCam()
	{
		return null;
	}
}
