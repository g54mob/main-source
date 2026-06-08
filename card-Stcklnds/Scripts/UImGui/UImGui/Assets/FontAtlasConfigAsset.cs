using UnityEngine;

namespace UImGui.Assets
{
	[CreateAssetMenu(menuName = "Dear ImGui/Font Atlas Configuration")]
	internal sealed class FontAtlasConfigAsset : ScriptableObject
	{
		public uint RasterizerFlags;

		public FontDefinition[] Fonts;
	}
}
