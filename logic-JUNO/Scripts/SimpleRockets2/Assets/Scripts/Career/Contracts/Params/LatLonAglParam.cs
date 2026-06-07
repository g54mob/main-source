using System.Xml.Linq;
using ModApi.Common.Extensions;
using UnityEngine;

namespace Assets.Scripts.Career.Contracts.Params
{
	public class LatLonAglParam : ContractParam
	{
		private string _value;

		public override string Value => _value;

		public LatLonAglParam(XElement xml)
			: base(xml)
		{
			Vector3d vector3dAttribute = xml.GetVector3dAttribute("value");
			double doubleAttribute = xml.GetDoubleAttribute("latOffset");
			double doubleAttribute2 = xml.GetDoubleAttribute("lonOffset");
			double doubleAttribute3 = xml.GetDoubleAttribute("aglOffset");
			vector3dAttribute.x += doubleAttribute;
			vector3dAttribute.y += doubleAttribute2;
			vector3dAttribute.z += doubleAttribute3;
			_value = $"{vector3dAttribute.x},{vector3dAttribute.y},{vector3dAttribute.z}";
		}
	}
}
