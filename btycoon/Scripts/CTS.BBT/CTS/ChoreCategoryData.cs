using AssetIcons;
using CTS.BBT;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/AI/Chore Category Data")]
	public class ChoreCategoryData : ScriptableObject
	{
		[field: SerializeField]
		[field: UniqueFlag(true)]
		public ChoreCategory Category { get; private set; }

		[field: SerializeField]
		public LocalizedString Name { get; private set; }

		[field: SerializeField]
		public LocalizedString Description { get; private set; }

		[AssetIcon("100%", "100%", "0", "0", 64, IconAnchor.Center, IconAspect.Fit, "true", "#ffffff", 0, FontStyle.Normal, IconAnchor.Center, IconProjection.Perspective, -1, null)]
		[field: SerializeField]
		[field: ShowAssetPreview(64, 64)]
		public Sprite Icon { get; private set; }
	}
}
