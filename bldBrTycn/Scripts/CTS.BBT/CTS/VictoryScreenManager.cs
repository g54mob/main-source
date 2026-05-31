using System;
using System.Collections.Generic;
using CTS.BBT;
using CTS.Core;
using CTS.UI;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

namespace CTS
{
	public class VictoryScreenManager : MonoSingleton<VictoryScreenManager>
	{
		[SerializeField]
		[Foldout("Text")]
		private TextMeshProUGUI _timer;

		[SerializeField]
		[Foldout("Text")]
		private TextMeshProUGUI _date;

		[SerializeField]
		[Foldout("Text")]
		private TextMeshProUGUI _year;

		[SerializeField]
		[Foldout("Text")]
		private TextMeshProUGUI _nameCity;

		private LockToggle _time = new LockToggle();

		[SerializeField]
		[Foldout("ScriptableSO")]
		private CareerProfileMethods _careerProfile;

		[SerializeField]
		[Foldout("ScriptableSO")]
		private LevelLoader _levelLoader;

		[Foldout("Text")]
		private TextMeshProUGUI _treasury;

		[SerializeField]
		private VictoryScreenActorSpineLinker _spineLinker;

		[SerializeField]
		private GameObject _victoryScreen;

		[SerializeField]
		private List<Image> _startImage;

		[SerializeField]
		private VictoryScreen_StarsAnimation _starAnimation;

		[SerializeField]
		private EActors _personnaToShow;

		[SerializeField]
		private VictoryScreenActorSpineLinker _actorSpineLinker;

		[SerializeField]
		private CanvasGroupController _canvasGroupController;

		[SerializeField]
		[Foldout("Stats")]
		private UI_StatsCounter _prefab;

		[SerializeField]
		[Foldout("Stats")]
		private GameObject _spacingPrefab;

		[SerializeField]
		[Foldout("Stats")]
		private Transform _container;

		[SerializeField]
		[Foldout("Stats")]
		private Color _clearColor;

		[SerializeField]
		[Foldout("Stats")]
		private Color _darkColor;

		[SerializeField]
		[Foldout("Stats")]
		private StatsGroup[] _statGroups;

		private MapInfoSO CurrentMap => CTSSingleton<GameMode>.Instance.LevelInfo;

		public static event Action LevelFinish;

		protected override void SingletonAwake()
		{
			_time.Add(MonoSingleton<TimeController>.Instance);
			for (int i = 0; i < _statGroups.Length; i++)
			{
				for (int j = 0; j < _statGroups[i].Stats.Length; j++)
				{
					UI_StatsCounter uI_StatsCounter = UnityEngine.Object.Instantiate(_prefab, _container);
					uI_StatsCounter.Init(_statGroups[i].Stats[j], (j % 2 == 0) ? _darkColor : _clearColor);
					if (j == 0 && i == 0)
					{
						_treasury = (TextMeshProUGUI)uI_StatsCounter.Counter;
					}
				}
				if (i < _statGroups.Length - 1)
				{
					UnityEngine.Object.Instantiate(_spacingPrefab, _container);
				}
			}
			CalendarHandlers.CalendarLoaded += ChangeTheDate;
			CalendarHandlers.NewMonth += ChangeTheDate;
			LocalizationSettings.SelectedLocaleChanged += ChangeTheDate;
			if (CTSSingleton<ProfileManager>.TryGetInstance(out var outInstance) && outInstance.CurrentProfile is CareerProfile careerProfile)
			{
				_timer.text = careerProfile.GetTimePlayed(CurrentMap).ToString();
			}
			_container.gameObject.SetActive(value: false);
			_container.gameObject.SetActive(value: true);
		}

		private void Start()
		{
			close();
		}

		private void open()
		{
			_canvasGroupController.QuickShow();
		}

		private void close()
		{
			_canvasGroupController.QuickHide();
		}

		private void OnEnable()
		{
			if (CurrentMap != null)
			{
				_nameCity.text = CurrentMap.LevelNameLocalizationString.GetLocalizedString().ToString();
				MapInfoSO.MapWinScore += MapInfoSO_MapWinScore;
				MapInfoSO.CheckSuccesToiletAndLoan += MapInfoSO_CheckSuccesToiletAndLoan;
			}
		}

		private void OnDisable()
		{
			MapInfoSO.CheckSuccesToiletAndLoan -= MapInfoSO_CheckSuccesToiletAndLoan;
			MapInfoSO.MapWinScore -= MapInfoSO_MapWinScore;
		}

		protected override void OnSingletonDestroy()
		{
			_spineLinker.HideAll();
			LocalizationSettings.SelectedLocaleChanged -= ChangeTheDate;
			CalendarHandlers.CalendarLoaded -= ChangeTheDate;
			CalendarHandlers.NewMonth -= ChangeTheDate;
		}

		[Button(null, EButtonEnableMode.Always)]
		public void QuitCanvas()
		{
			_time.Unlock();
			CTSSingleton<ProfileManager>.Instance.Save();
			close();
			MonoSingleton<MusicManager>.Instance.PlayBarMusic();
		}

		public void ReturnToSelectionMap()
		{
			_time.Unlock();
			CTSSingleton<ProfileManager>.Instance.Save();
			_levelLoader.LoadScene(unloadActive: true);
		}

		private void ChangeTheDate(Locale locale)
		{
			UptadeTheScreen();
		}

		private void ChangeTheDate()
		{
			UptadeTheScreen();
		}

		[Button(null, EButtonEnableMode.Always)]
		public void DebuShowingTheVictoryScreen()
		{
			_time.Lock();
			_actorSpineLinker.HideAll();
			_actorSpineLinker.ShowingTheVictorySplinePersonna(_personnaToShow);
			UptadeTheScreen();
			open();
			MonoSingleton<MusicManager>.Instance.PlayMenuMusic();
			_starAnimation.LaunchAnim();
			_actorSpineLinker.ShowingTheVictorySplinePersonna(_personnaToShow);
		}

		[Button(null, EButtonEnableMode.Always)]
		private void activeStars()
		{
			MapInfoSO_MapWinScore(CurrentMap);
		}

		public void ShowingTheVictoryScreen()
		{
			_time.Lock();
			_actorSpineLinker.ShowingTheVictorySplinePersonna(CurrentMap.MainCharacter);
			UptadeTheScreen();
			open();
			MonoSingleton<MusicManager>.Instance.PlayMenuMusic();
			_starAnimation.LaunchAnim();
			_actorSpineLinker.ShowingTheVictorySplinePersonna(CurrentMap.MainCharacter);
		}

		private void MapInfoSO_CheckSuccesToiletAndLoan(MapInfoSO obj, int score)
		{
			if (CTSSingleton<ProfileManager>.TryGetInstance(out var outInstance) && outInstance.CurrentProfile is CareerProfile { LevelProgress: var levelProgress } && levelProgress.TryGetValue(obj, out var value))
			{
				Debug.Log(value.Score);
				if (score <= 2)
				{
					VictoryScreenManager.LevelFinish?.Invoke();
				}
			}
		}

		private void MapInfoSO_MapWinScore(MapInfoSO obj)
		{
			if (CTSSingleton<ProfileManager>.TryGetInstance(out var outInstance) && outInstance.CurrentProfile is CareerProfile { LevelProgress: var levelProgress } && levelProgress.TryGetValue(obj, out var value))
			{
				float fillbyimage = 6f / (float)_startImage.Count;
				float fillRest = value.Score;
				_starAnimation.SetUp(fillRest, fillbyimage);
				ShowingTheVictoryScreen();
			}
		}

		public void UptadeTheScreen()
		{
			if (CTSSingleton<ProfileManager>.TryGetInstance(out var outInstance) && outInstance.CurrentProfile is CareerProfile careerProfile)
			{
				TimeSpan timeSpan = TimeSpan.FromSeconds(careerProfile.GetTimePlayed(CurrentMap));
				_timer.text = $"{timeSpan.Hours:D2}:{timeSpan.Minutes:D2}";
				Debug.Log(timeSpan);
			}
			_date.text = string.Empty;
			_year.text = string.Empty;
			_treasury.text = "$" + MonoSingleton<MoneyHandler>.Instance.CurrentMoney;
			_date.text = MonoSingleton<CalendarHandlers>.Instance.GetMonthDateString();
			_year.text = (MonoSingleton<CalendarHandlers>.Instance.CurrentYear + 1).ToString();
		}

		private void Update()
		{
			if (!(CurrentMap == null) && CTSSingleton<ProfileManager>.TryGetInstance(out var outInstance) && outInstance.CurrentProfile is CareerProfile careerProfile)
			{
				careerProfile.TimePlayed(CurrentMap, Time.unscaledDeltaTime);
			}
		}
	}
}
