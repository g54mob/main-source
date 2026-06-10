using NSMedieval.FloatingOverlaySystem;
using NSMedieval.UI.Utils;
using TMPro;
using UnityEngine;

namespace NSMedieval.State
{
	public class ThoughtBubbleFloatingElement : FloatingElementBase
	{
		[SerializeField]
		private GameObject icon1;

		[SerializeField]
		private GameObject icon2;

		public void SetupIcons(string icon1, string icon2)
		{
			if (!string.IsNullOrEmpty(icon1))
			{
				this.icon1.GetComponent<TMP_Text>().text = AssetUtils.GetSpriteAsset(icon1) + "   ";
			}
			else
			{
				this.icon1.SetActive(value: false);
			}
			if (!string.IsNullOrEmpty(icon2))
			{
				this.icon2.GetComponent<TMP_Text>().text = AssetUtils.GetSpriteAsset(icon2) + "   ";
			}
			else
			{
				this.icon2.SetActive(value: false);
			}
		}
	}
}
