using Jundroo.Common.Attributes;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public enum PartTargetingMode
	{
		[DisplayName("Single Part")]
		SinglePart = 0,
		[DisplayName("Multiple Parts")]
		MultipleParts = 1,
		[DisplayName("Custom")]
		Custom = 2
	}
}
