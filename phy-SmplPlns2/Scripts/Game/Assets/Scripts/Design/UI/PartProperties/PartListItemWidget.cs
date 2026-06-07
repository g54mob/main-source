using Assets.Scripts.Craft.Parts;
using Jundroo.Common.Utils;
using Jundroo.Juicy;
using Jundroo.Juicy.Widgets;

namespace Assets.Scripts.Design.UI.PartProperties
{
	public class PartListItemWidget : WidgetScript
	{
		private PartListWidget _partList;

		public int PartID { get; set; }

		public void Initialize(PartListWidget partListWidget, PartData part)
		{
			_partList = partListWidget;
			PartID = part.Id;
			string richText = (base.Widget.Stylesheet.GetConstant("PartNameFormat") ?? "{PartName}").Replace("{PartName}", StringUtility.ClampString(part.Name, 25)).Replace("{PartNumber}", part.Id.ToString());
			base.Widget.FindWidget<TextWidget>("item-name").RichText = richText;
		}

		private void OnDeleteClicked(Widget widget)
		{
			_partList.OnItemDeleted(this);
		}

		private void OnHoverEnter(Widget widget)
		{
			PartData partById = Designer.Instance.Aircraft.GetPartById(PartID);
			if (partById.PartScript != null)
			{
				partById.PartScript.PartMaterialScript.IsHighlighted = true;
			}
		}

		private void OnHoverExit(Widget widget)
		{
			PartData partById = Designer.Instance.Aircraft.GetPartById(PartID);
			if (partById.PartScript != null)
			{
				partById.PartScript.PartMaterialScript.IsHighlighted = false;
			}
		}
	}
}
