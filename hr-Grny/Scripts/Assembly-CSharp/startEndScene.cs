using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class startEndScene : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CstartTheEnd1_003Ed__30 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public startEndScene _003C_003E4__this;

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
		public _003CstartTheEnd1_003Ed__30(int _003C_003E1__state)
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
	private sealed class _003CstartTheEnd2_003Ed__31 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public startEndScene _003C_003E4__this;

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
		public _003CstartTheEnd2_003Ed__31(int _003C_003E1__state)
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

	public float fadeBlackSpeed;

	public Image blackScreen;

	public float fogEndDistance;

	public bool fog;

	public GameObject granny1;

	public GameObject granny1Anim;

	public GameObject granny2;

	public GameObject granny2Gone;

	public GameObject granny3Home;

	public GameObject GrannyGoneTeddy;

	public GameObject teddy;

	public GameObject cam1;

	public GameObject cam2;

	public GameObject grannyAnim;

	public GameObject soundEffects;

	public GameObject slendrinaTexture;

	public float fadeSpeed;

	public bool slendrinaFade;

	public GameObject theEndText1;

	public GameObject theEndText2;

	public bool playerWon;

	public GameObject Halloween;

	public GameObject lightsInsideNormal;

	public GameObject lightsInsideHalloween;

	public GameObject Christmas;

	public GameObject lightsInsideChristmas;

	public GameObject MerryChristmasText;

	public GameObject MerryChristmasTextNoGranny;

	public virtual void Start()
	{
	}

	public virtual void Update()
	{
	}

	[IteratorStateMachine(typeof(_003CstartTheEnd1_003Ed__30))]
	public virtual IEnumerator startTheEnd1()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CstartTheEnd2_003Ed__31))]
	public virtual IEnumerator startTheEnd2()
	{
		return null;
	}

	public virtual void readyToMainMenu()
	{
	}
}
