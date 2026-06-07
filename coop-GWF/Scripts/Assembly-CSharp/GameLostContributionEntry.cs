using System;
using System.Collections;
using DG.Tweening;
using FMODUnity;
using TMPro;
using UnityEngine;

public class GameLostContributionEntry : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI playerNameText;

	[SerializeField]
	private TextMeshProUGUI contributionText;

	[SerializeField]
	private EventReference textChangeSfx;

	private string _playerName;

	private long _contribution;

	private UIColorPalette _colorPalette;

	public void Setup(string playerName, long contribution)
	{
		_playerName = playerName;
		_contribution = contribution;
		_colorPalette = Resources.Load<UIColorPalette>("ColorSettings");
	}

	public IEnumerator Animate(float duration)
	{
		playerNameText.text = _playerName;
		yield return new WaitForSeconds(duration);
		contributionText.color = ((_contribution >= 0) ? _colorPalette.profitGreen : _colorPalette.lossRed);
		DOVirtual.Float(0f, 1f, duration, delegate(float t)
		{
			double a = (float)_contribution * t;
			contributionText.text = MoneyFormatter.FormatWithDollar((long)Math.Round(a)) ?? "";
			if (_contribution != 0L)
			{
				SFXManager.SFXOneShot(textChangeSfx);
			}
		}).SetEase(Ease.OutCubic).OnComplete(delegate
		{
			contributionText.transform.DOPunchScale(contributionText.transform.localScale * 0.2f, 0.5f, 1);
		});
		yield return new WaitForSeconds(duration + 0.5f);
	}

	public void SetImmediate()
	{
		playerNameText.text = _playerName;
		contributionText.color = ((_contribution >= 0) ? _colorPalette.profitGreen : _colorPalette.lossRed);
		contributionText.text = MoneyFormatter.FormatWithDollar(_contribution) ?? "";
	}
}
