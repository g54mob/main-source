using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Michsky.DreamOS
{
	public class ImageMessage : MonoBehaviour
	{
		public Image imageObject;

		public ButtonManager viewButton;

		public TextMeshProUGUI timeText;

		[HideInInspector]
		public PhotoGalleryManager pgm;

		private WindowManager pgmwm;

		[HideInInspector]
		public Sprite spriteVar;

		[HideInInspector]
		public string title;

		[HideInInspector]
		public string description;

		private void Start()
		{
			if (pgm == null)
			{
				viewButton.Interactable(value: false);
				return;
			}
			pgmwm = pgm.gameObject.GetComponent<WindowManager>();
			viewButton.onClick.AddListener(delegate
			{
				pgmwm.OpenWindow();
				pgm.OpenPhoto(spriteVar, title, description);
			});
		}
	}
}
