using System;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using I2.Loc;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones.DronePreconditions
{
	[Serializable]
	public class NoDownloadedDrones : DronePrecondition
	{
		public override bool Check(NimbatusDrone drone)
		{
			if (drone != null && drone.DroneData != null)
			{
				return !drone.DroneData.WasShared;
			}
			return true;
		}

		public override bool Check(DroneData drone)
		{
			if (drone != null)
			{
				return !drone.WasShared;
			}
			return true;
		}

		protected override string GetStatus(bool check)
		{
			return (check ? LabelHelper.White : LabelHelper.DarkOrange) + LocalizationManager.GetTermTranslation("Preconditions/No downloaded drones");
		}
	}
}
