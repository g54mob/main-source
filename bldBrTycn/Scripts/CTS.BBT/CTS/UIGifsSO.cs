using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Video;

namespace CTS
{
	[CreateAssetMenu(fileName = "UIGifsSO", menuName = "BBT/UIGifsSO/UIGifsSO")]
	public class UIGifsSO : ScriptableObject
	{
		public enum EHelpingMediaType
		{
			none = 0,
			Image = 1,
			VideoClip = 2
		}

		[field: SerializeField]
		public EHelpingMediaType SelectedMediaType { get; private set; }

		[field: SerializeField]
		[field: ShowIf("SelectedMediaType", EHelpingMediaType.VideoClip)]
		public VideoClip VideoClip { get; private set; }

		[field: SerializeField]
		[field: ShowIf("SelectedMediaType", EHelpingMediaType.Image)]
		public Sprite Image { get; private set; }

		[field: SerializeField]
		public LocalizedString VideoTitle { get; private set; }

		[field: SerializeField]
		public LocalizedString VideoBody { get; private set; }
	}
}
