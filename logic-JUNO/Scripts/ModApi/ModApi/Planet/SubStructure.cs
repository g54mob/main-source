using System;
using System.Collections.Generic;
using System.Xml.Linq;
using ModApi.Common.Extensions;
using ModApi.Settings;
using UnityEngine;

namespace ModApi.Planet
{
	[Serializable]
	public class SubStructure : ISubStructureParent
	{
		public enum CameraCollisionType
		{
			Default = 0,
			Collide = 1,
			NoCollide = 2
		}

		public const string ElementName = "SubStructure";

		private const int CurrentVersion = 1;

		private Color? _color;

		private IDynamicStructureMaterial[] _dynamicMaterials;

		[SerializeField]
		private Vector3 _localPosition = Vector3.zero;

		[SerializeField]
		private Vector3 _localRotation = Vector3.zero;

		[SerializeField]
		private Vector3 _localScale = Vector3.one;

		[SerializeField]
		private string _name;

		[SerializeField]
		private string _prefabPath;

		[NonSerialized]
		private List<SubStructure> _subStructures = new List<SubStructure>();

		private float? _tiling;

		public Vector3? AngularVelocity { get; set; }

		public CameraCollisionType CameraCollision { get; set; }

		public bool Collapsed { get; set; }

		public Color? Color
		{
			get
			{
				return _color;
			}
			set
			{
				_color = value;
			}
		}

		public int LevelOfDetail { get; set; }

		public GameObject LoadedGameObject { get; private set; }

		public Vector3 LocalPosition
		{
			get
			{
				return _localPosition;
			}
			set
			{
				_localPosition = value;
			}
		}

		public Vector3 LocalRotation
		{
			get
			{
				return _localRotation;
			}
			set
			{
				_localRotation = value;
			}
		}

		public Vector3 LocalScale
		{
			get
			{
				return _localScale;
			}
			set
			{
				_localScale = value;
			}
		}

		public double Mass { get; set; }

		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
			}
		}

		public ISubStructureParent Parent { get; private set; }

		public string PrefabPath
		{
			get
			{
				return _prefabPath;
			}
			set
			{
				_prefabPath = value;
			}
		}

		public TerrainQualitySettings.StructureDetailQuality RequiredQuality { get; set; }

		public StructureNodeData StructureNodeData { get; private set; }

		public IReadOnlyList<SubStructure> SubStructures => _subStructures;

		public float? Tiling
		{
			get
			{
				return _tiling;
			}
			set
			{
				_tiling = value;
			}
		}

		public int Version { get; private set; }

		public SubStructure(XElement xml, StructureNodeData structureNodeData)
		{
			Version = ((int?)xml.Attribute("version")) ?? 1;
			_name = xml.GetStringAttribute("name");
			_prefabPath = xml.GetStringAttribute("prefabPath");
			_tiling = xml.GetFloatAttributeOrNull("tiling");
			_color = xml.GetColorAttribute("color", XmlColorFormat.HexRGB);
			_localPosition = xml.GetVector3Attribute("position");
			_localRotation = xml.GetVector3Attribute("rotation");
			_localScale = xml.GetVector3Attribute("scale");
			Mass = xml.GetDoubleAttribute("mass");
			AngularVelocity = xml.GetVector3AttributeOrNull("angularVelocity");
			Collapsed = xml.GetBoolAttribute("collapsed");
			LevelOfDetail = xml.GetIntAttribute("lod");
			RequiredQuality = xml.GetEnumAttribute("quality", TerrainQualitySettings.StructureDetailQuality.Low);
			StructureNodeData = structureNodeData;
			CameraCollision = xml.GetEnumAttribute("cameraCollision", CameraCollisionType.Default);
			if (Version != 1)
			{
				UpgradeVersion();
			}
		}

		public SubStructure(string name, string prefabPath, StructureNodeData structureNodeData)
		{
			Version = 1;
			Name = name;
			PrefabPath = prefabPath;
			StructureNodeData = structureNodeData;
		}

		public static void DeserializeSubStructures(XElement xml, ISubStructureParent parent, List<SubStructure> deserializedSubStructures = null)
		{
			foreach (XElement item in xml.Elements("SubStructure"))
			{
				SubStructure subStructure = new SubStructure(item, parent.StructureNodeData);
				subStructure.SetParent(parent, null);
				deserializedSubStructures?.Add(subStructure);
				DeserializeSubStructures(item, subStructure);
			}
		}

		void ISubStructureParent.AddSubStructure(SubStructure subStructure, SubStructure insertBefore)
		{
			int num = _subStructures.IndexOf(insertBefore);
			if (num >= 0 && insertBefore != null)
			{
				_subStructures.Insert(num, subStructure);
			}
			else
			{
				_subStructures.Add(subStructure);
			}
		}

		public XElement GenerateXml(string elementName)
		{
			XElement xElement = new XElement(elementName, new XAttribute("version", Version), new XAttribute("name", _name), new XAttribute("prefabPath", _prefabPath), new XAttribute("position", Utilities.Vector3ToString(_localPosition)), new XAttribute("rotation", Utilities.Vector3ToString(_localRotation)), new XAttribute("collapsed", Collapsed), new XAttribute("lod", LevelOfDetail), new XAttribute("quality", RequiredQuality), new XAttribute("scale", Utilities.Vector3ToString(_localScale)));
			if (CameraCollision != CameraCollisionType.Default)
			{
				xElement.Add(new XAttribute("cameraCollision", CameraCollision));
			}
			if (_tiling.HasValue)
			{
				xElement.Add(new XAttribute("tiling", _tiling.Value));
			}
			if (_color.HasValue)
			{
				xElement.Add(new XAttribute("color", "#" + _color.Value.ToXAttributeValue(XmlColorFormat.HexRGB)));
			}
			if (Mass > 0.0)
			{
				xElement.Add(new XAttribute("mass", Mass));
			}
			if (AngularVelocity.HasValue)
			{
				xElement.Add(new XAttribute("angularVelocity", Utilities.Vector3ToString(AngularVelocity.Value)));
			}
			foreach (SubStructure subStructure in SubStructures)
			{
				xElement.Add(subStructure.GenerateXml(elementName));
			}
			return xElement;
		}

		public void OnGameObjectLoaded(GameObject g)
		{
			LoadedGameObject = g;
			_dynamicMaterials = g.GetComponentsInChildren<IDynamicStructureMaterial>();
		}

		public void OnGameObjectUnloaded()
		{
			LoadedGameObject = null;
			_dynamicMaterials = null;
		}

		void ISubStructureParent.RemoveSubStructure(SubStructure subStructure)
		{
			_subStructures.Remove(subStructure);
		}

		public void SetParent(ISubStructureParent parent, SubStructure insertBefore)
		{
			if (Parent != null)
			{
				Parent.RemoveSubStructure(this);
			}
			Parent = parent;
			StructureNodeData = Parent?.StructureNodeData;
			if (Parent != null)
			{
				Parent.AddSubStructure(this, insertBefore);
			}
		}

		public void UpdateDynamicMaterials()
		{
			if ((Tiling.HasValue || Color.HasValue) && _dynamicMaterials != null)
			{
				IDynamicStructureMaterial[] dynamicMaterials = _dynamicMaterials;
				for (int i = 0; i < dynamicMaterials.Length; i++)
				{
					dynamicMaterials[i].UpdateMaterial(Tiling.GetValueOrDefault(), Color ?? UnityEngine.Color.white);
				}
			}
			foreach (SubStructure subStructure in SubStructures)
			{
				subStructure.UpdateDynamicMaterials();
			}
		}

		private void UpgradeVersion()
		{
			Version = 1;
		}
	}
}
