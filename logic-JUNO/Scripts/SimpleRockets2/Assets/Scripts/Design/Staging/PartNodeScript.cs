using System.Collections.Generic;
using ModApi.Craft.Parts;
using UI.Xml;
using UnityEngine.UI;

namespace Assets.Scripts.Design.Staging
{
	public class PartNodeScript : TreeNodeScript
	{
		public CategoryNodeScript CategoryNode => base.Parent as CategoryNodeScript;

		public bool FlaggedForDeletion { get; set; }

		public PartData PartData { get; set; }

		public override void HighlightParts(bool highlight)
		{
			PartData.PartScript.PartMaterialScript.IsHighlighted = highlight;
		}

		public void Initialize(StagingEditorScript stagingEditor, XmlElement element, PartData partData)
		{
			InitializeNode(stagingEditor, element);
			PartData = partData;
			base.Text = partData.Name;
			element.GetElementByInternalId<Image>("node-icon").sprite = ActivationTypeIcons.GetActivationIcon(partData.Config.StageActivationType);
		}

		protected override void GetPartNodesRecursive(List<PartNodeScript> nodes)
		{
			nodes.Add(this);
		}
	}
}
