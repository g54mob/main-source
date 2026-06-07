using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Flight.Sim;
using Assets.Scripts.State;
using ModApi.Common.Extensions;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Flight.Sim;
using ModApi.Scripts.State;
using ModApi.State;
using UnityEngine;

namespace Assets.Scripts.Career.Contracts.Requirements
{
	public class SpawnCraftRequirement : ContractRequirement
	{
		private bool _allowPlayerControl;

		private string _craftFilePath;

		private string _craftName;

		private bool _destroyOnContractClosed;

		private LaunchLocation _launchLocation;

		private XElement _orbitLocation;

		private bool _spawned;

		private string _trackingId;

		public override string DisplayValue => null;

		public SpawnCraftRequirement(XElement xml, Contract contract)
			: base(xml, contract)
		{
			_craftName = xml.Attribute("craftName").Value;
			_trackingId = xml.Attribute("craftTrackingId")?.Value;
			_spawned = xml.GetBoolAttribute("spawned");
			_allowPlayerControl = xml.GetBoolAttribute("allowPlayerControl");
			_destroyOnContractClosed = xml.GetBoolAttribute("destroyOnContractClosed");
			string value = xml.Attribute("craftXml").Value;
			_craftFilePath = Path.Combine(CareerState.CheckOverridePath(contract.Context.ResourcesPath, "Crafts/"), value);
			if (!File.Exists(_craftFilePath))
			{
				_craftFilePath = Path.Combine("Default", "Crafts/", value);
				if (!File.Exists(_craftFilePath))
				{
					throw new ContractException("Cannot find craft XML file required to spawn craft: " + value);
				}
			}
			XElement xElement = xml.Element("SpawnCraft.LaunchLocation");
			XElement xElement2 = xml.Element("SpawnCraft.OrbitLocation");
			if (xElement != null && xElement2 != null)
			{
				throw new ContractException("SpawnCraft cannot have both a '<SpawnCraft.LaunchLocation>' and a '<SpawnCraft.OrbitLocation>'. It can only have one or the other.");
			}
			if (xElement != null)
			{
				_launchLocation = new LaunchLocation(xElement);
				return;
			}
			if (xElement2 != null)
			{
				_orbitLocation = xElement2;
				return;
			}
			throw new ContractException("SpawnCraft needs a child tag '<SpawnCraft.LaunchLocation>' to define its launch location.");
		}

		public override void OnContractClosed(FlightStateData flightStateData)
		{
			base.OnContractClosed(flightStateData);
			if (!_destroyOnContractClosed)
			{
				return;
			}
			if (base.FlightContext != null)
			{
				CraftNode craftNode = base.FlightContext.FlightState.GetCraftNode((CraftNode node) => node.ContractTrackingId == _trackingId);
				if (craftNode != null)
				{
					craftNode.DestroyOnExitFlightScene = true;
				}
			}
			else if (flightStateData != null)
			{
				ICraftNodeData craftNodeData = flightStateData?.CraftNodes.Where((ICraftNodeData x) => x.ContractTrackingId == _trackingId).FirstOrDefault();
				if (craftNodeData != null)
				{
					flightStateData.RemoveCraftNode(craftNodeData);
				}
			}
		}

		public override void OnFlightEnd()
		{
			base.OnFlightEnd();
		}

		public override void OnFlightStart(IFlightContext flightContext)
		{
			base.OnFlightStart(flightContext);
			if (!string.IsNullOrEmpty(_trackingId))
			{
				CraftNode craftNode = flightContext.FlightState.GetCraftNode((CraftNode node) => node.ContractTrackingId == _trackingId);
				_spawned = craftNode != null;
			}
		}

		public override void SaveStatusToXml()
		{
			base.SaveStatusToXml();
			base.Xml.SetAttributeValue("craftTrackingId", _trackingId);
			base.Xml.SetAttributeValue("spawned", _spawned);
		}

		protected override bool Evaluate(ICraftNode craftNode)
		{
			if (!_spawned)
			{
				_spawned = true;
				SpawnCraft();
			}
			return true;
		}

		protected override void ResetRequirementStatus()
		{
			base.ResetRequirementStatus();
		}

		private LaunchLocation CreateLaunchLocationFromOrbitLocation(XElement orbitLocation)
		{
			double doubleAttribute = orbitLocation.GetDoubleAttribute("apoapsis");
			double doubleAttribute2 = orbitLocation.GetDoubleAttribute("periapsis");
			double nu = orbitLocation.GetDoubleAttribute("trueAnomaly") * 0.01745329;
			double w = orbitLocation.GetDoubleAttribute("argumentOfPeriapsis") * 0.01745329;
			double inclination = orbitLocation.GetDoubleAttribute("inclination") * 0.01745329;
			double num = orbitLocation.GetDoubleAttribute("ascendingNode") * 0.01745329;
			Vector3d vector3dAttribute = orbitLocation.GetVector3dAttribute("heading", Vector3d.zero);
			string stringAttribute = orbitLocation.GetStringAttribute("planetName");
			IPlanetNode planet = base.FlightContext.Planet;
			if (!string.IsNullOrEmpty(stringAttribute))
			{
				planet = base.FlightContext.GetPlanet(stringAttribute);
				if (planet == null)
				{
					Debug.LogError("Could not find planet '" + stringAttribute + "'");
				}
			}
			if (orbitLocation.GetBoolAttribute("includePlanetRotation"))
			{
				num -= planet.RotationAngle - Math.PI / 2.0;
			}
			double num2 = doubleAttribute + planet.PlanetData.Radius;
			double num3 = doubleAttribute2 + planet.PlanetData.Radius;
			double a = (num2 + num3) / 2.0;
			double e = (num2 - num3) / (num2 + num3);
			OrbitMath.GetStateVectorsFromTrueAnomaly(new Orbit(0.0, e, a, w, nu, inclination, num, planet.PlanetData.Mass, prograde: true), nu, out var position, out var velocity);
			position = OrbitMath.ConvertOrbitToFromGameCoords(position);
			velocity = OrbitMath.ConvertOrbitToFromGameCoords(velocity);
			return new LaunchLocation("Temp", planet.Name, position, velocity, Quaterniond.Euler(vector3dAttribute.x, vector3dAttribute.y, vector3dAttribute.z), 0.0);
		}

		private void SpawnCraft()
		{
			if (_craftFilePath == null)
			{
				return;
			}
			if (_trackingId == null)
			{
				_trackingId = Guid.NewGuid().ToString();
			}
			XElement root = XDocument.Load(_craftFilePath).Root;
			CraftData craftData = Game.Instance.CraftLoader.LoadCraftImmediate(root);
			craftData.RemoveInvalidParts = false;
			foreach (PartData part in craftData.Assembly.Parts)
			{
				part.IsSpawned = true;
			}
			foreach (XElement item in base.Xml.Elements("SpawnCraft.Payload"))
			{
				string payloadId = item.GetStringAttribute("payloadId");
				string stringAttribute = item.GetStringAttribute("mapTo");
				PartData partData = craftData.Assembly.Parts.Where((PartData x) => x.Payload?.PayloadId == payloadId).FirstOrDefault();
				if (partData != null)
				{
					partData.Payload.PayloadId = stringAttribute;
					continue;
				}
				Debug.Log("Could not find payload ID " + payloadId + " in craft " + _craftFilePath + " SpawnCraft in contract " + base.Contract.Id);
			}
			root = craftData.GenerateXml(null, optimizeXml: true, generateRequiredMods: false);
			if (_orbitLocation != null)
			{
				_launchLocation = CreateLaunchLocationFromOrbitLocation(_orbitLocation);
			}
			CraftNode craftNode = base.FlightContext.SpawnCraft(_craftName, craftData, _launchLocation, root);
			craftNode.ContractTrackingId = _trackingId;
			craftNode.AllowPlayerControl = _allowPlayerControl;
			if (_launchLocation.LocationType == LaunchLocationType.SurfaceLockedGround)
			{
				craftNode.InContactWithPlanet = true;
			}
			craftNode.FlightStart();
		}
	}
}
