using System.Collections.Generic;
using Assets.Scripts.Craft.Parts.Modifiers.Eva;
using TMPro;
using UI.Xml;

namespace Assets.Scripts.Ui.Crew
{
	public class CompartmentTarget
	{
		private List<CrewItem> _crew = new List<CrewItem>();

		private bool _isExpanded = true;

		public CrewCompartmentData Compartment { get; }

		public IReadOnlyList<CrewItem> Crew => _crew;

		public XmlElement Element { get; private set; }

		public bool IsExpanded
		{
			get
			{
				return _isExpanded;
			}
			set
			{
				if (_isExpanded == value)
				{
					return;
				}
				if (_isExpanded)
				{
					Element.AddClass("expanded");
				}
				else
				{
					Element.RemoveClass("expanded");
				}
				_isExpanded = value;
				foreach (CrewItem item in _crew)
				{
					item.Visible = IsExpanded;
				}
			}
		}

		public CompartmentTarget(XmlElement element, CrewCompartmentData compartment)
		{
			Element = element;
			Compartment = compartment;
		}

		public void AddCrew(CrewItem crewItem)
		{
			crewItem.Compartment = this;
			crewItem.Element.transform.SetParent(Element.transform.parent);
			crewItem.Element.transform.SetSiblingIndex(Element.transform.GetSiblingIndex() + 1);
			crewItem.Element.AddClass("nested");
			crewItem.Visible = IsExpanded;
			_crew.Add(crewItem);
		}

		public void Refresh()
		{
			TextMeshProUGUI elementByInternalId = Element.GetElementByInternalId<TextMeshProUGUI>("status");
			if (Compartment != null)
			{
				elementByInternalId.text = $"{Crew.Count} / {Compartment.Capacity}";
			}
			else
			{
				elementByInternalId.text = $"{Crew.Count}";
			}
		}

		public void RemoveCrew(CrewItem crewItem)
		{
			_crew.Remove(crewItem);
			crewItem.Element.RemoveClass("nested");
			crewItem.Compartment = null;
			Refresh();
		}
	}
}
