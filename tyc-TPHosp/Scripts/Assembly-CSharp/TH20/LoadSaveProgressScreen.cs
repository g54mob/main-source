using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class LoadSaveProgressScreen : MonoBehaviour
	{
		[SerializeField]
		private LoadSaveProgressData _defaultLoadSaveScreen;

		[SerializeField]
		private LoadSaveProgressData _remixLoadSaveScreen;

		[SerializeField]
		private float _animationXScalar = 1.4f;

		[SerializeField]
		private float _animationXScalarBack = 1.2f;

		[SerializeField]
		private float _animationXScalarFurtherBack = 1f;

		[SerializeField]
		private float _animateInTime = 1f;

		[SerializeField]
		private float _animateOutTime = 1f;

		private LoadSaveProgressData _currentLoadSaveScreenData;

		private Coroutine _currentOperationCoroutine;

		public bool IsAnimating => _currentOperationCoroutine != null;

		public bool IsVisible => base.gameObject.activeSelf;

		public float Alpha { get; private set; }

		public void Show(LevelConfig levelConfig = null)
		{
			if (levelConfig != null && levelConfig.IsRemixLevel)
			{
				_currentLoadSaveScreenData = _remixLoadSaveScreen;
				GameObjectUtils.SetActive(_remixLoadSaveScreen.ParentPanel, isActive: true);
				GameObjectUtils.SetActive(_defaultLoadSaveScreen.ParentPanel, isActive: false);
			}
			else
			{
				_currentLoadSaveScreenData = _defaultLoadSaveScreen;
				GameObjectUtils.SetActive(_remixLoadSaveScreen.ParentPanel, isActive: false);
				GameObjectUtils.SetActive(_defaultLoadSaveScreen.ParentPanel, isActive: true);
			}
			SetProgress(0f);
			GameObjectUtils.SetActive(base.gameObject, isActive: true);
			if (levelConfig != null)
			{
				if (SandboxSaveManager.CurrentSettings != null)
				{
					_currentLoadSaveScreenData.TitleLabelText.text = SandboxSaveManager.CurrentSettings.DisplayName;
					_currentLoadSaveScreenData.DetailsLabelText.text = string.Empty;
					_currentLoadSaveScreenData.BackingImage.overrideSprite = null;
				}
				else
				{
					_currentLoadSaveScreenData.TitleLabelText.text = ((levelConfig.DisplayNameLocalised.Term != null) ? levelConfig.DisplayNameLocalised.Translation : string.Empty);
					_currentLoadSaveScreenData.DetailsLabelText.text = ((levelConfig.GetLoadingDescriptionString().Term != null) ? levelConfig.GetLoadingDescriptionString().Translation : string.Empty);
					_currentLoadSaveScreenData.BackingImage.overrideSprite = null;
				}
			}
			else
			{
				_currentLoadSaveScreenData.TitleLabelText.text = string.Empty;
				_currentLoadSaveScreenData.DetailsLabelText.text = string.Empty;
				_currentLoadSaveScreenData.BackingImage.overrideSprite = null;
			}
			_currentOperationCoroutine = StartCoroutine(ShowLoadingScreenCoroutine());
		}

		public void Hide()
		{
			_currentOperationCoroutine = StartCoroutine(HideLoadingScreenCoroutine());
		}

		public void SetProgress(float progress)
		{
			GameObjectUtils.SetImageFillAmountIfDifferent(_currentLoadSaveScreenData.ProgressBarImage, progress);
		}

		private IEnumerator ShowLoadingScreenCoroutine()
		{
			RectTransform cloudLeftRect = (RectTransform)_currentLoadSaveScreenData.CloudCurtainsLeft.transform;
			RectTransform cloudRightRect = (RectTransform)_currentLoadSaveScreenData.CloudCurtainsRight.transform;
			RectTransform cloudLeftBackRect = (RectTransform)_currentLoadSaveScreenData.CloudCurtainsLeftBack.transform;
			RectTransform cloudRightBackRect = (RectTransform)_currentLoadSaveScreenData.CloudCurtainsRightBack.transform;
			RectTransform cloudLeftFurtherBackRect = (RectTransform)_currentLoadSaveScreenData.CloudCurtainsLeftFurtherBack.transform;
			RectTransform cloudRightFurtherBackRect = (RectTransform)_currentLoadSaveScreenData.CloudCurtainsRightFurtherBack.transform;
			float num = (float)Screen.width * _animationXScalar;
			float num2 = (float)Screen.width * _animationXScalarBack;
			float num3 = (float)Screen.width * _animationXScalarFurtherBack;
			cloudLeftRect.anchoredPosition = new Vector2(0f - num, 0f);
			cloudRightRect.anchoredPosition = new Vector2(num, 0f);
			cloudLeftBackRect.anchoredPosition = new Vector2(0f - num2, 0f);
			cloudRightBackRect.anchoredPosition = new Vector2(num2, 0f);
			cloudLeftFurtherBackRect.anchoredPosition = new Vector2(0f - num3, 0f);
			cloudRightFurtherBackRect.anchoredPosition = new Vector2(num3, 0f);
			_currentLoadSaveScreenData.LoadingScreenCanvasGroup.alpha = 0f;
			GameObjectUtils.SetActive(_currentLoadSaveScreenData.LoadingPanel, isActive: true);
			GameObjectUtils.SetActive(_currentLoadSaveScreenData.CloudCurtainsLeft.gameObject, isActive: true);
			GameObjectUtils.SetActive(_currentLoadSaveScreenData.CloudCurtainsRight.gameObject, isActive: true);
			GameObjectUtils.SetActive(_currentLoadSaveScreenData.CloudCurtainsLeftBack.gameObject, isActive: true);
			GameObjectUtils.SetActive(_currentLoadSaveScreenData.CloudCurtainsRightBack.gameObject, isActive: true);
			GameObjectUtils.SetActive(_currentLoadSaveScreenData.CloudCurtainsLeftFurtherBack.gameObject, isActive: true);
			GameObjectUtils.SetActive(_currentLoadSaveScreenData.CloudCurtainsRightFurtherBack.gameObject, isActive: true);
			yield return null;
			float elapsedTime = 0f;
			Alpha = 0f;
			float animateInTime = (DebugVars.FastLoadingScreenAnimation.Value ? 0.1f : _animateInTime);
			while (elapsedTime < animateInTime)
			{
				elapsedTime += Time.unscaledDeltaTime;
				Alpha = Mathf.Clamp01(Alpha + Time.unscaledTime);
				float num4 = elapsedTime / animateInTime;
				float p = Mathf.Clamp01(elapsedTime / (animateInTime * 0.6f));
				float p2 = Mathf.Clamp01(elapsedTime / (animateInTime * 0.35f));
				_currentLoadSaveScreenData.CloudCurtainsLeft.alpha = Mathf.Clamp01(num4 * 5f);
				_currentLoadSaveScreenData.CloudCurtainsRight.alpha = Mathf.Clamp01(num4 * 5f);
				_currentLoadSaveScreenData.CloudCurtainsLeftBack.alpha = Mathf.Clamp01(num4 * 5f);
				_currentLoadSaveScreenData.CloudCurtainsRightBack.alpha = Mathf.Clamp01(num4 * 5f);
				_currentLoadSaveScreenData.CloudCurtainsLeftFurtherBack.alpha = Mathf.Clamp01(num4 * 5f);
				_currentLoadSaveScreenData.CloudCurtainsRightFurtherBack.alpha = Mathf.Clamp01(num4 * 5f);
				float num5 = EasingsUtils.CubicEaseOut(num4);
				float t = EasingsUtils.CubicEaseOut(p);
				float t2 = EasingsUtils.CubicEaseOut(p2);
				num = (float)Screen.width * _animationXScalar;
				num2 = (float)Screen.width * _animationXScalarBack;
				num3 = (float)Screen.width * _animationXScalarFurtherBack;
				cloudLeftRect.anchoredPosition = new Vector2(Mathf.Lerp(0f - num, 0f, num5), 0f);
				cloudRightRect.anchoredPosition = new Vector2(Mathf.Lerp(num, 0f, num5), 0f);
				cloudLeftBackRect.anchoredPosition = new Vector2(Mathf.Lerp(0f - num2, 0f, t), 0f);
				cloudRightBackRect.anchoredPosition = new Vector2(Mathf.Lerp(num2, 0f, t), 0f);
				cloudLeftFurtherBackRect.anchoredPosition = new Vector2(Mathf.Lerp(0f - num3, 0f, t2), 0f);
				cloudRightFurtherBackRect.anchoredPosition = new Vector2(Mathf.Lerp(num3, 0f, t2), 0f);
				_currentLoadSaveScreenData.LoadingScreenCanvasGroup.alpha = num5;
				yield return null;
			}
			GameObjectUtils.SetActive(_currentLoadSaveScreenData.CloudCurtainsLeftBack.gameObject, isActive: false);
			GameObjectUtils.SetActive(_currentLoadSaveScreenData.CloudCurtainsRightBack.gameObject, isActive: false);
			GameObjectUtils.SetActive(_currentLoadSaveScreenData.CloudCurtainsLeftFurtherBack.gameObject, isActive: false);
			GameObjectUtils.SetActive(_currentLoadSaveScreenData.CloudCurtainsRightFurtherBack.gameObject, isActive: false);
			_currentOperationCoroutine = null;
		}

		private IEnumerator HideLoadingScreenCoroutine()
		{
			RectTransform cloudLeftRect = (RectTransform)_currentLoadSaveScreenData.CloudCurtainsLeft.transform;
			RectTransform cloudRightRect = (RectTransform)_currentLoadSaveScreenData.CloudCurtainsRight.transform;
			RectTransform rectTransform = (RectTransform)_currentLoadSaveScreenData.CloudCurtainsLeftBack.transform;
			RectTransform rectTransform2 = (RectTransform)_currentLoadSaveScreenData.CloudCurtainsRightBack.transform;
			RectTransform rectTransform3 = (RectTransform)_currentLoadSaveScreenData.CloudCurtainsLeftFurtherBack.transform;
			RectTransform obj = (RectTransform)_currentLoadSaveScreenData.CloudCurtainsRightFurtherBack.transform;
			float animationX = (float)Screen.width * _animationXScalar;
			cloudLeftRect.anchoredPosition = new Vector2(0f, 0f);
			cloudRightRect.anchoredPosition = new Vector2(0f, 0f);
			rectTransform.anchoredPosition = new Vector2(0f, 0f);
			rectTransform2.anchoredPosition = new Vector2(0f, 0f);
			rectTransform3.anchoredPosition = new Vector2(0f, 0f);
			obj.anchoredPosition = new Vector2(0f, 0f);
			_currentLoadSaveScreenData.LoadingScreenCanvasGroup.alpha = 1f;
			GameObjectUtils.SetActive(_currentLoadSaveScreenData.LoadingPanel, isActive: true);
			GameObjectUtils.SetActive(_currentLoadSaveScreenData.CloudCurtainsLeft.gameObject, isActive: true);
			GameObjectUtils.SetActive(_currentLoadSaveScreenData.CloudCurtainsRight.gameObject, isActive: true);
			GameObjectUtils.SetActive(_currentLoadSaveScreenData.CloudCurtainsLeftBack.gameObject, isActive: false);
			GameObjectUtils.SetActive(_currentLoadSaveScreenData.CloudCurtainsRightBack.gameObject, isActive: false);
			GameObjectUtils.SetActive(_currentLoadSaveScreenData.CloudCurtainsLeftFurtherBack.gameObject, isActive: false);
			GameObjectUtils.SetActive(_currentLoadSaveScreenData.CloudCurtainsRightFurtherBack.gameObject, isActive: false);
			yield return null;
			float elapsedTime = 0f;
			float animateOutTime = (DebugVars.FastLoadingScreenAnimation.Value ? 0.1f : _animateOutTime);
			while (elapsedTime < animateOutTime)
			{
				elapsedTime += Time.unscaledDeltaTime;
				Alpha = Mathf.Clamp01(Alpha - Time.unscaledTime);
				float num = EasingsUtils.CubicEaseIn(elapsedTime / animateOutTime);
				cloudLeftRect.anchoredPosition = new Vector2(Mathf.Lerp(0f, 0f - animationX, num), 0f);
				cloudRightRect.anchoredPosition = new Vector2(Mathf.Lerp(0f, animationX, num), 0f);
				_currentLoadSaveScreenData.LoadingScreenCanvasGroup.alpha = 1f - num;
				yield return null;
			}
			GameObjectUtils.SetActive(_currentLoadSaveScreenData.CloudCurtainsLeft.gameObject, isActive: false);
			GameObjectUtils.SetActive(_currentLoadSaveScreenData.CloudCurtainsRight.gameObject, isActive: false);
			_currentOperationCoroutine = null;
			GameObjectUtils.SetActive(base.gameObject, isActive: false);
		}

		private IEnumerator AnimateCoroutine(bool show)
		{
			RectTransform cloudLeftRect = (RectTransform)_currentLoadSaveScreenData.CloudCurtainsLeft.transform;
			RectTransform cloudRightRect = (RectTransform)_currentLoadSaveScreenData.CloudCurtainsRight.transform;
			RectTransform cloudLeftBackRect = (RectTransform)_currentLoadSaveScreenData.CloudCurtainsLeftBack.transform;
			RectTransform cloudRightBackRect = (RectTransform)_currentLoadSaveScreenData.CloudCurtainsRightBack.transform;
			RectTransform cloudLeftFurtherBackRect = (RectTransform)_currentLoadSaveScreenData.CloudCurtainsLeftFurtherBack.transform;
			RectTransform cloudRightFurtherBackRect = (RectTransform)_currentLoadSaveScreenData.CloudCurtainsRightFurtherBack.transform;
			float num = (float)Screen.width * _animationXScalar;
			float num2 = (float)Screen.width * _animationXScalarBack;
			float num3 = (float)Screen.width * _animationXScalarFurtherBack;
			cloudLeftRect.anchoredPosition = new Vector2(0f - num, 0f);
			cloudRightRect.anchoredPosition = new Vector2(num, 0f);
			cloudLeftBackRect.anchoredPosition = new Vector2(0f - num2, 0f);
			cloudRightBackRect.anchoredPosition = new Vector2(num2, 0f);
			cloudLeftFurtherBackRect.anchoredPosition = new Vector2(0f - num3, 0f);
			cloudRightFurtherBackRect.anchoredPosition = new Vector2(num3, 0f);
			GameObjectUtils.SetActive(_currentLoadSaveScreenData.LoadingPanel, !show);
			GameObjectUtils.SetActive(_currentLoadSaveScreenData.CloudCurtainsLeft.gameObject, isActive: true);
			GameObjectUtils.SetActive(_currentLoadSaveScreenData.CloudCurtainsRight.gameObject, isActive: true);
			GameObjectUtils.SetActive(_currentLoadSaveScreenData.CloudCurtainsLeftBack.gameObject, isActive: true);
			GameObjectUtils.SetActive(_currentLoadSaveScreenData.CloudCurtainsRightBack.gameObject, isActive: true);
			GameObjectUtils.SetActive(_currentLoadSaveScreenData.CloudCurtainsLeftFurtherBack.gameObject, isActive: true);
			GameObjectUtils.SetActive(_currentLoadSaveScreenData.CloudCurtainsRightFurtherBack.gameObject, isActive: true);
			yield return null;
			float elapsedTime = 0f;
			float animateInTime = (DebugVars.FastLoadingScreenAnimation.Value ? 0.1f : _animateInTime);
			while (elapsedTime < animateInTime)
			{
				elapsedTime += Time.unscaledDeltaTime;
				float num4 = elapsedTime / animateInTime;
				float p = Mathf.Clamp01(elapsedTime / (animateInTime * 0.6f));
				float p2 = Mathf.Clamp01(elapsedTime / (animateInTime * 0.35f));
				_currentLoadSaveScreenData.CloudCurtainsLeft.alpha = Mathf.Clamp01(num4 * 5f);
				_currentLoadSaveScreenData.CloudCurtainsRight.alpha = Mathf.Clamp01(num4 * 5f);
				_currentLoadSaveScreenData.CloudCurtainsLeftBack.alpha = Mathf.Clamp01(num4 * 5f);
				_currentLoadSaveScreenData.CloudCurtainsRightBack.alpha = Mathf.Clamp01(num4 * 5f);
				_currentLoadSaveScreenData.CloudCurtainsLeftFurtherBack.alpha = Mathf.Clamp01(num4 * 5f);
				_currentLoadSaveScreenData.CloudCurtainsRightFurtherBack.alpha = Mathf.Clamp01(num4 * 5f);
				float t = EasingsUtils.CubicEaseOut(num4);
				float t2 = EasingsUtils.CubicEaseOut(p);
				float t3 = EasingsUtils.CubicEaseOut(p2);
				num = (float)Screen.width * _animationXScalar;
				num2 = (float)Screen.width * _animationXScalarBack;
				num3 = (float)Screen.width * _animationXScalarFurtherBack;
				cloudLeftRect.anchoredPosition = new Vector2(Mathf.Lerp(0f - num, 0f, t), 0f);
				cloudRightRect.anchoredPosition = new Vector2(Mathf.Lerp(num, 0f, t), 0f);
				cloudLeftBackRect.anchoredPosition = new Vector2(Mathf.Lerp(0f - num2, 0f, t2), 0f);
				cloudRightBackRect.anchoredPosition = new Vector2(Mathf.Lerp(num2, 0f, t2), 0f);
				cloudLeftFurtherBackRect.anchoredPosition = new Vector2(Mathf.Lerp(0f - num3, 0f, t3), 0f);
				cloudRightFurtherBackRect.anchoredPosition = new Vector2(Mathf.Lerp(num3, 0f, t3), 0f);
				yield return null;
			}
			GameObjectUtils.SetActive(_currentLoadSaveScreenData.LoadingPanel, show);
			yield return null;
			GameObjectUtils.SetActive(_currentLoadSaveScreenData.CloudCurtainsLeftBack.gameObject, isActive: false);
			GameObjectUtils.SetActive(_currentLoadSaveScreenData.CloudCurtainsRightBack.gameObject, isActive: false);
			GameObjectUtils.SetActive(_currentLoadSaveScreenData.CloudCurtainsLeftFurtherBack.gameObject, isActive: false);
			GameObjectUtils.SetActive(_currentLoadSaveScreenData.CloudCurtainsRightFurtherBack.gameObject, isActive: false);
			elapsedTime = 0f;
			float animateOutTime = (DebugVars.FastLoadingScreenAnimation.Value ? 0.1f : _animateOutTime);
			while (elapsedTime < animateOutTime)
			{
				elapsedTime += Time.unscaledDeltaTime;
				float t4 = EasingsUtils.CubicEaseIn(elapsedTime / animateOutTime);
				num = (float)Screen.width * _animationXScalar;
				cloudLeftRect.anchoredPosition = new Vector2(Mathf.Lerp(0f, 0f - num, t4), 0f);
				cloudRightRect.anchoredPosition = new Vector2(Mathf.Lerp(0f, num, t4), 0f);
				yield return null;
			}
			GameObjectUtils.SetActive(_currentLoadSaveScreenData.CloudCurtainsLeft.gameObject, isActive: false);
			GameObjectUtils.SetActive(_currentLoadSaveScreenData.CloudCurtainsRight.gameObject, isActive: false);
			_currentOperationCoroutine = null;
			if (!show)
			{
				GameObjectUtils.SetActive(base.gameObject, isActive: false);
			}
		}
	}
}
