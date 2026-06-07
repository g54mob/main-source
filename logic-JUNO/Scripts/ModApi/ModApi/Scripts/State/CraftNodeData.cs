using System.Collections.Generic;
using System.Xml.Linq;
using ModApi.Flight.Sim;
using ModApi.Mods;
using ModApi.State;
using UnityEngine;

namespace ModApi.Scripts.State
{
	public abstract class CraftNodeData : ICraftNodeData
	{
		public abstract bool AllowPlayerControl { get; }

		public abstract string ContractTrackingId { get; }

		public abstract float CraftMass { get; }

		public abstract int CraftPartCount { get; }

		public abstract bool HasCommandPod { get; }

		public abstract Quaterniond Heading { get; }

		public abstract bool InContactWithPlanet { get; }

		public abstract IReadOnlyCollection<InitialCraftNodeData> InitialCraftNodeData { get; }

		public abstract List<int> InitialCraftNodeIds { get; }

		public abstract string Name { get; }

		public abstract int NodeId { get; }

		public abstract OrbitData OrbitData { get; }

		public abstract string ParentName { get; }

		public abstract Vector3d Position { get; }

		public RequiredModsData RequiredMods { get; set; }

		public abstract Vector3d? SurfacePosition { get; }

		public abstract Quaterniond? SurfaceRotation { get; }

		public abstract Vector3d? SurfaceVelocity { get; }

		public abstract Vector3d Velocity { get; }

		public abstract double WaterDepth { get; }

		public XElement GenerateXml()
		{
			XElement xElement = new XElement("Craft");
			xElement.SetAttributeValue("id", NodeId);
			xElement.SetAttributeValue("name", Name);
			xElement.SetAttributeValue("parent", ParentName);
			xElement.SetAttributeValue("position", Utilities.Vector3dToString(Position));
			xElement.SetAttributeValue("velocity", Utilities.Vector3dToString(Velocity));
			xElement.SetAttributeValue("heading", Utilities.QuaterniondToString(Heading));
			xElement.SetAttributeValue("inContactWithPlanet", InContactWithPlanet);
			xElement.SetAttributeValue("hasCommandPod", HasCommandPod);
			xElement.SetAttributeValue("craftMass", CraftMass);
			xElement.SetAttributeValue("craftPartCount", CraftPartCount);
			xElement.SetAttributeValue("contractTrackingId", ContractTrackingId);
			xElement.SetAttributeValue("allowPlayerControl", AllowPlayerControl);
			xElement.SetAttributeValue("waterDepth", WaterDepth);
			Utilities.SetIntListAttribute(xElement, "initialNodes", InitialCraftNodeIds);
			if (InContactWithPlanet)
			{
				xElement.SetAttributeValue("surfacePosition", Utilities.Vector3dToString(SurfacePosition.Value));
				xElement.SetAttributeValue("surfaceVelocity", Utilities.Vector3dToString(SurfaceVelocity.Value));
				xElement.SetAttributeValue("surfaceRotation", Utilities.QuaterniondToString(SurfaceRotation.Value));
			}
			if (InitialCraftNodeData.Count > 0)
			{
				XElement xElement2 = new XElement("InitialCrafts");
				xElement.Add(xElement2);
				foreach (InitialCraftNodeData initialCraftNodeDatum in InitialCraftNodeData)
				{
					xElement2.Add(initialCraftNodeDatum.GenerateXml());
				}
			}
			xElement.Add(OrbitData.GenerateXml());
			xElement.Add(RequiredMods?.GenerateXml());
			return xElement;
		}
	}
}
