using I2.Loc;
using Simulator;
using TMPro;
using UnityEngine;

namespace Tabletop.GameWorld
{
	public class UI_WargameBannerRoundText : MonoBehaviour
	{
		[Header("UI Components")]
		[SerializeField]
		private TextMeshProUGUI m_mainText;

		[SerializeField]
		private TextMeshProUGUI m_roundValueText;

		[SerializeField]
		private SimulatorText m_roundResultText;

		[SerializeField]
		[TermsPopup("")]
		private string m_roundLostTerm;

		[SerializeField]
		[TermsPopup("")]
		private string m_roundWonTerm;

		[SerializeField]
		[TermsPopup("")]
		private string m_roundDrawTerm;

		public void SetRoundValue(int roundNumber)
		{
			m_mainText.enabled = true;
			m_roundValueText.gameObject.SetActive(value: true);
			m_roundResultText.gameObject.SetActive(value: false);
			m_roundValueText.text = roundNumber.ToString();
		}

		public void SetRoundResult(EWargameResult result)
		{
			m_mainText.enabled = true;
			m_roundValueText.gameObject.SetActive(value: false);
			m_roundResultText.gameObject.SetActive(value: true);
			string term = result switch
			{
				EWargameResult.PLAYER_A => m_roundWonTerm, 
				EWargameResult.PLAYER_B => m_roundLostTerm, 
				EWargameResult.DRAW => m_roundDrawTerm, 
				_ => string.Empty, 
			};
			m_roundResultText.SetTerm(term);
		}

		public void SetEnabled(bool value)
		{
			m_mainText.enabled = value;
			m_roundValueText.gameObject.SetActive(value);
			m_roundResultText.gameObject.SetActive(value);
		}
	}
}
