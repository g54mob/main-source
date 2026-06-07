using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tabletop.GameWorld
{
	public class UI_CollectionCompletionBar : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI m_titleText;

		[SerializeField]
		private TextMeshProUGUI m_percentageText;

		[SerializeField]
		private Image m_percentageImage;

		public string Title
		{
			get
			{
				return m_titleText.text;
			}
			set
			{
				m_titleText.text = value;
			}
		}

		public float Value
		{
			get
			{
				return m_percentageImage.fillAmount;
			}
			set
			{
				m_percentageImage.fillAmount = value;
				m_percentageText.text = (value * 100f).ToString("0.0") + "%";
			}
		}
	}
}
