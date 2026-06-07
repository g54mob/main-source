using ModApi.Craft.Parts;
using TMPro;
using UI.Xml;

namespace Assets.Scripts.Design.Staging
{
	public class CategoryNodeScript : TreeNodeScript
	{
		private TextMeshProUGUI _countText;

		public StageActivationType ActivationType { get; private set; }

		public override bool Empty => base.Children.Count == 0;

		public void AddPartNode(PartNodeScript partNode)
		{
			AddChild(partNode);
		}

		public void Initialize(StagingEditorScript stagingEditor, XmlElement element, StageActivationType stageActivationType)
		{
			InitializeNode(stagingEditor, element);
			_countText = element.GetElementByInternalId<TextMeshProUGUI>("count");
			ActivationType = stageActivationType;
			string text = "None";
			switch (ActivationType)
			{
			case StageActivationType.Detacher:
				text = "Interstages";
				break;
			case StageActivationType.Engine:
				text = "Engines";
				break;
			case StageActivationType.Fairing:
				text = "Fairings";
				break;
			case StageActivationType.LandingLeg:
				text = "Landing Legs";
				break;
			case StageActivationType.Parachute:
				text = "Parachutes";
				break;
			case StageActivationType.Payload:
				text = "Payloads";
				break;
			}
			base.Text = text;
		}

		public void RemovePartNode(PartNodeScript partNode)
		{
			RemoveChild(partNode);
			if (base.Children.Count == 0)
			{
				base.Visible = false;
			}
		}

		public override void UpdateContent()
		{
			base.Visible = base.Parent.Expanded && !Empty;
			if (base.Visible)
			{
				if (base.Children.Count == 1)
				{
					base.Button.gameObject.SetActive(value: false);
					foreach (TreeNodeScript child in base.Children)
					{
						child.Visible = true;
						child.XmlElement.RemoveClass("indent-2");
					}
				}
				else
				{
					base.Button.gameObject.SetActive(value: true);
					foreach (TreeNodeScript child2 in base.Children)
					{
						child2.Visible = base.Expanded;
						child2.XmlElement.AddClass("indent-2");
					}
				}
			}
			_countText.text = "x" + base.Children.Count;
		}
	}
}
