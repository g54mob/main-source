using DG.Tweening;
using Libs;
using PostProcess;
using ScriptableObjects.ScriptableObjectScripts.Settings;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
	public class GameTimerCtrl : SingletonMonoBehaviour<GameTimerCtrl>
	{
		public TMP_Text stateText;

		public TMP_Text timerText;

		public CanvasGroup canvasGroup;

		public CanvasGroup watchCanvasGroup;

		public Image counterImage;

		public Sprite waitingCounterImage;

		public Sprite waveCounterImage;

		public Sprite longThinkTimeImage;

		public TMP_Text nextText;

		public GameObject remainLongThinkTimeBG;

		public TMP_Text remainLongThinkTimeCountDownText;

		public BothSideBar countBar;

		public BothSideBar overtimeBar;

		public LonkThinkCtrl thinkCtrl;

		[SerializeField]
		private UILookEmphasis lookEmphasis;

		[SerializeField]
		private TMP_Text plusTimeText;

		[SerializeField]
		public GameObject watchObj;

		[SerializeField]
		private SkeletonGraphicController waveStartCutin;

		[SerializeField]
		private SkeletonGraphicController bossCutin;

		[SerializeField]
		private SkeletonGraphicController lastBossCutin;

		[SerializeField]
		private SkeletonGraphicController breakTimerSpine;

		[SerializeField]
		private GameObject pauseObj;

		[SerializeField]
		private TMP_Text pauseText;

		[SerializeField]
		private Color defaultTimerColor;

		[SerializeField]
		private Color overtimeTimerColor;

		private bool _isCancel;

		private double _gearCache;

		private PostProcessSetting _postInfo;

		private WaveInfoData _waveInfo;

		private bool _isOvertime;

		public static readonly string WatchBreakAll;

		public static readonly string LastBattleCutin;

		private bool _cancelOk;

		public GameObject tutorialTimerGroup;

		public TMP_Text tutorialTimerText;

		public UnityAction OnReturnAction;

		private double _tutorialTimerCount;

		public static bool ActiveTime { get; set; }

		public static bool PauseTimer { get; set; }

		private bool TextCountOk => false;

		private bool LongThinkingOk => false;

		public double TutorialTimerCount
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		private void Awake()
		{
		}

		public static string GetTimerFormat(double time)
		{
			return null;
		}

		public void Init()
		{
		}

		private bool IsUnlimitedTimeMode()
		{
			return false;
		}

		public void UpdateTimerUI()
		{
		}

		public void ActiveOverTimeUI(bool enable)
		{
		}

		public void DisplayFreeControlPausePanel(bool on)
		{
		}

		public void UpdateWaveTimer(int waveCount, double newValue, bool isStandby)
		{
		}

		private bool TrialLongthinkCondition()
		{
			return false;
		}

		public void OnSwitchLongTimeThinking()
		{
		}

		public void OnLongTimeThinking()
		{
		}

		private void NaturalRelease()
		{
		}

		private void FinishLongthink()
		{
		}

		public void PlusTime(double plusTime)
		{
		}

		public void OnCancelThinking()
		{
		}

		public void UpdateLongThinkUI()
		{
		}

		public void PlayTimerEmphasis()
		{
		}

		public void StopTimerEmphasis()
		{
		}

		public void PlayLongThinkEmphasis()
		{
		}

		public void StopLongThinkEmphasis()
		{
		}

		public void ToggleGroupInteractive(bool value)
		{
		}

		public Sequence PlayWaveStartCutin()
		{
			return null;
		}

		public Sequence PlayBossWaveCutin()
		{
			return null;
		}

		public Sequence PlayBreakWatch()
		{
			return null;
		}

		public Sequence PlayLastBossWaveCutin()
		{
			return null;
		}

		private void OnDisable()
		{
		}

		public void TutorialTimerInit()
		{
		}

		public void UpdateTutorialTimer()
		{
		}

		public void finishTutorialTimer()
		{
		}

		public void OnRetryTutorial()
		{
		}
	}
}
