using System.Xml.Linq;
using ModApi.Common.Extensions;
using ModApi.Planet.Modifiers.Attributes;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace ModApi.Planet.Modifiers.VertexData
{
	[PlanetModifierInfo("Get Position", "A planet modifier used to get the position of the terrain on a unit sphere and store it in a data output. The position values are XYZ coordinates between the range of -1 and 1, representing the surface of a sphere with a radius of one and centered on (0,0,0).")]
	public class GetPosition : VertexDataCommonPassPlanetModifier
	{
		[SerializeField]
		[Range(-1f, 9f)]
		[DataSlot(DataSlotType.Output, "X", true, true, Order = 0, Tooltip = "The data output used to store the X-position value.")]
		private int _dataIndexX = -1;

		[SerializeField]
		[Range(-1f, 9f)]
		[DataSlot(DataSlotType.Output, "Y", true, true, Order = 1, Tooltip = "The data output used to store the Y-position value.")]
		private int _dataIndexY = -1;

		[SerializeField]
		[Range(-1f, 9f)]
		[DataSlot(DataSlotType.Output, "Z", true, true, Order = 2, Tooltip = "The data output used to store the Z-position value.")]
		private int _dataIndexZ = -1;

		private bool _hasRotation;

		[SerializeField]
		[InspectorProperty(null, false, Label = "Rotation", Order = 30, Tooltip = "The rotation in degrees about the X, Y, and Z axis to be applied to the planet before returning the requested positions.")]
		private Vector3 _rotation = Vector3.zero;

		private Quaterniond _rotationQuaternion;

		public override VertexDataType VertexDataType => VertexDataType.Both;

		public override void GetVertexData(PlanetVertexDataInput input, PlanetVertexData data)
		{
			Vector3d vector3d = (_hasRotation ? (_rotationQuaternion * input.Position) : input.Position);
			if (_dataIndexX != -1)
			{
				data.Data[_dataIndexX] = vector3d.x;
			}
			if (_dataIndexY != -1)
			{
				data.Data[_dataIndexY] = vector3d.y;
			}
			if (_dataIndexZ != -1)
			{
				data.Data[_dataIndexZ] = vector3d.z;
			}
		}

		public override void GetVertexData(PlanetVertexDataInput input, PlanetBiomeVertexData data)
		{
			Vector3d vector3d = (_hasRotation ? (_rotationQuaternion * input.Position) : input.Position);
			if (_dataIndexX != -1)
			{
				data.Data[_dataIndexX] = vector3d.x;
			}
			if (_dataIndexY != -1)
			{
				data.Data[_dataIndexY] = vector3d.y;
			}
			if (_dataIndexZ != -1)
			{
				data.Data[_dataIndexZ] = vector3d.z;
			}
		}

		public override void Initialize(IPlanetData planetData)
		{
			base.Initialize(planetData);
			_hasRotation = false;
			if (_rotation.x != 0f || _rotation.y != 0f || _rotation.z != 0f)
			{
				_hasRotation = true;
				_rotationQuaternion = Quaterniond.Euler(_rotation.x, _rotation.y, _rotation.z);
			}
		}

		public override void SaveXml(XElement xml)
		{
			base.SaveXml(xml);
			xml.SetAttributeValue("dataIndexX", _dataIndexX);
			xml.SetAttributeValue("dataIndexY", _dataIndexY);
			xml.SetAttributeValue("dataIndexZ", _dataIndexZ);
			xml.SetAttribute("rotation", _rotation);
		}

		protected override void RestoreXml(XElement xml)
		{
			base.RestoreXml(xml);
			_dataIndexX = (int)xml.Attribute("dataIndexX");
			_dataIndexY = (int)xml.Attribute("dataIndexY");
			_dataIndexZ = (int)xml.Attribute("dataIndexZ");
			_rotation = xml.GetVector3AttributeOrNull("rotation") ?? Vector3.zero;
		}
	}
}
