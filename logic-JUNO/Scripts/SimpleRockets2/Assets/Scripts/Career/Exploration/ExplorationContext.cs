using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Flight.MapView;
using Assets.Scripts.Flight.MapView.Interfaces;
using Assets.Scripts.Flight.MapView.Items;
using Assets.Scripts.State;
using ModApi.Common.Extensions;
using ModApi.Craft;
using ModApi.Flight.MapView;
using ModApi.Flight.Sim;
using ModApi.Flight.UI;
using UnityEngine;

namespace Assets.Scripts.Career.Exploration
{
	public class ExplorationContext
	{
		public const string XmlElementName = "Exploration";

		private ExplorationNode _activeNode;

		private IPlanetNode _activePlanet;

		private List<ExplorationNode> _nodes = new List<ExplorationNode>();

		private ExplorationNode _targetedNode;

		public ExplorationNode ActiveNode => _activeNode;

		public CareerState Career { get; }

		public IFlightContext Flight { get; private set; }

		public IReadOnlyList<ExplorationNode> Nodes => _nodes;

		public event ExplorationNode.LandmarkDelegate LandmarkComplete;

		public ExplorationContext(CareerState career, XElement xml, XElement statusXml)
		{
			Career = career;
			IEnumerable<XElement> enumerable = xml?.Elements("Planet");
			if (enumerable != null)
			{
				foreach (XElement item2 in enumerable)
				{
					ExplorationNode item = new ExplorationNode(item2, this);
					_nodes.Add(item);
				}
			}
			IEnumerable<XElement> enumerable2 = statusXml?.Elements("Planet");
			if (enumerable2 == null)
			{
				return;
			}
			foreach (XElement item3 in enumerable2)
			{
				string name = item3.GetStringAttribute("name");
				ExplorationNode explorationNode = _nodes.Where((ExplorationNode x) => x.Name == name).FirstOrDefault();
				if (explorationNode != null)
				{
					explorationNode.RestoreStatus(item3);
				}
				else
				{
					Debug.LogError("Could not find exploration node for planet '" + name + "'");
				}
			}
		}

		public XElement GenerateStatusXml()
		{
			XElement xElement = new XElement("Exploration");
			foreach (ExplorationNode node in _nodes)
			{
				xElement.Add(node.GenerateStatusXml());
			}
			return xElement;
		}

		public void OnFlightEnd()
		{
			SubscribeEvents(subscribe: false);
			SetTargetedNode(null);
			DeactivateActiveNode();
			Flight = null;
			_activePlanet = null;
		}

		public void OnFlightStart(IFlightContext flight)
		{
			Flight = flight;
			SelectActiveNode();
			SubscribeEvents(subscribe: true);
		}

		public void OnFlightUpdate()
		{
			if (_activePlanet != Flight.Planet)
			{
				SelectActiveNode();
			}
			_activeNode?.OnFlightUpdate(Flight);
		}

		private void ActivateActiveNode()
		{
			if (_activeNode != null)
			{
				_activeNode.OnActivated(Flight);
				_activeNode.LandmarkComplete += OnLocationComplete;
			}
		}

		private void DeactivateActiveNode()
		{
			if (_activeNode != null)
			{
				_activeNode.OnDeactivated();
				_activeNode.LandmarkComplete -= OnLocationComplete;
				_activeNode = null;
			}
		}

		private void OnCraftChangedSoi()
		{
			SelectActiveNode();
		}

		private void OnCraftContact(ICraftNode craft, int numDroods)
		{
			ActiveNode.OnCraftContact(craft, numDroods);
		}

		private void OnCraftFlyBy(ICraftNode craft, int numDroods)
		{
			ActiveNode.OnCraftFlyBy(craft, numDroods);
		}

		private void OnCraftOrbit(ICraftNode craft, int numDroods)
		{
			ActiveNode.OnCraftOrbit(craft, numDroods);
		}

		private void OnLocationComplete(ExplorationLandmark location)
		{
			this.LandmarkComplete?.Invoke(location);
			Game.Instance.FlightScene.FlightSceneUI.FlightLog.AddLog("Landmark '" + location.Name + "' found!", FlightLogEntryCategory.Default);
		}

		private void OnMapViewTargetChanged(ICameraFocusable target)
		{
			string text = null;
			MapPlanet mapPlanet = target as MapPlanet;
			text = ((!(mapPlanet != null)) ? target?.OrbitNode?.Parent?.Name : mapPlanet.PlanetNode.Name);
			SetTargetedNode(text);
		}

		private void SelectActiveNode()
		{
			DeactivateActiveNode();
			_activePlanet = Flight.Planet;
			_activeNode = _nodes.Where((ExplorationNode x) => x.Name == Flight.Planet.Name).FirstOrDefault();
			ActivateActiveNode();
		}

		private void SetTargetedNode(string name)
		{
			if (!(name != _targetedNode?.Name))
			{
				return;
			}
			if (_targetedNode != null)
			{
				if (_activeNode != _targetedNode)
				{
					_targetedNode.OnDeactivated();
				}
				_targetedNode = null;
			}
			_targetedNode = _nodes.Where((ExplorationNode x) => x.Name == name).FirstOrDefault();
			if (_targetedNode != null)
			{
				_targetedNode.OnActivated(Flight);
			}
		}

		private void SubscribeEvents(bool subscribe)
		{
			MapViewScript mapViewScript = Game.Instance.FlightScene.ViewManager.MapViewManager.MapView as MapViewScript;
			ICurrentCameraTarget currentCameraTarget = mapViewScript.Ioc.Resolve<ICurrentCameraTarget>(mapViewScript.Context);
			if (subscribe)
			{
				currentCameraTarget.TargetChanged += OnMapViewTargetChanged;
				Flight.CraftOrbit += OnCraftOrbit;
				Flight.CraftHyperbolicOrbit += OnCraftFlyBy;
				Flight.CraftContact += OnCraftContact;
				Flight.CraftChangedSoi += OnCraftChangedSoi;
			}
			else
			{
				currentCameraTarget.TargetChanged -= OnMapViewTargetChanged;
				Flight.CraftOrbit -= OnCraftOrbit;
				Flight.CraftHyperbolicOrbit -= OnCraftFlyBy;
				Flight.CraftContact -= OnCraftContact;
				Flight.CraftChangedSoi -= OnCraftChangedSoi;
			}
		}
	}
}
