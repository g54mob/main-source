#define ENABLE_DEBUG_LOGS
using System;
using System.Collections;
using System.Collections.Generic;
using Data.Quests;
using Data.Quests.SubQuestEvents;
using Data.Variables;
using Events;
using Logic.Factory;
using NaughtyAttributes;
using Presentation.Locators;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using UnityEngine.Video;
using Utils;

namespace Logic.Story
{
	public class IntroManager : MonoBehaviour
	{
		private static readonly int Presence = Shader.PropertyToID("_presence");

		private const string INTRO_PP_RENDERFEATURE_NAME = "IntroPostProcess";

		private const float VIDEO_PREPARE_TIMEOUT_TIME = 6f;

		private static readonly string INTRO_VIDEO_PATH = Application.streamingAssetsPath + "/Videos/Intro/";

		[SerializeField]
		private Material _introPostProcessMaterial;

		[SerializeField]
		private List<SubQuestSO> _introSubQuests = new List<SubQuestSO>();

		[SerializeField]
		private List<string> _videoClipsURLs = new List<string>();

		[SerializeField]
		private VideoPlayer _videoPlayer;

		[SerializeField]
		private Canvas _cameraCanvas;

		[SerializeField]
		private InputActionReference _uiVisibilityActionRef;

		[SerializeField]
		private InputActionReference _escapeActionRef;

		[SerializeField]
		private BoolVariableSO _uiVisibility;

		[SerializeField]
		private FocusCameraSubQuestEventSO _focusCameraEvent;

		[SerializeField]
		private QuestManagerLocator _questManagerLocator;

		[SerializeField]
		private InputActionAsset _inputActionAsset;

		[SerializeField]
		private CameraLocator _cameraLocator;

		[SerializeField]
		private GlobalVolumeManagerLocator _globalVolumeManagerLocator;

		[SerializeField]
		private RenderFeatureRetriever _renderFeatureRetriever;

		[SerializeField]
		private IntroManagerLocator _introManagerLocator;

		[SerializeField]
		private ShowTutorialSO _showTutorialSO;

		[SerializeField]
		private BoolVariableSO _factoryFloorActionsEnabled;

		[SerializeField]
		private BoolVariableSO _zenModeSO;

		[SerializeField]
		private AudioManagerLocator _audioManagerLocator;

		[SerializeField]
		private BaseEvent _finishedLoadingSaveEvent;

		[SerializeField]
		private FactoryLoader _factoryLoader;

		private Coroutine _introCoroutine;

		private bool _completedIntro;

		private Coroutine _playVideoCoroutine;

		private bool _introHasStarted;

		public bool CompletedIntro => _completedIntro;

		public event Action OnIntroStart;

		public event Action OnIntroEnd;

		private void Awake()
		{
			_introManagerLocator.IntroManager = this;
		}

		private void OnDisable()
		{
			ToggleIntroRenderFeatures(toggle: false);
			_introPostProcessMaterial.SetFloat(Presence, 0f);
			SetPlayingIntroSFX(active: false);
			_introHasStarted = false;
			if (_introCoroutine != null)
			{
				StopCoroutine(_introCoroutine);
			}
		}

		public void ResetToDefault()
		{
			_completedIntro = false;
			_introHasStarted = false;
		}

		public void ApplySaveData(bool completedIntro)
		{
			_completedIntro = completedIntro;
			TryStartIntro();
		}

		public void TryStartIntro()
		{
			if (!_introHasStarted)
			{
				_introHasStarted = true;
				if (_factoryLoader.HasFinishedLoadingSave)
				{
					StartIntroInternal();
				}
				else
				{
					_finishedLoadingSaveEvent.Register(StartIntroInternal);
				}
			}
		}

		private void StartIntroInternal()
		{
			_finishedLoadingSaveEvent.UnRegister(StartIntroInternal);
			if (_completedIntro || _zenModeSO.Value || !_showTutorialSO.Value)
			{
				SkipIntro();
			}
			else
			{
				_introCoroutine = StartCoroutine(IntroCoroutine());
			}
		}

		private void SkipIntro()
		{
			_questManagerLocator.QuestManager.StartQuest();
			CompleteIntro();
		}

		private IEnumerator IntroCoroutine()
		{
			InitializeIntro();
			yield return InitAndWaitForIntroVideo();
			this.OnIntroStart?.Invoke();
			yield return new WaitForSeconds(1f);
			yield return ToggleIntroPostProcess(appear: true);
			yield return ShowIntroNarrations();
			yield return ToggleIntroPostProcess(appear: false);
			_questManagerLocator.QuestManager.StartQuest();
			yield return null;
			CompleteIntro();
		}

		private void SetPlayingIntroSFX(bool active)
		{
			_audioManagerLocator.AudioManager.SetIntroSnapshot(active);
			if (active)
			{
				_audioManagerLocator.AudioManager.PlayIntroLoop();
			}
			else
			{
				_audioManagerLocator.AudioManager.StopIntroLoop();
			}
		}

		private void CompleteIntro()
		{
			_cameraCanvas.gameObject.SetActive(value: false);
			ToggleFactoryInputs(toggle: true);
			TogglePostProcessing(toggle: true);
			ToggleUIVisibility(toggle: true);
			ToggleIntroRenderFeatures(toggle: false);
			this.OnIntroEnd?.Invoke();
			_completedIntro = true;
		}

		private void InitializeIntro()
		{
			_introPostProcessMaterial.SetFloat(Presence, 0f);
			_cameraCanvas.worldCamera = _cameraLocator.Camera;
			_cameraCanvas.planeDistance = 1f;
			_cameraCanvas.gameObject.SetActive(value: true);
			_focusCameraEvent.Execute();
			ResetQuestsValidators();
			TogglePostProcessing(toggle: false);
			ToggleFactoryInputs(toggle: false);
			ToggleUIVisibility(toggle: false);
			ToggleIntroRenderFeatures(toggle: true);
			SetPlayingIntroSFX(active: true);
		}

		private IEnumerator InitAndWaitForIntroVideo()
		{
			RenderTexture targetTexture = (RenderTexture)(_videoPlayer.GetComponent<RawImage>().texture = new RenderTexture(3840, 2160, 0, RenderTextureFormat.DefaultHDR, RenderTextureReadWrite.Linear));
			_videoPlayer.targetTexture = targetTexture;
			_videoPlayer.isLooping = true;
			yield return PlayVideo(_videoClipsURLs[0]);
		}

		private IEnumerator PlayVideo(string videoUrl)
		{
			try
			{
				_videoPlayer.url = INTRO_VIDEO_PATH + videoUrl;
				_videoPlayer.Prepare();
			}
			catch (Exception ex)
			{
				this.Log(ex.ToString(), "PlayVideo", 209);
			}
			float safeTimeout = 0f;
			while (!_videoPlayer.isPrepared)
			{
				safeTimeout += Time.deltaTime;
				if (safeTimeout >= 6f)
				{
					yield break;
				}
				yield return null;
			}
			try
			{
				_videoPlayer.Play();
			}
			catch (Exception ex2)
			{
				this.Log(ex2.ToString(), "PlayVideo", 230);
			}
			while (!_videoPlayer.isPlaying)
			{
				yield return null;
			}
		}

		private IEnumerator ShowIntroNarrations()
		{
			for (int i = 0; i < _introSubQuests.Count; i++)
			{
				_introSubQuests[i].OnStart();
				if (i != 0)
				{
					if (_playVideoCoroutine != null)
					{
						StopCoroutine(_playVideoCoroutine);
					}
					_playVideoCoroutine = StartCoroutine(PlayVideo(_videoClipsURLs[i]));
				}
				while (!_introSubQuests[i].Validator.IsValid())
				{
					yield return null;
				}
			}
			SetPlayingIntroSFX(active: false);
			_videoPlayer.isLooping = false;
			IntroManager introManager = this;
			List<string> videoClipsURLs = _videoClipsURLs;
			yield return introManager.PlayVideo(videoClipsURLs[videoClipsURLs.Count - 1]);
			while (_videoPlayer.isPlaying)
			{
				yield return null;
			}
		}

		private IEnumerator ToggleIntroPostProcess(bool appear)
		{
			if (appear)
			{
				for (float timer = 0f; timer <= 1f; timer += Time.deltaTime)
				{
					_introPostProcessMaterial.SetFloat(Presence, timer);
					yield return null;
				}
				_introPostProcessMaterial.SetFloat(Presence, 1f);
				yield break;
			}
			for (float timer = 1f; timer > 0f; timer -= Time.deltaTime)
			{
				_introPostProcessMaterial.SetFloat(Presence, timer);
				yield return null;
			}
			_introPostProcessMaterial.SetFloat(Presence, 0f);
		}

		private void ToggleIntroRenderFeatures(bool toggle)
		{
			foreach (ScriptableRendererFeature item in _renderFeatureRetriever.GetRenderFeaturesFromName("IntroPostProcess"))
			{
				item.SetActive(toggle);
			}
		}

		private void ToggleUIVisibility(bool toggle)
		{
			_uiVisibility.SetValue(toggle);
			if (toggle)
			{
				_escapeActionRef.action.Enable();
				_uiVisibilityActionRef.action.Enable();
			}
			else
			{
				_escapeActionRef.action.Disable();
				_uiVisibilityActionRef.action.Disable();
			}
		}

		private void ToggleFactoryInputs(bool toggle)
		{
			InputActionMap inputActionMap = _inputActionAsset.FindActionMap("FactoryFloor");
			if (toggle)
			{
				inputActionMap.Enable();
			}
			else
			{
				inputActionMap.Disable();
			}
			_factoryFloorActionsEnabled.SetValue(toggle);
		}

		private void ResetQuestsValidators()
		{
			foreach (SubQuestSO introSubQuest in _introSubQuests)
			{
				introSubQuest.Validator.Reset();
			}
		}

		private void TogglePostProcessing(bool toggle)
		{
			_cameraLocator.Camera.GetUniversalAdditionalCameraData().renderPostProcessing = toggle;
		}

		[Button("Skip Intro", EButtonEnableMode.Playmode)]
		public void DebugSkipIntro()
		{
			if (_introCoroutine != null)
			{
				StopCoroutine(_introCoroutine);
			}
			_introPostProcessMaterial.SetFloat(Presence, 1f);
			SetPlayingIntroSFX(active: false);
			_questManagerLocator.QuestManager.StartQuest();
			CompleteIntro();
		}
	}
}
