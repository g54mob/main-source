using Jundroo.Common.Attributes;

namespace Assets.Scripts.Design
{
	public enum PartManipulationMode
	{
		[DisplayName("None")]
		None = 0,
		[DisplayName("Rotation X-Axis")]
		RotateX = 1,
		[DisplayName("Rotation Y-Axis")]
		RotateY = 2,
		[DisplayName("Rotation Z-Axis")]
		RotateZ = 3,
		[DisplayName("Translation X-Axis")]
		TranslateX = 4,
		[DisplayName("Translation Y-Axis")]
		TranslateY = 5,
		[DisplayName("Translation Z-Axis")]
		TranslateZ = 6
	}
}
