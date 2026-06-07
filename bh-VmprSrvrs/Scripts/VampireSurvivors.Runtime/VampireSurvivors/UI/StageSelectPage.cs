using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.App.Scripts.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework.Cheats;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors.UI
{
	public class StageSelectPage : BaseUIPage
	{
		public enum SelectionPhase
		{
			PHASE1 = 0,
			PHASE2 = 1
		}

		[CompilerGenerated]
		private sealed class _003CWaitAndSelect_003Ed__62 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public StageSelectPage _003C_003E4__this;

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
			public _003CWaitAndSelect_003Ed__62(int _003C_003E1__state)
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
		private sealed class _003CWaitRoutine_003Ed__89 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Action cb;

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
			public _003CWaitRoutine_003Ed__89(int _003C_003E1__state)
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
		private GameObject stagePrefab;

		[SerializeField]
		private RectTransform container;

		[SerializeField]
		private Image _BackgroundPanel;

		[SerializeField]
		private Localize nameText;

		[SerializeField]
		private Localize tips;

		[SerializeField]
		private Localize hyperTips;

		[SerializeField]
		private TextMeshProUGUI _PageTitle;

		[SerializeField]
		private TickBoxUI _HyperModeTickBox;

		[SerializeField]
		private TickBoxUI _HurryModeTickBox;

		[SerializeField]
		private TickBoxUI _MazzoModeTickBox;

		[SerializeField]
		private TickBoxUI _LimitBreakTickBox;

		[SerializeField]
		private TickBoxUI _InverseModeTickBox;

		[SerializeField]
		private TickBoxUI _EndlessModeTickBox;

		[SerializeField]
		private TickBoxUI _LockSelectedTickBox;

		[SerializeField]
		private Button _ConfirmButton;

		[SerializeField]
		private Button _SelectButton;

		[SerializeField]
		private StageStatsPanel _Stats;

		[SerializeField]
		private SongSelectionPanel _SongPanel;

		[SerializeField]
		private Button _SelectableSongButton;

		[SerializeField]
		private Button _SelectableSpeedButton;

		[SerializeField]
		private Button _AdvancedSettingsButton;

		[SerializeField]
		private RelicPanel _RelicPanel;

		[SerializeField]
		private RectTransform _InfoPanel;

		[SerializeField]
		private RectTransform _SliderRect;

		[SerializeField]
		private StageRandomPanel _StageRandomPanel;

		[SerializeField]
		private GameObject _SharePassivesPanel;

		[SerializeField]
		private TickBoxUI _SharePassivesBox;

		[SerializeField]
		private GameObject _DescriptionPanelTextPage;

		public SelectionPhase _selectionPhase;

		private SignalBus _signalBus;

		private List<GameObject> _spawned;

		private StageItemUI _selectedStage;

		private StageItemUI _highlightedStage;

		private StageData _selectedData;

		private DataManager _data;

		private PlayerOptions _playerOptions;

		private DiContainer _diContainer;

		private StageSelectionCheatCodeManager _cheats;

		private AdventureManager _adventureManager;

		private AdvancedMusicSelection _advancedMusicPanel;

		private bool _hurryModeAvailable;

		private bool _hyperModeAvailable;

		private bool _mazzoModeAvailable;

		private bool _limitBreakAvailable;

		private bool _inverseModeAvailable;

		private bool _endlessModeAvailable;

		private bool _hasConfirmed;

		private bool _phase1Disabled;

		private bool _phase2Disabled;

		private List<Selectable> _availableOptions;

		private bool _hasBanger;

		private bool _hasRandomOptions;

		private bool _hasRandomEvents;

		private bool _hasRandomLevelUps;

		private bool _hasToggles;

		[Inject]
		private void Construct(SignalBus signal, DataManager data, PlayerOptions player, DiContainer diContainer, AdventureManager adventureManager)
		{
		}

		private void Start()
		{
		}

		protected override void Update()
		{
		}

		private void OnDestroy()
		{
		}

		private void BackPressed()
		{
		}

		protected override void OnShowStart(GameObject g)
		{
		}

		[IteratorStateMachine(typeof(_003CWaitAndSelect_003Ed__62))]
		private IEnumerator WaitAndSelect()
		{
			return null;
		}

		private void AutoSizeStageDescriptions()
		{
		}

		protected override void OnEnterPressed()
		{
		}

		private void OnDisable()
		{
		}

		protected override void OnHideStart(GameObject g)
		{
		}

		protected override void OnHideFinish(GameObject g)
		{
		}

		public void OpenAdvancedMusicSelectionPanel()
		{
		}

		private void ReEnable()
		{
		}

		private void RefreshSongPanel()
		{
		}

		public void ConfirmStage()
		{
		}

		public void SelectStage()
		{
		}

		public void HighlightStage(StageItemUI item)
		{
		}

		public void SetInfoPanel(StageItemUI stageItemUI, StageData stage, StageType stageType)
		{
		}

		public void SetHyper(bool b)
		{
		}

		public void SetHurry(bool b)
		{
		}

		public void SetArcanas(bool b)
		{
		}

		public void SetLimitBreak(bool b)
		{
		}

		public void SetInverse(bool b)
		{
		}

		public void SetEndless(bool b)
		{
		}

		public void ToggleHyper()
		{
		}

		public void SetSharePassives(bool b)
		{
		}

		private static Dictionary<StageType, List<StageData>> Stage6Checks(Dictionary<StageType, List<StageData>> STAGE_DATA, PlayerOptions playerOptions)
		{
			return null;
		}

		private void Populate()
		{
		}

		public static Dictionary<StageType, List<StageData>> GetAvailableStages(DataManager data, PlayerOptions playerOptions)
		{
			return null;
		}

		private void GenerateNavigation()
		{
		}

		private GameObject CreateStageItem(StageData stage, StageType type, int index)
		{
			return null;
		}

		private void WaitAndDo(Action cb)
		{
		}

		[IteratorStateMachine(typeof(_003CWaitRoutine_003Ed__89))]
		private static IEnumerator WaitRoutine(Action cb)
		{
			return null;
		}

		private void EnableInfoPanelNavigation()
		{
		}

		private void SetNavigationPhase1()
		{
		}

		private void SetNavigationPhase2()
		{
		}

		private void DisableFirstPhaseGroup()
		{
		}

		private void EnableFirstPhaseGroup()
		{
		}

		private void DisableSecondPhaseGroup()
		{
		}

		private void EnableSecondPhaseGroup()
		{
		}

		public void SwitchInput(UIHelper.ActiveInputType input)
		{
		}
	}
}
