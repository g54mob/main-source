using Rhizomatic;
using UnityEngine;

namespace GRP
{
	[CreateAssetMenu(menuName = "GRP/Main/RenderingLayerHighlightConfig", fileName = "RenderingLayerHighlightConfig")]
	[AssetCreator(typeof(MainAssetCategory))]
	public class RenderingLayerHighlightConfig : HighlightConfig
	{
		public RenderingLayerMask mask;

		protected override Highlight DoGetHighlight()
		{
			return null;
		}
	}
}
