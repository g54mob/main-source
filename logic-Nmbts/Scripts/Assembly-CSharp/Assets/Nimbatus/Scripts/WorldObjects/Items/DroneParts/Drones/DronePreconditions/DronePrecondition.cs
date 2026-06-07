using System;
using System.Xml.Serialization;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones.DronePreconditions
{
	[Serializable]
	[XmlInclude(typeof(DronePartCount))]
	[XmlInclude(typeof(DroneSize))]
	[XmlInclude(typeof(NoInputAllowed))]
	[XmlInclude(typeof(AllPartsAvailable))]
	[XmlInclude(typeof(SumoRequirements))]
	[XmlInclude(typeof(NoDownloadedDrones))]
	[XmlInclude(typeof(VersusArenaRequirements))]
	[XmlInclude(typeof(VersusRaceRequirements))]
	[XmlInclude(typeof(RaceTrackRequirements))]
	[XmlInclude(typeof(CombatArenaRequirements))]
	[XmlInclude(typeof(RaceTrackRequirementsAutonomous))]
	[XmlInclude(typeof(AffordDeployCost))]
	[XmlInclude(typeof(NoStackingParts))]
	public abstract class DronePrecondition
	{
		public abstract bool Check(NimbatusDrone drone);

		public abstract bool Check(DroneData drone);

		public string GetStatus(DroneData drone, out bool status)
		{
			if (drone == null)
			{
				status = true;
				return GetStatus(true);
			}
			status = Check(drone);
			return GetStatus(status);
		}

		public string GetStatus(NimbatusDrone drone, out bool status)
		{
			if (drone == null)
			{
				status = true;
				return GetStatus(true);
			}
			status = Check(drone);
			return GetStatus(status);
		}

		protected abstract string GetStatus(bool active);
	}
}
