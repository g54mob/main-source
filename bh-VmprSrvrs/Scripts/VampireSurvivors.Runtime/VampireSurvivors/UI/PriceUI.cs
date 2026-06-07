using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivors.UI
{
	public class PriceUI : MonoBehaviour
	{
		[SerializeField]
		private Image Icon;

		[SerializeField]
		private TextMeshProUGUI Text;

		private bool _shouldUpdateFormatting;

		public void SetPrice(float price)
		{
		}

		private void LateUpdate()
		{
		}
	}
}
