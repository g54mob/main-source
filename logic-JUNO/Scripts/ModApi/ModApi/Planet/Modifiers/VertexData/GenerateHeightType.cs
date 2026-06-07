using ModApi.Common.Attributes;

namespace ModApi.Planet.Modifiers.VertexData
{
	public enum GenerateHeightType
	{
		[DisplayName("Lerp Min To Max")]
		LerpMinToMax = 0,
		[DisplayName("Lerp To/From Zero")]
		LerpToFromZero = 1
	}
}
