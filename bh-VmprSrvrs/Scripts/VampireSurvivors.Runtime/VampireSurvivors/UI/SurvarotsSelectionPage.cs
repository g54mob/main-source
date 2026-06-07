using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors.UI
{
	public class SurvarotsSelectionPage : BaseUIPage, ISetArcanaInfo
	{
		[CompilerGenerated]
		private sealed class _003CSpawnContent_003Ed__60 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SurvarotsSelectionPage _003C_003E4__this;

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
			public _003CSpawnContent_003Ed__60(int _003C_003E1__state)
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
		private sealed class _003CWaitAndConfigureRandomButton_003Ed__82 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SurvarotsSelectionPage _003C_003E4__this;

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
			public _003CWaitAndConfigureRandomButton_003Ed__82(int _003C_003E1__state)
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
		private sealed class _003CWaitAndSelect_003Ed__83 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SurvarotsSelectionPage _003C_003E4__this;

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
			public _003CWaitAndSelect_003Ed__83(int _003C_003E1__state)
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
		private Transform _cardInfoPanelsRoot;

		[FormerlySerializedAs("_TitleGroup")]
		[FormerlySerializedAs("_TitlePanel")]
		[SerializeField]
		private RectTransform _titleGroup;

		[FormerlySerializedAs("_CardContainer")]
		[SerializeField]
		private RectTransform _cardContainer;

		[FormerlySerializedAs("_MinorCardContainer")]
		[SerializeField]
		private RectTransform _minorCardContainer;

		[FormerlySerializedAs("_ArcanaCardPrefab")]
		[SerializeField]
		private GameObject _arcanaCardPrefab;

		[SerializeField]
		private GameObject _boosterButton;

		[SerializeField]
		private TextMeshProUGUI _boosterPriceText;

		[SerializeField]
		private RectTransform _CurrencyPanel;

		[FormerlySerializedAs("_GetButton")]
		[SerializeField]
		private GameObject _getButton;

		[FormerlySerializedAs("_TopParticles")]
		[SerializeField]
		private ParticleEmitterManager _topParticles;

		[FormerlySerializedAs("_BottomParticles")]
		[SerializeField]
		private ParticleEmitterManager _bottomParticles;

		[FormerlySerializedAs("_CardOrigin")]
		[SerializeField]
		private RectTransform _cardOrigin;

		[FormerlySerializedAs("_SelectedCardOrigin")]
		[SerializeField]
		private RectTransform _selectedCardOrigin;

		[FormerlySerializedAs("_BlackFader")]
		[SerializeField]
		private Image _blackFader;

		[FormerlySerializedAs("_CollectRandomButton")]
		[SerializeField]
		private Image _collectRandomButton;

		[FormerlySerializedAs("_MajorSelectionGroup")]
		[SerializeField]
		private GameObject _majorSelectionGroup;

		[FormerlySerializedAs("_MinorSelectionGroup")]
		[SerializeField]
		private GameObject _minorSelectionGroup;

		[FormerlySerializedAs("_BigArcanaCard")]
		[SerializeField]
		private GameObject _bigArcanaCard;

		[FormerlySerializedAs("_StripContainer")]
		[SerializeField]
		private RectTransform _stripContainer;

		[FormerlySerializedAs("_MinorGetButton")]
		[SerializeField]
		private RectTransform _minorGetButton;

		[FormerlySerializedAs("_SkipButton")]
		[SerializeField]
		private RectTransform _skipButton;

		[FormerlySerializedAs("_RerollButton")]
		[SerializeField]
		private RectTransform _rerollButton;

		[FormerlySerializedAs("_RerollCountText")]
		[SerializeField]
		private TextMeshProUGUI _rerollCountText;

		[FormerlySerializedAs("_SkipCountText")]
		[SerializeField]
		private TextMeshProUGUI _skipCountText;

		[FormerlySerializedAs("_EquipmentPanel")]
		[SerializeField]
		private PauseEquipmentPanel _equipmentPanel;

		[FormerlySerializedAs("_CharacterStatsPanel")]
		[SerializeField]
		private GameObject _characterStatsPanel;

		[FormerlySerializedAs("_DEBUGPAGE2")]
		[SerializeField]
		private bool _debugpage2;

		[FormerlySerializedAs("_RerollAnimContainer")]
		[SerializeField]
		private RectTransform _rerollAnimContainer;

		[FormerlySerializedAs("_InfoGroup")]
		[FormerlySerializedAs("_InfoPanel")]
		[SerializeField]
		private RectTransform _infoGroup;

		[FormerlySerializedAs("_MinorBackground")]
		[FormerlySerializedAs("_MinorPanel")]
		[SerializeField]
		private RectTransform _minorBackground;

		[FormerlySerializedAs("_MajorBackground")]
		[FormerlySerializedAs("_MajorPanel")]
		[SerializeField]
		private RectTransform _majorBackground;

		[SerializeField]
		private RectTransform _majorForeground;

		[FormerlySerializedAs("_TitleBackground")]
		[FormerlySerializedAs("_HeaderPanel")]
		[SerializeField]
		private RectTransform _titleBackground;

		[FormerlySerializedAs("_CharacterPanelBackground")]
		[SerializeField]
		private RectTransform _characterPanelBackground;

		[FormerlySerializedAs("_CharacterPanel")]
		[SerializeField]
		private GameObject _characterPanel;

		[FormerlySerializedAs("_CharacterImage")]
		[SerializeField]
		private Image _characterImage;

		[FormerlySerializedAs("_CardRings")]
		[SerializeField]
		private List<SpinningRingOfCards> _cardRings;

		[FormerlySerializedAs("_MaxWeaponsBeforeCarousel")]
		[SerializeField]
		private int _maxWeaponsBeforeCarousel;

		[SerializeField]
		private CardInfoUI _cardInfoUI;

		[SerializeField]
		private CardRiskInfoUI _survarotInfoRisk;

		[SerializeField]
		private CardEditionInfoUI _survarotInfoEdition;

		private List<GameObject> _spawned;

		private List<GameObject> _allSpawnedInOrder;

		private DataManager _data;

		private PlayerOptions _playerOptions;

		private SignalBus _signalBus;

		private CharacterSkillCard_Base _currentSelected;

		private string _arcanaCacheGroupName;

		private Selectable _previouslyHighlightedDraftCard;

		private int _lastSelected;

		private ArcanaCardUI _selected;

		private bool _hasPickedRandom;

		private bool _hasFreeReroll;

		private VampireSurvivors.Objects.Characters.CharacterController _controllingCharacter;

		private bool _hasFinishedPopulationAnimation;

		private bool _rngInit;

		private Unity.Mathematics.Random _random;

		private int _boostersBought;

		[Inject]
		private void Construct(DataManager data, PlayerOptions player, SignalBus signalBus)
		{
		}

		protected override void Awake()
		{
		}

		[IteratorStateMachine(typeof(_003CSpawnContent_003Ed__60))]
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

		private void SetBoosterButton()
		{
		}

		private float CurrentBoosterCost()
		{
			return 0f;
		}

		public void Booster()
		{
		}

		private void PerformBooster()
		{
		}

		private void PurchaseBooster()
		{
		}

		private void PerformReRoll()
		{
		}

		public void Reroll()
		{
		}

		protected override void OnHideFinish(GameObject g)
		{
		}

		private void PopulateMenu()
		{
		}

		private void EnableInputFirstMenu()
		{
		}

		private void SetRandomButton()
		{
		}

		[IteratorStateMachine(typeof(_003CWaitAndConfigureRandomButton_003Ed__82))]
		private IEnumerator WaitAndConfigureRandomButton()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CWaitAndSelect_003Ed__83))]
		private IEnumerator WaitAndSelect(GameObject forcedSelect = null)
		{
			return null;
		}

		private void InitializeNormalArcanaParticles()
		{
		}

		private ArcanaCardUI SpawnCharacterCard(ArcanaData data, ArcanaType type, SkillCardEdition edition)
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

		private void OnSelectedCharacterCardRemotely(OnlineSignals.OnlineSelectedCharacterCard cardInfo)
		{
		}

		private void OnReRolledCharacterCardsRemotely()
		{
		}

		private void OnBoosterSurvarotsRemotely()
		{
		}

		private void PlayJingle()
		{
		}

		private void PlayLightSound()
		{
		}

		public void SetInfo(ArcanaData data, ArcanaType type, ArcanaCardUI ui)
		{
		}

		public void Select()
		{
		}

		public void Random()
		{
		}

		private void OpenMenu()
		{
		}
	}
}
