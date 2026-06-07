using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assets.Scripts.Analytics.Logging;
using Assets.Scripts.Audio;
using Assets.Scripts.Craft.Paint;
using Assets.Scripts.Flight;
using Assets.Scripts.Flight.Maps;
using Assets.Scripts.GuiNew;
using Assets.Scripts.Input;
using Assets.Scripts.Levels;
using Assets.Scripts.Scenes.Events;
using Assets.Scripts.UI;
using Assets.Scripts.UI.Dialogs;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.Scenes
{
	public class SceneManager : MonoBehaviour
	{
		private enum SceneTransitionState
		{
			Default = 0,
			SceneUnloading = 1,
			SceneLoading = 2,
			PostLoadDelay = 3,
			LoadingScreenFadeOut = 4
		}

		private const string DefaultLoadingText = "Loading...";

		private const float LoadScreenFadeTime = 0.4f;

		private const float MinimumLoadScreenTime = 0.5f;

		private bool _breakPostLoadDelay;

		[SerializeField]
		private Canvas _canvas;

		private ILoadingScreenTextureProvider _defaultLoadingScreenTextureProvider;

		private LoadingScreenTextureData _loadingScreenTexture;

		private SortedList<int, ILoadingScreenTextureProvider> _loadingScreenTextureProviders;

		private bool _paintTexturesProcessed;

		private List<Action> _postSceneLoadActions;

		private bool _queuedSceneTransition;

		[SerializeField]
		private CanvasGroup _transitionCanvasGroup;

		[SerializeField]
		private RawImage _transitionImage;

		[SerializeField]
		private TextMeshProUGUI _transitionLoadingText;

		[SerializeField]
		private TextMeshProUGUI _transitionLoadingTextXR;

		private SceneTransitionState _transitionState;

		public string CurrentScene => UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

		public string EndLevelReturnScene { get; set; }

		public bool InDesigner
		{
			get
			{
				if (!InDesignerScene)
				{
					return InFlightDesigner;
				}
				return true;
			}
		}

		public bool InDesignerScene { get; private set; }

		public bool InFlightDesigner => FlightSceneScript.Instance?.Designer?.Active == true;

		public bool InFlightScene { get; private set; }

		public bool InMenuScene { get; private set; }

		public Canvas LoadingScreenCanvas => _canvas;

		public bool SceneTransitionInProgress => _transitionState != SceneTransitionState.Default;

		public event EventHandler<SceneEventArgs> SceneLoaded;

		public event EventHandler<SceneEventArgs> SceneLoading;

		public event EventHandler<SceneTransitionEventArgs> SceneTransitionCompleted;

		public event EventHandler<SceneTransitionEventArgs> SceneTransitionStarted;

		public event EventHandler<SceneEventArgs> SceneUnloaded;

		public event EventHandler<SceneEventArgs> SceneUnloading;

		public static SceneManager Create(GameObject parent)
		{
			SceneManager sceneManager = Game.Instance.ResourceLoader.InstantiatePrefab<SceneManager>("Common/SceneManager");
			sceneManager.name = "SceneManager";
			if (parent != null)
			{
				sceneManager.transform.SetParent(parent.transform);
			}
			else
			{
				UnityEngine.Object.DontDestroyOnLoad(sceneManager.gameObject);
			}
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

		public Coroutine LoadDesigner(Action callback = null)
		{
			if (Game.Instance.Device.IsVRExclusiveBuild || Game.Instance.XRDeviceManager.HmdActive)
			{
				if (CurrentScene != "Terrain")
				{
					return LoadFlight();
				}
				return LoadMenu();
			}
			return LoadScene("Designer", callback);
		}

		public void LoadDesignerCompleted()
		{
			Time.fixedDeltaTime = 0.1f;
			Physics.autoSyncTransforms = true;
			GameState.Instance.RaiseDesignerEntered();
		}

		public Coroutine LoadFlight(string returnScene = null, string selectedCraftId = "__editor__.xml")
		{
			if (returnScene != null)
			{
				EndLevelReturnScene = returnScene;
			}
			Game.Instance.SelectedCraftId = selectedCraftId;
			return LoadScene("Terrain");
		}

		public void LoadLevelMenuWithMessage(string message, params object[] args)
		{
			bool flag = Game.Instance.Device.IsVRExclusiveBuild || Game.Instance.XRDeviceManager.HmdActive;
			LoadScene(flag ? "LevelMenuVR" : "MainMenu", delegate
			{
				Assets.Scripts.GuiNew.DialogScript.CreateDialog(showCancel: false).MessageText = ((args == null || args.Length == 0) ? message : string.Format(message, args));
			});
		}

		public Coroutine LoadMenu(Action callback = null)
		{
			bool flag = Game.Instance.Device.IsVRExclusiveBuild || Game.Instance.XRDeviceManager.HmdActive;
			return LoadScene(flag ? "LevelMenuVR" : "MainMenu", callback);
		}

		public Coroutine LoadScene(string sceneName, Action callback = null)
		{
			if (sceneName != "Terrain")
			{
				EndLevelReturnScene = null;
			}
			if (Game.Instance.Device.IsVRBuild && !SceneSupportsVR(sceneName))
			{
				Game.Instance.XRDeviceManager.SetXrActive(active: false);
			}
			return StartCoroutine(LoadSceneCoroutine(sceneName, callback));
		}

		public void LoadTerrainCompleted()
		{
			GameState instance = GameState.Instance;
			instance.RaiseMapEntered(instance.CurrentLevelName, instance.CurrentMapName);
		}

		public void LoadTraining()
		{
			LoadScene("Training");
		}

		public void QueuePostSceneLoadAction(Action action)
		{
			_postSceneLoadActions.Add(action);
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
			_postSceneLoadActions = new List<Action>();
			_queuedSceneTransition = false;
			_transitionState = SceneTransitionState.Default;
			OnSceneLoading(CurrentScene);
			RegisterDevConsoleCommands();
		}

		protected virtual void OnDestroy()
		{
		}

		protected virtual IEnumerator Start()
		{
			yield return new WaitForEndOfFrame();
			OnSceneLoaded(CurrentScene, GameState.Instance.IsInLevel, mapRestarted: false);
		}

		private static bool SceneSupportsVR(string sceneName)
		{
			return sceneName switch
			{
				"MainMenu" => true, 
				"LevelMenuVR" => true, 
				"Terrain" => true, 
				_ => false, 
			};
		}

		private IEnumerator CompleteSceneTransition(string previousSceneName, string sceneName, float startTime)
		{
			try
			{
				_transitionState = SceneTransitionState.PostLoadDelay;
				_breakPostLoadDelay = false;
				GC.Collect();
				Resources.UnloadUnusedAssets();
				if (sceneName == "Terrain")
				{
					while (!(LevelBase.CurrentLevel?.Started ?? false) && !_breakPostLoadDelay)
					{
						yield return null;
					}
				}
				yield return null;
				yield return null;
				yield return null;
				float num = Time.realtimeSinceStartup - startTime;
				if (num < 0.5f && !_breakPostLoadDelay)
				{
					float time = 0.5f - num;
					yield return new WaitForSecondsRealtime(time);
				}
				_transitionState = SceneTransitionState.LoadingScreenFadeOut;
				_transitionLoadingText.enabled = false;
				_transitionLoadingTextXR.enabled = false;
				float a = 1f;
				while (a > 0f && !_breakPostLoadDelay)
				{
					a -= Time.unscaledDeltaTime / 0.4f;
					if (a < 0f)
					{
						a = 0f;
					}
					_transitionCanvasGroup.alpha = a;
					yield return null;
				}
				_transitionImage.texture = null;
				if (_loadingScreenTexture != null)
				{
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
				_canvas.gameObject.SetActive(value: false);
				this.SceneTransitionCompleted?.Invoke(this, new SceneTransitionEventArgs(previousSceneName, sceneName));
			}
			finally
			{
				_transitionState = SceneTransitionState.Default;
			}
		}

		private LoadingScreenTextureData GetLoadingScreenTexture(string previousSceneName, string sceneName)
		{
			LoadingScreenTextureData loadingScreenTextureData = null;
			foreach (ILoadingScreenTextureProvider value in _loadingScreenTextureProviders.Values)
			{
				loadingScreenTextureData = value.GetLoadingScreenTexture(sceneName, previousSceneName);
				if (loadingScreenTextureData != null)
				{
					break;
				}
			}
			if (loadingScreenTextureData == null)
			{
				loadingScreenTextureData = _defaultLoadingScreenTextureProvider.GetLoadingScreenTexture(sceneName, previousSceneName);
			}
			if (loadingScreenTextureData == null)
			{
				loadingScreenTextureData = DefaultLoadingScreenTextureProvider.DefaultLoadingScreen;
			}
			return loadingScreenTextureData;
		}

		private IEnumerator LoadSceneCoroutine(string sceneName, Action callback = null)
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
				if (_transitionState == SceneTransitionState.PostLoadDelay)
				{
					_breakPostLoadDelay = true;
				}
			}
			float startTime = Time.realtimeSinceStartup;
			string previousSceneName = CurrentScene;
			bool wasInLevel = GameState.Instance.IsInLevel;
			bool mapRestarted = previousSceneName == "Terrain" && sceneName == "Terrain";
			StartSceneTransition(previousSceneName, sceneName);
			yield return endOfFrame;
			UnityEngine.SceneManagement.SceneManager.LoadScene("Transition", LoadSceneMode.Additive);
			yield return endOfFrame;
			AudioListener audioListener = UnityEngine.SceneManagement.SceneManager.GetSceneByName("Transition").GetRootGameObjects()[0].GetComponent<AudioListener>();
			audioListener.enabled = false;
			_canvas.worldCamera = UnityEngine.SceneManagement.SceneManager.GetSceneByName("Transition").GetRootGameObjects()[0].GetComponent<Camera>();
			OnSceneUnloading(previousSceneName, sceneName);
			yield return UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(previousSceneName);
			audioListener.enabled = true;
			yield return endOfFrame;
			OnSceneUnloaded(previousSceneName);
			Transform transform = _canvas.worldCamera.transform;
			Vector3 right = transform.right;
			float z = Vector3.Angle(Vector3.ProjectOnPlane(right, Vector3.up), right) * Mathf.Sign(transform.position.y - right.y);
			_transitionLoadingTextXR.transform.localEulerAngles = new Vector3(0f, 0f, z);
			yield return endOfFrame;
			yield return endOfFrame;
			yield return endOfFrame;
			yield return endOfFrame;
			yield return PerformTransitionSceneActions();
			OnSceneLoading(sceneName);
			UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
			yield return null;
			yield return null;
			OnSceneLoaded(sceneName, !wasInLevel && GameState.Instance.IsInLevel, mapRestarted);
			yield return CompleteSceneTransition(previousSceneName, sceneName, startTime);
			callback?.Invoke();
			yield return PerformPostSceneLoadTasks(sceneName);
		}

		private void OnSceneLoaded(string sceneName, bool levelLoaded, bool mapRestarted)
		{
			InputWrapper.ApplySceneControls();
			GameState instance = GameState.Instance;
			if (levelLoaded)
			{
				instance.RaiseLevelEntered(instance.CurrentLevelName, instance.CurrentMapName);
			}
			if (mapRestarted)
			{
				instance.RaiseLevelRestarted();
			}
			try
			{
				this.SceneLoaded?.Invoke(this, new SceneEventArgs(sceneName));
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			if (sceneName == "Designer")
			{
				LoadDesignerCompleted();
			}
			else if (sceneName == "Terrain")
			{
				LoadTerrainCompleted();
			}
		}

		private void OnSceneLoading(string sceneName)
		{
			InDesignerScene = sceneName == "Designer";
			InFlightScene = sceneName == "Terrain";
			InMenuScene = sceneName == "MainMenu" || sceneName == "LevelMenuVR";
			AudioMixing.IsInDesigner = !InFlightScene;
			if (Game.Instance.CurrentLevel == null || Game.Instance.CurrentMap == null)
			{
				Game.Instance.CurrentLevel = Game.Instance.LevelDatabase.GetLevel("LevelSandbox");
				Game.Instance.CurrentMap = new DefaultMap();
			}
			GameState instance = GameState.Instance;
			instance.IsInDesigner = InDesignerScene;
			instance.IsInLevel = InDesignerScene || InFlightScene;
			instance.CurrentLevelName = (instance.IsInLevel ? Game.Instance.CurrentLevel.Name : string.Empty);
			instance.CurrentMapName = (instance.IsInLevel ? Game.Instance.CurrentMap.Name : string.Empty);
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
			try
			{
				this.SceneUnloaded?.Invoke(this, new SceneEventArgs(sceneName));
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		private void OnSceneUnloading(string sceneName, string nextSceneName)
		{
			GameState instance = GameState.Instance;
			if (sceneName == "Designer")
			{
				instance.RaiseDesignerExited();
				instance.IsInDesigner = false;
				if (nextSceneName != "Designer" && nextSceneName != "Terrain")
				{
					instance.RaiseLevelExited(instance.CurrentLevelName, instance.CurrentMapName);
					instance.IsInLevel = false;
					instance.CurrentLevelName = string.Empty;
					instance.CurrentMapName = string.Empty;
				}
			}
			else if (sceneName == "Terrain")
			{
				instance.RaiseMapExited(instance.CurrentLevelName, instance.CurrentMapName);
				if (nextSceneName != "Terrain" && nextSceneName != "Designer")
				{
					instance.RaiseLevelExited(instance.CurrentLevelName, instance.CurrentMapName);
					instance.IsInLevel = false;
					instance.CurrentLevelName = string.Empty;
					instance.CurrentMapName = string.Empty;
				}
			}
			try
			{
				this.SceneUnloading?.Invoke(this, new SceneEventArgs(sceneName));
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		private IEnumerator PerformPostSceneLoadTasks(string sceneName)
		{
			bool queuedSceneTransition = _queuedSceneTransition;
			if (sceneName == "MainMenu" && !_paintTexturesProcessed && !queuedSceneTransition)
			{
				_paintTexturesProcessed = true;
				yield return ProcessPendingPaintTextures();
			}
			if (queuedSceneTransition || _postSceneLoadActions.Count <= 0)
			{
				yield break;
			}
			Action[] array = _postSceneLoadActions.ToArray();
			_postSceneLoadActions.Clear();
			Action[] array2 = array;
			foreach (Action action in array2)
			{
				try
				{
					action?.Invoke();
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
		}

		private IEnumerator PerformTransitionSceneActions()
		{
			TransitionSceneCleanup();
			Game.Instance.Settings.SaveIfNecessary();
			yield return null;
			MobileLogger.ForceRealtimeLogging = false;
			MobileLogger.FlushPendingLogsToFile();
		}

		private IEnumerator ProcessPendingPaintTextures()
		{
			yield return null;
			PaintTextureManager paintTextureManager = Game.Instance.PaintTextureManager;
			if (paintTextureManager.HasTexturesPendingProcessing)
			{
				_paintTexturesProcessed = true;
				ProgressBarDialogScript progressDialog = Game.Instance.UserInterface.CreateProgressBarDialog();
				progressDialog.Title = "Processing Paint Textures";
				progressDialog.ShowCancelButton = false;
				Progress<(string, float)> progress = new Progress<(string, float)>(delegate((string, float) x)
				{
					progressDialog.ProgressText = x.Item1;
					progressDialog.SetProgress(x.Item2);
				});
				Task task = paintTextureManager.ProcessPendingTexturesAsync(progress);
				yield return new WaitUntil(() => task.IsCompleted);
				progressDialog.Close();
				if (task.Exception != null)
				{
					Debug.LogException(task.Exception);
					Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.Okay, "An error occurred processing paint textures. See the log for more details.");
				}
				paintTextureManager.RebuildTextureArrays();
			}
		}

		private void RegisterDevConsoleCommands()
		{
		}

		private void StartSceneTransition(string previousSceneName, string sceneName)
		{
			_queuedSceneTransition = false;
			_transitionState = SceneTransitionState.SceneUnloading;
			try
			{
				this.SceneTransitionStarted?.Invoke(this, new SceneTransitionEventArgs(previousSceneName, sceneName));
				_canvas.gameObject.SetActive(value: true);
				_transitionCanvasGroup.alpha = 1f;
				_loadingScreenTexture = GetLoadingScreenTexture(previousSceneName, sceneName);
				float num = GetComponentInChildren<CanvasScaler>()?.scaleFactor ?? 1f;
				Texture texture = _loadingScreenTexture.Texture;
				float num2 = Mathf.Max((float)Screen.width / num / (float)texture.width, (float)Screen.height / num / (float)texture.height);
				_transitionImage.rectTransform.sizeDelta = new Vector2((float)texture.width * num2 + 2f, (float)texture.height * num2 + 2f);
				_transitionImage.texture = texture;
				bool flag = Game.Instance.Device.IsVRExclusiveBuild || (Game.Instance.Device.IsVRBuild && Game.Instance.XRDeviceManager.HmdActive);
				_transitionLoadingText.enabled = _loadingScreenTexture.ShowLoadingText && !flag;
				_transitionLoadingTextXR.enabled = _loadingScreenTexture.ShowLoadingText && flag && previousSceneName != "Startup";
				_transitionLoadingText.text = "Loading...";
				_transitionLoadingTextXR.text = "Loading...";
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		private void TransitionSceneCleanup()
		{
			Physics.autoSyncTransforms = false;
			Game.Instance.CraftUpdateManager.OnSceneTransitionCleanup();
			LevelBase.CurrentLevel = null;
		}
	}
}
