using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class StarAwardNotificationUnlockListItem : MonoBehaviour
	{
		[SerializeField]
		private Image _icon;

		[SerializeField]
		private TMP_Text _label;

		public void Setup(Sprite sprite, string text)
		{
			_icon.overrideSprite = sprite;
			_label.text = text;
		}
	}
}
