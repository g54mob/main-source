using System;
using System.Collections;
using CTS.BBT;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class GameMode : CTSSingleton<GameMode>
	{
		[SerializeField]
		private GameObject[] _enableOnNewGame;

		[SerializeField]
		private GameObject[] _enableOnFreeMode;

		[SerializeField]
		private GameObject[] _enableOnStory;

		[InjectScope(EGetScope.Singleton)]
		[Inject(false)]
		private LoadingScreen _loadingScreen;

		private readonly LockToggle _loadingScreenToggle = new LockToggle();

		[field: SerializeField]
		public MapInfoSO LevelInfo { get; private set; }

		public static EGameMode StartMode { get; set; }

		public static string SaveToLoad { get; set; }

		public string SaveLoaded { get; private set; }

		public static bool IsNewGame
		{
			get
			{
				if (CTSSingleton<GameMode>.InstanceExists())
				{
					if (string.IsNullOrEmpty(CTSSingleton<GameMode>.Instance.SaveLoaded))
					{
						return string.IsNullOrEmpty(SaveToLoad);
					}
					return false;
				}
				return true;
			}
		}

		public EGameMode CurrentMode { get; private set; }

		public float LastSaveTime { get; private set; }

		public float TimeSinceSave => Time.realtimeSinceStartup - LastSaveTime;

		public static event Action<MapInfoSO> SceneLoaded;

		public static event Action ProfileLoaded;

		public static event Action QuitScene;

		public void ResetTimeSinceSave()
		{
			LastSaveTime = Time.realtimeSinceStartup;
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void Init()
		{
			SaveToLoad = null;
		}

		protected override void SingletonAwake()
		{
			ResetTimeSinceSave();
			if ((bool)_loadingScreen)
			{
				_loadingScreenToggle.Add(_loadingScreen);
			}
			_loadingScreenToggle.Add(MonoSingleton<TimeController>.Instance);
			_loadingScreenToggle.Lock();
		}

		protected override void OnSingletonDestroy()
		{
			GameMode.QuitScene?.Invoke();
		}

		private IEnumerator Start()
		{
			yield return Coroutines.WaitForSecondsUnscaled(0.5f);
			if (IsNewGame)
			{
				LoadProfile();
			}
			else
			{
				LoadGame();
			}
			if (IsNewGame && StartMode != EGameMode.DevMode)
			{
				SetArrayActive(_enableOnNewGame, value: true);
			}
			while (AutomaticMapLoader.IsLoading)
			{
				yield return null;
			}
			yield return null;
			GameMode.SceneLoaded?.Invoke(LevelInfo);
			CurrentMode = StartMode;
			if (CurrentMode == EGameMode.Story)
			{
				SetArrayActive(_enableOnStory, value: true);
			}
			else if (CurrentMode == EGameMode.FreeMode)
			{
				SetArrayActive(_enableOnFreeMode, value: true);
			}
			if (!IsNewGame)
			{
				yield return null;
				yield return Coroutines.WaitForSecondsUnscaled(1f);
			}
			_loadingScreenToggle.Unlock();
			void LoadGame()
			{
				if (!CTSSingleton<ProfileManager>.Instance.LoadCurrentProfile())
				{
					SaveToLoad = null;
					SaveLoaded = null;
				}
				else
				{
					GameMode.ProfileLoaded?.Invoke();
					if (!CTSSingleton<ProfileManager>.Instance.LoadSceneSave(SaveToLoad))
					{
						SaveToLoad = null;
						SaveLoaded = null;
					}
					else
					{
						SaveLoaded = SaveToLoad;
						SaveToLoad = null;
					}
				}
			}
			void LoadProfile()
			{
				if (!CTSSingleton<ProfileManager>.Instance.LoadCurrentProfile())
				{
					SaveToLoad = null;
					SaveLoaded = null;
				}
				else
				{
					GameMode.ProfileLoaded?.Invoke();
				}
			}
			static void SetArrayActive(GameObject[] array, bool value)
			{
				for (int i = 0; i < array.Length; i++)
				{
					array[i].SetActive(value);
				}
			}
		}
	}
}
