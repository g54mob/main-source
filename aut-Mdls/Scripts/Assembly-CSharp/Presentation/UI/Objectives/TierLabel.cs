using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.Objectives
{
	public class TierLabel : MonoBehaviour
	{
		[SerializeField]
		private Image _tierBg;

		[SerializeField]
		private TextMeshProUGUI _tierText;

		[SerializeField]
		private GameObject _tierIcon;

		public void Initialize(Color color)
		{
			_tierBg.color = color;
			_tierIcon.SetActive(value: false);
		}

		public void SetTier(int tier, int max)
		{
			if (tier > 0)
			{
				_tierText.text = (tier + 1).ToString();
				_tierIcon.SetActive(tier >= max);
				_tierText.gameObject.SetActive(tier < max);
			}
		}
	}
}
