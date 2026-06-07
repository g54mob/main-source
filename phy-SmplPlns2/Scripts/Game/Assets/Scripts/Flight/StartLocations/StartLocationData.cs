using System.Xml.Linq;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Flight.StartLocations
{
	public class StartLocationData
	{
		public static readonly Vector3 DefaultDistributionAxis = Vector3.right;

		public static readonly float DefaultMaxDistributionAmount = 50f;

		public string AreaName { get; set; }

		public string Description { get; set; }

		public string DisplayName { get; set; }

		public Vector3 DistributionAxis { get; set; }

		public string DynamicLocationId { get; set; }

		public string Id { get; set; }

		public float InitialSpeed { get; set; }

		public float InitialThrottle { get; set; }

		public Vector3 InitialVelocity { get; set; }

		public bool IsDynamicLocation => DynamicLocationId != null;

		public bool IsRunwayTakeoff { get; set; }

		public StartLocationType LocationType { get; set; }

		public float MaxDistributionAmount { get; set; }

		public string OverflowLocation { get; set; }

		public Vector3 Position { get; set; }

		public Vector3 Rotation { get; set; }

		public bool? StartOnGround { get; set; }

		public StartLocationData()
		{
		}

		public StartLocationData(XElement xml, StartLocationType type)
		{
			Id = xml.GetStringAttribute("id") ?? xml.GetStringAttribute("name");
			DisplayName = xml.GetStringAttribute("displayName") ?? xml.GetStringAttribute("name");
			AreaName = xml.GetStringAttribute("areaName") ?? xml.GetStringAttribute("area");
			Position = xml.GetVector3Attribute("position") + GetPositionOffset(AreaName);
			Rotation = xml.GetVector3Attribute("rotation");
			IsRunwayTakeoff = xml.GetBoolAttribute("isRunwayTakeoff");
			StartOnGround = xml.GetBoolAttributeOrNull("startOnGround");
			InitialSpeed = xml.GetFloatAttribute("initialSpeed");
			InitialVelocity = xml.GetVector3Attribute("initialVelocity", Vector3.zero);
			InitialThrottle = xml.GetFloatAttribute("initialThrottle");
			DynamicLocationId = xml.GetStringAttribute("dynamicLocationId");
			DistributionAxis = xml.GetVector3Attribute("distributionAxis", DefaultDistributionAxis);
			MaxDistributionAmount = xml.GetFloatAttribute("maxDistributionAmount", DefaultMaxDistributionAmount);
			OverflowLocation = xml.GetStringAttribute("overflowLocation");
			Description = xml.GetStringAttribute("description");
			LocationType = type;
		}

		public StartLocationData(string id, string displayName, string areaName, StartLocationType locationType, Vector3 position, Vector3 rotation, Vector3 initialVelocity, bool? startOnGround)
		{
			Id = id;
			DisplayName = displayName;
			AreaName = areaName;
			Position = position;
			Rotation = rotation;
			InitialVelocity = initialVelocity;
			StartOnGround = startOnGround;
			LocationType = locationType;
		}

		public StartLocationData Clone()
		{
			return (StartLocationData)MemberwiseClone();
		}

		public XElement GenerateXml()
		{
			return new XElement("Location", new XAttribute("id", Id ?? string.Empty), new XAttribute("displayName", DisplayName ?? Id ?? string.Empty), new XAttribute("areaName", AreaName ?? string.Empty), new XAttribute("position", (Position - GetPositionOffset(AreaName)).ToXAttributeValue()), new XAttribute("rotation", Rotation.ToXAttributeValue()), new XAttribute("isRunwayTakeoff", IsRunwayTakeoff), StartOnGround.ToXAttributeOrNull("startOnGround"), (InitialSpeed > 0f) ? new XAttribute("initialSpeed", InitialSpeed) : new XAttribute("initialVelocity", InitialVelocity.ToXAttributeValue()), InitialThrottle.ToXAttributeOrNull("initialThrottle", 0f), DynamicLocationId.ToXAttributeOrNull("dynamicLocationId"), DistributionAxis.ToXAttributeOrNull("distributionAxis", DefaultDistributionAxis), MaxDistributionAmount.ToXAttributeOrNull("maxDistributionAmount", DefaultMaxDistributionAmount), OverflowLocation.ToXAttributeOrNull("overflowLocation"), Description.ToXAttributeOrNull("description"));
		}

		public int GetSpawnLocationHashCode()
		{
			string text = Id;
			if (LocationType == StartLocationType.Custom || LocationType == StartLocationType.Temp)
			{
				Vector3 position = Position;
				int num = Mathf.RoundToInt(position.x / 10f) * 10;
				int num2 = Mathf.RoundToInt(position.y / 10f) * 10;
				int num3 = Mathf.RoundToInt(position.z / 10f) * 10;
				text = (IsDynamicLocation ? Id : string.Empty) + $"{num},{num2},{num3}";
			}
			return StringUtility.GetStableHashCode(text);
		}

		private Vector3 GetPositionOffset(string areaName)
		{
			Vector3 result = Vector3.zero;
			if (IsSp1Area(areaName))
			{
				result = new Vector3(-400000f, 0f, -400000f);
			}
			return result;
		}

		private bool IsSp1Area(string areaName)
		{
			switch (areaName)
			{
			default:
				return areaName == "Sky Park City";
			case "Wright Isles":
			case "Krakabloa":
			case "Snowstone":
			case "Maywar Island":
				return true;
			}
		}
	}
}
