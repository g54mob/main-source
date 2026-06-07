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

public class InGameUI : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_AnimateHPChange_003Ed__115 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public InGameUI _003C_003E4__this;

		private float _003CstartTime_003E5__2;

		private float _003Clen_003E5__3;

		private float _003CstartVal_003E5__4;

		private float _003CtgtVal_003E5__5;

		private Color _003CtgtAura_003E5__6;

		private Color _003CtgtOverhealthAura_003E5__7;

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
		public _003C_AnimateHPChange_003Ed__115(int _003C_003E1__state)
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
	private sealed class _003C_AnimateHUDEquipmentFuserMode_003Ed__152 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public InGameUI _003C_003E4__this;

		public bool isOn;

		private float _003CstartTime_003E5__2;

		private float _003Clen_003E5__3;

		private Vector2 _003CstartPos_003E5__4;

		private Vector2 _003CtgtPos_003E5__5;

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
		public _003C_AnimateHUDEquipmentFuserMode_003Ed__152(int _003C_003E1__state)
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
	private sealed class _003C_AnimateXPChange_003Ed__121 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public InGameUI _003C_003E4__this;

		private float _003CstartXP_003E5__2;

		private float _003CstartTime_003E5__3;

		private float _003Clen_003E5__4;

		private Color _003CtgtAura_003E5__5;

		private float _003ClvlUpTime_003E5__6;

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
		public _003C_AnimateXPChange_003Ed__121(int _003C_003E1__state)
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
	private sealed class _003C_RunAim_003Ed__97 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public InGameUI _003C_003E4__this;

		private bool _003CshouldClampPos_003E5__2;

		private bool _003CshouldSpinCursor_003E5__3;

		private float _003Crot_003E5__4;

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
		public _003C_RunAim_003Ed__97(int _003C_003E1__state)
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
	private sealed class _003C_RunAutofireAnim_003Ed__103 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public InGameUI _003C_003E4__this;

		private Vector3 _003Crot_003E5__2;

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
		public _003C_RunAutofireAnim_003Ed__103(int _003C_003E1__state)
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
	private sealed class _003C_RunBossBar_003Ed__135 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public InGameUI _003C_003E4__this;

		public GridPieceObj boss;

		private float _003CstartTime_003E5__2;

		private float _003CfadeLen_003E5__3;

		private Color _003ClvlProgressStartAuraColor_003E5__4;

		private Color _003ClvlProgressTgtAuraColor_003E5__5;

		private Color _003ClvlProgressStartBaseColor_003E5__6;

		private Color _003ClvlProgressTgtBaseColor_003E5__7;

		private int _003CnumIconsDeleted_003E5__8;

		private float _003CprevFillAmt_003E5__9;

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
		public _003C_RunBossBar_003Ed__135(int _003C_003E1__state)
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
	private sealed class _003C_RunBossBurst_003Ed__136 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public InGameUI _003C_003E4__this;

		private float _003Clen_003E5__2;

		private float _003CstartTime_003E5__3;

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
		public _003C_RunBossBurst_003Ed__136(int _003C_003E1__state)
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
	private sealed class _003C_RunClearBonus_003Ed__125 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public InGameUI _003C_003E4__this;

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
		public _003C_RunClearBonus_003Ed__125(int _003C_003E1__state)
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
	private sealed class _003C_RunDamaged_003Ed__140 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public PieceDmgType dmgType;

		public InGameUI _003C_003E4__this;

		private Color _003Cc_003E5__2;

		private float _003CfadeLen_003E5__3;

		private float _003CstartTime_003E5__4;

		private float _003CpulseStartTime_003E5__5;

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
		public _003C_RunDamaged_003Ed__140(int _003C_003E1__state)
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
	private sealed class _003C_RunDeathBonus_003Ed__127 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public InGameUI _003C_003E4__this;

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
		public _003C_RunDeathBonus_003Ed__127(int _003C_003E1__state)
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
	private sealed class _003C_RunLevelCompleteBonus_003Ed__129 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public InGameUI _003C_003E4__this;

		public bool isFirstComplete;

		public bool isFirsCharComplete;

		public bool isFirstComboComplete;

		public int amt;

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
		public _003C_RunLevelCompleteBonus_003Ed__129(int _003C_003E1__state)
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
	private sealed class _003C_RunLevelIntro_003Ed__108 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public InGameUI _003C_003E4__this;

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
		public _003C_RunLevelIntro_003Ed__108(int _003C_003E1__state)
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
	private sealed class _003C_RunLvlIconDisappear_003Ed__133 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public Image img;

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
		public _003C_RunLvlIconDisappear_003Ed__133(int _003C_003E1__state)
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
	private sealed class _003C_RunPollClosed_003Ed__159 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public InGameUI _003C_003E4__this;

		private float _003Clen_003E5__2;

		private float _003CstartTime_003E5__3;

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
		public _003C_RunPollClosed_003Ed__159(int _003C_003E1__state)
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
	private sealed class _003C_RunTwitchTimer_003Ed__156 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public InGameUI _003C_003E4__this;

		public float len;

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
		public _003C_RunTwitchTimer_003Ed__156(int _003C_003E1__state)
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

	public static InGameUI I;

	public Canvas CvsNoScale;

	public CanvasScaler CvsNoScaleScaler;

	public RectTransform WrapperNoScaleSafeArea;

	public RectTransform WrapperHUDEquipment;

	public CanvasGroup CvsGrpHUDEquipment;

	public CanvasScaler CvsScaler;

	public RectTransform WrapperSafeArea;

	public Image ImgAimCursor;

	public RectTransform XfmAimCursor;

	private CoroutineHandle _aimAnim;

	private Vector2 _cursorPos;

	public SerializedObjectPool<AmmoItem> AmmoPool;

	public CanvasGroup GrpLayerInfo;

	public LocalizationParamsManager ParamsLayerNum;

	public TextMeshProUGUI TxtLayerNum;

	public Localize LocLayerName;

	public TextMeshProUGUI TxtLayerName;

	private CoroutineHandle _layerNameAnim;

	public RectTransform WrapperLeft;

	public RectTransform WrapperRight;

	public CanvasGroup CvsGrpMain;

	public Canvas CvsHealth;

	public CanvasGroup GrpHealthValues;

	public TextMeshProUGUI TxtCurHealth;

	public TextMeshProUGUI TxtTotalHealth;

	public CoolButton BtnHealthHover;

	public Image HealthFill;

	public Image OverhealthFill;

	private CoroutineHandle _curHealthAnim;

	private Color _defaultHPColor;

	private Color _defaultHPAura;

	private Color _defaultOverhealAura;

	public RectTransform WrapperWidget;

	public RectTransform WrapperXP;

	public Image ImgWidgetOverlay;

	public Sprite DefaultWidgetOverlay;

	public Vector2 DefaultWidgetPos;

	public Vector2 DefaultWidgetSize;

	public Image XPFill;

	public TextMeshProUGUI TxtGold;

	private CoroutineHandle _curXPAnim;

	private Color _defaultXPColor;

	private Color _defaultXPAura;

	public RectTransform WrapperGameSpeed;

	public CanvasGroup GrpLvlProgressIcons;

	public Image LvlProgressFill;

	public Image[] ImgProgressBosses;

	public Sprite[] SprMiniboss;

	public Image OverlayBossInactive;

	public Image OverlayBossActive;

	public AnimationCurve CrvBossBurst;

	public AnimationCurve CrvBossBurstIntensity;

	public RectTransform WrapperBossBurst;

	public Image[] ImgBossBurst;

	public RectTransform XfmBossName;

	public CanvasGroup GrpBossName;

	public Localize LocBossName;

	public LocalizationParamsManager ParamsBossName;

	public Image BossBarFill;

	public CanvasGroup CvsGrpUpgrades;

	public SerializedObjectPool<HUDUpgradeItem> UpgradeItemPool;

	public HorizontalLayoutGroup GrpHeroes;

	public HorizontalLayoutGroup GrpPassives;

	public CanvasGroup GrpClearBonus;

	public Localize LocClearGoldLabel;

	public LocalizationParamsManager ParamsClearGold;

	private CoroutineHandle _curClearBonusAnim;

	public CoolButton BtnLevelUp;

	public RectTransform WrapperLevelUpInd;

	public LocalizationParamsManager ParamsLevelUpInd;

	public Image BackingLevelUpInd;

	public ImageAnimator LeveUpIndAnimator;

	public Image DamageOverlay;

	private CoroutineHandle _damageAnim;

	public Image TimeFreezeOverlay;

	private CoroutineHandle _timeFreezeAnim;

	public BtnPrompt PromptRecall;

	public RectTransform WrapperTwitch;

	public Localize LocTwitchDesc;

	public LocalizationParamsManager ParamsTwitchDesc;

	public Slider SldTwitchProgress;

	public GameObject WrapperTouchControls;

	public CoolButton BtnPause;

	public CoolButton BtnTouchShoot;

	public CoolButton BtnTouchAutofire;

	public Image ImgTouchAutofire;

	public CoolButton BtnTouchCheats;

	private int _numTimesPressedCheats;

	private float _lastTouchCheatTime;

	public bool IsRunningAimCursor;

	private CoroutineHandle _autofireAnim;

	private float _curDisplayedHealth;

	private float _displayedXP;

	private bool _isRunningXP;

	private bool _activatedBossBar;

	private EventInstance _healthbarSFX;

	private CoroutineHandle _curHUDEquipAnim;

	private CoroutineHandle _twitchAnim;

	private void Awake()
	{
	}

	public Vector2 GetTgtHUDPos()
	{
		return default(Vector2);
	}

	public float GetScaleFactor()
	{
		return 0f;
	}

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	public void OnInputChanged()
	{
	}

	[IteratorStateMachine(typeof(_003C_RunAim_003Ed__97))]
	private IEnumerator<float> _RunAim()
	{
		return null;
	}

	public float GetControllerCursorMoveSpeed()
	{
		return 0f;
	}

	public void MoveCursor(Vector2 amt)
	{
	}

	public void SetCursorPos(Vector2 pos)
	{
	}

	private void OnAutofireChanged()
	{
	}

	[IteratorStateMachine(typeof(_003C_RunAutofireAnim_003Ed__103))]
	private IEnumerator<float> _RunAutofireAnim()
	{
		return null;
	}

	public void OnGameStateChanged()
	{
	}

	public Vector2 GetCursorPos()
	{
		return default(Vector2);
	}

	public Vector3 GetCursorWorldPos()
	{
		return default(Vector3);
	}

	private void OnCurBallChanged()
	{
	}

	[IteratorStateMachine(typeof(_003C_RunLevelIntro_003Ed__108))]
	private IEnumerator<float> _RunLevelIntro()
	{
		return null;
	}

	private void OnBallStateChanged()
	{
	}

	public void Init(bool isLoading)
	{
	}

	private void OnSecondPassed()
	{
	}

	public void RefreshHealthBar(bool animate = false)
	{
	}

	public void SetDisplayedHealth(float h)
	{
	}

	[IteratorStateMachine(typeof(_003C_AnimateHPChange_003Ed__115))]
	private IEnumerator<float> _AnimateHPChange()
	{
		return null;
	}

	public void RefreshXP(bool animate)
	{
	}

	public void SetDisplayedXP(float xp)
	{
	}

	private void CheckDisplayedXPLevelUp()
	{
	}

	[IteratorStateMachine(typeof(_003C_AnimateXPChange_003Ed__121))]
	private IEnumerator<float> _AnimateXPChange()
	{
		return null;
	}

	public void RefreshResources()
	{
	}

	private void OnUpgradesChanged()
	{
	}

	public void RunClearBonus()
	{
	}

	[IteratorStateMachine(typeof(_003C_RunClearBonus_003Ed__125))]
	private IEnumerator<float> _RunClearBonus()
	{
		return null;
	}

	public void RunDeathBonus()
	{
	}

	[IteratorStateMachine(typeof(_003C_RunDeathBonus_003Ed__127))]
	private IEnumerator<float> _RunDeathBonus()
	{
		return null;
	}

	public void RunLevelCompleteBonus(bool isFirstComplete, bool isFirsCharComplete, bool isFirstComboComplete, int amt)
	{
	}

	[IteratorStateMachine(typeof(_003C_RunLevelCompleteBonus_003Ed__129))]
	private IEnumerator<float> _RunLevelCompleteBonus(bool isFirstComplete, bool isFirsCharComplete, bool isFirstComboComplete, int amt)
	{
		return null;
	}

	public void RefreshAvailLevelUps()
	{
	}

	public void ActivateBossBar(GridPieceObj boss)
	{
	}

	[IteratorStateMachine(typeof(_003C_RunLvlIconDisappear_003Ed__133))]
	private IEnumerator<float> _RunLvlIconDisappear(Image img)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_RunBossBar_003Ed__135))]
	private IEnumerator<float> _RunBossBar(GridPieceObj boss)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_RunBossBurst_003Ed__136))]
	private IEnumerator<float> _RunBossBurst()
	{
		return null;
	}

	private void SetBossBurstPct(float intensity, float pct)
	{
	}

	public void UpdateBossProgress()
	{
	}

	public void OnDamaged(float amt, PieceDmgType dmgType)
	{
	}

	[IteratorStateMachine(typeof(_003C_RunDamaged_003Ed__140))]
	private IEnumerator<float> _RunDamaged(float amt, PieceDmgType dmgType)
	{
		return null;
	}

	private void OnHealthHover()
	{
	}

	private void OnHealthHoverExit()
	{
	}

	private void OnPauseClicked()
	{
	}

	private void OnShootClicked()
	{
	}

	private void OnAutofireClicked()
	{
	}

	private void OnTouchCheatsClicked()
	{
	}

	private void OnLevelUpClicked()
	{
	}

	private AmmoItem CreateAmmoItem(HeroInst h, float theta)
	{
		return null;
	}

	public void RefreshAmmoDisplay()
	{
	}

	public void SetHUDEquipmentFuserMode(bool isOn)
	{
	}

	[IteratorStateMachine(typeof(_003C_AnimateHUDEquipmentFuserMode_003Ed__152))]
	private IEnumerator<float> _AnimateHUDEquipmentFuserMode(bool isOn)
	{
		return null;
	}

	public bool IsHUDEquipmentInFuserMode()
	{
		return false;
	}

	public void RunTwitchTimer(float len)
	{
	}

	[IteratorStateMachine(typeof(_003C_RunTwitchTimer_003Ed__156))]
	private IEnumerator<float> _RunTwitchTimer(float len)
	{
		return null;
	}

	public void CloseTwitchPoll(TwitchRandomEventType evType)
	{
	}

	public void CloseTwitchPoll(string msg)
	{
	}

	[IteratorStateMachine(typeof(_003C_RunPollClosed_003Ed__159))]
	private IEnumerator<float> _RunPollClosed()
	{
		return null;
	}
}
