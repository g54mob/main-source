using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MEC;
using UnityEngine;

public class MainMenuUIMgr : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_LerpFOV_003Ed__21 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public float fovLen;

		public MainMenuUIMgr _003C_003E4__this;

		public float startFov;

		public float tgtFov;

		private float _003CfovTime_003E5__2;

		float IEnumerator<float>.Current
		{
			[DebuggerHidden]
			get
			{
				return 0f;
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
		public _003C_LerpFOV_003Ed__21(int _003C_003E1__state)
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
	private sealed class _003C_RunCam_003Ed__22 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public MainMenuUIMgr _003C_003E4__this;

		public bool hasData;

		private Transform _003CcamStart_003E5__2;

		private Transform _003CcamEnd_003E5__3;

		private Camera _003Ccam_003E5__4;

		private float _003CstartTime_003E5__5;

		private float _003Clen_003E5__6;

		float IEnumerator<float>.Current
		{
			[DebuggerHidden]
			get
			{
				return 0f;
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
		public _003C_RunCam_003Ed__22(int _003C_003E1__state)
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
	private sealed class _003C_RunContinue_003Ed__24 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public MainMenuUIMgr _003C_003E4__this;

		private float _003CstartTime_003E5__2;

		private float _003Clen_003E5__3;

		float IEnumerator<float>.Current
		{
			[DebuggerHidden]
			get
			{
				return 0f;
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
		public _003C_RunContinue_003Ed__24(int _003C_003E1__state)
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

	public static MainMenuUIMgr I;

	public BaseSettingsUI Settings;

	public DialogUI Dialog;

	public SelectSlotUI Slot;

	public CreditsUI Credits;

	public IntroCutsceneObj IntroCutscene;

	public GameHoverPopup Hover;

	public FullScreenMessageUI FullScrn;

	public CloudOutOfSyncUI OutOfSync;

	public Camera MainCam;

	public AnimationCurve CrvBallbylonCam;

	private CoroutineHandle _camAnim;

	public CoolButtonViz BtnVizCentered;

	public CoolButtonViz BtnVizLeft;

	public Material MatIntroVillage;

	public Material MatIntroVillage2;

	public Material MatIntroVillageNoRainbow;

	public Material MatIntroVillage2NoRainbow;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	public void RunIntroCutscene()
	{
	}

	[IteratorStateMachine(typeof(_003C_LerpFOV_003Ed__21))]
	private IEnumerator<float> _LerpFOV(float startFov, float tgtFov, float fovLen)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_RunCam_003Ed__22))]
	private IEnumerator<float> _RunCam(bool hasData)
	{
		return null;
	}

	public void RunContinue()
	{
	}

	[IteratorStateMachine(typeof(_003C_RunContinue_003Ed__24))]
	private IEnumerator<float> _RunContinue()
	{
		return null;
	}

	public void LoadSaveSlot(int slot)
	{
	}

	private void ConfirmLoadBattle()
	{
	}

	private void LoadBase()
	{
	}
}
