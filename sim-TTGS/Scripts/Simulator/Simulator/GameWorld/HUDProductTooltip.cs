using DG.Tweening;
using Dhs5.Utility.Updates;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Simulator.GameWorld
{
	public class HUDProductTooltip : MonoBehaviour
	{
		[Header("References")]
		[SerializeField]
		private CanvasGroup m_canvasGroup;

		[Space(10f)]
		[SerializeField]
		private SimulatorText m_productNameText;

		[SerializeField]
		protected Image m_itemImage;

		[SerializeField]
		protected TextMeshProUGUI m_currentPriceText;

		[SerializeField]
		protected TextMeshProUGUI m_marketPriceText;

		[Header("Delays")]
		[SerializeField]
		private float m_canvasFadeDuration = 0.25f;

		[SerializeField]
		private float m_delayShowTooltip = 0.5f;

		private Tween m_canvasTween;

		private DelayedCallHandle m_handle;

		private bool m_isShown;

		public void ShowTooltip(ProductData data = null)
		{
			m_handle.Kill();
			base.gameObject.SetActive(value: true);
			m_canvasGroup.alpha = 0f;
			Updater.CallInXSeconds(m_delayShowTooltip, delegate
			{
				ShowValue(show: true, data);
			}, out m_handle);
			m_isShown = true;
		}

		public void HideTooltip()
		{
			m_handle.Kill();
			ShowValue(show: false, null);
			m_isShown = false;
		}

		private void ShowValue(bool show, ProductData data)
		{
			m_canvasTween?.Kill();
			m_canvasTween = m_canvasGroup.DOFade(show ? 1 : 0, m_canvasFadeDuration).OnComplete(SetActive);
			if (show)
			{
				m_productNameText.SetTerm(data.NameTerm);
				m_itemImage.sprite = data.Sprite;
				m_marketPriceText.text = PriceManager.GetProductMarketPrice(data.UID).ToStringMoneyFormat();
				if (PriceManager.TryGetProductPrice(data.UID, out var price))
				{
					m_currentPriceText.text = price.ToStringMoneyFormat();
				}
				else
				{
					m_currentPriceText.text = "- - -";
				}
			}
		}

		private void SetActive()
		{
			base.gameObject.SetActive(m_isShown);
		}
	}
}
