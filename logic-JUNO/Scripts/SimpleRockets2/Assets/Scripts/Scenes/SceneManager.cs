using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Assets.Scripts.DevConsole;
using Assets.Scripts.Flight.MapView.Items;
using Assets.Scripts.Flight.Sim;
using Assets.Scripts.Logging;
using Assets.Scripts.Services.Ads;
using Assets.Scripts.Services.Analytics;
using Assets.Scripts.State;
using Assets.Scripts.Tools;
using ModApi;
using ModApi.CelestialData;
using ModApi.Common.Extensions;
using ModApi.Planet;
using ModApi.Scenes;
using ModApi.Scenes.Events;
using ModApi.Scenes.Parameters;
using ModApi.Settings;
using ModApi.Settings.Core.Events;
using TMPro;
using UI.Xml;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.Scenes
{
	public class SceneManager : MonoBehaviour, ISceneManager
	{
		private const string DefaultLoadingText = "Loading...";

		private const float LoadScreenFadeTime = 0.4f;

		private const float MinimumLoadScreenTime = 1f;

		[SerializeField]
		private Canvas _canvas;

		[SerializeField]
		private bool _debugLoadingScreen;

		private ILoadingScreenTextureProvider _defaultLoadingScreenTextureProvider;

		private float _equirectangularMapGenerationBrightnessAdjustment;

		private LoadingScreenTextureData _loadingScreenTexture;

		private SortedList<int, ILoadingScreenTextureProvider> _loadingScreenTextureProviders;

		private HashSet<Guid> _planetarySystemMapGenerationConfirmed;

		private string _previousSceneName;

		private bool _queuedSceneTransition;

		[SerializeField]
		private TextMeshProUGUI _transitionAuthorText;

		[SerializeField]
		private CanvasGroup _transitionCanvasGroup;

		[SerializeField]
		private RawImage _transitionImage;

		[SerializeField]
		private TextMeshProUGUI _transitionLoadingText;

		private SceneTransitionState _transitionState;

		public string CurrentScene => UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

		public DesignSceneLoadParameters DesignSceneLoadParameters { get; private set; }

		public bool EnableCubemapLoadingDuringSceneTransitions { get; set; }

		public bool EnableEquirectangularMapGenerationDuringSceneTransitions { get; set; }

		public FlightSceneLoadParameters FlightSceneLoadParameters { get; private set; }

		public bool InDesignerScene { get; private set; }

		public bool InFlightScene { get; private set; }

		public bool InMenuScene { get; private set; }

		public bool InPlanetStudioScene { get; private set; }

		public bool InTechTreeScene { get; private set; }

		public MenuSceneLoadParameters MenuSceneLoadParameters { get; private set; }

		public SceneTransitionState SceneTransitionState => _transitionState;

		public event EventHandler<SceneEventArgs> SceneLoaded;

		public event EventHandler<SceneEventArgs> SceneLoading;

		public event EventHandler<SceneTransitionEventArgs> SceneTransitionCompleted;

		public event EventHandler<SceneTransitionEventArgs> SceneTransitionStarted;

		public event EventHandler<SceneEventArgs> SceneUnloaded;

		public event EventHandler<SceneEventArgs> SceneUnloading;

		public static SceneManager Create(GameObject parent)
		{
			SceneManager sceneManager = Game.Instance.ResourceLoader.InstantiatePrefab<SceneManager>("SceneManager");
			sceneManager.name = "SceneManager";
			sceneManager.transform.SetParent(parent.transform);
			return sceneManager;
		}

		public void DeactivateCurrentScene()
		{
			GameObject[] rootGameObjects = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
			for (int i = 0; i < rootGameObjects.Length; i++)
			{
				rootGameObjects[i].SetActive(value: false);
			}
		}

		public void LoadDesigner()
		{
			LoadDesigner(null);
		}

		public void LoadDesigner(DesignSceneLoadParameters loadParameters = null)
		{
			DesignSceneLoadParameters = loadParameters;
			LoadScene("Design");
		}

		public void LoadFlight(FlightSceneLoadParameters loadParameters = null)
		{
			if (loadParameters != null)
			{
				FlightSceneLoadParameters = loadParameters;
			}
			LoadScene("Flight");
		}

		public void LoadMenu(MenuSceneLoadParameters loadParameters = null)
		{
			MenuSceneLoadParameters = loadParameters;
			LoadScene("Menu");
		}

		public void LoadPlanetStudio()
		{
			LoadScene("PlanetStudio");
		}

		public void LoadPreviousScene()
		{
			if (!string.IsNullOrWhiteSpace(_previousSceneName))
			{
				LoadScene(_previousSceneName);
			}
			else
			{
				LoadMenu();
			}
		}

		public void LoadScene(string sceneName)
		{
			StartCoroutine(LoadSceneCoroutine(sceneName));
		}

		public void LoadTechTree()
		{
			LoadScene("TechTree");
		}

		public void RegisterLoadingScreenTextureProvider(ILoadingScreenTextureProvider provider, int priority)
		{
			_loadingScreenTextureProviders.Add(priority, provider);
		}

		public void ReloadCurrentScene()
		{
			LoadScene(CurrentScene);
		}

		protected virtual void Awake()
		{
			_loadingScreenTextureProviders = new SortedList<int, ILoadingScreenTextureProvider>();
			_defaultLoadingScreenTextureProvider = new DefaultLoadingScreenTextureProvider();
			_queuedSceneTransition = false;
			_transitionState = SceneTransitionState.Default;
			_planetarySystemMapGenerationConfirmed = new HashSet<Guid>();
			SceneSkybox.Initialize(this);
			UpdateCurrentSceneInfo(CurrentScene);
			OnSceneLoading(CurrentScene);
			RegisterDevConsoleCommands();
		}

		protected virtual void OnDestroy()
		{
			Game.Instance.Settings.Quality.Terrain.Cubemaps.Changed -= OnCubemapQualitySettingsChanged;
			Game.Instance.CelestialDatabase.Refreshed -= OnCelestialDatabaseRefreshed;
		}

		protected virtual void Start()
		{
			Game.Instance.Settings.Quality.Terrain.Cubemaps.Changed += OnCubemapQualitySettingsChanged;
			Game.Instance.CelestialDatabase.Refreshed += OnCelestialDatabaseRefreshed;
			OnSceneLoaded(CurrentScene);
		}

		private IEnumerator CompleteSceneTransition(string previousSceneName, string sceneName, float startTime)
		{
			try
			{
				_transitionState = SceneTransitionState.PostLoadDelay;
				GC.Collect();
				Resources.UnloadUnusedAssets();
				yield return null;
				HackFixResolution();
				yield return null;
				yield return null;
				float num = Time.realtimeSinceStartup - startTime;
				if (num < 1f)
				{
					float time = 1f - num;
					yield return new WaitForSecondsRealtime(time);
				}
				_transitionState = SceneTransitionState.LoadingScreenFadeOut;
				_transitionLoadingText.enabled = false;
				_transitionAuthorText.enabled = false;
				float a = 1f;
				while (a > 0f)
				{
					a -= Time.unscaledDeltaTime / 0.4f;
					if (a < 0f)
					{
						a = 0f;
					}
					_transitionCanvasGroup.alpha = a;
					yield return null;
				}
				UnloadLoadingScreenTexture();
				_canvas.gameObject.SetActive(value: false);
				this.SceneTransitionCompleted?.Invoke(this, new SceneTransitionEventArgs(previousSceneName, sceneName));
			}
			finally
			{
				_transitionState = SceneTransitionState.Default;
			}
		}

		private void EnableTemporaryAudioListener(bool enable)
		{
			base.gameObject.AddMissingComponent<AudioListener>().enabled = enable;
		}

		private IEnumerator GenerateCelestialBodyMaps()
		{
			if (!EnableCubemapLoadingDuringSceneTransitions && !EnableEquirectangularMapGenerationDuringSceneTransitions)
			{
				yield break;
			}
			try
			{
				CelestialDatabase celestialDatabase = Game.Instance.CelestialDatabase;
				CelestialFileReference celestialFileReference = Game.Instance.GameState?.LoadFlightStateData()?.PlanetarySystemFileReference;
				CelestialFile planetarySystemFile = ((celestialFileReference == null) ? null : celestialDatabase.GetFile(celestialFileReference));
				if (planetarySystemFile == null || _planetarySystemMapGenerationConfirmed.Contains(planetarySystemFile.Id))
				{
					yield break;
				}
				SolarSystemDataScript planetarySystem = SolarSystemDataScript.CreateFromFile(planetarySystemFile, createTerrainData: false, applyScaleAndOverrides: true);
				int planetIndex = 0;
				foreach (PlanetDataScript planet in planetarySystem.Planets)
				{
					planetIndex++;
					if (EnableCubemapLoadingDuringSceneTransitions && !PlanetCubemapUtility.Exists(planet))
					{
						_transitionAuthorText.enabled = false;
						_transitionLoadingText.text = $"Creating Planet {planetIndex} of {planetarySystem.Planets.Count}: {planet.Name}";
						yield return new WaitForEndOfFrame();
						try
						{
							ApplicationState.PushTask("Generating Cubemap: " + planet.Name);
							yield return PlanetCubemapUtility.CreateCubemapsAsync(planet);
						}
						finally
						{
							ApplicationState.PopTask("Generating Cubemap: " + planet.Name);
						}
					}
					if (EnableEquirectangularMapGenerationDuringSceneTransitions && !PlanetCubemapUtility.ExistsEquirectangular(planet))
					{
						_transitionAuthorText.enabled = false;
						_transitionLoadingText.text = "Creating " + planet.Name + " Map";
						yield return new WaitForEndOfFrame();
						try
						{
							ApplicationState.PushTask("Generating Equirectangular Map: " + planet.Name);
							PlanetCubemapUtility.CreateEquirectangularMap(planet, _equirectangularMapGenerationBrightnessAdjustment);
						}
						finally
						{
							ApplicationState.PopTask("Generating Equirectangular Map: " + planet.Name);
						}
					}
				}
				_planetarySystemMapGenerationConfirmed.Add(planetarySystemFile.Id);
				_transitionLoadingText.text = "Loading...";
				yield return new WaitForEndOfFrame();
			}
			finally
			{
				_transitionLoadingText.text = "Loading...";
			}
		}

		private LoadingScreenTextureData GetLoadingScreenTexture(string previousSceneName, string sceneName)
		{
			string flightSceneActivePlanet = FlightSceneLoadParameters?.LoadingScreen;
			LoadingScreenTextureData loadingScreenTextureData = null;
			foreach (ILoadingScreenTextureProvider value in _loadingScreenTextureProviders.Values)
			{
				loadingScreenTextureData = value.GetLoadingScreenTexture(sceneName, previousSceneName, flightSceneActivePlanet);
				if (loadingScreenTextureData != null)
				{
					break;
				}
			}
			if (loadingScreenTextureData == null)
			{
				loadingScreenTextureData = _defaultLoadingScreenTextureProvider.GetLoadingScreenTexture(sceneName, previousSceneName, flightSceneActivePlanet);
			}
			if (loadingScreenTextureData == null)
			{
				loadingScreenTextureData = DefaultLoadingScreenTextureProvider.DefaultLoadingScreen;
			}
			return loadingScreenTextureData;
		}

		private void HackFixResolution()
		{
			if (!Device.IsUnityEditor && !Device.IsMobileBuild)
			{
				DisplayQualitySettings display = Game.Instance.QualitySettings.Display;
				Resolution value = display.Resolution.Value;
				Resolution currentResolution = Screen.currentResolution;
				if (value.width != currentResolution.width || value.height != currentResolution.height)
				{
					Debug.Log($"Fixing resolution: {currentResolution} --> {value}");
					Screen.SetResolution(value.width, value.height, display.Fullscreen.Value);
				}
			}
		}

		private IEnumerator LoadSceneCoroutine(string sceneName)
		{
			WaitForEndOfFrame endOfFrame = new WaitForEndOfFrame();
			if (_queuedSceneTransition)
			{
				Debug.LogError("Scene transition aborted due to 2 pending scene transitions.");
				yield break;
			}
			if (_transitionState == SceneTransitionState.SceneUnloading)
			{
				Debug.Log("Scene transition aborted due to an already pending scene transition.");
				yield break;
			}
			while (_transitionState != SceneTransitionState.Default)
			{
				_queuedSceneTransition = true;
				yield return endOfFrame;
			}
			float startTime = Time.realtimeSinceStartup;
			string previousSceneName = (_previousSceneName = CurrentScene);
			ApplicationState.PushTask("Loading Scene: " + sceneName);
			StartSceneTransition(previousSceneName, sceneName);
			yield return endOfFrame;
			UnityEngine.SceneManagement.SceneManager.LoadScene("Transition", LoadSceneMode.Additive);
			yield return endOfFrame;
			EnableTemporaryAudioListener(enable: true);
			OnSceneUnloading(previousSceneName);
			yield return UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(previousSceneName);
			yield return endOfFrame;
			OnSceneUnloaded(previousSceneName);
			UpdateCurrentSceneInfo("Transition");
			yield return PerformTransitionSceneActions();
			if (_debugLoadingScreen)
			{
				yield return PerformLoadingScreenDebugging();
			}
			AdManagerScript ads = Game.Instance.Ads;
			if (ads.AdsEnabled && sceneName == "Flight")
			{
				Task adTask = ads.ShowAdForFlightSceneLoad(delegate
				{
					SetLoadingScreenColors(Color.black);
				});
				yield return new WaitUntil(() => adTask.IsCompleted);
				SetLoadingScreenColors(Color.white);
				yield return endOfFrame;
			}
			EnableTemporaryAudioListener(enable: false);
			UpdateCurrentSceneInfo(sceneName);
			OnSceneLoading(sceneName);
			UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
			yield return null;
			OnSceneLoaded(sceneName);
			ApplicationState.PopTask("Loading Scene: " + sceneName);
			yield return CompleteSceneTransition(previousSceneName, sceneName, startTime);
		}

		private void OnCelestialDatabaseRefreshed(object sender, EventArgs e)
		{
			_planetarySystemMapGenerationConfirmed.Clear();
		}

		private void OnCubemapQualitySettingsChanged(object sender, SettingChangedEventArgs<TerrainQualitySettings.PlanetCubemapQuality> e)
		{
			_planetarySystemMapGenerationConfirmed.Clear();
		}

		private void OnSceneLoaded(string sceneName)
		{
			Game.Instance.InputManager.EnableControlsForScene(sceneName);
			try
			{
				this.SceneLoaded?.Invoke(this, new SceneEventArgs(sceneName));
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		private void OnSceneLoading(string sceneName)
		{
			try
			{
				this.SceneLoading?.Invoke(this, new SceneEventArgs(sceneName));
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		private void OnSceneUnloaded(string sceneName)
		{
			_transitionState = SceneTransitionState.SceneLoading;
			if (sceneName == "Design")
			{
				Game.Instance.Designer = null;
			}
			try
			{
				this.SceneUnloaded?.Invoke(this, new SceneEventArgs(sceneName));
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		private void OnSceneUnloading(string sceneName)
		{
			try
			{
				this.SceneUnloading?.Invoke(this, new SceneEventArgs(sceneName));
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			try
			{
				IAnalyticsManager analytics = Game.Instance.Analytics;
				if (analytics.Enabled)
				{
					switch (sceneName)
					{
					case "Design":
					{
						Dictionary<string, object> eventData2 = new Dictionary<string, object>
						{
							{
								"GameMode",
								Game.Instance.GameState?.Mode.ToString() ?? string.Empty
							},
							{
								"PlaytimeInSeconds",
								(int)(analytics.SceneTimeTracker?.TimeInScene ?? 0.0)
							}
						};
						Game.Instance.Analytics.LogEvent("DesignerExited", eventData2);
						break;
					}
					case "Menu":
					{
						Dictionary<string, object> eventData3 = new Dictionary<string, object>
						{
							{
								"GameMode",
								Game.Instance.GameState?.Mode.ToString() ?? string.Empty
							},
							{
								"PlaytimeInSeconds",
								(int)(analytics.SceneTimeTracker?.TimeInScene ?? 0.0)
							}
						};
						Game.Instance.Analytics.LogEvent("MenuExited", eventData3);
						break;
					}
					case "TechTree":
					{
						Dictionary<string, object> eventData4 = new Dictionary<string, object>
						{
							{
								"GameMode",
								Game.Instance.GameState?.Mode.ToString() ?? string.Empty
							},
							{
								"PlaytimeInSeconds",
								(int)(analytics.SceneTimeTracker?.TimeInScene ?? 0.0)
							}
						};
						Game.Instance.Analytics.LogEvent("TechTreeExited", eventData4);
						break;
					}
					case "PlanetStudio":
					{
						Dictionary<string, object> eventData = new Dictionary<string, object> { 
						{
							"PlaytimeInSeconds",
							(int)(analytics.SceneTimeTracker?.TimeInScene ?? 0.0)
						} };
						Game.Instance.Analytics.LogEvent("PlanetStudioExited", eventData);
						break;
					}
					}
				}
			}
			catch (Exception exception2)
			{
				Debug.LogException(exception2);
			}
		}

		private IEnumerator PerformLoadingScreenDebugging()
		{
			List<string> loadingScreenList = null;
			int screenWidth = Screen.width;
			int screenHeight = Screen.height;
			while (_debugLoadingScreen)
			{
				yield return null;
				if (loadingScreenList == null)
				{
					loadingScreenList = DefaultLoadingScreenTextureProvider.LoadingScreenPaths.ToList();
				}
				int num = loadingScreenList.IndexOf(DefaultLoadingScreenTextureProvider.LastUsedTextureResourcePath);
				if (num < 0)
				{
					num = 0;
				}
				bool num2 = screenWidth != Screen.width || screenHeight != Screen.height;
				string text = null;
				if (num2)
				{
					screenWidth = Screen.width;
					screenHeight = Screen.height;
					text = loadingScreenList[num];
					Debug.Log($"Resolution Changed ({screenWidth}x{screenHeight}), reloading current image: {text}");
				}
				else if (UnityEngine.Input.GetKeyDown(KeyCode.UpArrow) || UnityEngine.Input.GetKeyDown(KeyCode.DownArrow))
				{
					text = loadingScreenList[num];
					Debug.Log("Reloading current image: " + text);
				}
				else if (UnityEngine.Input.GetKeyDown(KeyCode.LeftArrow))
				{
					text = loadingScreenList[(num + 1) % loadingScreenList.Count];
					Debug.Log("Loading previous image: " + text);
				}
				else if (UnityEngine.Input.GetKeyDown(KeyCode.RightArrow))
				{
					text = loadingScreenList[(num > 0) ? (num - 1) : (loadingScreenList.Count - 1)];
					Debug.Log("Loading next image: " + text);
				}
				if (text != null)
				{
					LoadingScreenTextureData loadingScreenTexture = DefaultLoadingScreenTextureProvider.GetLoadingScreenTexture(text);
					SetupLoadingScreenUI(loadingScreenTexture);
				}
			}
		}

		private IEnumerator PerformTransitionSceneActions()
		{
			if (PartViewerScript.RegeneratePartIcons)
			{
				PartViewerScript.Create(createPartShaderScript: true).TakeAllPartPictures(retakeExisting: true, destroySelfWhenComplete: true);
			}
			yield return GenerateCelestialBodyMaps();
			yield return TransitionSceneCleanup();
			MemoryLeakUtility.OnSceneUnloaded();
			Game.Instance.Settings.SaveIfNecessary();
			MobileLogger.ForceRealtimeLogging = false;
			MobileLogger.FlushPendingLogsToFile();
		}

		private void RegisterDevConsoleCommands()
		{
			DevConsoleService.Instance.RegisterCommand("GenerateEquirectangularMaps", delegate
			{
				EnableEquirectangularMapGenerationDuringSceneTransitions = true;
				_equirectangularMapGenerationBrightnessAdjustment = 0f;
				_planetarySystemMapGenerationConfirmed.Clear();
				LoadScene(CurrentScene);
			});
			DevConsoleService.Instance.RegisterCommand("GenerateEquirectangularMaps", delegate(float brightness)
			{
				EnableEquirectangularMapGenerationDuringSceneTransitions = true;
				_equirectangularMapGenerationBrightnessAdjustment = brightness;
				_planetarySystemMapGenerationConfirmed.Clear();
				LoadScene(CurrentScene);
			});
		}

		private void SetLoadingScreenColors(Color color)
		{
			_transitionImage.color = color;
			_transitionLoadingText.color = color;
			_transitionAuthorText.color = color;
		}

		private void SetupLoadingScreenUI(LoadingScreenTextureData textureData)
		{
			if (_loadingScreenTexture != null)
			{
				UnloadLoadingScreenTexture();
			}
			_loadingScreenTexture = textureData;
			_canvas.gameObject.SetActive(value: true);
			_transitionCanvasGroup.alpha = 1f;
			_loadingScreenTexture.SetRectTransformPosition(_transitionImage.rectTransform);
			Texture texture = _loadingScreenTexture.Texture;
			float num = GetComponentInChildren<CanvasScaler>()?.scaleFactor ?? 1f;
			float num2 = Mathf.Max((float)Screen.width / num / (float)texture.width, (float)Screen.height / num / (float)texture.height);
			_transitionImage.rectTransform.sizeDelta = new Vector2((float)texture.width * num2 + 2f, (float)texture.height * num2 + 2f);
			_transitionImage.texture = texture;
			_transitionLoadingText.enabled = _loadingScreenTexture.ShowLoadingText;
			_transitionLoadingText.text = "Loading...";
			_transitionAuthorText.enabled = !string.IsNullOrWhiteSpace(_loadingScreenTexture.AuthorText);
			_transitionAuthorText.text = "<size=60%>Image By:</size>\n" + _loadingScreenTexture.AuthorText;
			SetLoadingScreenColors(Color.white);
		}

		private void StartSceneTransition(string previousSceneName, string sceneName)
		{
			_queuedSceneTransition = false;
			_transitionState = SceneTransitionState.SceneUnloading;
			try
			{
				this.SceneTransitionStarted?.Invoke(this, new SceneTransitionEventArgs(previousSceneName, sceneName));
				LoadingScreenTextureData loadingScreenTexture = GetLoadingScreenTexture(previousSceneName, sceneName);
				SetupLoadingScreenUI(loadingScreenTexture);
				if (sceneName == "Flight")
				{
					EnableCubemapLoadingDuringSceneTransitions = true;
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		private IEnumerator TransitionSceneCleanup()
		{
			QualitySettings.shadowDistance = Game.Instance.QualitySettings.Shadows.MaxShadowDistance;
			foreach (ElementTagHandler value in ((Dictionary<string, ElementTagHandler>)typeof(XmlLayoutUtilities).GetField("m_TagHandlers", BindingFlags.Static | BindingFlags.NonPublic).GetValue(null)).Values)
			{
				value.SetInstance(null, null);
			}
			TerrainGeneratorCacheData.CleanupOnSceneTransition();
			MapItem.OnSceneTransition();
			OrbitMath.ResetPools();
			yield return new WaitForEndOfFrame();
			yield return new WaitForEndOfFrame();
			GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, blocking: true);
		}

		private void UnloadLoadingScreenTexture()
		{
			_transitionImage.texture = null;
			if (_loadingScreenTexture == null)
			{
				return;
			}
			try
			{
				if (_loadingScreenTexture.DisposalMethod == LoadingScreenTextureDisposalMethod.UnloadAsset)
				{
					Resources.UnloadAsset(_loadingScreenTexture.Texture);
				}
				else if (_loadingScreenTexture.DisposalMethod == LoadingScreenTextureDisposalMethod.Destroy)
				{
					UnityEngine.Object.Destroy(_loadingScreenTexture.Texture);
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			_loadingScreenTexture = null;
		}

		private void UpdateCurrentSceneInfo(string sceneName)
		{
			InDesignerScene = sceneName == "Design";
			InFlightScene = sceneName == "Flight";
			InMenuScene = sceneName == "Menu";
			InPlanetStudioScene = sceneName == "PlanetStudio";
			InTechTreeScene = sceneName == "TechTree";
		}
	}
}
