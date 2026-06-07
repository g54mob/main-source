using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using VampireSurvivors.Achievements;
using VampireSurvivors.App.Framework.System;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.Spells;
using Zenject;

namespace VampireSurvivors.UI
{
	public class RecapPage : BaseUIPage
	{
		public struct StatsDisplay
		{
			public string Name;

			public int Level;

			public string WeaponFrameName;

			public string WeaponTextureName;

			public float InflictedDamage;

			public float Lifetime;

			public float Dps;

			public bool IsBestDps;

			public bool IsBestRaw;

			public CharacterType Owner;

			public Color NameColor;
		}

		private class CustomPickupData
		{
			public ItemType? ItemType;

			public int Amount;

			public string FrameName;

			public string TextureName;
		}

		[CompilerGenerated]
		private sealed class _003CSelectDoneDelayed_003Ed__64 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public RecapPage _003C_003E4__this;

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
			public _003CSelectDoneDelayed_003Ed__64(int _003C_003E1__state)
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

		[FormerlySerializedAs("MapTitle")]
		[SerializeField]
		private TextMeshProUGUI _MapTitle;

		[FormerlySerializedAs("CharacterName")]
		[SerializeField]
		private TextMeshProUGUI _CharacterName;

		[SerializeField]
		private TextMeshProUGUI _EggCount;

		[FormerlySerializedAs("Survived")]
		[SerializeField]
		private PropertyUI _Survived;

		[FormerlySerializedAs("Gold")]
		[SerializeField]
		private PropertyUI _Gold;

		[FormerlySerializedAs("Levels")]
		[SerializeField]
		private PropertyUI _Levels;

		[FormerlySerializedAs("Enemies")]
		[SerializeField]
		private PropertyUI _Enemies;

		[FormerlySerializedAs("WeaponRecapContainer")]
		[SerializeField]
		private RectTransform _WeaponRecapContainer;

		[FormerlySerializedAs("WeaponIcons")]
		[SerializeField]
		private RectTransform _WeaponIcons;

		[FormerlySerializedAs("StatIcons")]
		[SerializeField]
		private RectTransform _StatIcons;

		[FormerlySerializedAs("LootIcons")]
		[SerializeField]
		private RectTransform _LootIcons;

		[FormerlySerializedAs("WeaponRecapPrefab")]
		[SerializeField]
		private GameObject _WeaponRecapPrefab;

		[FormerlySerializedAs("AchievementsPanel")]
		[SerializeField]
		private GameObject _AchievementsPanel;

		[FormerlySerializedAs("QuantityIconPrefab")]
		[SerializeField]
		private IconQuantityUI _QuantityIconPrefab;

		[FormerlySerializedAs("CharacterIcon")]
		[SerializeField]
		private Image _CharacterIcon;

		[FormerlySerializedAs("AchievementPopup")]
		[SerializeField]
		private AchievementPopup _AchievementPopup;

		[SerializeField]
		private Selectable _DoneButton;

		[SerializeField]
		private GameObject _HideAchievementsButton;

		[SerializeField]
		private GameObject _AcceptAchievementsButton;

		[SerializeField]
		private TickBoxUI _AcceptAchievementsTickBoxUI;

		[SerializeField]
		private GameObject _DestructablePrefab;

		[SerializeField]
		private GameObject _ArcanaPrefab;

		[SerializeField]
		private RectTransform _ArcanaContainer;

		[SerializeField]
		private RectTransform _TweenOrigin;

		[SerializeField]
		private GameObject _UnlockBadge;

		[SerializeField]
		private TextMeshProUGUI _UnlockCountText;

		[SerializeField]
		private Button _WatchAdForExtraGoldButton;

		[SerializeField]
		private ParticleEmitterManager _CoinEmitter;

		[SerializeField]
		private GameObject _PreviousCharacterButton;

		[SerializeField]
		private GameObject _NextCharacterButton;

		[SerializeField]
		private Button _openLogsButton;

		[SerializeField]
		private FakeSliderHandleController _sliderHandle;

		private SignalBus _signalBus;

		private PlayerOptions _playerOptions;

		private AchievementManager _achievements;

		private DataManager _dataManager;

		private PlayerStats _playerStats;

		private ArcanaManager _arcanaManager;

		private UnityServicesManager _unityServicesManager;

		private AdventureManager _adventureManager;

		private SpellsManager _spellsManager;

		private AchievementManager _achievementManager;

		private ParticleSystem _particles;

		private StringBuilder _timeFormatStringBuilder;

		private RectTransform _rectTransform;

		private List<Tween> _activeTweens;

		private VampireSurvivors.Objects.Characters.CharacterController _currentCharacter;

		private int _currentCharacterIndex;

		private List<GameObject> _spawned;

		private Dictionary<CharacterType, GameObject> _characterWeapons;

		private bool _isFirstShow;

		private int _selectedCharacterIndex;

		private Color hiddenWeaponNameColor;

		[Inject]
		private void Construct(SignalBus signal, AchievementManager achievement, PlayerOptions playerOptions, DataManager dataManager, PlayerStats playerStats, ArcanaManager arcanaManager, UnityServicesManager unityServicesManager, AdventureManager adventureManager, SpellsManager spellsManager, AchievementManager achievementManager)
		{
		}

		public void HideAchievements()
		{
		}

		public void AcceptAchievementsToggle(bool _ = true)
		{
		}

		public void DoneClicked()
		{
		}

		public void ReturnToLanding()
		{
		}

		public void WatchAdForExtraGold()
		{
		}

		public void NextCharacter()
		{
		}

		public void PreviousCharacter()
		{
		}

		private void RefreshCharacterSpecificStats()
		{
		}

		protected override void OnShowStart(GameObject g)
		{
		}

		private AchievementData CheckCompleteAdventure(out bool willReturnToLandingFromPopup)
		{
			willReturnToLandingFromPopup = default(bool);
			return null;
		}

		[IteratorStateMachine(typeof(_003CSelectDoneDelayed_003Ed__64))]
		private IEnumerator SelectDoneDelayed()
		{
			return null;
		}

		private void EditorShowCompletionPopup()
		{
		}

		private void OnDestroy()
		{
		}

		private void SetInfo()
		{
		}

		private void DoAnimations()
		{
		}

		private void SetHeader()
		{
		}

		private void SetCharacter()
		{
		}

		private void SetRunStats()
		{
		}

		private void AddWeapons()
		{
		}

		private static void CalculateBestStats(List<StatsDisplay> allStats)
		{
		}

		private StatsDisplay GenerateStatsDisplay(Weapon weapon)
		{
			return default(StatsDisplay);
		}

		public void AddPowerUps()
		{
		}

		public void AddCollectedItems()
		{
		}

		private void SpawnDestructible(int index, float duration, string frameName, string textureName)
		{
		}

		private void AddArcanas()
		{
		}

		private void GenerateWeaponRecap(StatsDisplay statsDisplay)
		{
		}

		private void QueueAchievements(List<AchievementData> achievementsUnlocked)
		{
		}

		private bool CanShowPostRunGoldAdRewardButton()
		{
			return false;
		}

		private void RewardExtraGoldFromAd()
		{
		}

		private void PlayParticles()
		{
		}

		public void OpenLogs()
		{
		}
	}
}
