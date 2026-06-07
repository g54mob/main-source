using UnityEngine;

namespace ModApi.Craft.Parts.Styles
{
	public class PartStyleData
	{
		private PartData _part;

		public PartData Part => _part;

		public IPartStyle Style { get; set; }

		public Vector2 TextureOffset { get; set; }

		public IPartTextureStyle TextureStyle { get; set; }

		public Vector2 TextureTiling { get; set; }

		public PartStyleData(PartData part, IPartStyle style, IPartTextureStyle textureStyle)
		{
			_part = part;
			Style = style;
			TextureStyle = textureStyle;
			TextureTiling = Vector2.one;
			TextureOffset = Vector2.zero;
		}

		public PartStyleData(PartData part, IPartStyle style, IPartTextureStyle textureStyle, Vector2 tiling, Vector2 offset)
		{
			_part = part;
			Style = style;
			TextureStyle = textureStyle;
			TextureTiling = tiling;
			TextureOffset = offset;
		}
	}
}
