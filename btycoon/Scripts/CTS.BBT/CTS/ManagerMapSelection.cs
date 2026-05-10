using System;
using System.Collections;
using CTS.Core;
using CTS.Core.Utilities;
using CTS.Utilities;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace CTS
{
	public class ManagerMapSelection : MonoBehaviour
	{
		public static Action<ManagerMapSelection> StartMap;

		[SerializeField]
		private AudioSource _audioSource;

		[SerializeField]
		private float _fadeInAudio;

		[SerializeField]
		private float _fadeOutAudio;

		[SerializeField]
		[Foldout("VFX Effects")]
		private GameObject _planeHider;

		[SerializeField]
		[Foldout("VFX Effects")]
		private float _planeHiderAlphaMax;

		[SerializeField]
		[Foldout("VFX Effects")]
		private float _disfocusBlur;

		[SerializeField]
		[Foldout("VFX Effects")]
		private float _focusBlur;

		[SerializeField]
		[Foldout("Card Info City")]
		private float _yPopUp;

		private Material _materialPlaneHider;

		[SerializeField]
		[Foldout("Button")]
		private Button _buttonReturn;

		[SerializeField]
		[Foldout("Button")]
		private Button _buttonLaunchMap;

		[SerializeField]
		[Foldout("Button")]
		private Button _buttonReplay;

		[SerializeField]
		[Foldout("VFX Effects")]
		private Volume _volumeBlur;

		[SerializeField]
		[Foldout("Canvas")]
		private GameObject _canvasInformationMap;

		[SerializeField]
		[Foldout("Canvas")]
		private GameObject _choiceCanvas;

		[SerializeField]
		[Foldout("Card Info City")]
		private GameObject _infoCardPrefab;

		private PopupInformation _popupInfo;

		private PopupInformation _popupSelectedInfoCity;

		private GameObject _infoCardInstance;

		private Transform _cityTransform;

		private MapInfoSO _currentSelectedMapInfo;

		private MainCamera _mainCameraScript;

		private Camera _mainCamera;

		private Coroutine _currentCoroutine;

		private SelectionMap_ManagerVFXStars _selectedMapInfoStars;

		public bool SomethingIsSelected { get; private set; }

		[field: SerializeField]
		public AudioAsset Ambiance { get; private set; }

		[field: SerializeField]
		[field: Foldout("Map Parameters")]
		public AnimationCurve TimeCurve { get; private set; }

		[field: SerializeField]
		[field: Foldout("Map Parameters")]
		public Transform PosForTheFocus { get; private set; }

		[field: SerializeField]
		[field: Foldout("Map Parameters")]
		public float TransitionTime { get; private set; }

		[field: SerializeField]
		[field: Scene]
		public int GameSceneToUnload { get; private set; }

		private void Start()
		{
			_mainCameraScript = MonoSingleton<MainCamera>.Instance.GetComponent<MainCamera>();
			_mainCamera = _mainCameraScript.GetComponent<Camera>();
			StartMap?.Invoke(this);
			_infoCardInstance = CTSFactory.Instantiate(_infoCardPrefab, _choiceCanvas.transform, instantiateInWorldSpace: false, false);
			_popupInfo = _infoCardInstance.GetComponent<PopupInformation>();
			_popupSelectedInfoCity = _canvasInformationMap.GetComponent<PopupInformation>();
			MeshRenderer component = _planeHider.GetComponent<MeshRenderer>();
			_materialPlaneHider = new Material(component.material);
			component.material = _materialPlaneHider;
			Disfocus(0.01f);
			_volumeBlur.weight = _disfocusBlur;
			ActiveAmbianceSound(Ambiance);
			if (MonoSingleton<MusicManager>.Instance != null)
			{
				MonoSingleton<MusicManager>.Instance.PauseTrack();
				StartCoroutine(LaunchGoodMusic());
			}
			_selectedMapInfoStars = GetComponent<SelectionMap_ManagerVFXStars>();
		}

		private IEnumerator LaunchGoodMusic()
		{
			yield return Coroutines.WaitForSecondsRealtime(1f);
			MonoSingleton<MusicManager>.Instance.PlaySelectionMapMusic();
		}

		public void SomethingSelected(bool selection)
		{
			SomethingIsSelected = selection;
			if (selection)
			{
				_choiceCanvas.SetActive(value: false);
				HideInfoCard();
				_mainCameraScript.Movements.enabled = false;
				_mainCameraScript.MouseControls.enabled = false;
			}
			else
			{
				_choiceCanvas.SetActive(value: true);
				_buttonReturn.onClick.RemoveAllListeners();
				_buttonLaunchMap.onClick.RemoveAllListeners();
				_buttonReplay.onClick.RemoveAllListeners();
				_currentSelectedMapInfo = null;
				_mainCameraScript.Movements.enabled = true;
				_mainCameraScript.MouseControls.enabled = true;
			}
		}

		public void LaunchNewScene()
		{
			if (!(_currentSelectedMapInfo == null))
			{
				CTSSingleton<ProfileManager>.Instance.RestartScene(_currentSelectedMapInfo, EGameMode.Story);
			}
		}

		public void ContinueLevel()
		{
			if (!(_currentSelectedMapInfo == null) && CTSSingleton<ProfileManager>.TryGetInstance(out var outInstance) && outInstance.CurrentProfile is CareerProfile careerProfile)
			{
				careerProfile.PlayMap(_currentSelectedMapInfo);
			}
		}

		public void FocusObject(float duration)
		{
			StartCoroutine(LerpAlphaForColor(0f, _planeHiderAlphaMax, TransitionTime, _materialPlaneHider));
			StartCoroutine(ChangingBlur(duration, _disfocusBlur, _focusBlur));
		}

		public void Disfocus(float duration)
		{
			StartCoroutine(LerpAlphaForColor(_planeHiderAlphaMax, 0f, TransitionTime, _materialPlaneHider));
			StartCoroutine(ChangingBlur(duration, _focusBlur, _disfocusBlur));
		}

		public void DesactiveInformationMap()
		{
			_canvasInformationMap.SetActive(value: false);
			ActiveAmbianceSound(Ambiance);
		}

		public void ActiveInformationMapCanvas(MapSelection currentMap, MapInfoSO mapInfo)
		{
			_currentSelectedMapInfo = mapInfo;
			_popupSelectedInfoCity.ChangeInformation(mapInfo);
			_canvasInformationMap.SetActive(value: true);
			_buttonReturn.onClick.AddListener(currentMap.ReturnToPos);
			_buttonLaunchMap.onClick.AddListener(ContinueLevel);
			_buttonReplay.onClick.AddListener(LaunchNewScene);
		}

		private IEnumerator ChangingBlur(float duration, float start, float end)
		{
			float time = 0f;
			while (time < duration)
			{
				_volumeBlur.weight = Mathf.Lerp(start, end, time / duration);
				time += Time.unscaledDeltaTime;
				yield return null;
			}
			_volumeBlur.weight = end;
			yield return null;
		}

		public IEnumerator LerpAlphaForColor(float startAlpha, float endAlpha, float duration, Material material)
		{
			float time = 0f;
			Color initialColor = material.color;
			while (time < duration)
			{
				float t = time / duration;
				float a = Mathf.Lerp(startAlpha, endAlpha, t);
				Color color = new Color(initialColor.r, initialColor.g, initialColor.b, a);
				material.color = color;
				time += Time.unscaledDeltaTime;
				yield return null;
			}
			Color color2 = new Color(initialColor.r, initialColor.g, initialColor.b, endAlpha);
			material.color = color2;
		}

		public void ShowInfoCard(Transform city, MapInfoSO mapInfo)
		{
			_cityTransform = city;
			UpdateInfoCard(mapInfo);
			_infoCardInstance.SetActive(value: true);
		}

		public void HideInfoCard()
		{
			_infoCardInstance.SetActive(value: false);
		}

		private void UpdateInfoCard(MapInfoSO mapInfo)
		{
			_popupInfo.ChangeInformation(mapInfo);
		}

		public void ActiveAmbianceSound(AudioAsset asset)
		{
			float newVolume = asset.VolumeRange.RandomInRange();
			if (_currentCoroutine != null)
			{
				StopCoroutine(_currentCoroutine);
			}
			_currentCoroutine = StartCoroutine(FadeOutIn(_audioSource, asset, newVolume, _fadeOutAudio, _fadeInAudio));
		}

		private IEnumerator FadeOutIn(AudioSource audioSource, AudioAsset newAsset, float newVolume, float fadeOutDuration, float fadeInDuration)
		{
			if (audioSource.isPlaying)
			{
				float startVolume = audioSource.volume;
				for (float t = 0f; t < fadeOutDuration; t += Time.deltaTime)
				{
					audioSource.volume = Mathf.Lerp(startVolume, 0f, t / fadeOutDuration);
					yield return null;
				}
				audioSource.Stop();
				audioSource.volume = 0f;
			}
			newVolume = newAsset.VolumeRange.RandomInRange();
			_audioSource.PlaySoundAsset(newAsset, newVolume);
			for (float startVolume = 0f; startVolume < fadeInDuration; startVolume += Time.deltaTime)
			{
				audioSource.volume = Mathf.Lerp(0f, newVolume, startVolume / fadeInDuration);
				yield return null;
			}
			audioSource.volume = newVolume;
		}

		private void Update()
		{
			if (_infoCardInstance.activeSelf && _cityTransform != null)
			{
				Vector3 position = _mainCamera.WorldToScreenPoint(_cityTransform.position);
				position += new Vector3(0f, _yPopUp, 0f);
				_infoCardInstance.transform.position = position;
			}
		}
	}
}
