using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class ZoneMapNode : MonoBehaviour
{
	[Header("Hierarchy Targets")]
	public RectTransform visualWrapper;

	public RectTransform shadowTransform;

	public Image shadowImage;

	[Header("UI Data References")]
	public Image nodeBackgroundImage;

	public Image nodeRadialImage;

	public Image nodeIconImage;

	public Image nodeFrameImage;

	public Button nodeButton;

	public TextMeshProUGUI nodeNameText;

	[Header("Juice Settings")]
	public float floatSpeed = 1f;

	public float floatHeight = 15f;

	public float shadowShrinkAmount = 0.7f;

	public float shadowLightAlpha = 0.3f;

	[Tooltip("Time in seconds to complete one full 360-degree rotation. Higher values = slower rotation.")]
	public float radialRotationDuration = 4f;

	[Header("Travel Dots")]
	public GameObject dotsContainer;

	public RectTransform[] travelDots;

	[Header("Afford Notification")]
	public GameObject affordNotification;

	[Header("Colors")]
	public Color selectedColor = Color.yellow;

	private int _myIndex;

	private ZoneMapController _controller;

	private ZoneData _zoneData;

	private bool _isUnlocked;

	private Vector2 _wrapperOriginalPos;

	private float _shadowOriginalAlpha;

	private Tween _floatTween;

	private Tween _shadowScaleTween;

	private Tween _shadowFadeTween;

	private Tween _wrapperScaleTween;

	private Tween _saturationTween;

	private Tween _radialRotateTween;

	private void Awake()
	{
		if (visualWrapper != null)
		{
			_wrapperOriginalPos = visualWrapper.anchoredPosition;
		}
		if (shadowImage != null)
		{
			_shadowOriginalAlpha = shadowImage.color.a;
		}
	}

	private void OnDestroy()
	{
		KillAllTweens();
	}

	public void Setup(ZoneData data, int index, bool isLastNode, ZoneMapController controller, Material zoneMat, bool animateUnlock = false)
	{
		KillAllTweens();
		_myIndex = index;
		_controller = controller;
		_zoneData = data;
		_isUnlocked = data.isUnlocked;
		if (visualWrapper != null)
		{
			visualWrapper.anchoredPosition = _wrapperOriginalPos;
			visualWrapper.localScale = Vector3.one;
		}
		if (shadowTransform != null)
		{
			shadowTransform.localScale = Vector3.one;
		}
		if (shadowImage != null)
		{
			Color color = shadowImage.color;
			color.a = _shadowOriginalAlpha;
			shadowImage.color = color;
		}
		if (nodeIconImage != null)
		{
			nodeIconImage.sprite = data.zoneIcon;
			nodeIconImage.color = Color.white;
			nodeIconImage.material = zoneMat;
		}
		string text = data.zoneName.ToLowerInvariant().Replace(" ", ".");
		string text2 = "#ui.zone." + text + ".title";
		LocalizedString localizedString = new LocalizedString("Skills", text2);
		if (nodeNameText != null)
		{
			if (!data.isUnlocked)
			{
				nodeNameText.text = "????";
			}
			else
			{
				string text3 = localizedString.GetLocalizedString();
				if (string.IsNullOrWhiteSpace(text3) || text3 == text2)
				{
					text3 = data.zoneName;
				}
				nodeNameText.text = text3;
			}
		}
		if (dotsContainer != null)
		{
			dotsContainer.SetActive(!isLastNode);
		}
		nodeButton.onClick.RemoveAllListeners();
		nodeButton.onClick.AddListener(OnNodeClicked);
	}

	public void SetSelected(bool isSelected)
	{
		_floatTween?.Kill();
		_shadowScaleTween?.Kill();
		_shadowFadeTween?.Kill();
		_wrapperScaleTween?.Kill();
		_radialRotateTween?.Kill();
		if (visualWrapper == null)
		{
			return;
		}
		if (isSelected)
		{
			if (nodeRadialImage != null)
			{
				_radialRotateTween = nodeRadialImage.rectTransform.DORotate(new Vector3(0f, 0f, -360f), radialRotationDuration, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
			}
			_wrapperScaleTween = visualWrapper.DOScale(1.1f, 0.3f).SetEase(Ease.OutBack);
			_floatTween = visualWrapper.DOAnchorPosY(_wrapperOriginalPos.y + floatHeight, floatSpeed).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
			if (shadowTransform != null && shadowImage != null)
			{
				_shadowScaleTween = shadowTransform.DOScale(Vector3.one * shadowShrinkAmount, floatSpeed).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
				_shadowFadeTween = shadowImage.DOFade(shadowLightAlpha, floatSpeed).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
			}
			return;
		}
		if (nodeRadialImage != null)
		{
			nodeRadialImage.rectTransform.DORotate(Vector3.zero, 0.2f).SetEase(Ease.OutQuad);
		}
		visualWrapper.DOScale(1f, 0.2f);
		visualWrapper.DOAnchorPos(_wrapperOriginalPos, 0.2f);
		if (shadowTransform != null)
		{
			shadowTransform.DOScale(1f, 0.2f);
		}
		if (shadowImage != null)
		{
			shadowImage.DOFade(_shadowOriginalAlpha, 0.2f);
		}
	}

	private void KillAllTweens()
	{
		_floatTween?.Kill();
		_shadowScaleTween?.Kill();
		_shadowFadeTween?.Kill();
		_wrapperScaleTween?.Kill();
		_saturationTween?.Kill();
		_radialRotateTween?.Kill();
		if (visualWrapper != null)
		{
			visualWrapper.DOKill();
		}
		if (shadowTransform != null)
		{
			shadowTransform.DOKill();
		}
		if (shadowImage != null)
		{
			shadowImage.DOKill();
		}
		if (affordNotification != null)
		{
			affordNotification.transform.DOKill();
		}
	}

	public void AnimateTravelDots(bool movingRight)
	{
		if (travelDots != null && travelDots.Length != 0)
		{
			RectTransform[] array = travelDots;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].DOKill();
			}
			StartCoroutine(DoDotWaveSequence(movingRight));
		}
	}

	private IEnumerator DoDotWaveSequence(bool movingRight)
	{
		float jumpHeight = 20f;
		float duration = 0.4f;
		float stagger = 0.1f;
		int num = ((!movingRight) ? (travelDots.Length - 1) : 0);
		int end = (movingRight ? travelDots.Length : (-1));
		int step = (movingRight ? 1 : (-1));
		for (int i = num; i != end; i += step)
		{
			SoundManager.PlaySound("mapPlop");
			RectTransform obj = travelDots[i];
			obj.DOJumpAnchorPos(obj.anchoredPosition, jumpHeight, 1, duration);
			yield return new WaitForSeconds(stagger);
		}
	}

	public void UpdateAffordNotification()
	{
		if (affordNotification == null || _zoneData == null)
		{
			return;
		}
		if (_zoneData.isUnlocked)
		{
			if (affordNotification.activeSelf)
			{
				affordNotification.transform.DOKill();
				affordNotification.transform.DOScale(0f, 0.3f).SetEase(Ease.InBack).OnComplete(delegate
				{
					affordNotification.SetActive(value: false);
					affordNotification.transform.localScale = Vector3.one;
				});
			}
			return;
		}
		double effectiveZoneUnlockCost = GameManager.Instance.GetEffectiveZoneUnlockCost(_zoneData);
		if (GameManager.Instance.totalMoney >= effectiveZoneUnlockCost)
		{
			affordNotification.transform.DOKill();
			affordNotification.SetActive(value: true);
			affordNotification.transform.localScale = Vector3.one;
		}
		else if (affordNotification.activeSelf)
		{
			affordNotification.transform.DOKill();
			affordNotification.transform.DOScale(0f, 0.3f).SetEase(Ease.InBack).OnComplete(delegate
			{
				affordNotification.SetActive(value: false);
				affordNotification.transform.localScale = Vector3.one;
			});
		}
		else
		{
			affordNotification.SetActive(value: false);
		}
	}

	private void OnNodeClicked()
	{
		_controller.SelectZone(_myIndex);
	}
}
