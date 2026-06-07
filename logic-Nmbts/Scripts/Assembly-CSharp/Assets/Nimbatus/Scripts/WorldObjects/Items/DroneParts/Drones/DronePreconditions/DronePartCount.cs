using System;
using System.Collections.Generic;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using I2.Loc;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones.DronePreconditions
{
	[Serializable]
	public class DronePartCount : DronePrecondition
	{
		public int MaxCount;

		public override bool Check(NimbatusDrone drone)
		{
			if (drone != null)
			{
				return drone.RootDronePart.GetNumberOfDroneParts<DronePart>() <= MaxCount;
			}
			return false;
		}

		public override bool Check(DroneData drone)
		{
			return ((drone != null) ? new int?(drone.NumberOfParts) : ((int?)null)) <= MaxCount;
		}

		protected override string GetStatus(bool check)
		{
			string text = (check ? LabelHelper.White : LabelHelper.DarkOrange);
			if (MaxCount <= 0)
			{
				return text + LocalizationManager.GetTermTranslation("Preconditions/No drone parts");
			}
			string translation = LocalizationManager.GetTermTranslation("Preconditions/Less drone parts");
			LocalizationManager.ApplyLocalizationParams(ref translation, new Dictionary<string, string> { 
			{
				"Count",
				MaxCount.ToString()
			} });
			return text + translation;
		}
	}
}
