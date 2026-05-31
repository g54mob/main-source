using AssetIcons;
using CTS.Core;
using CTS.UI;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/Main Character Data")]
	public class MainCharacterData : ScriptableStringKey
	{
		[field: SerializeField]
		public LocalizedString CharacterName { get; private set; }

		[field: SerializeField]
		public PaletteData Color { get; private set; }

		[field: SerializeField]
		public Sprite SquareIcon { get; private set; }

		[field: SerializeField]
		[field: ActorPopup(false)]
		public string DialogueActorId { get; private set; }

		[field: SerializeField]
		public AudioAsset DialogueAngry { get; private set; }

		[field: SerializeField]
		public AudioAsset DialogueNeutral { get; private set; }

		[field: SerializeField]
		public AudioAsset DialogueHonored { get; private set; }

		[AssetIcon("100%", "100%", "0", "0", 64, IconAnchor.Center, IconAspect.Fit, "true", "#ffffff", 0, FontStyle.Normal, IconAnchor.Center, IconProjection.Perspective, -1, null)]
		public Sprite GetAssetIcon()
		{
			return SquareIcon;
		}
	}
}
