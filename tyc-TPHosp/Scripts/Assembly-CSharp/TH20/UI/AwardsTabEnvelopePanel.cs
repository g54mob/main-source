using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20.UI
{
	public class AwardsTabEnvelopePanel : OverviewMenuTabPanel
	{
		private struct LetterAndEnvelopeInstanceData
		{
			public GameObject _Instance;

			public Animator _Animator;
		}

		[SerializeField]
		private ButtonAnimator _theOpenButton;

		[SerializeField]
		private ButtonAnimator _theOpenAllButton;

		[SerializeField]
		private TMP_Text _openButtonText;

		[SerializeField]
		private RawImage _letterRenderTargetImage;

		[SerializeField]
		private GameObject _letterAndEnvelopePrefab;

		[SerializeField]
		private TMP_Text _topPageText;

		[SerializeField]
		private TMP_Text _bottomPageText;

		[SerializeField]
		private TMP_Text _bottomPageTextAlt1;

		[SerializeField]
		private TMP_Text _bottomPageTextAlt2;

		[SerializeField]
		private float _openEnvelopeTime = 2f;

		[SerializeField]
		private float _removeEnvelopeTime = 1.1f;

		[SerializeField]
		private float _envelopeOffsetZ = -0.3f;

		[SerializeField]
		private float _envelopeOffsetRoll = -5f;

		[SerializeField]
		private float _envelopeOffsetScale = -0.25f;

		[SerializeField]
		private float _envelopeColourValueFore = 1f;

		[SerializeField]
		private float _envelopeColourValueBack = 0.5f;

		private bool _openAll;

		private CanvasGroup _theEnvelopeGroup;

		private DynamicButton _dynamicButton4Open;

		private DynamicButton _dynamicButton4OpenAll;

		private LetterAndEnvelopeInstanceData[] _letterAndEnvelopeInstances = new LetterAndEnvelopeInstanceData[2];

		private GameObject _cameraInstance;

		private Camera _camera;

		private RenderTexture _letterRenderTexture;

		private Vector3 _letterAndEnvelopeBasePosition;

		private Vector3 _letterAndEnvelopeBaseRotation;

		private Vector3 _letterAndEnvelopeBaseScale;

		private Vector3 _letterAndEnvelopeStartPosition;

		private Vector3 _letterAndEnvelopeStartRotation;

		private Vector3 _letterAndEnvelopeStartScale;

		private Vector3 _currentInstanceDestPosition;

		private Vector3 _currentInstanceDestRotation;

		private Vector3 _currentInstanceDestScale;

		private Vector3 _backLetterOffsetVec;

		private Vector3 _backLetterOffsetRot;

		private Vector3 _backLetterOffsetScale;

		private float _openEnvelopeTimer;

		private float _removeEnvelopeTimer;

		private bool _openLetterRequested;

		private bool _removeLetterRequested;

		private int _currentInstanceIndex;

		private bool _presentingPenultimateAward;

		private const float cAnimObjectOffsetX = 0f;

		private const float cAnimObjectOffsetY = 0f;

		private const float cAnimObjectOffsetZ = 0f;

		private const float cFadeInOutButtonsTime = 1f;

		private const float cFadeInLetterTextTime = 0.5f;

		private const float cFadeInEnvelopesTextTime = 0.75f;

		private const float cFadeOutEnvelopesTextTime = 1f;

		private const float cRepositionForegroundEnvelopeTime = 0.4f;

		private static float cCameraAndLetterOffsetY = 200f;

		private static float cPitchAngleOffset = 0f;

		private static float cLetterAndEnvelopleOffsetY = 0f;

		private static float cLetterAndEnvelopleScale = 1f;

		public override void Setup(OverviewMenuTab theTabRoot)
		{
			base.Setup(theTabRoot);
			ResetLetterText();
			_presentingPenultimateAward = false;
			_theEnvelopeGroup = GetComponent<CanvasGroup>();
			if (_theEnvelopeGroup != null)
			{
				_theEnvelopeGroup.alpha = 0f;
			}
			if ((bool)_theOpenButton)
			{
				_dynamicButton4Open = _theOpenButton.GetComponent<DynamicButton>();
				if ((bool)_dynamicButton4Open)
				{
					_dynamicButton4Open.onPrimaryDown.AddListener(OpenEnvelope);
				}
				SetOpenButtonState(active: false);
			}
			if ((bool)_theOpenAllButton)
			{
				_dynamicButton4OpenAll = _theOpenAllButton.GetComponent<DynamicButton>();
				if ((bool)_dynamicButton4OpenAll)
				{
					_dynamicButton4OpenAll.onPrimaryDown.AddListener(OpenAllEnvelopes);
				}
				SetOpenAllButtonState(active: false);
			}
		}

		public void ForceOpenEnvelope()
		{
			OpenEnvelope();
		}

		private void OpenEnvelope()
		{
			SetOpenButtonState(active: true);
			EnvelopeOpen();
		}

		public void EnvelopeAppearClosed()
		{
			ResetLetterText();
			if (_letterAndEnvelopeInstances[_currentInstanceIndex]._Instance != null)
			{
				_letterAndEnvelopeInstances[_currentInstanceIndex]._Animator.SetParameter("OnAppearClosed");
			}
			_openLetterRequested = false;
			_removeLetterRequested = false;
		}

		public void EnvelopeOpen()
		{
			if (_letterAndEnvelopeInstances[_currentInstanceIndex]._Instance != null)
			{
				_letterAndEnvelopeInstances[_currentInstanceIndex]._Animator.SetParameter("OnOpen");
			}
			_openLetterRequested = true;
			_openEnvelopeTimer = _openEnvelopeTime;
		}

		public void EnvelopeRemove()
		{
			ResetLetterText();
			if (_letterAndEnvelopeInstances[_currentInstanceIndex]._Instance != null)
			{
				_letterAndEnvelopeInstances[_currentInstanceIndex]._Animator.SetParameter("OnRemove");
			}
			_removeLetterRequested = true;
			_removeEnvelopeTimer = _removeEnvelopeTime;
		}

		public void FadeInEnvelopes()
		{
			StartCoroutine(ProcessFadeInEnvelopes());
		}

		private void OpenAllEnvelopes()
		{
			SetOpenButtonState(active: false);
			SetOpenAllButtonState(active: false);
			StartCoroutine(PrepareOpenAll());
		}

		protected override void Update()
		{
			base.Update();
			if (_openEnvelopeTimer > 0f)
			{
				_openEnvelopeTimer -= Time.unscaledDeltaTime;
			}
			if (_removeEnvelopeTimer > 0f)
			{
				_removeEnvelopeTimer -= Time.unscaledDeltaTime;
				if (_removeEnvelopeTimer <= 0f)
				{
					SwapLetterAndEnvelopeInstances();
				}
			}
		}

		public void Reset()
		{
			ResetLetterText();
			HideLetter();
		}

		public void SetOpenButtonState(bool active, bool enabled = false)
		{
			if (!enabled)
			{
				active = false;
			}
			if ((bool)_theOpenButton)
			{
				_theOpenButton.gameObject.SetActive(active);
				_theOpenButton.enabled = enabled;
				if ((bool)_dynamicButton4Open)
				{
					_dynamicButton4Open.enabled = enabled;
				}
				if (_theOpenButton.gameObject.activeSelf)
				{
					FadeInOpenButton();
				}
			}
			if ((bool)_openButtonText)
			{
				_openButtonText.gameObject.SetActive(enabled);
			}
		}

		public void SetOpenAllButtonState(bool active, bool enabled = false)
		{
			if ((bool)_theOpenAllButton)
			{
				_theOpenAllButton.gameObject.SetActive(active);
				_theOpenAllButton.enabled = enabled;
				if ((bool)_dynamicButton4OpenAll)
				{
					_dynamicButton4OpenAll.enabled = enabled;
				}
				if (_theOpenAllButton.gameObject.activeSelf)
				{
					FadeInOpenAllButton();
				}
			}
		}

		private void SetButtonAlpha(GameObject inButtonGameObject, float inAlpha)
		{
			CanvasGroup component = inButtonGameObject.GetComponent<CanvasGroup>();
			if (component != null)
			{
				component.alpha = inAlpha;
			}
		}

		private void FadeInOpenButton()
		{
			SetButtonAlpha(_theOpenButton.gameObject, 0f);
			StartCoroutine(ProcessFadeInOpenButton());
		}

		private void FadeInOpenAllButton()
		{
			SetButtonAlpha(_theOpenAllButton.gameObject, 0f);
			StartCoroutine(ProcessFadeInOpenAllButton());
		}

		private IEnumerator ProcessFadeInOpenButton()
		{
			bool stop = false;
			float time = 0f;
			float duration = 1f;
			do
			{
				if (time >= duration)
				{
					stop = true;
				}
				SetButtonAlpha(_theOpenButton.gameObject, Mathf.Lerp(0f, 1f, EasingsUtils.CubicEaseOut(Mathf.Clamp01(time / duration))));
				yield return null;
				time += Time.unscaledDeltaTime;
			}
			while (!stop);
		}

		private IEnumerator ProcessFadeInOpenAllButton()
		{
			bool stop = false;
			float time = 0f;
			float duration = 1f;
			do
			{
				if (time >= duration)
				{
					stop = true;
				}
				SetButtonAlpha(_theOpenAllButton.gameObject, Mathf.Lerp(0f, 1f, EasingsUtils.CubicEaseOut(Mathf.Clamp01(time / duration))));
				yield return null;
				time += Time.unscaledDeltaTime;
			}
			while (!stop);
		}

		public void HideLetter()
		{
		}

		public bool LetterOpened()
		{
			if (_openLetterRequested)
			{
				return _openEnvelopeTimer <= 0f;
			}
			return false;
		}

		public bool LetterRemoved()
		{
			if (_removeLetterRequested)
			{
				return _removeEnvelopeTimer <= 0f;
			}
			return false;
		}

		public void RepositionForegroundEnvelope()
		{
			_currentInstanceDestPosition = _letterAndEnvelopeBasePosition;
			_currentInstanceDestRotation = _letterAndEnvelopeBaseRotation;
			_currentInstanceDestScale = _letterAndEnvelopeBaseScale;
			StartCoroutine(RepostionForegroundLetterAndEnvelopeInstance());
		}

		public void ResetLetterText()
		{
			SetLetterText("", "");
		}

		public void SetLetterText(string topText, string bottomText, string bottomText2 = "")
		{
			if ((bool)_topPageText)
			{
				_topPageText.text = topText;
			}
			if (bottomText2.IsNullOrEmpty())
			{
				if ((bool)_bottomPageText)
				{
					_bottomPageText.text = bottomText;
				}
				if ((bool)_bottomPageTextAlt1)
				{
					_bottomPageTextAlt1.text = "";
				}
				if ((bool)_bottomPageTextAlt2)
				{
					_bottomPageTextAlt2.text = "";
				}
			}
			else
			{
				if ((bool)_bottomPageText)
				{
					_bottomPageText.text = "";
				}
				if ((bool)_bottomPageTextAlt1)
				{
					_bottomPageTextAlt1.text = bottomText;
				}
				if ((bool)_bottomPageTextAlt2)
				{
					_bottomPageTextAlt2.text = bottomText2;
				}
			}
			if (!topText.IsNullOrEmpty())
			{
				StartCoroutine(FadeInLetterText());
			}
			else
			{
				SetTextAlpha(0f);
			}
		}

		private IEnumerator FadeInLetterText()
		{
			bool stop = false;
			float time = 0f;
			float duration = 0.5f;
			do
			{
				if (time >= duration)
				{
					stop = true;
				}
				SetTextAlpha(Mathf.Lerp(0f, 1f, EasingsUtils.CubicEaseOut(Mathf.Clamp01(time / duration))));
				yield return null;
				time += Time.unscaledDeltaTime;
			}
			while (!stop);
		}

		private void SetTextAlpha(float inAlpha)
		{
			if ((bool)_topPageText)
			{
				_topPageText.alpha = inAlpha;
			}
			if ((bool)_bottomPageText)
			{
				_bottomPageText.alpha = inAlpha;
			}
			if ((bool)_bottomPageTextAlt1)
			{
				_bottomPageTextAlt1.alpha = inAlpha;
			}
			if ((bool)_bottomPageTextAlt2)
			{
				_bottomPageTextAlt2.alpha = inAlpha;
			}
		}

		public bool ReadyToOpenAll()
		{
			return _openAll;
		}

		public void SetPresentingPenultimateAward(bool bSet)
		{
			_presentingPenultimateAward = bSet;
		}

		public void SetupEnvelopeAndLetter()
		{
			if (_letterAndEnvelopePrefab != null)
			{
				_letterRenderTexture = new RenderTexture(1024, 1024, 24, RenderTextureFormat.ARGBHalf);
				_letterRenderTargetImage.texture = _letterRenderTexture;
				_letterRenderTargetImage.gameObject.SetActive(value: true);
				_cameraInstance = new GameObject("AwardLetterCamera", typeof(Camera));
				_camera = _cameraInstance.GetComponent<Camera>();
				_camera.targetTexture = _letterRenderTexture;
				_camera.allowHDR = true;
				_camera.allowMSAA = true;
				_camera.useOcclusionCulling = true;
				_camera.fieldOfView = 65f;
				_camera.aspect = 1f;
				_camera.clearFlags = CameraClearFlags.Color;
				_camera.backgroundColor = new Color(0f, 0f, 0f, 0f);
				_camera.cullingMask = 1 << LayerMask.NameToLayer("Metagame");
				_cameraInstance.transform.localPosition = new Vector3(0f, cCameraAndLetterOffsetY, -1f);
				_cameraInstance.transform.localPosition += GetObjectsPositionOffset();
				_cameraInstance.transform.localEulerAngles = new Vector3(cPitchAngleOffset, 0f, 0f);
				_letterAndEnvelopeBasePosition = new Vector3(0f, cCameraAndLetterOffsetY, 1f);
				_letterAndEnvelopeBasePosition += GetObjectsPositionOffset();
				Vector3 vector = _letterAndEnvelopeBasePosition - _cameraInstance.transform.localPosition;
				vector = Quaternion.AngleAxis(cPitchAngleOffset, Vector3.right) * vector;
				_letterAndEnvelopeBasePosition = _cameraInstance.transform.localPosition + vector;
				_letterAndEnvelopeBasePosition.y += cLetterAndEnvelopleOffsetY;
				_letterAndEnvelopeBaseRotation = new Vector3(cPitchAngleOffset, 0f, 0f);
				_letterAndEnvelopeBaseScale = new Vector3(cLetterAndEnvelopleScale, cLetterAndEnvelopleScale, cLetterAndEnvelopleScale);
				_backLetterOffsetVec = new Vector3(0f, 0f, _envelopeOffsetZ);
				_backLetterOffsetRot = new Vector3(0f, 0f, _envelopeOffsetRoll);
				_backLetterOffsetScale = new Vector3(_envelopeOffsetScale, _envelopeOffsetScale, 0f);
				_letterAndEnvelopeStartPosition = _letterAndEnvelopeBasePosition - Quaternion.AngleAxis(cPitchAngleOffset, Vector3.right) * _backLetterOffsetVec;
				_letterAndEnvelopeStartRotation = _letterAndEnvelopeBaseRotation - _backLetterOffsetRot;
				_letterAndEnvelopeStartScale = _letterAndEnvelopeBaseScale - _backLetterOffsetScale;
				_currentInstanceIndex = 0;
				CreateLetterAndEnvelopeInstance(1);
				CreateLetterAndEnvelopeInstance(0);
			}
		}

		private void CreateLetterAndEnvelopeInstance(int instanceIndex)
		{
			GameObject gameObject = Object.Instantiate(_letterAndEnvelopePrefab);
			gameObject.transform.localPosition = _letterAndEnvelopeStartPosition;
			gameObject.transform.localEulerAngles = _letterAndEnvelopeStartRotation;
			gameObject.transform.localScale = _letterAndEnvelopeStartScale;
			_letterAndEnvelopeInstances[instanceIndex]._Instance = gameObject;
			_letterAndEnvelopeInstances[instanceIndex]._Animator = gameObject.GetComponent<Animator>();
			SetLetterAndEnvelopeInstanceColorValue(instanceIndex, _envelopeColourValueBack);
		}

		private void DestroyLetterAndEnvelopeInstance(int instanceIndex)
		{
			if (_letterAndEnvelopeInstances[instanceIndex]._Instance != null)
			{
				Object.Destroy(_letterAndEnvelopeInstances[instanceIndex]._Instance);
				_letterAndEnvelopeInstances[instanceIndex]._Instance = null;
			}
		}

		private void SetLetterAndEnvelopeInstanceColorValue(int instanceIndex, float colourValue)
		{
			if (!(_letterAndEnvelopeInstances[instanceIndex]._Instance != null))
			{
				return;
			}
			List<SkinnedMeshRenderer> list = new List<SkinnedMeshRenderer>();
			_letterAndEnvelopeInstances[instanceIndex]._Instance.GetComponentsInChildren(list);
			foreach (SkinnedMeshRenderer item in list)
			{
				Material[] materials = item.materials;
				foreach (Material obj in materials)
				{
					Color color = obj.color;
					color.r = colourValue;
					color.g = colourValue;
					color.b = colourValue;
					obj.color = color;
				}
			}
		}

		public GameObject GetLetterBeamFocusGameObject()
		{
			return _letterRenderTargetImage.transform.parent.gameObject;
		}

		private void SwapLetterAndEnvelopeInstances()
		{
			DestroyLetterAndEnvelopeInstance(_currentInstanceIndex);
			if (!_presentingPenultimateAward)
			{
				CreateLetterAndEnvelopeInstance(_currentInstanceIndex);
			}
			_currentInstanceIndex = ((_currentInstanceIndex == 0) ? 1 : 0);
		}

		private IEnumerator RepostionForegroundLetterAndEnvelopeInstance()
		{
			bool stop = false;
			float time = 0f;
			float duration = 0.4f;
			do
			{
				if (time >= duration)
				{
					stop = true;
				}
				float t = EasingsUtils.CubicEaseOut(Mathf.Clamp01(time / duration));
				if (_letterAndEnvelopeInstances[_currentInstanceIndex]._Instance != null)
				{
					_letterAndEnvelopeInstances[_currentInstanceIndex]._Instance.transform.localPosition = Vector3.Lerp(_letterAndEnvelopeStartPosition, _currentInstanceDestPosition, t);
					_letterAndEnvelopeInstances[_currentInstanceIndex]._Instance.transform.localEulerAngles = Vector3.Lerp(_letterAndEnvelopeStartRotation, _currentInstanceDestRotation, t);
					_letterAndEnvelopeInstances[_currentInstanceIndex]._Instance.transform.localScale = Vector3.Lerp(_letterAndEnvelopeStartScale, _currentInstanceDestScale, t);
					SetLetterAndEnvelopeInstanceColorValue(_currentInstanceIndex, Mathf.Lerp(_envelopeColourValueBack, _envelopeColourValueFore, t));
				}
				yield return null;
				time += Time.unscaledDeltaTime;
			}
			while (!stop);
			if (_letterAndEnvelopeInstances[_currentInstanceIndex]._Instance != null)
			{
				_letterAndEnvelopeInstances[_currentInstanceIndex]._Instance.transform.localPosition = _currentInstanceDestPosition;
				_letterAndEnvelopeInstances[_currentInstanceIndex]._Instance.transform.localEulerAngles = _currentInstanceDestRotation;
				_letterAndEnvelopeInstances[_currentInstanceIndex]._Instance.transform.localScale = _currentInstanceDestScale;
				SetLetterAndEnvelopeInstanceColorValue(_currentInstanceIndex, _envelopeColourValueFore);
			}
		}

		private Vector3 GetObjectsPositionOffset()
		{
			return new Vector3(0f, 0f, 0f);
		}

		private void OnDestroy()
		{
			DestroyLetterAndEnvelopeInstance(0);
			DestroyLetterAndEnvelopeInstance(1);
			if (_cameraInstance != null)
			{
				Object.Destroy(_cameraInstance);
			}
			if (_letterRenderTexture != null)
			{
				Object.Destroy(_letterRenderTexture);
			}
		}

		private IEnumerator ProcessFadeInEnvelopes()
		{
			bool stop = false;
			float time = 0f;
			float duration = 0.75f;
			do
			{
				if (time >= duration)
				{
					stop = true;
				}
				_theEnvelopeGroup.alpha = EasingsUtils.CubicEaseOut(Mathf.Clamp01(time / duration));
				yield return null;
				time += Time.unscaledDeltaTime;
			}
			while (!stop);
		}

		private IEnumerator PrepareOpenAll()
		{
			_openAll = true;
			bool stop = false;
			float time = 1f;
			float startAlpha = _theEnvelopeGroup.alpha;
			if (startAlpha > 0f && (bool)_theEnvelopeGroup)
			{
				do
				{
					if (time < 0f)
					{
						stop = true;
					}
					_theEnvelopeGroup.alpha = startAlpha * EasingsUtils.CubicEaseOut(Mathf.Clamp01(time));
					yield return null;
					time -= Time.unscaledDeltaTime;
				}
				while (!stop);
			}
			SetOpenButtonState(active: false);
		}
	}
}
