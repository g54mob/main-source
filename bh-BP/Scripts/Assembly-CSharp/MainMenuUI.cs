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

public class MainMenuUI : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_FadeCanvasGroup_003Ed__72 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public float delay;

		public MainMenuUI _003C_003E4__this;

		public float tgtAlpha;

		private float _003CstartTime_003E5__2;

		private float _003CstartAlpha_003E5__3;

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
		public _003C_FadeCanvasGroup_003Ed__72(int _003C_003E1__state)
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
	private sealed class _003C_RunCredits_003Ed__65 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public MainMenuUI _003C_003E4__this;

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
		public _003C_RunCredits_003Ed__65(int _003C_003E1__state)
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
	private sealed class _003C_RunSplash_003Ed__60 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public float entryFadeLen;

		public float holdLen;

		public float exitFadeLen;

		public float waitLen;

		public CanvasGroup grp;

		public MainMenuUI _003C_003E4__this;

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
		public _003C_RunSplash_003Ed__60(int _003C_003E1__state)
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
	private sealed class _003C_RunSplashScreen_003Ed__58 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public MainMenuUI _003C_003E4__this;

		private float _003CbtnStartTime_003E5__2;

		private RectTransform _003CvertGrpXfm_003E5__3;

		private RectOffset _003Cpadding_003E5__4;

		private int _003CstartPadding_003E5__5;

		private int _003CtgtPadding_003E5__6;

		private float _003CstartTime_003E5__7;

		private float _003Clen_003E5__8;

		private Vector2 _003CballStartPos_003E5__9;

		private Vector2 _003CpitStartPos_003E5__10;

		private Vector2 _003CballTgtPos_003E5__11;

		private Vector2 _003CpitTgtPos_003E5__12;

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
		public _003C_RunSplashScreen_003Ed__58(int _003C_003E1__state)
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

	public static MainMenuUI I;

	public VerticalLayoutGroup VertGrpButtons;

	public RectTransform XfmBtns;

	public CanvasGroup GrpBtns;

	public CoolSelectableWrapper WrapperBtns;

	[NamedArray(typeof(MainMenuOption))]
	public MainMenuBtn[] Btns;

	public Material MatBtnCentered;

	public Material MatBtnLeft;

	public MeshRenderer PrecompileCube;

	public CoolButton BtnPrecompileSkip;

	public bool IsRunningSplashScreen;

	private CoroutineHandle _splashScreenRoutine;

	public Image ImgSplashBacking;

	public Canvas CvsSplashScreen;

	public CanvasGroup CvsGrpDevolver;

	public CanvasGroup CvsGrpMyLogo;

	public TextMeshProUGUI TxtMyLogo;

	public CanvasGroup CvsGrpEpilepsy;

	public CanvasGroup CvsGrpShaders;

	public CanvasGroup CvsGrpMobileFreeTrial;

	public CoolButton BtnFreeTrialContinue;

	public CoolButton BtnFreeTrialBuy;

	public Localize LocFreeTrialBuy;

	private bool _continueTrial;

	public Slider SliderShaderProgress;

	public BaseCharObj[] BallbylonGuards;

	public BaseCharObj[] BallbylonChars;

	public GameObject WrapperTitle;

	public Image LogoBackground;

	public Image LogoBall;

	public Image LogoX;

	public Image LogoPit;

	public XboxGamertagDisplay GamertagDisplay;

	public DiscordIconDisplay DiscordDisp;

	private bool _skipSplash;

	private bool _hasAnySaveData;

	private EventInstance _splashStinger;

	public CoolButton BtnMobileSkip;

	public Image ImgMobileSkipFill;

	public GameObject WrapperCloudState;

	public Localize LocCloudSaveState;

	public CanvasGroup CvsGrpCloudSaveState;

	public CoolButton BtnCloudSaveState;

	private string _cheatCodeOrder;

	private const int kShaderVersion = 1;

	private CoroutineHandle _curFade;

	private void Awake()
	{
	}

	public void EnableLanguageChoice(bool isOn)
	{
	}

	public void SetBtnsEnabled(bool enabled)
	{
	}

	public void SetBtnViz(CoolButtonViz viz)
	{
	}

	public void SetBtnAlign(TextAlignmentOptions align)
	{
	}

	public void SetBtnMat(Material m)
	{
	}

	public void SetSecondaryBtnAlpha(float alpha)
	{
	}

	private void Start()
	{
	}

	public void RefreshSaveDataState()
	{
	}

	public void MarkSavesAllDeleted()
	{
	}

	private void UpdatePrecompileProgress(ref int idx, int total)
	{
	}

	public void SetBallbylonCharColor(Color c)
	{
	}

	public void RunBallbylonChars()
	{
	}

	[IteratorStateMachine(typeof(_003C_RunSplashScreen_003Ed__58))]
	private IEnumerator<float> _RunSplashScreen()
	{
		return null;
	}

	private void OnPurchaseFailed(int errorCode)
	{
	}

	[IteratorStateMachine(typeof(_003C_RunSplash_003Ed__60))]
	private IEnumerator<float> _RunSplash(CanvasGroup grp, float entryFadeLen, float holdLen, float exitFadeLen, float waitLen)
	{
		return null;
	}

	private void MyUpdate()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnInputChanged()
	{
	}

	public void SelectBtn(MainMenuOption option)
	{
	}

	[IteratorStateMachine(typeof(_003C_RunCredits_003Ed__65))]
	private IEnumerator<float> _RunCredits()
	{
		return null;
	}

	private void OnPrecompileSkipClicked()
	{
	}

	private void SkipPrecompile()
	{
	}

	private void OnFreeTrialContinueClicked()
	{
	}

	private void OnFreeTrialBuyClicked()
	{
	}

	public void FadeCanvasGroup(float delay, float tgtAlpha)
	{
	}

	[IteratorStateMachine(typeof(_003C_FadeCanvasGroup_003Ed__72))]
	private IEnumerator<float> _FadeCanvasGroup(float delay, float tgtAlpha)
	{
		return null;
	}
}
