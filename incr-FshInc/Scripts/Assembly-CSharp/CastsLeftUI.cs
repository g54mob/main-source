using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CastsLeftUI : MonoBehaviour
{
	[Header("UI References")]
	[SerializeField]
	private TextMeshProUGUI currentCastsText;

	[SerializeField]
	private TextMeshProUGUI maxCastsText;

	[SerializeField]
	private Transform containerTransform;

	[SerializeField]
	private Image rodImage;

	[Header("Animation Settings")]
	[SerializeField]
	private float punchScale = 1.3f;

	[SerializeField]
	private float punchDuration = 0.25f;

	[SerializeField]
	private Color lowCastsColor = new Color(1f, 0.5f, 0.5f);

	[SerializeField]
	private int lowCastsThreshold = 3;

	[SerializeField]
	private float shakeStrength = 10f;

	[Header("Slide-In Animation")]
	[SerializeField]
	private float initialWait = 0.2f;

	[SerializeField]
	private float slideInDuration = 0.5f;

	[SerializeField]
	private Ease slideInEase = Ease.OutBack;

	private Color _defaultColor;

	private int _previousCasts;

	public PlayerManager playerManager;

	private RectTransform _containerRect;

	private Vector2 _originalAnchoredPos;

	private void Start()
	{
		_containerRect = containerTransform as RectTransform;
		if (_containerRect != null)
		{
			_originalAnchoredPos = _containerRect.anchoredPosition;
			Vector2 anchoredPosition = new Vector2(_originalAnchoredPos.x, _originalAnchoredPos.y + 100f);
			_containerRect.anchoredPosition = anchoredPosition;
			_containerRect.DOAnchorPos(_originalAnchoredPos, slideInDuration).SetDelay(initialWait).SetEase(slideInEase);
		}
		if (currentCastsText != null)
		{
			_defaultColor = currentCastsText.color;
		}
		if (playerManager != null)
		{
			playerManager.OnCastsChanged += UpdateDisplay;
			if (PlayerStats.Instance != null)
			{
				UpdateDisplay(playerManager.currentEnergy, PlayerStats.Instance.MaxEnergy);
			}
		}
		else
		{
			Debug.LogError("CastsLeftUI: PlayerManager.Instance is not found!");
		}
	}

	private void OnDestroy()
	{
		if (playerManager != null)
		{
			playerManager.OnCastsChanged -= UpdateDisplay;
		}
	}

	private void UpdateDisplay(int current, int max)
	{
		if (!(currentCastsText == null) && !(maxCastsText == null))
		{
			currentCastsText.text = current.ToString();
			maxCastsText.text = max.ToString();
			float fillAmount = (float)current / (float)max;
			rodImage.fillAmount = fillAmount;
			if (current < _previousCasts)
			{
				PlayUpdateAnimation(current);
			}
			bool flag = current <= lowCastsThreshold && current >= 0;
			currentCastsText.DOColor(flag ? lowCastsColor : _defaultColor, 0.2f);
			_previousCasts = current;
		}
	}

	private void PlayUpdateAnimation(int currentCasts)
	{
		currentCastsText.transform.DOKill(complete: true);
		containerTransform.DOKill(complete: true);
		Sequence s = DOTween.Sequence();
		s.Append(currentCastsText.transform.DOPunchScale(Vector3.one * (punchScale - 1f), punchDuration, 5, 0.5f));
		s.Join(containerTransform.DOShakePosition(punchDuration * 1.5f, new Vector3(shakeStrength, 0f, 0f)));
	}
}
