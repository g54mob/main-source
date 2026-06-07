using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using VampireSurvivors.App.Framework.System;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Cheats;
using VampireSurvivors.Objects;
using VampireSurvivors.Signals;
using VampireSurvivors.Spells;
using Zenject;

namespace VampireSurvivors.UI
{
	public class MainMenuPage : BaseUIPage
	{
		[CompilerGenerated]
		private sealed class _003CSetAdventuresPortraitLayout_003Ed__77 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public MainMenuPage _003C_003E4__this;

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
			public _003CSetAdventuresPortraitLayout_003Ed__77(int _003C_003E1__state)
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
		private sealed class _003CWaitAndReShow_003Ed__69 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public MainMenuPage _003C_003E4__this;

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
			public _003CWaitAndReShow_003Ed__69(int _003C_003E1__state)
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

		[FormerlySerializedAs("FirstSelected")]
		[SerializeField]
		private Selectable _FirstSelected;

		[SerializeField]
		private GameObject _BestiaryButton;

		[SerializeField]
		private GameObject _SecretsButton;

		[SerializeField]
		private GameObject _PowerUpButton;

		[SerializeField]
		private GameObject _StartButton;

		[SerializeField]
		private GameObject _UnlocksButton;

		[SerializeField]
		private GameObject _CollectionButton;

		[SerializeField]
		private GameObject _CreditsButton;

		[SerializeField]
		private Button _QuickStartButton;

		[SerializeField]
		private GameObject _QuitButton;

		[SerializeField]
		private GameObject _DlcButton;

		[SerializeField]
		private GameObject _DLCStoreButton;

		[SerializeField]
		private GameObject LogoAnchor;

		[SerializeField]
		private GameObject _AdventureButton;

		[SerializeField]
		private GameObject _OnlineButton;

		[SerializeField]
		private Image _AdventureFader;

		[SerializeField]
		private Image _AdventureShadow;

		[SerializeField]
		private ParticleSystem _DustParticles;

		[SerializeField]
		private Transform _MiddleVampire;

		[SerializeField]
		private Transform _TitleLogo;

		[SerializeField]
		private PixelateEffect _pixelEffect;

		[SerializeField]
		private AscensionPanel _AscensionPanel;

		[SerializeField]
		private Transform _StartButtonDefaultAnchor;

		[SerializeField]
		private Transform _AdventureButtonDefaultAnchor;

		[SerializeField]
		private Transform _PowerUpButtonDefaultAnchor;

		[SerializeField]
		private Transform _CollectionButtonDefaultAnchor;

		[SerializeField]
		private Transform _BestiaryButtonDefaultAnchor;

		[SerializeField]
		private Transform _CreditsButtonDefaultAnchor;

		[SerializeField]
		private Transform _UnlocksButtonDefaultAnchor;

		[SerializeField]
		private Transform _SecretsButtonDefaultAnchor;

		[SerializeField]
		private Transform _DLCStoreButtonDefaultAnchor;

		[SerializeField]
		private Transform _QuickStartButtonDefaultAnchor;

		[SerializeField]
		private Transform _StartButtonAdventureAnchor;

		[SerializeField]
		private Transform _AdventureButtonAdventureAnchor;

		[SerializeField]
		private Transform _PowerUpButtonAdventureAnchor;

		[SerializeField]
		private Transform _CollectionButtonAdventureAnchor;

		[SerializeField]
		private Transform _BestiaryButtonAdventureAnchor;

		[SerializeField]
		private Transform _CreditsButtonAdventureAnchor;

		[SerializeField]
		private Transform _UnlocksButtonAdventureAnchor;

		[SerializeField]
		private Transform _SecretsButtonAdventureAnchor;

		[SerializeField]
		private Transform _DLCStoreButtonAdventureAnchor;

		[SerializeField]
		private Transform _QuickStartButtonAdventureAnchor;

		private DiContainer _diContainer;

		private SignalBus _signalBus;

		private PlayerOptions _playerOptions;

		private DataManager _dataManager;

		private MultiplayerManager _multiplayerManager;

		private AdventureManager _adventureManager;

		private UnityServicesManager _unityServicesManager;

		private SpellsManager _spellsManager;

		private Material _pixelizer;

		private GameObject _automationButton;

		private IntroSceneCheatManager _cheats;

		private bool _doShadowGag;

		public PlayerOptions PlayerOptions => null;

		[Inject]
		private void Construct(SignalBus signal, DiContainer container, PlayerOptions player, DataManager dataManager, MultiplayerManager multiplayerManager, AdventureManager adventureManager, UnityServicesManager unityServicesManager, SpellsManager spellsManager)
		{
		}

		protected override void Awake()
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

		private void ReselectStartButton()
		{
		}

		private void Test(bool t)
		{
		}

		private bool HasAdventuresUnlocked()
		{
			return false;
		}

		protected override void OnShowStart(GameObject g)
		{
		}

		private void SetMobileDlcStoreVisibility()
		{
		}

		private void OnAdventureAscended(bool result)
		{
		}

		private void HideAscensionPanel()
		{
		}

		private void ExitAdventureLayout()
		{
		}

		[IteratorStateMachine(typeof(_003CWaitAndReShow_003Ed__69))]
		private IEnumerator WaitAndReShow()
		{
			return null;
		}

		protected override void OnHideStart(GameObject g)
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		protected override void OnHideFinish(GameObject g)
		{
		}

		private void PlayAdventureUnlockAnimation()
		{
		}

		private void TweenButtonsDuringUnlockAnimation()
		{
		}

		private void SetAdventuresLayout()
		{
		}

		[IteratorStateMachine(typeof(_003CSetAdventuresPortraitLayout_003Ed__77))]
		private IEnumerator SetAdventuresPortraitLayout()
		{
			return null;
		}

		private void SetDefaultLayout()
		{
		}

		public void ShowAchievements()
		{
		}

		public void ShowCollections()
		{
		}

		public void ShowDLCStore()
		{
		}

		private void SetVisibility(UISignals.SetMainMenuPageVisibility sig)
		{
		}

		public void GetDlc()
		{
		}

		public void ShowOptions()
		{
		}

		public void ShowCredits()
		{
		}

		public void ShowPowerUps()
		{
		}

		public void ShowCharacterSelect()
		{
		}

		public void ShowOnline()
		{
		}

		private void ShowOnlineCheckAgeOKCallback(bool isAgeOk)
		{
		}

		private void ShowOnlineCheckEntitlementCallback(bool hasEntitlement)
		{
		}

		private void CloseOnlineCommunicatingPopup()
		{
		}

		private void OnOnlineNotAllowed()
		{
		}

		public void ShowBestiary()
		{
		}

		public void ShowSecrets()
		{
		}

		public void ShowAdventuresView()
		{
		}

		private void QuickStartGame()
		{
		}

		private List<CharacterType> GetValidQuickCharacters()
		{
			return null;
		}

		private List<StageType> GetValidQuickStages()
		{
			return null;
		}

		private void UpdateUnlocksButtonText()
		{
		}

		private void UpdateSecretsButtonVisibility()
		{
		}
	}
}
