using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using FMOD.Studio;
using I2.Loc;
using MEC;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IntroCutsceneObj : CutsceneObj
{
	[CompilerGenerated]
	private sealed class _003C_FadeToRed_003Ed__72 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public IntroCutsceneObj _003C_003E4__this;

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
		public _003C_FadeToRed_003Ed__72(int _003C_003E1__state)
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
	private sealed class _003C_RunCamZoom_003Ed__61 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public float len;

		public AnimationCurve crv;

		public IntroCutsceneObj _003C_003E4__this;

		public Camera cam;

		public Transform startxfm;

		public Transform endXfm;

		private float _003CstartTime_003E5__2;

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
		public _003C_RunCamZoom_003Ed__61(int _003C_003E1__state)
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
	private sealed class _003C_RunIntro_003Ed__58 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public IntroCutsceneObj _003C_003E4__this;

		private float _003CstartTime_003E5__2;

		private Vector3 _003CstartCamPos_003E5__3;

		private Quaternion _003CstartCamRot_003E5__4;

		private float _003Clen_003E5__5;

		private Vector3 _003CstartLightRot_003E5__6;

		private Vector3 _003CstartMeteorPos_003E5__7;

		private Vector3 _003CtgtMeteorPos_003E5__8;

		private float _003CcamPanStartPct_003E5__9;

		private float _003CstartShadowStr_003E5__10;

		private Vector3 _003CslowMoTgtMeteorPos_003E5__11;

		private float _003CmeteorStartScale_003E5__12;

		private float _003CmeteorEndScale_003E5__13;

		private float _003CtextStartPct_003E5__14;

		private float _003CtextEndTime_003E5__15;

		private bool _003CenabledText_003E5__16;

		private bool _003CfadedOutText_003E5__17;

		private Vector3 _003CelevatorStart_003E5__18;

		private Vector3 _003CelevatorEnd_003E5__19;

		private bool _003Cexited_003E5__20;

		private bool _003CplayedOneshot_003E5__21;

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
		public _003C_RunIntro_003Ed__58(int _003C_003E1__state)
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

	public static IntroCutsceneObj I;

	public TextMeshProUGUI Txt;

	public Localize Loc;

	private Camera _mainCam;

	public CanvasGroup CvsGrp;

	public Image ImgBacking;

	public GameObject Meteor;

	public TrailRenderer MeteorTrail;

	public Light GlobalLight;

	[Header("Enviro")]
	public GameObject WrapperEnviro;

	public Material MatEnviro1;

	public Material MatEnviro2;

	public MeshRenderer RendEnviro1;

	public MeshRenderer RendEnviro2;

	public Camera CamRenderTex;

	public Canvas CvsRenderTex;

	public RawImage ImgRenderTex;

	[Header("BALLBYLON")]
	public GameObject WrapperBallbylon;

	public Transform XfmCamDefault;

	public Transform XfmCamDefaultZoomedOut;

	public Transform XfmCamIntroStart;

	public Transform XfmCamMeteorHitCentered;

	public Transform XfmCamMeteorHit;

	public Transform XfmCamTopDown;

	public Transform XfmCamTopDownFar;

	public MeshRenderer RendRainbowSkybox;

	public MeshRenderer[] RendBallbylonFog;

	public MeshRenderer[] BallbylonRends;

	public MeshRenderer[] BallbylonCityRends;

	[Header("PIT 1")]
	public Transform XfmCamPitTopDownFar;

	public Transform XfmCamPitTopDownNear;

	public GameObject[] WrapperPitSmoke;

	[Header("PIT 2")]
	public GameObject WrapperPitDescend;

	public Transform XfmCamElevatorStartFar;

	public Transform XfmCamElevatorStart;

	public Transform XfmCamElevatorEnd;

	public Transform XfmElevator;

	public BaseElevatorObj BaseElevator;

	public GameObject WrapperElevatorVicinity;

	public GameObject WrapperElevator;

	public BaseCharObj[] BaseChars;

	public Transform XfmCamPitDefaultFar;

	public Transform XfmCamPitDefaultNear;

	public MeshRenderer[] PitDefaultRends;

	[Header("curves")]
	public AnimationCurve CrvCamDefaultToCenter;

	public AnimationCurve CrvCamCenterToMeteor;

	public AnimationCurve CrvElevatorStart;

	public AnimationCurve CrvElevatorDescend;

	public float ScreenShakeSize;

	public float ScreenShakeLen;

	private CoroutineHandle _curAnim;

	private CoroutineHandle _updateAnim;

	private float _mouseHoldLength;

	private CoroutineHandle _curCamZoom;

	private EventInstance _loopingSFX;

	private Vector3 _camSteadyPos;

	private float _lastTouchTime;

	private const float kFadeInLen = 0.75f;

	private const float kFadeRedLen = 0.5f;

	private const float kFadeOutLen = 0.5f;

	private void Awake()
	{
	}

	public override void Play()
	{
	}

	[IteratorStateMachine(typeof(_003C_RunIntro_003Ed__58))]
	private IEnumerator<float> _RunIntro()
	{
		return null;
	}

	public void UpdateFog(Camera cam)
	{
	}

	private void RunCamZoom(Camera cam, Transform startxfm, Transform endXfm, float len, AnimationCurve crv)
	{
	}

	[IteratorStateMachine(typeof(_003C_RunCamZoom_003Ed__61))]
	private IEnumerator<float> _RunCamZoom(Camera cam, Transform startxfm, Transform endXfm, float len, AnimationCurve crv)
	{
		return null;
	}

	private void MyUpdate()
	{
	}

	public void Complete(bool isSkip)
	{
	}

	public void LerpXfm(Transform xfm, Transform startXfm, Transform endXfm, float pct)
	{
	}

	public void SetCamSteadyPos(Vector3 pos)
	{
	}

	public Vector3 GetCamSteadyPos()
	{
		return default(Vector3);
	}

	public void MatchXfm(Transform xfm, Transform toMatch)
	{
	}

	[IteratorStateMachine(typeof(_003C_FadeToRed_003Ed__72))]
	private IEnumerator<float> _FadeToRed()
	{
		return null;
	}

	public void SetEnviroRainbow(float amt)
	{
	}

	public void SetEnviroShadow(float amt)
	{
	}

	private void SetBallbylonFogAlpha(float alpha)
	{
	}
}
