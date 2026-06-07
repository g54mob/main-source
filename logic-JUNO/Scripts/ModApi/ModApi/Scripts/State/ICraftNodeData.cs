using System.Collections.Generic;
using System.Xml.Linq;
using ModApi.Flight.Sim;
using ModApi.Mods;
using ModApi.State;
using UnityEngine;

namespace ModApi.Scripts.State
{
	public interface ICraftNodeData
	{
		bool AllowPlayerControl { get; }

		string ContractTrackingId { get; }

		float CraftMass { get; }

		int CraftPartCount { get; }

		bool HasCommandPod { get; }

		Quaterniond Heading { get; }

		bool InContactWithPlanet { get; }

		IReadOnlyCollection<InitialCraftNodeData> InitialCraftNodeData { get; }

		List<int> InitialCraftNodeIds { get; }

		string Name { get; }

		int NodeId { get; }

		OrbitData OrbitData { get; }

		string ParentName { get; }

		Vector3d Position { get; }

		RequiredModsData RequiredMods { get; set; }

		Vector3d? SurfacePosition { get; }

		Quaterniond? SurfaceRotation { get; }

		Vector3d? SurfaceVelocity { get; }

		Vector3d Velocity { get; }

		double WaterDepth { get; }

		XElement GenerateXml();
	}
}
