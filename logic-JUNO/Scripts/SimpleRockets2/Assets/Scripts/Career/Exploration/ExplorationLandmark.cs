using System;
using System.Xml.Linq;
using Assets.Scripts.Career.Contracts;
using ModApi.Common.Extensions;
using UnityEngine;

namespace Assets.Scripts.Career.Exploration
{
	public class ExplorationLandmark
	{
		public const string ElementName = "Landmark";

		private ContractLocation _contractLocation;

		private LocationNode _node;

		public string Description { get; }

		public ExplorationNode ExplorationNode { get; }

		public string Id { get; }

		public bool IsComplete { get; set; }

		public string Name => _contractLocation.Name;

		public string PlanetName => _contractLocation?.PlanetName;

		public int Research { get; }

		public ExplorationLandmark(XElement xml, ExplorationNode node)
		{
			ExplorationNode = node;
			Id = xml.GetStringAttribute("id");
			Research = xml.GetIntAttribute("research");
			Description = xml.GetStringAttribute("description");
			string stringAttribute = xml.GetStringAttribute("locationId");
			_contractLocation = (string.IsNullOrWhiteSpace(stringAttribute) ? null : node.Context.Career.Contracts.GetContractLocation(stringAttribute));
			if (_contractLocation == null)
			{
				_contractLocation = new ContractLocation(xml);
				_contractLocation.PlanetName = node.Name;
				return;
			}
			if (node.Name != _contractLocation.PlanetName)
			{
				throw new Exception("Planet of contract location '" + stringAttribute + "' does not match planet for exploration landmark " + Id + ".");
			}
			_contractLocation.LoadOverriddenXmlAttributes(xml);
		}

		public void OnActivated(IFlightContext flightContext)
		{
			if (_node == null)
			{
				_node = flightContext.CreateLocationNode(_contractLocation, "LandmarkNode");
				_node.Register(flightContext);
				if (IsComplete)
				{
					MarkNodeCompleted();
				}
			}
		}

		public void OnDeactivated()
		{
			if (_node != null)
			{
				_node.Unregister();
				_node = null;
			}
		}

		public bool OnFlightUpdate(IFlightContext flight)
		{
			if (_node.CalculateDistanceToPosition(flight.CraftNode.Position) < _contractLocation.Range && (!_contractLocation.Grounded || flight.CraftNode.InContactWithPlanet))
			{
				IsComplete = true;
			}
			if (IsComplete)
			{
				MarkNodeCompleted();
			}
			return IsComplete;
		}

		private void MarkNodeCompleted()
		{
			_node.IconColor = new Color32(71, 164, 71, byte.MaxValue);
			_node.ShowInGameView = false;
		}
	}
}
