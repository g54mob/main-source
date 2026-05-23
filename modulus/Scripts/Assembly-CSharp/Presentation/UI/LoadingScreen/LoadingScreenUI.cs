#define ENABLE_DEBUG_ERRORS
using System;
using System.Collections;
using DG.Tweening;
using Events;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using Utils;

namespace Presentation.UI.LoadingScreen
{
	public class LoadingScreenUI : MonoBehaviour
	{
		[SerializeField]
		private BaseEvent _finishedLoadingSaveEvent;

		[SerializeField]
		private BaseEvent _loadingScreenCreatedEvent;

		[SerializeField]
		private BaseEvent _loadingScreenDestroyedEvent;

		[SerializeField]
		private float _minimumLoadingScreenTime = 1f;

		[SerializeField]
		private TextMeshProUGUI _loadingSaveFileName;

		[SerializeField]
		private Transform _bgImagesParent;

		[Header("Fade Out")]
		[SerializeField]
		private CanvasGroup _canvasGroup;

		[SerializeField]
		private float _fadeOutDelay = 1f;

		[SerializeField]
		private float _fadeOutSeconds = 1f;

		[SerializeField]
		private Ease _fadeOutEase = Ease.Linear;

		private float _timeShown;

		private bool _shouldDestroy;

		public Action OnShowLoadingScreen = delegate
		{
		};

		private void Awake()
		{
			_timeShown = 0f;
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
			_finishedLoadingSaveEvent.Register(DestroyLoadingScreen);
			RandomizeLoadingScreenBg();
		}

		private void RandomizeLoadingScreenBg()
		{
			int childCount = _bgImagesParent.childCount;
			int index = UnityEngine.Random.Range(0, childCount);
			for (int i = 0; i < childCount; i++)
			{
				_bgImagesParent.GetChild(i).gameObject.SetActive(value: false);
			}
			_bgImagesParent.GetChild(index).gameObject.SetActive(value: true);
		}

		private void Start()
		{
			StartCoroutine(IStart());
			_loadingScreenCreatedEvent.Fire();
			IEnumerator IStart()
			{
				yield return new WaitForFixedUpdate();
				OnShowLoadingScreen();
				OnShowLoadingScreen = delegate
				{
				};
			}
		}

		private void OnDestroy()
		{
			_finishedLoadingSaveEvent.UnRegister(DestroyLoadingScreen);
			_loadingScreenDestroyedEvent.Fire();
		}

		private void Update()
		{
			_timeShown += Time.deltaTime;
			if (_shouldDestroy && _timeShown > _minimumLoadingScreenTime)
			{
				DestroyLoadingScreen();
			}
		}

		[Button(null, EButtonEnableMode.Always)]
		public void DestroyLoadingScreen()
		{
			if (_timeShown > _minimumLoadingScreenTime)
			{
				_canvasGroup.DOFade(0f, _fadeOutSeconds).SetEase(_fadeOutEase).SetDelay(_fadeOutDelay)
					.OnComplete(OnFinishedFadeOut);
				_shouldDestroy = false;
			}
			else
			{
				_shouldDestroy = true;
			}
		}

		private void OnFinishedFadeOut()
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}

		public void SetSaveFileNameEmpty()
		{
			_loadingSaveFileName.SetText(string.Empty);
		}

		public void SetSaveFileName(SaveFile? saveFile)
		{
			if (!saveFile.HasValue)
			{
				_loadingSaveFileName.SetText(string.Empty);
				return;
			}
			if (!string.IsNullOrEmpty(saveFile.Value.Info.AutoSaveSourceSaveName))
			{
				_loadingSaveFileName.SetText(LocalizationUtility.GetLocalizedText("AutoSave.Autosave") + "(" + saveFile.Value.Info.AutoSaveSourceSaveName.UnsanitizeSpaces() + ")");
				return;
			}
			if (!string.IsNullOrEmpty(saveFile.Value.Info.GetDisplaySaveName(saveFile.Value)))
			{
				_loadingSaveFileName.SetText(saveFile.Value.Info.GetDisplaySaveName(saveFile.Value));
				return;
			}
			this.LogError("Displayname was empty on savefile " + saveFile.Value.Path, "SetSaveFileName", 121);
			_loadingSaveFileName.SetText(string.Empty);
		}
	}
}
