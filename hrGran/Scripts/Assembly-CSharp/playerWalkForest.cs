using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.UI;

public class playerWalkForest : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003Cfading_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public playerWalkForest _003C_003E4__this;

		private DepthOfFieldModel.Settings _003Cdof_003E5__2;

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
		public _003Cfading_003Ed__15(int _003C_003E1__state)
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

	public Image m_Image;

	private bool m_Fading;

	private bool startFading;

	private bool DOF;

	public GameObject granny;

	public GameObject grannyAnim;

	public PostProcessingProfile PlayerInForest;

	public AudioClip GrannyHit;

	public AudioClip jumpScareSound;

	public GameObject bloodScreenHolder;

	public GameObject skipText;

	public GameObject sparkle;

	public GameObject music;

	public GameObject music2;

	public virtual void Start()
	{
	}

	[IteratorStateMachine(typeof(_003Cfading_003Ed__15))]
	private IEnumerator fading()
	{
		return null;
	}

	private void Update()
	{
	}

	public void jumpScare()
	{
	}
}
