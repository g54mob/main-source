using System;
using System.Xml.Linq;
using ModApi.Common.Extensions;
using ModApi.Flight.GameView;
using ModApi.Flight.Sim;
using UnityEngine;

namespace ModApi.State
{
	public class LaunchLocation
	{
		private const int CurrentVersion = 2;

		private double? _headingSimple;

		public double AltitudeAboveGroundLevel { get; set; }

		public string Description { get; private set; }

		public double FreeRecoveryRadius { get; set; }

		public Quaterniond Heading { get; set; }

		public double? HeadingSimple
		{
			get
			{
				return _headingSimple;
			}
			set
			{
				_headingSimple = value;
				Heading = CalculateHeading(_headingSimple.GetValueOrDefault());
			}
		}

		public string Image { get; set; }

		public string ImagePath { get; set; }

		public double Latitude { get; set; }

		public double LaunchCostPerKG { get; }

		public LaunchLocationType LocationType { get; private set; }

		public double Longitude { get; set; }

		public double MaxCraftDiameter { get; }

		public double MaxCraftHeight { get; }

		public double MaxCraftMass { get; }

		public string Name { get; set; }

		public OrbitData Orbit { get; }

		public Vector3d OrbitalPosition { get; private set; }

		public string PlanetName { get; set; }

		public Quaterniond Rotation => Heading;

		public bool UserCreated { get; set; }

		public Vector3d Velocity { get; private set; }

		public int Version { get; private set; }

		public double WaterRecoveryBonus { get; set; }

		public LaunchLocation(string name, LaunchLocationType type, string planetName, double latitude, double longitude, Vector3d velocity, double heading, double altitudeAboveGroundLevel)
		{
			if (type == LaunchLocationType.Orbital)
			{
				throw new ArgumentException("Orbital launch locations require a Vector3d position rather than latitude/longitude");
			}
			Version = 2;
			Name = name;
			LocationType = type;
			PlanetName = planetName;
			Latitude = latitude;
			Longitude = longitude;
			OrbitalPosition = Vector3d.zero;
			Velocity = velocity;
			AltitudeAboveGroundLevel = altitudeAboveGroundLevel;
			HeadingSimple = heading;
		}

		public LaunchLocation(string name, LaunchLocationType type, string planetName, double latitude, double longitude, Vector3d velocity, Quaterniond heading, double altitudeAboveGroundLevel)
		{
			if (type == LaunchLocationType.Orbital)
			{
				throw new ArgumentException("Orbital launch locations require a Vector3d position rather than latitude/longitude");
			}
			Version = 2;
			Name = name;
			LocationType = type;
			PlanetName = planetName;
			Latitude = latitude;
			Longitude = longitude;
			OrbitalPosition = Vector3d.zero;
			Velocity = velocity;
			AltitudeAboveGroundLevel = altitudeAboveGroundLevel;
			HeadingSimple = null;
			Heading = heading;
		}

		public LaunchLocation(string name, string planetName, Vector3d orbitalPosition, Vector3d velocity, Quaterniond heading, double altitudeAboveGroundLevel)
		{
			Version = 2;
			Name = name;
			LocationType = LaunchLocationType.Orbital;
			PlanetName = planetName;
			OrbitalPosition = orbitalPosition;
			Velocity = velocity;
			AltitudeAboveGroundLevel = altitudeAboveGroundLevel;
			HeadingSimple = null;
			Heading = heading;
		}

		public LaunchLocation(XElement xml)
		{
			Version = ((int?)xml.Attribute("version")) ?? 1;
			Name = (string)xml.Attribute("name");
			Description = (string)xml.Attribute("description");
			PlanetName = (string)xml.Attribute("planetName");
			UserCreated = (bool?)xml.Attribute("userCreated") == true;
			Latitude = ((double?)xml.Attribute("latitude")).GetValueOrDefault();
			Longitude = ((double?)xml.Attribute("longitude")).GetValueOrDefault();
			OrbitalPosition = xml.GetVector3dAttributeOrNull("orbitalPosition") ?? Vector3d.zero;
			Velocity = xml.GetVector3dAttributeOrNull("velocity") ?? Vector3d.zero;
			AltitudeAboveGroundLevel = ((double?)xml.Attribute("agl")).GetValueOrDefault();
			Image = xml.GetStringAttribute("image");
			LaunchCostPerKG = xml.GetDoubleAttribute("launchCostPerKG");
			MaxCraftDiameter = xml.GetDoubleAttribute("maxCraftDiameter");
			MaxCraftHeight = xml.GetDoubleAttribute("maxCraftHeight");
			MaxCraftMass = xml.GetDoubleAttribute("maxCraftMass") * 0.009999999776482582;
			FreeRecoveryRadius = ((double?)xml.Attribute("freeRecoveryRadius")).GetValueOrDefault();
			WaterRecoveryBonus = ((double?)xml.Attribute("waterRecoveryBonus")) ?? 1.0;
			Vector4d? vector4dAttributeOrNull = xml.GetVector4dAttributeOrNull("heading");
			if (!vector4dAttributeOrNull.HasValue)
			{
				HeadingSimple = (double?)xml.Attribute("heading");
			}
			else
			{
				Vector4d value = vector4dAttributeOrNull.Value;
				Heading = new Quaterniond(value.x, value.y, value.z, value.w);
			}
			LocationType = xml.GetEnumAttributeOrNull<LaunchLocationType>("type").GetValueOrDefault();
			if (LocationType == LaunchLocationType.Orbital)
			{
				XElement xElement = xml.Element("Orbit");
				if (xElement != null)
				{
					Orbit = new OrbitData(xElement);
				}
			}
			if (Version != 2)
			{
				UpgradeLaunchLocation();
			}
		}

		public LaunchLocation(LaunchLocation launchLocation)
		{
			Version = launchLocation.Version;
			Name = launchLocation.Name;
			PlanetName = launchLocation.PlanetName;
			Latitude = launchLocation.Latitude;
			Longitude = launchLocation.Longitude;
			AltitudeAboveGroundLevel = launchLocation.AltitudeAboveGroundLevel;
			Description = launchLocation.Description;
			HeadingSimple = launchLocation.HeadingSimple;
			Heading = launchLocation.Heading;
			LocationType = launchLocation.LocationType;
			OrbitalPosition = launchLocation.OrbitalPosition;
			UserCreated = launchLocation.UserCreated;
			Velocity = launchLocation.Velocity;
			Image = launchLocation.Image;
			LaunchCostPerKG = launchLocation.LaunchCostPerKG;
			MaxCraftDiameter = launchLocation.MaxCraftDiameter;
			MaxCraftHeight = launchLocation.MaxCraftHeight;
			MaxCraftMass = launchLocation.MaxCraftMass;
			FreeRecoveryRadius = launchLocation.FreeRecoveryRadius;
			WaterRecoveryBonus = launchLocation.WaterRecoveryBonus;
		}

		public static Quaterniond CalculateHeading(double headingSimple, float latitude, float longitude)
		{
			Vector3 toDirection = Quaternion.Euler(0f - latitude, 0f - longitude, 0f) * Vector3.forward;
			Quaterniond quaterniond = Quaterniond.FromQuaternion(Quaternion.FromToRotation(Vector3.up, toDirection));
			Vector3d axis = quaterniond * Vector3d.up;
			return Quaterniond.AngleAxis(headingSimple - (double)longitude, axis) * quaterniond;
		}

		public static LaunchLocation CreateLaunchLocation(string name, IPlanetNode planetNode, Vector3d position, Vector3d velocity, Quaterniond heading, IReferenceFrame referenceFrame, LaunchLocationType type)
		{
			if (!Game.InFlightScene)
			{
				throw new InvalidOperationException("CreateLaunchLocation must be called from the flight scene.");
			}
			string name2 = planetNode.PlanetData.Name;
			double altitudeAboveGroundLevel = CalculateAgl(planetNode, position, referenceFrame, type);
			if (type == LaunchLocationType.Orbital)
			{
				return new LaunchLocation(name, name2, position, velocity, heading, altitudeAboveGroundLevel);
			}
			planetNode.GetSurfaceCoordinates(planetNode.PlanetVectorToSurfaceVector(position), out var latitude, out var longitude);
			if (type == LaunchLocationType.SurfaceLockedGround)
			{
				velocity = Vector3d.zero;
			}
			Quaterniond rotationInverse = planetNode.RotationInverse;
			velocity = rotationInverse * velocity;
			heading = rotationInverse * heading;
			LaunchLocation launchLocation = new LaunchLocation(name, type, name2, latitude * 57.29578, longitude * 57.29578, velocity, heading, altitudeAboveGroundLevel);
			if (type == LaunchLocationType.SurfaceLockedGround)
			{
				Vector3d normalized = position.normalized;
				launchLocation.HeadingSimple = Vector3d.Angle(Vector3d.ProjectOnPlane(heading * Vector3.forward, normalized), Vector3d.Cross(normalized, Vector3d.up));
			}
			return launchLocation;
		}

		public bool AreEqual(LaunchLocation launchLocation)
		{
			if (Name == launchLocation.Name && PlanetName == launchLocation.PlanetName && Latitude == launchLocation.Latitude && Longitude == launchLocation.Longitude && AltitudeAboveGroundLevel == launchLocation.AltitudeAboveGroundLevel && Description == launchLocation.Description && Heading == launchLocation.Heading && HeadingSimple == launchLocation.HeadingSimple && LocationType == launchLocation.LocationType && OrbitalPosition == launchLocation.OrbitalPosition && UserCreated == launchLocation.UserCreated)
			{
				return Velocity == launchLocation.Velocity;
			}
			return false;
		}

		public long CalculateLaunchCost(float price, float mass)
		{
			return (long)((double)price + LaunchCostPerKG * (double)mass * 100.0);
		}

		public XElement GenerateXml(bool savePlanetName = true, bool basicPropertiesOnly = false)
		{
			XElement xElement = new XElement("LaunchLocation");
			if (basicPropertiesOnly)
			{
				xElement.SetAttributeValue("name", Name);
				xElement.SetAttributeValue("version", Version);
			}
			else
			{
				xElement.SetAttributeValue("name", Name);
				xElement.SetAttributeValue("description", Description);
				xElement.SetAttributeValue("userCreated", UserCreated);
				xElement.SetAttributeValue("version", Version);
				xElement.SetAttributeValue("image", Image);
				xElement.SetAttributeValue("launchCostPerKG", LaunchCostPerKG);
				xElement.SetAttributeValue("maxCraftDiameter", MaxCraftDiameter);
				xElement.SetAttributeValue("maxCraftHeight", MaxCraftHeight);
				xElement.SetAttributeValue("maxCraftMass", MaxCraftMass * 100.0);
				xElement.SetAttributeValue("freeRecoveryRadius", FreeRecoveryRadius);
				xElement.SetAttributeValue("waterRecoveryBonus", WaterRecoveryBonus);
				if (!string.IsNullOrEmpty(Image))
				{
					xElement.SetAttributeValue("image", Image);
				}
			}
			if (savePlanetName)
			{
				xElement.SetAttributeValue("planetName", PlanetName);
			}
			if (LocationType == LaunchLocationType.Orbital)
			{
				xElement.SetAttribute("orbitalPosition", OrbitalPosition);
			}
			else
			{
				xElement.SetAttributeValue("latitude", Latitude);
				xElement.SetAttributeValue("longitude", Longitude);
			}
			if (LocationType != LaunchLocationType.SurfaceLockedGround)
			{
				xElement.SetAttribute("velocity", Velocity);
			}
			xElement.SetAttributeValue("agl", AltitudeAboveGroundLevel);
			if (HeadingSimple.HasValue)
			{
				xElement.SetAttributeValue("heading", HeadingSimple);
			}
			else
			{
				Quaterniond heading = Heading;
				xElement.SetAttribute("heading", new Vector4d(heading.x, heading.y, heading.z, heading.w));
			}
			xElement.SetAttributeValue("type", LocationType);
			if (Orbit != null)
			{
				xElement.Add(Orbit.GenerateXml());
			}
			return xElement;
		}

		private static double CalculateAgl(IPlanetNode planetNode, Vector3d position, IReferenceFrame referenceFrame, LaunchLocationType type)
		{
			double terrainHeight = planetNode.GetTerrainHeight(position);
			bool flag = planetNode.PlanetData.HasWater && terrainHeight < (double)planetNode.PlanetData.SeaLevel;
			double num = (flag ? ((double)planetNode.PlanetData.SeaLevel) : terrainHeight) + planetNode.PlanetData.Radius;
			double result = position.magnitude - num;
			if (type == LaunchLocationType.SurfaceLockedGround)
			{
				if (flag)
				{
					result = 0.0;
				}
				Vector3d planetVector = -position.normalized;
				Vector3 direction = referenceFrame.PlanetToFrameVector(planetVector);
				Vector3 origin = referenceFrame.PlanetToFramePosition(position);
				if (Physics.Raycast(new Ray(origin, direction), out var hitInfo, 1100f, 603979776))
				{
					double num2 = referenceFrame.FrameToPlanetPosition(hitInfo.point).magnitude - num;
					if (!flag || num2 > 0.0)
					{
						result = num2;
					}
				}
			}
			return result;
		}

		private Quaterniond CalculateHeading(double headingSimple)
		{
			return CalculateHeading(headingSimple, (float)Latitude, (float)Longitude);
		}

		private void UpgradeLaunchLocation()
		{
			if (Version == 1)
			{
				if (HeadingSimple.HasValue)
				{
					HeadingSimple += Longitude;
				}
				Version++;
			}
			Version = 2;
		}
	}
}
