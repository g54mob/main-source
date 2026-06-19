using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

namespace TH20
{
	public class SplashScreen : MonoBehaviour
	{
		private bool _skipPressed;

		[SerializeField]
		private VideoPlayer _segaIdentVideo;

		[SerializeField]
		private VideoReference _segaIdentVideoReference;

		[SerializeField]
		private RawImage m_videoTarget;

		[SerializeField]
		private AudioSource _segaIdentAudioSource;

		[SerializeField]
		private Image _twoPointSplash;

		[SerializeField]
		private GameObject _legalSplash;

		[SerializeField]
		private Image _masterFadeObject;

		[SerializeField]
		private Image _splashFadeObject;

		[SerializeField]
		private Transform _loadingIcon;

		[SerializeField]
		private Camera _camera;

		[SerializeField]
		private float _splashFadeInTime = 0.5f;

		[SerializeField]
		private float _splashHoldTime = 3f;

		[SerializeField]
		private float _splashFadeOutTime = 1f;

		[SerializeField]
		private float _splashFadeSkipTime = 0.2f;

		private RenderTexture m_RenderTexture;

		private Color m_RenderTextureClearColour = Color.black;

		private void Start()
		{
			_segaIdentVideo.clip = _segaIdentVideoReference.VideoClip;
			_segaIdentVideo.EnableAudioTrack(0, enabled: true);
			_segaIdentVideo.SetTargetAudioSource(0, _segaIdentAudioSource);
			SceneManager.SetActiveScene(SceneManager.GetSceneByName("SplashScreen"));
			StartCoroutine(StartIntro());
		}

		private void Update()
		{
			_skipPressed = Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1);
		}

		private IEnumerator StartIntro()
		{
			UnityEngine.Debug.Log("SplashScreen: Starting");
			_segaIdentVideo.gameObject.SetActive(value: false);
			_twoPointSplash.gameObject.SetActive(value: false);
			_legalSplash.SetActive(value: false);
			_loadingIcon.gameObject.SetActive(value: false);
			_masterFadeObject.gameObject.SetActive(value: false);
			_splashFadeObject.gameObject.SetActive(value: false);
			UnityEngine.Debug.Log("SplashScreen: Showing Video");
			m_RenderTexture = RenderTextureFactory.Create(1920, 1080, 0, RenderTextureFormat.ARGB32, m_RenderTextureClearColour);
			m_videoTarget.texture = m_RenderTexture;
			_segaIdentVideo.renderMode = VideoRenderMode.RenderTexture;
			_segaIdentVideo.targetTexture = m_RenderTexture;
			m_videoTarget.gameObject.SetActive(value: true);
			_segaIdentVideo.gameObject.SetActive(value: true);
			_segaIdentVideo.Prepare();
			float waitTime = 0f;
			while (!_segaIdentVideo.isPrepared && waitTime < 5f)
			{
				waitTime += Time.unscaledDeltaTime;
				yield return null;
			}
			if (_segaIdentVideo.isPrepared)
			{
				_segaIdentVideo.Play();
				while (_segaIdentVideo.isPlaying)
				{
					if (_skipPressed)
					{
						_segaIdentVideo.Stop();
						break;
					}
					yield return null;
				}
			}
			_segaIdentVideo.gameObject.SetActive(value: false);
			m_videoTarget.gameObject.SetActive(value: false);
			m_RenderTexture.Release();
			m_RenderTexture = null;
			if (!_skipPressed)
			{
				yield return new WaitForSecondsRealtime(1f);
			}
			_skipPressed = false;
			UnityEngine.Debug.Log("SplashScreen: Showing Two Point splash");
			yield return StartCoroutine(ShowNextTwoPointSplash());
			if (!_skipPressed)
			{
				yield return new WaitForSecondsRealtime(1f);
			}
			_skipPressed = false;
			UnityEngine.Debug.Log("SplashScreen: Showing Legal splash");
			yield return StartCoroutine(ShowNextLegalSplash());
			if (!_skipPressed)
			{
				yield return new WaitForSecondsRealtime(1f);
			}
			_loadingIcon.gameObject.SetActive(value: true);
			UnityEngine.Debug.Log("SplashScreen: Starting Main scene load");
			AsyncOperation mainSceneLoadOperation = SceneManager.LoadSceneAsync("Main", LoadSceneMode.Additive);
			mainSceneLoadOperation.allowSceneActivation = false;
			while (mainSceneLoadOperation.progress < 0.9f)
			{
				yield return null;
			}
			UnityEngine.Debug.Log("SplashScreen: Finalising Main scene load");
			mainSceneLoadOperation.allowSceneActivation = true;
			yield return mainSceneLoadOperation;
			UnityEngine.Debug.Log("SplashScreen: Finished Main scene load. Fading in.");
			_camera.gameObject.SetActive(value: false);
			_loadingIcon.gameObject.SetActive(value: false);
			float elapsedTime = 0f;
			float splashFadeInTime = (DebugVars.FastLoadingScreenAnimation.Value ? 0.1f : _splashFadeInTime);
			while (elapsedTime < splashFadeInTime)
			{
				elapsedTime += Time.unscaledDeltaTime;
				float num = Mathf.Clamp01(elapsedTime / splashFadeInTime);
				_masterFadeObject.color = new Color(0f, 0f, 0f, EasingsUtils.CubicEaseInOut(1f - num));
				yield return null;
			}
			_masterFadeObject.gameObject.SetActive(value: false);
			UnityEngine.Debug.Log("SplashScreen: Fade in finished. Unloading SplashScreen scene.");
			yield return SceneManager.UnloadSceneAsync("SplashScreen");
		}

		private IEnumerator ShowNextTwoPointSplash()
		{
			_splashFadeObject.gameObject.SetActive(value: true);
			_twoPointSplash.gameObject.SetActive(value: true);
			float elapsedTime = 0f;
			while (elapsedTime < _splashFadeInTime)
			{
				elapsedTime += Time.unscaledDeltaTime;
				float num = Mathf.Clamp01(elapsedTime / _splashFadeInTime);
				_splashFadeObject.color = new Color(0f, 0f, 0f, EasingsUtils.CubicEaseInOut(1f - num));
				yield return null;
			}
			_splashFadeObject.gameObject.SetActive(value: false);
			elapsedTime = 0f;
			while (elapsedTime < _splashHoldTime)
			{
				elapsedTime += Time.unscaledDeltaTime;
				if (_skipPressed)
				{
					break;
				}
				yield return null;
			}
			_splashFadeObject.gameObject.SetActive(value: true);
			float fadeOutTime = (_skipPressed ? _splashFadeSkipTime : _splashFadeOutTime);
			elapsedTime = 0f;
			while (elapsedTime < fadeOutTime)
			{
				elapsedTime += Time.unscaledDeltaTime;
				float p = Mathf.Clamp01(elapsedTime / fadeOutTime);
				_splashFadeObject.color = new Color(0f, 0f, 0f, EasingsUtils.CubicEaseInOut(p));
				yield return null;
			}
			_twoPointSplash.gameObject.SetActive(value: false);
			_splashFadeObject.gameObject.SetActive(value: false);
		}

		private IEnumerator ShowNextLegalSplash()
		{
			_splashFadeObject.gameObject.SetActive(value: true);
			_legalSplash.SetActive(value: true);
			float elapsedTime = 0f;
			while (elapsedTime < _splashFadeInTime)
			{
				elapsedTime += Time.unscaledDeltaTime;
				float num = Mathf.Clamp01(elapsedTime / _splashFadeInTime);
				_splashFadeObject.color = new Color(0f, 0f, 0f, EasingsUtils.CubicEaseInOut(1f - num));
				yield return null;
			}
			elapsedTime = 0f;
			while (elapsedTime < _splashHoldTime)
			{
				elapsedTime += Time.unscaledDeltaTime;
				if (_skipPressed)
				{
					break;
				}
				yield return null;
			}
			float fadeOutTime = (_skipPressed ? _splashFadeSkipTime : _splashFadeOutTime);
			elapsedTime = 0f;
			while (elapsedTime < fadeOutTime)
			{
				elapsedTime += Time.unscaledDeltaTime;
				float p = Mathf.Clamp01(elapsedTime / fadeOutTime);
				_splashFadeObject.color = new Color(0f, 0f, 0f, EasingsUtils.CubicEaseInOut(p));
				yield return null;
			}
			_legalSplash.SetActive(value: false);
			_splashFadeObject.gameObject.SetActive(value: false);
		}
	}
}
