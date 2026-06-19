using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Michsky.DreamOS
{
	public class VideoPreset : MonoBehaviour
	{
		public ButtonManager presetButton;

		public Image coverImage;

		public TextMeshProUGUI titleText;

		public TextMeshProUGUI descriptionText;

		public TextMeshProUGUI durationText;

		public VideoPlayerManager.VideoType type;

		[HideInInspector]
		public VideoPlayerManager manager;

		[HideInInspector]
		public int videoIndex;

		[HideInInspector]
		public string videoURL;
	}
}
