using Simulator.GameWorld;
using TMPro;
using UnityEngine;

namespace Simulator
{
	public class CashBoxElementUI : MonoBehaviour
	{
		[SerializeField]
		private CashAmount m_cashAmount;

		[SerializeField]
		private CashBox m_cashBox;

		[SerializeField]
		private Canvas m_canvas;

		[SerializeField]
		private TMP_Text m_text;

		private void Start()
		{
			SetActive(opened: false);
			RefreshText();
		}

		private void OnEnable()
		{
			m_cashBox.Opened += SetActive;
			GameplayApplicationOptions.Currency.OnValueChanged += OnCurrentValueChanged;
		}

		private void OnDisable()
		{
			m_cashBox.Opened -= SetActive;
			GameplayApplicationOptions.Currency.OnValueChanged -= OnCurrentValueChanged;
		}

		private void SetActive(bool opened)
		{
			m_canvas.gameObject.SetActive(opened);
		}

		private void OnCurrentValueChanged(GameplayApplicationOptions.ECurrency currency)
		{
			RefreshText();
		}

		private void RefreshText()
		{
			m_text.text = m_cashAmount.Get().Name();
		}
	}
}
