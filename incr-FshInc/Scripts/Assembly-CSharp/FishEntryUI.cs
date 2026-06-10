using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;

public class FishEntryUI : MonoBehaviour
{
	public TextMeshProUGUI fishText;

	public TextMeshProUGUI dotAndMoneyText;

	public GameObject perfectCatchContainer;

	public TextMeshProUGUI perfectCatchMoneyText;

	private int maxDots = 18;

	private CanvasGroup _canvasGroup;

	private void Awake()
	{
		_canvasGroup = GetComponent<CanvasGroup>();
		if (_canvasGroup == null)
		{
			_canvasGroup = base.gameObject.AddComponent<CanvasGroup>();
		}
		_canvasGroup.alpha = 0f;
	}

	public void Setup(string fishName, string rarity, int moneyGained, bool isPerfectCatch, int perfectBonusMoney = 0)
	{
		fishText.text = "> " + fishName + " [" + rarity + "]";
		LocalizedString localizedString = new LocalizedString("Skills", "#ui.unit.gold");
		string text = CurrencyFormatter.FormatMoney(moneyGained) + " " + localizedString.GetLocalizedString();
		string text2 = new string('.', Mathf.Max(0, maxDots - text.Length));
		dotAndMoneyText.text = text2 + " " + text;
		perfectCatchContainer.SetActive(isPerfectCatch);
		if (isPerfectCatch)
		{
			LocalizedString localizedString2 = new LocalizedString("Skills", "#ui.text.perfect.catch");
			perfectCatchMoneyText.text = localizedString2.GetLocalizedString() + " (+" + CurrencyFormatter.FormatMoney(perfectBonusMoney) + " " + localizedString.GetLocalizedString() + ")";
		}
	}

	public Tween AnimateIn(float duration)
	{
		base.transform.localScale = Vector3.one * 0.9f;
		return DOTween.Sequence().Append(_canvasGroup.DOFade(1f, duration * 0.5f)).Join(base.transform.DOScale(1.05f, duration * 0.5f).SetEase(Ease.OutBack))
			.Append(base.transform.DOScale(1f, duration * 0.5f).SetEase(Ease.OutQuad))
			.SetAutoKill(autoKillOnCompletion: false);
	}

	public void Setup(string fishName, string rarity, int moneyGained)
	{
		LocalizedString localizedString = new LocalizedString("Skills", "#ui.unit.gold");
		fishText.text = fishName + " [" + rarity + "]";
		string text = $"{moneyGained}{localizedString.GetLocalizedString()}";
		string text2 = new string('.', Mathf.Max(0, maxDots - text.Length));
		dotAndMoneyText.text = text2 + " " + text;
		perfectCatchContainer.SetActive(value: false);
	}
}
