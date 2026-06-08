using Rhizomatic;
using UnityEngine;

namespace GRP
{
	[CreateAssetMenu(menuName = "GRP/Main/LayerHighlightConfig", fileName = "LayerHighlightConfig")]
	[AssetCreator(typeof(MainAssetCategory))]
	public class LayerHighlightConfig : HighlightConfig
	{
		public string layer;

		protected override Highlight DoGetHighlight()
		{
			return null;
		}
	}
}
