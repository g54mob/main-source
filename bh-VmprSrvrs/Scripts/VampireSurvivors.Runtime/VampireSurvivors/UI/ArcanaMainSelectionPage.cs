using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DG.Tweening;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Items;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors.UI
{
	public class ArcanaMainSelectionPage : BaseUIPage, ISetArcanaInfo
	{
		public delegate void OnArcanaModeChange(ArcanaMode m);

		public enum ArcanaMode
		{
			LIGHT = 0,
			DARK = 1
		}

		public enum TentacleMode
		{
			TOP = 0,
			ENCIRCLING = 1
		}

		[CompilerGenerated]
		private sealed class _003CSpawnContent_003Ed__94 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ArcanaMainSelectionPage _003C_003E4__this;

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
			public _003CSpawnContent_003Ed__94(int _003C_003E1__state)
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
		private sealed class _003CWaitAndConfigureRandomButton_003Ed__117 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ArcanaMainSelectionPage _003C_003E4__this;

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
			public _003CWaitAndConfigureRandomButton_003Ed__117(int _003C_003E1__state)
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
		private sealed class _003CWaitAndForceSelect_003Ed__119 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public GameObject cardToSelect;

			public ArcanaMainSelectionPage _003C_003E4__this;

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
			public _003CWaitAndForceSelect_003Ed__119(int _003C_003E1__state)
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
		private sealed class _003CWaitAndSelect_003Ed__118 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ArcanaMainSelectionPage _003C_003E4__this;

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
			public _003CWaitAndSelect_003Ed__118(int _003C_003E1__state)
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
		private ArcanaInfoPanel _ArcanaInfoPanel;

		[SerializeField]
		private Localize _Count;

		[FormerlySerializedAs("_TitlePanel")]
		[SerializeField]
		private RectTransform _TitleGroup;

		[SerializeField]
		private RectTransform _CardContainer;

		[SerializeField]
		private RectTransform _MinorCardContainer;

		[SerializeField]
		private GameObject _ArcanaCardPrefab;

		[SerializeField]
		private GameObject _RandomButton;

		[SerializeField]
		private GameObject _GetButton;

		[SerializeField]
		private ParticleEmitterManager _TopParticles;

		[SerializeField]
		private ParticleEmitterManager _BottomParticles;

		[SerializeField]
		private RectTransform _CardOrigin;

		[SerializeField]
		private RectTransform _SelectedCardOrigin;

		[SerializeField]
		private Image _BlackFader;

		[SerializeField]
		private Image _CollectRandomButton;

		[SerializeField]
		private GameObject _MajorSelectionGroup;

		[SerializeField]
		private GameObject _MinorSelectionGroup;

		[SerializeField]
		private GameObject _BigArcanaCard;

		[SerializeField]
		private RectTransform _StripContainer;

		[SerializeField]
		private RectTransform _MinorGetButton;

		[SerializeField]
		private RectTransform _SkipButton;

		[SerializeField]
		private RectTransform _RerollButton;

		[SerializeField]
		private TextMeshProUGUI _RerollCountText;

		[SerializeField]
		private TextMeshProUGUI _SkipCountText;

		[SerializeField]
		private PauseEquipmentPanel _EquipmentPanel;

		[SerializeField]
		private GameObject _CharacterStatsPanel;

		[SerializeField]
		private bool _DEBUGPAGE2;

		[SerializeField]
		private RectTransform _RerollAnimContainer;

		[FormerlySerializedAs("_InfoPanel")]
		[SerializeField]
		private RectTransform _InfoGroup;

		[FormerlySerializedAs("_MinorPanel")]
		[SerializeField]
		private RectTransform _MinorBackground;

		[FormerlySerializedAs("_MajorPanel")]
		[SerializeField]
		private RectTransform _MajorBackground;

		[FormerlySerializedAs("_HeaderPanel")]
		[SerializeField]
		private RectTransform _TitleBackground;

		[SerializeField]
		private RectTransform _CharacterPanelBackground;

		[SerializeField]
		private GameObject _CharacterPanel;

		[SerializeField]
		private Image _CharacterImage;

		[SerializeField]
		private List<SpinningRingOfCards> _CardRings;

		[SerializeField]
		private int _MaxWeaponsBeforeCarousel;

		[SerializeField]
		private ArcanaDisplayContainer _DisplayContainer;

		[Header("Darkana")]
		[SerializeField]
		private GameObject _TentaclePrefab;

		[SerializeField]
		private RectTransform _TentacleSpawnRotator;

		[SerializeField]
		private RectTransform _TentacleSpawnAnchor;

		[SerializeField]
		private TextMeshProUGUI _TitleText;

		[SerializeField]
		private GameObject _TitleBloodMask;

		[SerializeField]
		private GameObject _PanelBloodMask;

		[SerializeField]
		private GameObject _InfoBloodMask;

		[SerializeField]
		private GameObject _MinorBloodMask;

		[SerializeField]
		private GameObject _CharacterPanelBloodMask;

		[SerializeField]
		private RectTransform _D20;

		[SerializeField]
		private ParticleEmitterManager _TopDarkanaParticles;

		[SerializeField]
		private ParticleEmitterManager _BottomDarkanaParticles;

		[SerializeField]
		private RectTransform _Skull;

		[SerializeField]
		private GameObject _DarkButton;

		[SerializeField]
		private Image _DarkButtonIcon;

		[SerializeField]
		private Image _TitleIcon;

		private List<GameObject> _darkSpawned;

		private List<GameObject> _spawned;

		private List<GameObject> _weaponSpawned;

		private List<ArcanaCardUI> _unlockedCards;

		private List<ArcanaCardUI> _darkUnlockedCards;

		private List<GameObject> _tentacles;

		private List<GameObject> _allSpawnedInOrder;

		private DataManager _data;

		private PlayerOptions _playerOptions;

		private SignalBus _signalBus;

		private ArcanaManager _arcanaManager;

		private Dictionary<WeaponType, List<WeaponData>> _weapons;

		private Dictionary<ItemType, ItemData> _items;

		private ArcanaType _currentSelected;

		private string _arcanaCacheGroupName;

		private Material _defaultGameRenderMaterial;

		private bool _hasUnlockedDarkanas;

		private int _draftCardCount;

		private Tween _d20Tween;

		private Selectable previouslyHighlightedDraftCard;

		private List<ArcanaType> _draftMajors;

		private List<ArcanaType> _discarded;

		private int _lastSelected;

		private ArcanaCardUI _selected;

		private bool _hasPickedRandom;

		private bool _hasFreeReroll;

		private VampireSurvivors.Objects.Characters.CharacterController _controllingCharacter;

		private bool isShowingMinor;

		private bool _hasFinishedPopulationAnimation;

		private bool _ShowDarkanaFirst;

		private bool _willPlayDarkanaIntro;

		private ArcanaMode _arcanaMode;

		public TentacleMode _tentacleMode;

		public static event OnArcanaModeChange ArcanaModeChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		[Inject]
		private void Construct(DataManager data, PlayerOptions player, ArcanaManager arcana, SignalBus signalBus)
		{
		}

		protected override void Awake()
		{
		}

		[IteratorStateMachine(typeof(_003CSpawnContent_003Ed__94))]
		public IEnumerator SpawnContent()
		{
			return null;
		}

		private void OnDestroy()
		{
		}

		protected override void OnShowStart(GameObject g)
		{
		}

		private void GetControllingCharacter()
		{
		}

		protected override void OnShowFinish(GameObject g)
		{
		}

		private void InitializeRingsOfCards()
		{
		}

		protected override void Update()
		{
		}

		private void SetMinorGetNavigation()
		{
		}

		private void PopulateSecondMenu()
		{
		}

		private void EnableInputSecondMenu()
		{
		}

		protected override VampireSurvivors.Objects.Characters.CharacterController GetCharacterControllingUi()
		{
			return null;
		}

		private void UpdateButtonNavigation()
		{
		}

		public void Skip()
		{
		}

		private void PerformSkip()
		{
		}

		private void SetReRollButton()
		{
		}

		private void PerformReRoll()
		{
		}

		public void Reroll()
		{
		}

		private void SetBigCardNavigation()
		{
		}

		protected override void OnHideFinish(GameObject g)
		{
		}

		private GameObject SpawnBigCard(ArcanaData data, ArcanaType type, bool isDum = false)
		{
			return null;
		}

		private void PopulateFirstMenu()
		{
		}

		private void EnableInputFirstMenu()
		{
		}

		private void SetRandomButton()
		{
		}

		[IteratorStateMachine(typeof(_003CWaitAndConfigureRandomButton_003Ed__117))]
		private IEnumerator WaitAndConfigureRandomButton()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CWaitAndSelect_003Ed__118))]
		private IEnumerator WaitAndSelect(GameObject forcedSelect = null)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CWaitAndForceSelect_003Ed__119))]
		private IEnumerator WaitAndForceSelect(GameObject cardToSelect)
		{
			return null;
		}

		private void InitializeNormalArcanaParticles()
		{
		}

		private void InitializeDarkanaParticles()
		{
		}

		private void InitializeTicklers()
		{
		}

		private ArcanaCardUI SpawnArcanaCard(ArcanaData data, ArcanaType type)
		{
			return null;
		}

		private void AddStrips()
		{
		}

		private void ClearSpawned()
		{
		}

		private void SelectArcana()
		{
		}

		private void OnSelectedArcanaRemotely(OnlineSignals.OnlineSelectedArcana arcana)
		{
		}

		private void OnReRolledArcanasRemotely()
		{
		}

		private void OnTransitionArcanaModeRemotely()
		{
		}

		public void GoToDarkana()
		{
		}

		private void SwitchArcanaMode()
		{
		}

		private void PlayJingle()
		{
		}

		private void PlayDarkSound()
		{
		}

		private void PlayLightSound()
		{
		}

		private void SetDarkDesign()
		{
		}

		public void SetLightDesign()
		{
		}

		private void SetCount()
		{
		}

		private void RandomD20Fall()
		{
		}

		public void SetInfo(ArcanaData data, ArcanaType type, ArcanaCardUI UI)
		{
		}

		public void Select()
		{
		}

		public void Random()
		{
		}
	}
}
