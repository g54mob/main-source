using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.UI;
using Zenject;

namespace VampireSurvivors
{
	public class PausePage : BaseUIPage
	{
		private enum PausePageState
		{
			NONE = 0,
			MAP = 1,
			GRIMOIRE = 2,
			OPTIONS = 3
		}

		[CompilerGenerated]
		private sealed class _003CForceLeftLayoutDelayed_003Ed__42 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PausePage _003C_003E4__this;

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
			public _003CForceLeftLayoutDelayed_003Ed__42(int _003C_003E1__state)
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
		private GameObject _Equipment;

		[SerializeField]
		private GameObject _MobileEquipment;

		[SerializeField]
		private GameObject _CharacterStatsPanel;

		[SerializeField]
		private GameObject _Options;

		[SerializeField]
		private List<PauseEquipmentPanel> _EquipmentPanels;

		[SerializeField]
		private GrimoireManager _Grimoire;

		[SerializeField]
		private GameObject _QuitDescriptionText;

		[SerializeField]
		private GameObject _Fader;

		[SerializeField]
		private VerticalLayoutGroup _LeftStatsLayoutGroup;

		[FormerlySerializedAs("_DisplayContainer")]
		[SerializeField]
		private ArcanaDisplayContainer _arcanasDisplayContainer;

		[FormerlySerializedAs("_survarrochiDisplayContainer")]
		[SerializeField]
		private SurvarotsDisplayContainer _survarotsDisplayContainer;

		[Header("Arcanas")]
		[SerializeField]
		private GameObject _Arcanas;

		[Header("Buttons")]
		[SerializeField]
		private RectTransform _ResumeButton;

		[SerializeField]
		private RectTransform _OptionsButton;

		[SerializeField]
		private RectTransform _QuitButton;

		[SerializeField]
		private RectTransform _GuidesButton;

		[SerializeField]
		private RectTransform _PickupsButton;

		[SerializeField]
		private RectTransform _OpenMapButton;

		[SerializeField]
		private RectTransform _OpenGrimoireButton;

		[SerializeField]
		private RectTransform _ZoomInMapButton;

		[SerializeField]
		private RectTransform _ZoomOutMapButton;

		[SerializeField]
		private GameObject _Map;

		[SerializeField]
		private MapManager _MapManager;

		private SignalBus _signalBus;

		private PlayerOptions _playerOptions;

		private GameManager _gameManager;

		private DataManager _dataManager;

		private LobbiesManager _lobbiesManager;

		private bool _hasGrimoire;

		private bool _hasMap;

		private bool _hasInitializedOptions;

		private bool _arcanasActive;

		private bool hadToDelayInitialization;

		[SerializeField]
		private PausePageState _State;

		protected override bool IsOnlineUi => false;

		[Inject]
		private void Construct(SignalBus signalBus, PlayerOptions playerOptions, GameManager gameManager, DataManager dataManager, LobbiesManager lobbiesManager)
		{
		}

		protected override void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void InitializePage()
		{
		}

		protected override void OnShowStart(GameObject g)
		{
		}

		[IteratorStateMachine(typeof(_003CForceLeftLayoutDelayed_003Ed__42))]
		private IEnumerator ForceLeftLayoutDelayed()
		{
			return null;
		}

		protected override void OnHideStart(GameObject g)
		{
		}

		protected override void OnHideFinish(GameObject g)
		{
		}

		public void ReturnToGame()
		{
		}

		public void Quit()
		{
		}

		public void OpenOptions()
		{
		}

		public void OpenEmpty()
		{
		}

		public void OpenMap()
		{
		}

		public void ToggleGuides()
		{
		}

		public void TogglePickups()
		{
		}

		public void OpenGrimoire()
		{
		}

		public void FormatButtons()
		{
		}

		protected override VampireSurvivors.Objects.Characters.CharacterController GetCharacterControllingUi()
		{
			return null;
		}

		private void InitToggles()
		{
		}

		private void UpdatePickupsToggleText()
		{
		}

		private void UpdateGuidesToggleText()
		{
		}

		private void HideAllPanels()
		{
		}
	}
}
