using System.Collections;
using System.Collections.Generic;
using System.IO;
using Client;
using Easing;
using Factory;
using FixMath;
using Gif.Components;
using Motorways.Audio;
using Motorways.Models;
using Motorways.Views.Trains;
using Popups;
using Screens;
using UnityEngine;
using UnityEngine.UI;

namespace Motorways.Views
{
	public class MovieScreen : BaseScalingScreen, IGameStartScreen
	{
		private enum ScreenState
		{
			Idle = 0,
			Recording = 1,
			Playing = 2,
			Paused = 3
		}

		private static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("MovieScreen");

		[Dependency]
		private ISoftwareCapabilities _softwareCapabilities;

		[Dependency]
		private PlayerActionController _playerActionController;

		[SerializeField]
		private RectTransform _frameRect;

		[SerializeField]
		private RectTransform _frameRectBorder;

		[SerializeField]
		private RectTransform _frameRectLeft;

		[SerializeField]
		private RectTransform _frameRectRight;

		[SerializeField]
		private RectTransform _frameRectTop;

		[SerializeField]
		private RectTransform _frameRectBottom;

		[SerializeField]
		private RectTransform _progressbarFill;

		[SerializeField]
		private RawImage _gifImage;

		[SerializeField]
		private Image _playImage;

		[SerializeField]
		private GameObject _saveButtonAnchor;

		[SerializeField]
		private Animator _playButtonAnimator;

		[SerializeField]
		private Sprite _playSprite;

		[SerializeField]
		private Sprite _pauseSprite;

		[SerializeField]
		private Sprite _loadingSprite;

		[Header("GIF Capture")]
		[SerializeField]
		[Tooltip("How much faster to run the simulation.")]
		private float SimulationSpeed = 5f;

		[Tooltip("Amount of frames to capture.")]
		[SerializeField]
		private int TotalFrames = 100;

		[SerializeField]
		[Tooltip("Gif resulting framerate.")]
		private int FrameRate = 12;

		[SerializeField]
		[Tooltip("Multiplied by the game's camera scale to get the screen's camera scale.")]
		private float CameraScale = 2f;

		[Tooltip("The padding between the frame and game playable area.")]
		[SerializeField]
		private float Padding = 40f;

		[SerializeField]
		[Tooltip("How long (in seconds) to run the simulation before capturing frames? Used to spin up the trails.")]
		private float WarmUpDuration = 1f;

		private static readonly int LoadingBool = Animator.StringToHash("Loading");

		protected MotorwaysGame _game;

		protected CityDefinition _newCity;

		protected MapDefinition _newMapDefinition;

		protected MapChallenge _newMapChallenge;

		private string _folderString = "";

		private float _desiredZoom;

		private Vector2 _desiredPosition;

		private Vector2 _oldCameraPosition;

		private Texture2D[] _frames;

		private int _currentFrame;

		private float _currentFrameTime;

		private ScreenState _state;

		private IEnumerator _gifCaptureCoroutine;

		private const float PlaybackFrameTime = 0.08f;

		private MemoryStream _gifStream;

		private AnimatedGifEncoder _gifEncoder;

		private RenderTexture _gifRenderTarget;

		private const float DeltaTime = 0.05f;

		private const float WarmUpProgressAmount = 0.2f;

		private ScreenState State
		{
			get
			{
				return _state;
			}
			set
			{
				if (_state != value)
				{
					_state = value;
					if (_state == ScreenState.Recording)
					{
						_playImage.sprite = _loadingSprite;
						_playButtonAnimator.SetBool(LoadingBool, value: true);
					}
					else if (_state == ScreenState.Playing)
					{
						_playImage.sprite = _pauseSprite;
						_playButtonAnimator.SetBool(LoadingBool, value: false);
					}
					else
					{
						_playImage.sprite = _playSprite;
						_playButtonAnimator.SetBool(LoadingBool, value: false);
					}
				}
			}
		}

		public void OnBackPressed()
		{
			if (_canvasGroup.CanvasGroup.blocksRaycasts)
			{
				_screenStack.PopOneScreen();
			}
		}

		public void OnGifCaptureButtonPressed()
		{
			if (State == ScreenState.Idle)
			{
				RecordGif();
			}
			else if (State == ScreenState.Playing || State == ScreenState.Paused)
			{
				SaveGif();
			}
		}

		public void OnPlayButtonPressed()
		{
			if (State == ScreenState.Idle)
			{
				RecordGif();
			}
			else if (State == ScreenState.Playing)
			{
				State = ScreenState.Paused;
			}
			else if (State == ScreenState.Paused)
			{
				State = ScreenState.Playing;
			}
		}

		private void SaveGif()
		{
			if (!Diagnostics.Verify(!string.IsNullOrEmpty(_folderString), "Parent folder string isn't set!"))
			{
				_folderString = "Mini Motorways";
			}
			StringKey stringKey = _appScope.Get<StringKey>();
			stringKey.InitWithString(_game.MapDefinition.mapName);
			StandaloneLocString standaloneLocString = StandaloneLocString.CreateString(_appScope, stringKey);
			_softwareCapabilities.SaveGif(_gifStream.ToArray(), standaloneLocString.ToString(), _folderString, out var messageId, out var messageHeaderId);
			if (messageId != StringId.None)
			{
				popupStack.PushPopup<ChallengeInfoPopup>().Initialise(_appScope, messageHeaderId, messageId);
			}
		}

		public override void OnCreatedInScope(IScope scope)
		{
			base.OnCreatedInScope(scope);
			StandaloneLocString standaloneLocString = StandaloneLocString.CreateString(_appScope, StringId.MiniMotorways);
			_folderString = standaloneLocString.ToString();
			_appScope.Release(standaloneLocString);
			_frames = new Texture2D[TotalFrames];
			_gifImage.enabled = false;
			_canvas.worldCamera = _gameCamera.UICamera;
		}

		private void Update()
		{
			if (State != ScreenState.Playing)
			{
				return;
			}
			_currentFrameTime += Time.deltaTime;
			if (_currentFrameTime >= 0.08f)
			{
				_currentFrameTime -= 0.08f;
				_gifImage.texture = _frames[_currentFrame];
				_currentFrame++;
				if (_currentFrame >= _frames.Length)
				{
					_currentFrame = 0;
				}
			}
		}

		public override void TransitionOut(ScreenStack.MotorwaysScreen inScreen)
		{
			if (_gifCaptureCoroutine != null)
			{
				_gameCamera.PostProcessingEnabled = true;
				_canvasGroup.SetBlocksRaycasts(doesBlockRaycasts: true);
				StopCoroutine(_gifCaptureCoroutine);
				_gifCaptureCoroutine = null;
			}
			_canvas.renderMode = RenderMode.ScreenSpaceOverlay;
			base.TransitionOut(inScreen);
			ReleaseGame();
			GameContainerScreen activeScreen = _screenStack.GetActiveScreen<GameContainerScreen>();
			activeScreen.SetGameSuspended(suspendGame: false);
			Game activeGame = activeScreen.GetActiveGame();
			ViewClient viewClient = activeGame.Scope.Get<ViewClient>();
			viewClient.SetAllGameObjectsEnabled(enabled: true);
			foreach (DestinationView view in viewClient.GetViews<DestinationView>())
			{
				view.SetPinViewVisible(isVisible: true);
			}
			foreach (VehicleView view2 in viewClient.GetViews<VehicleView>())
			{
				view2.SkipHeadlightResponseTime = false;
			}
			(activeGame as MotorwaysGame).StartAudio();
			_saveButtonAnchor.SetActive(value: false);
			AudioSystem.Instance.UpdateVolume(_player.VolumeSetting);
		}

		public override void TransitionOutTick()
		{
			base.TransitionOutTick();
			GameContainerScreen activeScreen = _screenStack.GetActiveScreen<GameContainerScreen>();
			ResizeFrame(activeScreen.GetActiveGame());
			_canvasGroup.Alpha = Mathf.Clamp01(1f - TransitionOutPercentage() * 2f);
			float t = Easings.CubicEaseInOut(TransitionOutPercentage());
			Vector3 position = Vector3.Lerp(_desiredPosition, _oldCameraPosition, t);
			_gameCamera.SetPosition(position);
		}

		public override void OnTransitionedOut()
		{
			base.OnTransitionedOut();
			(_screenStack.GetActiveScreen<GameContainerScreen>().GetActiveGame() as MotorwaysGame)?.StartAudio();
		}

		public override void OnTransitionedIn()
		{
			base.OnTransitionedIn();
			ResizeFrame(_game);
			_appScope.Get<InputState>().BlockGameInput = true;
			_playerActionController.CancelAllActions();
			_canvas.renderMode = RenderMode.ScreenSpaceCamera;
		}

		public virtual void PrepareForNewGame(CityDefinition newCity, MapDefinition newMapDefinition, MotorwaysGame game, MapChallenge newMapChallenge = null, bool startPaused = false)
		{
			_game = game;
			_newCity = newCity;
			_newMapDefinition = newMapDefinition;
			_newMapChallenge = newMapChallenge;
			RegisterThemeComponents(_themeDatabase.GetTheme());
		}

		public override void RegisterThemeComponents(ITheme theme)
		{
			base.RegisterThemeComponents(theme);
			if (!(_newCity != null))
			{
				return;
			}
			List<IThemeComponent> list = new List<IThemeComponent>();
			_newCity.GetComponentsInChildren(list);
			if (list != null)
			{
				foreach (IThemeComponent item in list)
				{
					item.InitializeTheme(_themeDatabase);
				}
			}
			if (themeComponents == null)
			{
				themeComponents = list;
			}
			else
			{
				themeComponents.AddRange(list);
			}
		}

		public override void TransitionInTick()
		{
			base.TransitionInTick();
			float t = Easings.CubicEaseInOut(TransitionInPercentage());
			_canvasGroup.Alpha = Mathf.Clamp01(TransitionInPercentage() * 2f);
			_gameCamera.OrthographicSize = Mathf.Lerp(_previousCameraZoom, _desiredZoom, t);
			Vector3 position = Vector3.Lerp(_transitionDetails.spline.inPoint, _desiredPosition, t);
			_gameCamera.SetPosition(position);
			ResizeFrame(_game);
		}

		private void ResizeFrame(Game game)
		{
			Rect areaToCapture = GetAreaToCapture(game);
			_frameRect.sizeDelta = areaToCapture.size / _frameRect.lossyScale;
			float size = (_rectTransform.sizeDelta.x - _frameRectBorder.rect.width) / 2f + 1f;
			float height = _frameRectBorder.rect.height;
			_frameRectLeft.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, size);
			_frameRectLeft.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
			_frameRectRight.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, size);
			_frameRectRight.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
			float size2 = _rectTransform.sizeDelta.y / 2f - _frameRectBorder.rect.height / 2f + _frameRect.localPosition.y;
			_frameRectTop.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, size2);
			float size3 = _rectTransform.sizeDelta.y / 2f - _frameRectBorder.rect.height / 2f - _frameRect.localPosition.y;
			_frameRectBottom.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, size3);
		}

		public override void TransitionIn(ScreenStack.MotorwaysScreen outScreen)
		{
			_saveButtonAnchor.SetActive(value: false);
			State = ScreenState.Idle;
			SetProgressBarFill(0f);
			GameContainerScreen gameContainerScreen = _appScope.Get<GameContainerScreen>();
			if (gameContainerScreen != null)
			{
				gameContainerScreen.SetGameSuspended(suspendGame: true);
				MotorwaysGame obj = gameContainerScreen.GetActiveGame() as MotorwaysGame;
				obj.StopAudio();
				obj.Scope.Get<ViewClient>().SetAllGameObjectsEnabled(enabled: false);
			}
			if (_game == null)
			{
				_game = _appScope.Get<MotorwaysGame>();
			}
			_game.SetMapDefinition(_newMapDefinition);
			_game.Start(_newCity, GameMode.Movie, _newMapChallenge, replaceExistingRules: true);
			AudioSystem.Instance.UpdateVolume(0);
			_game.SetPaused(isPaused: true);
			_game.Tick(0f);
			_game.Scope.Get<GameBehaviourModel>().CanGameOver = false;
			_game.Scope.Get<CityPlanModel>().SpawningMode = CityPlanModel.BuildingSpawningMode.None;
			foreach (VehicleView view in _game.Scope.Get<ViewClient>().GetViews<VehicleView>())
			{
				view.SkipHeadlightResponseTime = true;
			}
			PrepareForMovieCapture();
			SetDesiredCameraParameters();
			base.TransitionIn(outScreen);
			_oldCameraPosition = _transitionDetails.spline.inPoint;
		}

		public void PrepareForMovieCapture()
		{
			ViewClient viewClient = _game.Scope.Get<ViewClient>();
			foreach (DestinationView view in viewClient.GetViews<DestinationView>())
			{
				view.SetPinViewVisible(isVisible: false);
			}
			foreach (VehicleView view2 in viewClient.GetViews<VehicleView>())
			{
				view2.IsTrailActive = true;
			}
			foreach (TrainView view3 in viewClient.GetViews<TrainView>())
			{
				view3.IsTrailActive = true;
			}
		}

		private void ReleaseGame()
		{
			if (Diagnostics.Verify(_game != null, "Trying to release a game when we don't have one!"))
			{
				UnregisterThemeComponents();
				_game.StopAudio();
				_game.ClearPathfinder();
				_game.Scope.ParentScope.Release(_game);
				_game = null;
				Object.Destroy(_newCity.gameObject);
			}
		}

		private void SetDesiredCameraParameters()
		{
			Rect areaToCapture = GetAreaToCapture(_game);
			areaToCapture.min = _gameCamera.DefaultCamera.ScreenToWorldPoint(areaToCapture.min);
			areaToCapture.max = _gameCamera.DefaultCamera.ScreenToWorldPoint(areaToCapture.max);
			float a = areaToCapture.height / 2f * CameraScale;
			float b = areaToCapture.width / _gameCamera.DefaultCamera.aspect / 2f * CameraScale;
			_desiredZoom = Mathf.Max(a, b);
			ClockModel clockModel = _game.Scope.Get<ClockModel>();
			Vector3Fixed playableAreaPositionAtTime = _game.Scope.Get<City>().GetPlayableAreaPositionAtTime(clockModel.ExpansionTime);
			_desiredPosition = new Vector2((float)playableAreaPositionAtTime.x, (float)playableAreaPositionAtTime.y);
		}

		private void OnDrawGizmosSelected()
		{
			if (_game != null)
			{
				Rect areaToCapture = GetAreaToCapture(_game);
				Gizmos.color = Color.red;
				Gizmos.DrawWireCube(areaToCapture.center, areaToCapture.size);
				areaToCapture.min = _gameCamera.DefaultCamera.ScreenToWorldPoint(areaToCapture.min);
				areaToCapture.max = _gameCamera.DefaultCamera.ScreenToWorldPoint(areaToCapture.max);
				Gizmos.color = Color.blue;
				Gizmos.DrawWireCube(areaToCapture.center, areaToCapture.size);
			}
		}

		private Rect GetAreaToCapture(Game game)
		{
			ClockModel clockModel = game.Scope.Get<ClockModel>();
			RectFixed simulationPlayableAreaAtTime = game.Scope.Get<City>().GetSimulationPlayableAreaAtTime(clockModel.ExpansionTime);
			Vector3 position = (Vector3)(simulationPlayableAreaAtTime.Min * TilemapModel.TileWidth);
			Vector3 position2 = (Vector3)(simulationPlayableAreaAtTime.Max * TilemapModel.TileWidth);
			position = _gameCamera.DefaultCamera.WorldToScreenPoint(position);
			position2 = _gameCamera.DefaultCamera.WorldToScreenPoint(position2);
			return new Rect
			{
				min = position + new Vector3(0f - Padding, 0f - Padding),
				max = position2 + new Vector3(Padding, Padding)
			};
		}

		public void RecordGif()
		{
			State = ScreenState.Recording;
			_game.SetPaused(isPaused: false);
			_canvasGroup.SetBlocksRaycasts(doesBlockRaycasts: false);
			Log.Info("Preparing Gif Capture");
			_gifStream = new MemoryStream();
			_gifEncoder = new AnimatedGifEncoder();
			_gifEncoder.Start(_gifStream);
			_gifEncoder.SetFrameRate(FrameRate);
			_gifEncoder.SetRepeat(0);
			Rect areaToCapture = GetAreaToCapture(_game);
			_gifRenderTarget = RenderTexture.GetTemporary((int)areaToCapture.width, (int)areaToCapture.height);
			_gifCaptureCoroutine = RecordFrames(areaToCapture, TotalFrames);
			StartCoroutine(_gifCaptureCoroutine);
		}

		private void CaptureFrame(Rect rect)
		{
			if (Diagnostics.Verify(_currentFrame < _frames.Length, "Capturing more frames than expected! Have {0} but currently trying to get frame {1}", _frames.Length, _currentFrame))
			{
				_frames[_currentFrame] = new Texture2D((int)rect.width, (int)rect.height, TextureFormat.RGB24, mipChain: false);
				_frames[_currentFrame].ReadPixels(rect, 0, 0);
				_frames[_currentFrame].Apply();
				_gifEncoder.AddFrame(_frames[_currentFrame]);
			}
			_currentFrame++;
		}

		private IEnumerator RecordFrames(Rect rect, int totalFrames)
		{
			_gameCamera.PostProcessingEnabled = false;
			for (float accumulatedTime = 0f; accumulatedTime < WarmUpDuration; accumulatedTime += 0.05f)
			{
				yield return new WaitForSecondsRealtime(0.05f);
				_game.Tick(0.05f * SimulationSpeed);
				SetProgressBarFill(0.2f * (accumulatedTime / WarmUpDuration));
			}
			for (int frameIndex = 0; frameIndex < totalFrames; frameIndex++)
			{
				Log.Info("Capturing gif frame {0} of {1}", frameIndex, totalFrames);
				_game.Tick(0.05f * SimulationSpeed);
				yield return new WaitForEndOfFrame();
				CaptureFrame(rect);
				SetProgressBarFill(0.2f + 0.8f * ((float)frameIndex / (float)totalFrames));
			}
			SetProgressBarFill(1f);
			_gifEncoder.Finish();
			_gifEncoder = null;
			Log.Info("Gif Capture complete!");
			RenderTexture.ReleaseTemporary(_gifRenderTarget);
			_gameCamera.PostProcessingEnabled = true;
			_canvasGroup.SetBlocksRaycasts(doesBlockRaycasts: true);
			State = ScreenState.Playing;
			_currentFrame = 0;
			_gifImage.enabled = true;
			_gifImage.texture = _frames[_currentFrame];
			_saveButtonAnchor.SetActive(value: true);
			_gifCaptureCoroutine = null;
		}

		private void SetProgressBarFill(float progress)
		{
			float x = _progressbarFill.parent.GetComponent<RectTransform>().sizeDelta.x;
			_progressbarFill.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, x * progress);
		}

		private void DestroyFrames()
		{
			for (int i = 0; i < TotalFrames; i++)
			{
				if (_frames[i] != null)
				{
					Object.Destroy(_frames[i]);
					_frames[i] = null;
				}
			}
		}

		public override void Reset()
		{
			base.Reset();
			_desiredZoom = 0f;
			_desiredPosition = default(Vector2);
			_oldCameraPosition = default(Vector2);
			DestroyFrames();
			State = ScreenState.Idle;
			_gifImage.enabled = false;
			_currentFrame = 0;
			_currentFrameTime = 0f;
			_saveButtonAnchor.SetActive(value: false);
		}
	}
}
