using Rhizomatic;
using UnityEngine;

namespace GRP
{
	[CreateAssetMenu(menuName = "GRP/Main/MaterialHighlightConfig", fileName = "MaterialHighlightConfig")]
	[AssetCreator(typeof(MainAssetCategory))]
	public class MaterialHighlightConfig : HighlightConfig
	{
		public Material material;

		public bool forceColor;

		protected override Highlight DoGetHighlight()
		{
			return null;
		}
	}
}
