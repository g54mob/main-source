using System;
using System.Xml.Linq;
using ModApi.Common.Extensions;
using ModApi.Math;
using ModApi.Planet.Modifiers.Attributes;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace ModApi.Planet.Modifiers.VertexData
{
	[PlanetModifierInfo("Radial Flatten", "A planet modifier that flattens the terrain to a specified height radially around a specified latitude and longitude.")]
	public class RadialFlatten : VertexDataCommonPassPlanetModifier
	{
		[SerializeField]
		[InspectorProperty(null, false, Label = "Elevation", Order = 10, Tooltip = "The height, in meters, to which the terrain should be flattened.")]
		private double _elevation;

		[SerializeField]
		[InspectorProperty(null, false, Label = "Falloff Power", Order = 40, Tooltip = "The falloff power used when interpolating between the target elevation and original elevation.")]
		private double _falloffPower = 4.0;

		[SerializeField]
		[InspectorProperty(null, false, Label = "Inner Radius", Order = 20, Tooltip = "The inner radius, in meters, of the terrain to flatten. All terrain within this radius will be set to the specified elevation value. The elevation will be interpolated back to non-flattened terrain from the inner radius to the outer radius.")]
		private double _innerRadius = 100.0;

		[SerializeField]
		[InspectorProperty(null, false, Label = "Latitude / Longitude", Order = 50, Tooltip = "The latitude and longitude of the center point of the radial flatten.")]
		private Vector2d _latlong;

		[SerializeField]
		[InspectorProperty(null, false, Label = "Outer Radius", Order = 30, Tooltip = "The outer radius, in meters, of the terrain to flatten. All terrain beyond this radius will not be impacted by this modifier. The elevation will be interpolated from flattened terrain to non-flattened terrain from the inner radius to the outer radius.")]
		private double _outerRadius = 100.0;

		private Vector3d _position;

		[SerializeField]
		[InspectorProperty(null, false, Label = "Use Smooth Step", Order = 35, Tooltip = "Use the Smooth Step function instead of a falloff power curve. If selected, then Falloff Power will be ignored.")]
		private bool _smoothStep = true;

		private Guid? _structureNodeId;

		private double _unitSphereInnerRadius;

		private double _unitSphereOuterRadiusSquared;

		private double _unitSphereOuterToInnerRadiusDistance;

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

		public double InnerRadius
		{
			get
			{
				return _innerRadius;
			}
			set
			{
				_innerRadius = value;
			}
		}

		public Vector2d Latlong
		{
			get
			{
				return _latlong;
			}
			set
			{
				_latlong = value;
			}
		}

		public double OuterRadius
		{
			get
			{
				return _outerRadius;
			}
			set
			{
				_outerRadius = value;
			}
		}

		public Guid? StructureNodeId
		{
			get
			{
				return _structureNodeId;
			}
			set
			{
				_structureNodeId = value;
			}
		}

		public override VertexDataPlanetModifierPassType[] SupportedPassTypes => new VertexDataPlanetModifierPassType[3]
		{
			VertexDataPlanetModifierPassType.Biome,
			VertexDataPlanetModifierPassType.Height,
			VertexDataPlanetModifierPassType.HeightFinal
		};

		public override VertexDataType VertexDataType => VertexDataType.Both;

		public override void GetVertexData(PlanetVertexDataInput input, PlanetVertexData data)
		{
			Vector3d vector3d = input.Position - _position;
			double num = vector3d.x * vector3d.x + vector3d.y * vector3d.y + vector3d.z * vector3d.z;
			if (num < _unitSphereOuterRadiusSquared)
			{
				double num2 = Mathd.Sqrt(num) - _unitSphereInnerRadius;
				if (num2 > 0.0)
				{
					double num3 = num2 / _unitSphereOuterToInnerRadiusDistance;
					double num4 = 0.0;
					data.Height = Mathd.Lerp(t: (!_smoothStep) ? Mathd.Pow(num3, _falloffPower) : Mathd.SmoothStep(0.0, 1.0, num3), from: _elevation, to: data.Height);
				}
				else
				{
					data.Height = _elevation;
				}
			}
		}

		public override void GetVertexData(PlanetVertexDataInput input, PlanetBiomeVertexData data)
		{
			Vector3d vector3d = input.Position - _position;
			double num = vector3d.x * vector3d.x + vector3d.y * vector3d.y + vector3d.z * vector3d.z;
			if (num < _unitSphereOuterRadiusSquared)
			{
				double num2 = Mathd.Sqrt(num) - _unitSphereInnerRadius;
				if (num2 > 0.0)
				{
					double num3 = num2 / _unitSphereOuterToInnerRadiusDistance;
					double num4 = 0.0;
					data.Height = Mathd.Lerp(t: (!_smoothStep) ? Mathd.Pow(num3, _falloffPower) : Mathd.SmoothStep(0.0, 1.0, num3), from: _elevation, to: data.Height);
				}
				else
				{
					data.Height = _elevation;
				}
			}
		}

		public override void Initialize(IPlanetData planetData)
		{
			base.Initialize(planetData);
			_unitSphereOuterRadiusSquared = _outerRadius * _outerRadius / planetData.RadiusSquared;
			double num = Mathd.Sqrt(_unitSphereOuterRadiusSquared);
			double d = _innerRadius * _innerRadius / planetData.RadiusSquared;
			_unitSphereInnerRadius = Mathd.Sqrt(d);
			_unitSphereOuterToInnerRadiusDistance = num - _unitSphereInnerRadius;
			_position = MathUtils.LatitudeLongitudeToSphereUnitVector(_latlong.x * 0.01745329, _latlong.y * 0.01745329);
		}

		public override void SaveXml(XElement xml)
		{
			base.SaveXml(xml);
			xml.SetAttribute("latLong", _latlong);
			xml.SetAttributeValue("elevation", _elevation);
			xml.SetAttributeValue("falloffPower", _falloffPower);
			xml.SetAttributeValue("innerRadius", _innerRadius);
			xml.SetAttributeValue("outerRadius", _outerRadius);
			xml.SetAttributeValue("smoothStep", _smoothStep);
			xml.SetAttributeValue("structureNodeId", _structureNodeId);
		}

		protected override void RestoreXml(XElement xml)
		{
			base.RestoreXml(xml);
			_latlong = xml.GetVector2dAttribute("latLong");
			_elevation = (double)xml.Attribute("elevation");
			_falloffPower = (double)xml.Attribute("falloffPower");
			_innerRadius = (double)xml.Attribute("innerRadius");
			_outerRadius = (double)xml.Attribute("outerRadius");
			_smoothStep = (bool?)xml.Attribute("smoothStep") == true;
			_structureNodeId = (Guid?)xml.Attribute("structureNodeId");
			float planetScale = base.PlanetScale;
			_elevation *= planetScale;
			_innerRadius *= planetScale;
			_outerRadius *= planetScale;
		}
	}
}
