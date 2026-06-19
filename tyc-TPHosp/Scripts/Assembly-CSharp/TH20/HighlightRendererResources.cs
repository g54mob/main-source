using UnityEngine;

namespace TH20
{
	[CreateAssetMenu(menuName = "TH20/Configs/Highlight Renderer Manager", order = 1111)]
	public class HighlightRendererResources : ScriptableObjectWithID
	{
		public Material UnlitPassMaterial;

		public Material UnlitBlackPassMaterial;

		public Material HighlightExpandPassMaterial;

		public Material HighlightApplyPassMaterial;
	}
}
