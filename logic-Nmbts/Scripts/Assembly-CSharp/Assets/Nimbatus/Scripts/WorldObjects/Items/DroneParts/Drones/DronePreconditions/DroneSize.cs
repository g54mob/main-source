using System;
using System.Collections.Generic;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using I2.Loc;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones.DronePreconditions
{
	[Serializable]
	public class DroneSize : DronePrecondition
	{
		public float MaxDiameter;

		public override bool Check(NimbatusDrone drone)
		{
			if (drone != null)
			{
				return drone.CalculateDiameter() <= MaxDiameter;
			}
			return false;
		}

		public override bool Check(DroneData drone)
		{
			if (drone != null)
			{
				return drone.Diameter <= MaxDiameter;
			}
			return false;
		}

		protected override string GetStatus(bool check)
		{
			string obj = (check ? LabelHelper.White : LabelHelper.DarkOrange);
			string translation = LocalizationManager.GetTermTranslation("Preconditions/Less diameter");
			LocalizationManager.ApplyLocalizationParams(ref translation, new Dictionary<string, string> { 
			{
				"Length",
				MaxDiameter.ToString("F0")
			} });
			return obj + translation;
		}
	}
}
