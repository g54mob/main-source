using Rhizomatic;
using UnityEngine;

namespace GRP
{
	[CreateAssetMenu(menuName = "GRP/Main/ColorHighlightConfig", fileName = "ColorHighlightConfig")]
	[AssetCreator(typeof(MainAssetCategory))]
	public class ColorHighlightConfig : HighlightConfig
	{
		public Color color;

		protected override Highlight DoGetHighlight()
		{
			return null;
		}
	}
}
