using ModApi.CelestialData;

namespace ModApi.Planet.Modifiers.Attributes
{
	public class TextureFileReferenceAttribute : SupportFileReferenceAttribute
	{
		public TextureFileReferenceFilterType FilterType { get; }

		public TextureFileReferenceAttribute()
			: base(SupportFileType.Texture)
		{
			FilterType = TextureFileReferenceFilterType.Default;
		}

		public TextureFileReferenceAttribute(TextureFileReferenceFilterType filterType)
			: base(SupportFileType.Texture)
		{
			FilterType = filterType;
		}
	}
}
