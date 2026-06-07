using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using ModApi.Common.Extensions;
using ModApi.Craft;
using ModApi.Flight.Sim;
using ModApi.Mods;
using ModApi.Scripts.State;
using UnityEngine;

namespace ModApi.State
{
	public class CraftNodeDataStatic : CraftNodeData
	{
		private readonly float _craftMass;

		private bool _allowPlayerControl = true;

		private string _contractTrackingId;

		private int _craftPartCount;

		private bool _hasCommandPod;

		private Quaterniond _heading;

		private bool _inContactWithPlanet;

		private Dictionary<int, InitialCraftNodeData> _initialCraftNodeData = new Dictionary<int, InitialCraftNodeData>();

		private List<int> _initialCraftNodeIds = new List<int>();

		private string _name;

		private int _nodeId;

		private OrbitData _orbitData;

		private string _parentName;

		private Vector3d _position;

		private Vector3d? _surfacePosition;

		private Quaterniond? _surfaceRotation;

		private Vector3d? _surfaceVelocity;

		private Vector3d _velocity;

		private double _waterDepth;

		public override bool AllowPlayerControl => _allowPlayerControl;

		public override string ContractTrackingId => _contractTrackingId;

		public override float CraftMass => _craftMass;

		public override int CraftPartCount => _craftPartCount;

		public override bool HasCommandPod => _hasCommandPod;

		public override Quaterniond Heading => _heading;

		public override bool InContactWithPlanet => _inContactWithPlanet;

		public override IReadOnlyCollection<InitialCraftNodeData> InitialCraftNodeData => _initialCraftNodeData.Values;

		public override List<int> InitialCraftNodeIds => _initialCraftNodeIds;

		public override string Name => _name;

		public override int NodeId => _nodeId;

		public override OrbitData OrbitData => _orbitData;

		public override string ParentName => _parentName;

		public override Vector3d Position => _position;

		public override Vector3d? SurfacePosition => _surfacePosition;

		public override Quaterniond? SurfaceRotation => _surfaceRotation;

		public override Vector3d? SurfaceVelocity => _surfaceVelocity;

		public override Vector3d Velocity => _velocity;

		public override double WaterDepth => _waterDepth;

		public CraftNodeDataStatic(XElement element)
		{
			_nodeId = element.GetIntAttribute("id");
			_name = element.GetStringAttribute("name");
			_parentName = element.GetStringAttribute("parent");
			_position = element.GetVector3dAttribute("position");
			_velocity = element.GetVector3dAttribute("velocity");
			_heading = element.GetQuaterniondAttribute("heading");
			_hasCommandPod = element.GetBoolAttribute("hasCommandPod", defaultValue: true);
			_craftMass = element.GetFloatAttribute("craftMass");
			_craftPartCount = element.GetIntAttribute("craftPartCount");
			_contractTrackingId = element.GetStringAttribute("contractTrackingId");
			_waterDepth = element.GetDoubleAttribute("waterDepth");
			_allowPlayerControl = element.GetBoolAttribute("allowPlayerControl", defaultValue: true);
			_initialCraftNodeIds = Utilities.GetIntListAttribute(element, "initialNodes");
			foreach (XElement item in element.Elements("InitialCrafts").Elements("InitialCraft"))
			{
				try
				{
					InitialCraftNodeData initialCraftNodeData = new InitialCraftNodeData(item);
					_initialCraftNodeData[initialCraftNodeData.NodeId] = initialCraftNodeData;
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
					Debug.LogError($"Unable to load initial craft node data for craft '{_name ?? string.Empty}' (ID: '{_nodeId}')");
				}
			}
			XAttribute xAttribute = element.Attribute("grounded");
			if (xAttribute != null)
			{
				_inContactWithPlanet = (bool)xAttribute;
			}
			else
			{
				_inContactWithPlanet = element.GetBoolAttribute("inContactWithPlanet");
			}
			if (InContactWithPlanet)
			{
				_surfacePosition = element.GetVector3dAttribute("surfacePosition");
				_surfaceVelocity = element.GetVector3dAttribute("surfaceVelocity");
				_surfaceRotation = element.GetQuaterniondAttribute("surfaceRotation");
			}
			XElement xElement = element.Element("Orbit");
			if (xElement != null)
			{
				_orbitData = new OrbitData(xElement);
			}
			base.RequiredMods = new RequiredModsData(element.Element("RequiredMods"));
		}

		public CraftNodeDataStatic(ICraftNode craftNode, ICraftNodeData craftNodeData = null)
		{
			_craftMass = craftNode.CraftMass;
			_craftPartCount = craftNode.CraftPartCount;
			_contractTrackingId = craftNode.ContractTrackingId;
			_hasCommandPod = craftNode.HasCommandPod;
			_heading = craftNode.Heading;
			_inContactWithPlanet = craftNode.InContactWithPlanet;
			_name = craftNode.Name;
			_nodeId = craftNode.NodeId;
			_parentName = craftNode.Parent?.PlanetData.Name;
			_position = craftNode.Position;
			_surfacePosition = craftNode.GroundedSurfacePosition;
			_surfaceRotation = craftNode.GroundedSurfaceRotation;
			_surfaceVelocity = craftNode.GroundedSurfaceVelocity;
			_velocity = craftNode.Velocity;
			_orbitData = craftNode.Orbit?.GenerateOrbitData();
			_waterDepth = craftNode.WaterDepth;
			_initialCraftNodeIds = craftNode.InitialCraftNodeIds.ToList();
			foreach (InitialCraftNodeData initialCraftNodeDatum in craftNode.InitialCraftNodeData)
			{
				_initialCraftNodeData.Add(initialCraftNodeDatum.NodeId, initialCraftNodeDatum.Clone());
			}
			if (craftNodeData == null)
			{
				base.RequiredMods = new RequiredModsData();
			}
			else
			{
				base.RequiredMods = craftNodeData.RequiredMods;
			}
		}

		public CraftNodeDataStatic(string name, Vector3d position, Vector3d velocity, Quaterniond heading, bool hasCommandPod)
		{
			_name = name;
			_position = position;
			_velocity = velocity;
			_heading = heading;
			_hasCommandPod = hasCommandPod;
			base.RequiredMods = new RequiredModsData();
		}
	}
}
