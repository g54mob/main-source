using System;
using System.Collections.Generic;
using System.Xml.Linq;
using ModApi.Common.Extensions;
using ModApi.Flight.Sim;
using ModApi.State;
using UnityEngine;

namespace ModApi.Planet
{
	[Serializable]
	public class StructureNodeData : ISubStructureParent
	{
		private const int CurrentVersion = 2;

		[SerializeField]
		private double _elevation;

		[SerializeField]
		private AltitudeType _elevationType;

		[SerializeField]
		private double _gameViewLoadDistance = 100000.0;

		[SerializeField]
		private double _heading;

		[SerializeField]
		private Guid _id;

		[SerializeField]
		private double _latitude;

		[SerializeField]
		private Vector3 _localScale = Vector3.one;

		[SerializeField]
		private double _longitude;

		[SerializeField]
		private string _name;

		[SerializeField]
		private string _prefabPath;

		[SerializeField]
		private Quaterniond? _rotation;

		[SerializeField]
		private bool _visibleInMapView;

		public bool Collapsed { get; set; }

		public double Elevation
		{
			get
			{
				return _elevation;
			}
			set
			{
				_elevation = value;
			}
		}

		public AltitudeType ElevationType
		{
			get
			{
				return _elevationType;
			}
			set
			{
				_elevationType = value;
			}
		}

		public double GameViewLoadDistance
		{
			get
			{
				return _gameViewLoadDistance;
			}
			set
			{
				_gameViewLoadDistance = value;
			}
		}

		public double Heading
		{
			get
			{
				return _heading;
			}
			set
			{
				_heading = value;
			}
		}

		public Guid Id => _id;

		public double Latitude
		{
			get
			{
				return _latitude;
			}
			set
			{
				_latitude = value;
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

		public double[] LodDistanceScalars { get; set; }

		public double Longitude
		{
			get
			{
				return _longitude;
			}
			set
			{
				_longitude = value;
			}
		}

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

		public Quaterniond Rotation
		{
			get
			{
				return _rotation ?? LaunchLocation.CalculateHeading(Heading, (float)Latitude, (float)Longitude);
			}
			set
			{
				_rotation = value;
			}
		}

		StructureNodeData ISubStructureParent.StructureNodeData => this;

		[field: NonSerialized]
		public List<SubStructure> SubStructures { get; private set; } = new List<SubStructure>();

		public int Version { get; private set; }

		public bool VisibleInMapView
		{
			get
			{
				return _visibleInMapView;
			}
			set
			{
				_visibleInMapView = value;
			}
		}

		public StructureNodeData(XElement xml)
		{
			Version = ((int?)xml.Attribute("version")) ?? 1;
			_id = xml.GetGuidAttributeOrNull("id") ?? Guid.NewGuid();
			_name = xml.GetStringAttribute("name");
			_prefabPath = xml.GetStringAttribute("prefabPath");
			_latitude = xml.GetDoubleAttribute("latitude");
			_longitude = xml.GetDoubleAttribute("longitude");
			_elevation = xml.GetDoubleAttribute("elevation");
			_elevationType = xml.GetEnumAttribute("elevationType", AltitudeType.AboveGroundLevel);
			_heading = xml.GetDoubleAttribute("heading");
			_rotation = xml.GetQuaterniondAttributeOrNull("rotation");
			_visibleInMapView = xml.GetBoolAttribute("visibleInMapView", defaultValue: true);
			_localScale = xml.GetVector3Attribute("scale", Vector3.one);
			_gameViewLoadDistance = xml.GetDoubleAttribute("loadDistance", 100000.0);
			LodDistanceScalars = xml.GetDoubleArray("lodScales", new double[3] { 0.75, 0.5, 0.25 });
			Collapsed = xml.GetBoolAttribute("collapsed");
			SubStructure.DeserializeSubStructures(xml, this);
			if (Version != 2)
			{
				UpgradeVersion();
			}
		}

		public StructureNodeData(string name, string prefabPath)
		{
			Version = 2;
			_id = Guid.NewGuid();
			Name = name;
			PrefabPath = prefabPath;
			ElevationType = AltitudeType.AboveGroundLevel;
			LodDistanceScalars = new double[3] { 0.75, 0.5, 0.25 };
		}

		void ISubStructureParent.AddSubStructure(SubStructure subStructure, SubStructure insertBefore)
		{
			int num = SubStructures.IndexOf(insertBefore);
			if (num >= 0)
			{
				SubStructures.Insert(num, subStructure);
			}
			else
			{
				SubStructures.Add(subStructure);
			}
		}

		public XElement GenerateXml(string elementName)
		{
			XElement xElement = new XElement(elementName, new XAttribute("version", Version), new XAttribute("id", _id), new XAttribute("name", _name), new XAttribute("visibleInMapView", _visibleInMapView), new XAttribute("collapsed", Collapsed), new XAttribute("prefabPath", _prefabPath), new XAttribute("latitude", _latitude), new XAttribute("longitude", _longitude), new XAttribute("elevation", _elevation), new XAttribute("elevationType", _elevationType), new XAttribute("heading", _heading), new XAttribute("loadDistance", _gameViewLoadDistance), new XAttribute("scale", Utilities.Vector3ToString(_localScale)));
			xElement.SetAttribute("lodScales", LodDistanceScalars);
			if (_rotation.HasValue)
			{
				xElement.SetAttribute("rotation", _rotation.Value);
			}
			foreach (SubStructure subStructure in SubStructures)
			{
				xElement.Add(subStructure.GenerateXml("SubStructure"));
			}
			return xElement;
		}

		void ISubStructureParent.RemoveSubStructure(SubStructure subStructure)
		{
			SubStructures.Remove(subStructure);
		}

		private void UpgradeVersion()
		{
			if (Version == 1)
			{
				Heading += Longitude;
				Version++;
			}
			Version = 2;
		}
	}
}
