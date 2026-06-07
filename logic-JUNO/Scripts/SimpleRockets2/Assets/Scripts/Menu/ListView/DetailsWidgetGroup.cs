using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Ui;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Menu.ListView
{
	public class DetailsWidgetGroup : IDetailsWidget
	{
		private ListViewDetailsScript _listViewDetails;

		private XmlElement _parent;

		private bool _visible = true;

		private List<IDetailsWidget> _widgets = new List<IDetailsWidget>();

		public DetailsWidgetGroup Group { get; set; }

		public Transform Transform => null;

		public bool Visible
		{
			get
			{
				return _visible;
			}
			set
			{
				if (_visible == value)
				{
					return;
				}
				_visible = value;
				foreach (IDetailsWidget widget in _widgets)
				{
					widget.Visible = value;
				}
			}
		}

		public DetailsWidgetGroup(ListViewDetailsScript listViewDetails)
		{
			_listViewDetails = listViewDetails;
			_parent = _listViewDetails.XmlElement;
		}

		public DetailsButtonScript AddButton(string text)
		{
			DetailsButtonScript detailsButtonScript = LoadDetailWidgetResource<DetailsButtonScript>("details-button");
			detailsButtonScript.Text = text;
			AddWidget(detailsButtonScript);
			return detailsButtonScript;
		}

		public DetailsWidgetGroup AddGroup()
		{
			DetailsWidgetGroup detailsWidgetGroup = new DetailsWidgetGroup(_listViewDetails);
			AddWidget(detailsWidgetGroup);
			return detailsWidgetGroup;
		}

		public DetailsHeaderScript AddHeader(string text)
		{
			DetailsHeaderScript detailsHeaderScript = LoadDetailWidgetResource<DetailsHeaderScript>("details-header");
			detailsHeaderScript.Text = text;
			AddWidget(detailsHeaderScript);
			return detailsHeaderScript;
		}

		public DetailsImageScript AddImage()
		{
			DetailsImageScript detailsImageScript = LoadDetailWidgetResource<DetailsImageScript>("details-image");
			AddWidget(detailsImageScript);
			return detailsImageScript;
		}

		public DetailsInputScript AddInput()
		{
			DetailsInputScript detailsInputScript = LoadDetailWidgetResource<DetailsInputScript>("details-input");
			AddWidget(detailsInputScript);
			return detailsInputScript;
		}

		public DetailsMilestoneScript AddMilestone()
		{
			DetailsMilestoneScript detailsMilestoneScript = LoadDetailWidgetResource<DetailsMilestoneScript>("details-milestone");
			AddWidget(detailsMilestoneScript);
			return detailsMilestoneScript;
		}

		public DetailsPropertyScript AddProperty(string labelText)
		{
			DetailsPropertyScript detailsPropertyScript = LoadDetailWidgetResource<DetailsPropertyScript>("details-property");
			detailsPropertyScript.LabelText = labelText;
			AddWidget(detailsPropertyScript);
			return detailsPropertyScript;
		}

		public DetailsPropertyPairScript AddPropertyPair(string labelTextLeft, string labelTextRight)
		{
			DetailsPropertyPairScript detailsPropertyPairScript = LoadDetailWidgetResource<DetailsPropertyPairScript>("details-property-pair");
			detailsPropertyPairScript.LeftLabelText = labelTextLeft;
			detailsPropertyPairScript.RightLabelText = labelTextRight;
			AddWidget(detailsPropertyPairScript);
			return detailsPropertyPairScript;
		}

		public DetailsSpacerScript AddSpacer()
		{
			DetailsSpacerScript detailsSpacerScript = LoadDetailWidgetResource<DetailsSpacerScript>("details-spacer");
			AddWidget(detailsSpacerScript);
			return detailsSpacerScript;
		}

		public DetailsStarScript AddStar()
		{
			DetailsStarScript detailsStarScript = LoadDetailWidgetResource<DetailsStarScript>("details-star");
			AddWidget(detailsStarScript);
			return detailsStarScript;
		}

		public DetailsTextScript AddText(string text)
		{
			DetailsTextScript detailsTextScript = LoadDetailWidgetResource<DetailsTextScript>("details-text");
			detailsTextScript.Text = text;
			AddWidget(detailsTextScript);
			return detailsTextScript;
		}

		public DetailsTextScript AddText(string text, string color)
		{
			DetailsTextScript detailsTextScript = AddText(text);
			detailsTextScript.Color = color;
			return detailsTextScript;
		}

		public void DestroyWidget()
		{
			IDetailsWidget[] array = _widgets.ToArray();
			for (int i = 0; i < array.Length; i++)
			{
				array[i].DestroyWidget();
			}
			Group?.RemoveWidget(this);
		}

		public void Initialize(ListViewDetailsScript details)
		{
		}

		public void RemoveWidget(IDetailsWidget widget)
		{
			_widgets.Remove(widget);
		}

		private void AddWidget(IDetailsWidget widget)
		{
			IDetailsWidget detailsWidget = _widgets.LastOrDefault();
			_widgets.Add(widget);
			widget.Group = this;
			if (detailsWidget?.Transform != null && widget.Transform != null)
			{
				widget.Transform.SetSiblingIndex(detailsWidget.Transform.GetSiblingIndex() + 1);
			}
		}

		private T LoadDetailWidgetResource<T>(string name) where T : MonoBehaviour
		{
			T val = UiUtilities.CloneTemplate(_listViewDetails.XmlElement.xmlLayoutInstance.GetElementById(name), _parent).gameObject.AddComponent<T>();
			IDetailsWidget obj = val as IDetailsWidget;
			obj.Initialize(_listViewDetails);
			obj.Group = this;
			return val;
		}
	}
}
