using Assets.Scripts.Craft.Parts;

namespace Assets.Scripts.Design.UI.PartProperties
{
	public interface ISelectPartPropertyModifier
	{
		void OnPartSelectionToolClosed(string fieldName, PartData part);

		bool OnPartSelectionToolFilterPart(string fieldName, PartData part);
	}
}
