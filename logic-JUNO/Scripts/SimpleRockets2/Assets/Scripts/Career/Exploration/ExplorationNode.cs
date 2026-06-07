using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Career.Milestones;
using ModApi;
using ModApi.Common.Extensions;
using ModApi.Craft;
using UnityEngine;

namespace Assets.Scripts.Career.Exploration
{
	public class ExplorationNode
	{
		public delegate void LandmarkDelegate(ExplorationLandmark landmark);

		public const string ElementName = "Planet";

		private List<int> _contactIds = new List<int>();

		private List<int> _flybyIds = new List<int>();

		private List<int> _orbitIds = new List<int>();

		public ExplorationContext Context { get; }

		public int Indent { get; }

		public bool IsActive { get; private set; }

		public bool IsContactComplete => _contactIds.Count > 0;

		public bool IsFlyByComplete => _flybyIds.Count > 0;

		public bool IsLandmarksComplete
		{
			get
			{
				foreach (ExplorationLandmark landmark in Landmarks)
				{
					if (!landmark.IsComplete)
					{
						return false;
					}
				}
				return true;
			}
		}

		public bool IsOrbitComplete => _orbitIds.Count > 0;

		public List<ExplorationLandmark> Landmarks { get; private set; } = new List<ExplorationLandmark>();

		public string Name { get; }

		public int NumContacts => _contactIds.Count;

		public int NumFlyBys => _flybyIds.Count;

		public int NumOrbits => _orbitIds.Count;

		public string PlanetIconName { get; }

		public event LandmarkDelegate LandmarkComplete;

		public ExplorationNode(XElement xml, ExplorationContext context)
		{
			Context = context;
			Name = xml.GetStringAttribute("name");
			PlanetIconName = xml.GetStringAttribute("planetIcon") ?? Name;
			Indent = xml.GetIntAttribute("indent");
			IEnumerable<XElement> enumerable = xml.Elements("Landmark");
			if (enumerable == null)
			{
				return;
			}
			foreach (XElement item2 in enumerable)
			{
				ExplorationLandmark item = new ExplorationLandmark(item2, this);
				Landmarks.Add(item);
			}
		}

		public XElement GenerateStatusXml()
		{
			XElement xElement = new XElement("Planet");
			xElement.SetAttributeValue("name", Name);
			Utilities.SetIntListAttribute(xElement, "orbitIds", _orbitIds);
			Utilities.SetIntListAttribute(xElement, "flybyIds", _flybyIds);
			Utilities.SetIntListAttribute(xElement, "contactIds", _contactIds);
			foreach (ExplorationLandmark landmark in Landmarks)
			{
				XElement xElement2 = new XElement("Landmark");
				xElement2.SetAttributeValue("id", landmark.Id);
				xElement2.SetAttributeValue("complete", landmark.IsComplete);
				xElement.Add(xElement2);
			}
			return xElement;
		}

		public bool HasCraftContacted(int craftNodeId)
		{
			return _contactIds.Contains(craftNodeId);
		}

		public bool HasCraftFlyBy(int craftNodeId)
		{
			return _flybyIds.Contains(craftNodeId);
		}

		public bool HasCraftOrbited(int craftNodeId)
		{
			return _orbitIds.Contains(craftNodeId);
		}

		public bool HasMilestones(MilestoneContext milestonesContext)
		{
			return milestonesContext.GetMilestonesForPlanet(Name).Count > 0;
		}

		public bool IsMilestonesComplete(MilestoneContext milestonesContext)
		{
			foreach (Milestone item in milestonesContext.GetMilestonesForPlanet(Name))
			{
				if (!item.IsComplete)
				{
					return false;
				}
			}
			return true;
		}

		public void OnActivated(IFlightContext flightContext)
		{
			if (IsActive)
			{
				return;
			}
			IsActive = true;
			foreach (ExplorationLandmark landmark in Landmarks)
			{
				landmark.OnActivated(flightContext);
			}
		}

		public void OnCraftContact(ICraftNode craft, int numDroods)
		{
			foreach (int initialCraftNodeId in craft.InitialCraftNodeIds)
			{
				if (!_contactIds.Contains(initialCraftNodeId))
				{
					_contactIds.Add(initialCraftNodeId);
				}
			}
		}

		public void OnCraftFlyBy(ICraftNode craft, int numDroods)
		{
			foreach (int initialCraftNodeId in craft.InitialCraftNodeIds)
			{
				if (!_flybyIds.Contains(initialCraftNodeId))
				{
					_flybyIds.Add(initialCraftNodeId);
				}
			}
		}

		public void OnCraftOrbit(ICraftNode craft, int numDroods)
		{
			foreach (int initialCraftNodeId in craft.InitialCraftNodeIds)
			{
				if (!_orbitIds.Contains(initialCraftNodeId))
				{
					_orbitIds.Add(initialCraftNodeId);
				}
			}
		}

		public void OnDeactivated()
		{
			if (!IsActive)
			{
				return;
			}
			IsActive = false;
			foreach (ExplorationLandmark landmark in Landmarks)
			{
				landmark.OnDeactivated();
			}
		}

		public void OnFlightUpdate(IFlightContext flight)
		{
			if (Game.InLevel || Game.Instance.GameState.Career.Money < 0)
			{
				return;
			}
			foreach (ExplorationLandmark landmark in Landmarks)
			{
				if (!landmark.IsComplete && landmark.OnFlightUpdate(flight))
				{
					this.LandmarkComplete?.Invoke(landmark);
				}
			}
		}

		public void RestoreStatus(XElement statusElement)
		{
			_orbitIds = Utilities.GetIntListAttribute(statusElement, "orbitIds");
			_flybyIds = Utilities.GetIntListAttribute(statusElement, "flybyIds");
			_contactIds = Utilities.GetIntListAttribute(statusElement, "contactIds");
			IEnumerable<XElement> enumerable = statusElement.Elements("Landmark");
			if (enumerable == null)
			{
				return;
			}
			foreach (XElement item in enumerable)
			{
				string id = item.GetStringAttribute("id");
				ExplorationLandmark explorationLandmark = Landmarks.Where((ExplorationLandmark x) => x.Id == id).FirstOrDefault();
				if (explorationLandmark != null)
				{
					explorationLandmark.IsComplete = item.GetBoolAttribute("complete");
				}
				else
				{
					Debug.LogError("Could not find landmark with ID '" + id + "'");
				}
			}
		}
	}
}
