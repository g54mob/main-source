using Rhizomatic;
using UnityEngine;

namespace GRP
{
	[CreateAssetMenu(menuName = "GRP/Main/HighlightGroupConfig", fileName = "HighlightGroupConfig")]
	[AssetCreator(typeof(MainAssetCategory))]
	public class HighlightGroupConfig : HighlightConfig
	{
		public HighlightConfig[] highlights;

		protected override Highlight DoGetHighlight()
		{
			return null;
		}
	}
}
