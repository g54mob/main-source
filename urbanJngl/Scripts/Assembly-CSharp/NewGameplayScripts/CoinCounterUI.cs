using System;
using DG.Tweening;
using Infrastructure.Services;
using Infrastructure.Services.CoinService;
using TMPro;
using UnityEngine;

namespace NewGameplayScripts
{
	public class CoinCounterUI : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI coinText;

		private Sequence triggerAnimation;

		public static CoinCounterUI Instance { get; private set; }

		private void Awake()
		{
			Instance = this;
			AllServices.Container.Single<ICoinService>().OnCoinChanged += UpdateCoinText;
		}

		private void Start()
		{
			UpdateCoinText();
			CoinParticlesManagerUI.Instance.OnCoinHitCounter += CoinParticlesManagerUI_OnCoinHitCounter;
		}

		private void OnDestroy()
		{
			AllServices.Container.Single<ICoinService>().OnCoinChanged -= UpdateCoinText;
			CoinParticlesManagerUI.Instance.OnCoinHitCounter -= CoinParticlesManagerUI_OnCoinHitCounter;
		}

		private void CoinParticlesManagerUI_OnCoinHitCounter(object sender, EventArgs e)
		{
			GetCoins();
			SoundManager.Instance.OnRecievePoints();
		}

		private void UpdateCoinText()
		{
			if (coinText != null)
			{
				coinText.text = AllServices.Container.Single<ICoinService>().GetCoin().ToString();
			}
		}

		private void GetCoins()
		{
			SoundManager.Instance.OnRecievePoints();
			TriggerCounter();
		}

		public void CoinsNotEnough()
		{
			SoundManager.Instance.OnCoinsNotEnough();
			TriggerCounter();
		}

		public void TriggerCounter()
		{
			SoundManager.Instance.OnRecievePoints();
			triggerAnimation.Kill();
			triggerAnimation = DOTween.Sequence();
			triggerAnimation.Append(base.transform.DOScale(0.9f, 0.05f).SetEase(Ease.InOutSine)).Append(base.transform.DOScale(1.1f, 0.1f).SetEase(Ease.InOutSine)).Append(base.transform.DOScale(1f, 0.1f).SetEase(Ease.InOutSine))
				.Play();
		}
	}
}
