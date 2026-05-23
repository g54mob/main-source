using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class AdditionalRewardRow : MonoBehaviour
	{
		[SerializeField]
		private Image sourceImage;

		[SerializeField]
		private TMP_Text sourceName;

		[SerializeField]
		private Image getImage;

		[SerializeField]
		private TMP_Text getText;

		public void InitComponent(WaveRewardResultDialog.AdditionalRewardData data)
		{
		}

		public void SetIcon(ref Image iconImage, string iconPath)
		{
		}

		public void SetText(ref TMP_Text tmp, string name)
		{
		}
	}
}
