using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScene4 : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CStart_003Ed__11 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public GameOverScene4 _003C_003E4__this;

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
		public _003CStart_003Ed__11(int _003C_003E1__state)
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

	public GameObject Granny;

	public GameObject vindSound;

	public AudioClip smack;

	public AudioClip GrannySound;

	public AudioClip playerLand;

	public Image blackScreenTexture;

	public GameObject gameOverText;

	public Image gameOverTexture;

	public GameObject Beartrap;

	public GameObject BeartrapNM;

	[IteratorStateMachine(typeof(_003CStart_003Ed__11))]
	public virtual IEnumerator Start()
	{
		return null;
	}
}
