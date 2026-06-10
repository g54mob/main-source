using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class InvertGateDirectionEntry : MonoBehaviour
	{
		[SerializeField]
		private Image image;

		[SerializeField]
		private Image backgroundImage;

		[SerializeField]
		private Button toggleButton;

		[SerializeField]
		private Graphic toggleGraphicCheckmark;

		[SerializeField]
		private Graphic toggleGraphicPartial;

		public Button Toggle => toggleButton;

		public void Init(Color backgroundColor)
		{
			backgroundImage.color = backgroundColor;
		}

		public void SetCheckboxGraphic(bool enabled, bool partial)
		{
			toggleGraphicPartial.gameObject.SetActive(enabled && partial);
			toggleGraphicCheckmark.gameObject.SetActive(enabled && !partial);
		}
	}
}
