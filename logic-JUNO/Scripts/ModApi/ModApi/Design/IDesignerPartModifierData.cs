using ModApi.Craft.Parts;
using ModApi.Design.PartProperties;

namespace ModApi.Design
{
	public interface IDesignerPartModifierData
	{
		IDesignerPartPropertiesDesignerInterface DesignerPartProperties { get; }

		PartModifierData PartModifierData { get; }
	}
}
