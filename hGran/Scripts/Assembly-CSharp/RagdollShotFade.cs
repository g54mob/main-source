using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

[Serializable]
public class RagdollShotFade : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CStart_003Ed__16 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public RagdollShotFade _003C_003E4__this;

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
		public _003CStart_003Ed__16(int _003C_003E1__state)
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

	public GameObject Granny;

	public bool ragdollFade;

	public Shader shader1;

	public Shader shader2;

	public Renderer rend;

	public GameObject ragdollTexture;

	public GameObject leg1Texture;

	public GameObject leg2Texture;

	public GameObject Hair;

	public GameObject Eyes;

	public GameObject Tand;

	public GameObject Bat;

	public float fadeStartTime;

	public float timerCount;

	public bool checkFadeEarly;

	[IteratorStateMachine(typeof(_003CStart_003Ed__16))]
	public virtual IEnumerator Start()
	{
		return null;
	}

	public virtual void Update()
	{
	}
}
