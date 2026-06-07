using System.Collections.Generic;
using ModApi.Craft;
using ModApi.Flight.Sim;
using ModApi.Mods;
using ModApi.Scripts.State;
using UnityEngine;

namespace ModApi.State
{
	public class CraftNodeDataDynamic : CraftNodeData
	{
		public override bool AllowPlayerControl => CraftNode.AllowPlayerControl;

		public override string ContractTrackingId => CraftNode.ContractTrackingId;

		public override float CraftMass => CraftNode.CraftMass;

		public ICraftNode CraftNode { get; private set; }

		public override int CraftPartCount => CraftNode.CraftPartCount;

		public override bool HasCommandPod => CraftNode.HasCommandPod;

		public override Quaterniond Heading => CraftNode.Heading;

		public override bool InContactWithPlanet => CraftNode.InContactWithPlanet;

		public override IReadOnlyCollection<InitialCraftNodeData> InitialCraftNodeData => CraftNode.InitialCraftNodeData;

		public override List<int> InitialCraftNodeIds => CraftNode.InitialCraftNodeIds;

		public override string Name => CraftNode.Name;

		public override int NodeId => CraftNode.NodeId;

		public override OrbitData OrbitData => CraftNode.Orbit?.GenerateOrbitData();

		public override string ParentName => CraftNode.Parent?.PlanetData.Name;

		public override Vector3d Position => CraftNode.Position;

		public override Vector3d? SurfacePosition => CraftNode.GroundedSurfacePosition;

		public override Quaterniond? SurfaceRotation => CraftNode.GroundedSurfaceRotation;

		public override Vector3d? SurfaceVelocity => CraftNode.GroundedSurfaceVelocity;

		public override Vector3d Velocity => CraftNode.Velocity;

		public override double WaterDepth => CraftNode.WaterDepth;

		public CraftNodeDataDynamic(ICraftNode craftNode, ICraftNodeData craftNodeData = null)
		{
			CraftNode = craftNode;
			if (craftNodeData == null)
			{
				base.RequiredMods = new RequiredModsData();
			}
			else
			{
				base.RequiredMods = craftNodeData.RequiredMods;
			}
		}
	}
}
