using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.App.UI.Twitch;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Signals;
using VampireSurvivors.UI;
using Zenject;

namespace VampireSurvivors
{
	public class MainGamePage : BaseUIPage
	{
		[CompilerGenerated]
		private sealed class _003CWaitForConfig_003Ed__43 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public MainGamePage _003C_003E4__this;

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
			public _003CWaitForConfig_003Ed__43(int _003C_003E1__state)
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

		[SerializeField]
		private Image _ExperienceProgress;

		[SerializeField]
		private TextMeshProUGUI _EnemiesText;

		[SerializeField]
		private Image _KillsIcon;

		[SerializeField]
		private TextMeshProUGUI _CoinsText;

		[SerializeField]
		private TextMeshProUGUI _TimeText;

		[SerializeField]
		private TextMeshProUGUI _LevelText;

		[SerializeField]
		private GoldFeverUIManager _GoldFever;

		[SerializeField]
		private GameObject _CheatsPanel;

		[SerializeField]
		private GameObject _OnlineCheatsPanel;

		[SerializeField]
		private GameObject _XPBar;

		[SerializeField]
		private RectTransform _EquipmentPanelContainer;

		[SerializeField]
		private GameObject _PlayerEquipmentPanelPrefab;

		[SerializeField]
		private Button _PauseButton;

		[SerializeField]
		private Button _FastForwardButton;

		[SerializeField]
		private TwitchStageEventsPanel _TwitchStageEventsPanel;

		[SerializeField]
		private GameObject _SceneTransitionFader;

		[SerializeField]
		private GlimmerTechniqueCarousel _GlimmerTechniqueCarousel;

		[SerializeField]
		private GameObject _SpectateModeContainer;

		[SerializeField]
		private Image _SpectateModeIcon;

		[SerializeField]
		private TextMeshProUGUI _SpectateModePlayerName;

		[SerializeField]
		private TextMeshProUGUI _SpectateModeSwitchPlayerText;

		private SignalBus _signalBus;

		private GameSessionData _session;

		private readonly LocalizedString _levelString;

		private PlayerOptions _playerOptions;

		private StringBuilder _timeFormatStringBuilder;

		private Dictionary<VampireSurvivors.Objects.Characters.CharacterController, GameObject> _uiPanels;

		public TextMeshProUGUI SurvivedSecondsText => null;

		public Image KillsIcon => null;

		public TextMeshProUGUI KillsText => null;

		public GoldFeverUIManager GoldFever => null;

		public TwitchStageEventsPanel TwitchStageEventsPanel => null;

		protected override bool IsOnlineUi => false;

		[Inject]
		private void Construct(SignalBus signalBus, GameSessionData session, PlayerOptions playerOptions)
		{
		}

		protected override void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnEnable()
		{
		}

		[IteratorStateMachine(typeof(_003CWaitForConfig_003Ed__43))]
		private IEnumerator WaitForConfig()
		{
			return null;
		}

		private void OnDisable()
		{
		}

		public bool ArePanelsInitialized()
		{
			return false;
		}

		public void ReinitializeEquipment()
		{
		}

		public void UpdateKills()
		{
		}

		public void PerformSceneTransition(Action onCompleteCallback, float durationMillis = 3000f)
		{
		}

		public void ForceEquipmentLayoutRebuild()
		{
		}

		protected override void OnShowStart(GameObject g)
		{
		}

		private void UpdateExperienceProgress(GameplaySignals.CharacterXpChangedSignal sig)
		{
		}

		public void LevelUp()
		{
		}

		private void ToggleXPBar(UISignals.ToggleXPBarSignal sig)
		{
		}

		private void ToggleWeaponSlots(UISignals.ToggleWeaponSlotsSignal sig)
		{
		}

		private void FireNewGlimmerTechnique(UISignals.FireNewGlimmerTechnique sig)
		{
		}

		private void AssignLevel()
		{
		}

		protected override void Update()
		{
		}

		private void ChangeSpectateTargetUi()
		{
		}

		private void CheckSpectateMode()
		{
		}

		private bool IsSpectateModeActive()
		{
			return false;
		}

		private void UpdateCoins()
		{
		}

		private void ActivateGoldFever()
		{
		}

		private void DeactivateGoldFever()
		{
		}

		private void InitializeEquipment()
		{
		}
	}
}
