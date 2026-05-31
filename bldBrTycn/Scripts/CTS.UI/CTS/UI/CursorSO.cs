using AssetIcons;
using CTS.Core;
using NaughtyAttributes;
using UnityEngine;

namespace CTS.UI
{
	[CreateAssetMenu(fileName = "Cursors", menuName = "CTS/Cursors")]
	public class CursorSO : ScriptableStringKey
	{
		[AssetIcon("100%", "100%", "0", "0", 64, IconAnchor.Center, IconAspect.Fit, "true", "#ffffff", 0, FontStyle.Normal, IconAnchor.Center, IconProjection.Perspective, -1, null)]
		[field: SerializeField]
		[field: ShowAssetPreview(64, 64)]
		public Texture2D Icon { get; private set; }

		[field: SerializeField]
		public Vector2 CursorOffset { get; private set; }

		[field: SerializeField]
		public int DefaultOrder { get; private set; }
	}
}
