using System.Xml.Linq;
using ModApi.Craft.Parts;
using ModApi.Ui;

namespace Assets.Scripts.Design.PartProperties
{
	public class PartPropertiesUndoStep : UndoStep
	{
		public int PartId { get; private set; }

		public PartPropertiesUndoStep(XElement xml, int partId)
			: base(xml)
		{
			PartId = partId;
		}

		public override void OnRedoComplete(DesignerScript designer)
		{
			ShowPartProperties(designer);
		}

		public override void OnUndoComplete(DesignerScript designer)
		{
			ShowPartProperties(designer);
		}

		private void ShowPartProperties(DesignerScript designer)
		{
			PartData partById = designer.CraftScript.Data.Assembly.GetPartById(PartId);
			if (partById != null && partById.PartScript != null)
			{
				designer.SelectPart(partById.PartScript, null, justAdded: false);
			}
			IFlyout partProperties = designer.DesignerUi.Flyouts.PartProperties;
			if (!partProperties.IsOpen)
			{
				partProperties.Open();
				PartPropertiesFlyoutScript.OpenedViaUndoStep = true;
			}
		}
	}
}
