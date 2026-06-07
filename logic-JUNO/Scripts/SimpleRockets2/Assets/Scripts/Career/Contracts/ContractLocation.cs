using System.Xml.Linq;
using Assets.Scripts.Career.Contracts.Requirements;
using ModApi.Common.Extensions;
using UnityEngine;

namespace Assets.Scripts.Career.Contracts
{
	public class ContractLocation
	{
		public bool Grounded { get; set; }

		public string Id { get; set; }

		public Vector3d LatLonAgl { get; set; }

		public double LoadDistance { get; set; } = 20000.0;

		public string Name { get; set; }

		public string PlanetName { get; set; }

		public double Range { get; set; }

		public bool Shared { get; set; } = true;

		public RaceRequirement.CheckpointStyleType Style { get; set; }

		public bool VisibleInMapView { get; set; } = true;

		public ContractLocation()
		{
		}

		public ContractLocation(XElement xml)
		{
			Id = xml.GetStringAttribute("id", Id);
			PlanetName = xml.GetStringAttribute("planet", PlanetName);
			Vector3d? vector3dAttributeOrNull = xml.GetVector3dAttributeOrNull("latLonAgl");
			if (vector3dAttributeOrNull.HasValue)
			{
				LatLonAgl = vector3dAttributeOrNull.Value;
				LoadOverriddenXmlAttributes(xml);
				return;
			}
			throw new ContractException("ContractLocation " + Id + " does not have latLonAgl attribute.");
		}

		public ContractLocation Clone()
		{
			return new ContractLocation
			{
				Grounded = Grounded,
				Id = Id,
				LatLonAgl = LatLonAgl,
				LoadDistance = LoadDistance,
				Name = Name,
				PlanetName = PlanetName,
				Range = Range
			};
		}

		public void LoadOverriddenXmlAttributes(XElement xml)
		{
			Name = xml.GetStringAttribute("name", Name);
			Grounded = xml.GetBoolAttribute("grounded", Grounded);
			Shared = xml.GetBoolAttribute("shared", Shared);
			Range = xml.GetDoubleAttribute("range", Range);
			LoadDistance = xml.GetDoubleAttribute("loadDistance", LoadDistance);
			VisibleInMapView = xml.GetBoolAttribute("mapView", VisibleInMapView);
		}
	}
}
