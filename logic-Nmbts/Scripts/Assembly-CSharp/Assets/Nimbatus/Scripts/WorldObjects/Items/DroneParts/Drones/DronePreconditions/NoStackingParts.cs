using System;
using System.Collections.Generic;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones.DronePreconditions
{
	[Serializable]
	public class NoStackingParts : DronePrecondition
	{
		public override bool Check(NimbatusDrone drone)
		{
			if (drone != null)
			{
				if (DronePartManager.Instance.ActiveNumberOfDroneParts > 150)
				{
					return false;
				}
				List<DronePart> allChildParts = drone.RootDronePart.GetAllChildParts<DronePart>();
				foreach (DronePart item in allChildParts)
				{
					int num = 0;
					foreach (DronePart item2 in allChildParts)
					{
						if (Vector2.Distance(item.transform.position, item2.transform.position) < 2f)
						{
							num++;
						}
					}
					if (num > 9)
					{
						return false;
					}
				}
			}
			return true;
		}

		public override bool Check(DroneData drone)
		{
			if (drone != null)
			{
				DronePartData part = drone.RootDronePart as DronePartData;
				if (drone.NumberOfParts >= 150)
				{
					return false;
				}
				List<DronePartData> allChildParts = part.GetAllChildParts<DronePartData>();
				foreach (DronePartData item in allChildParts)
				{
					int num = 0;
					foreach (DronePartData item2 in allChildParts)
					{
						if (Vector2.Distance(item.CurrentPosition, item2.CurrentPosition) < 2f)
						{
							num++;
						}
					}
					if (num > 9)
					{
						return false;
					}
				}
			}
			return true;
		}

		protected override string GetStatus(bool check)
		{
			return (check ? LabelHelper.White : LabelHelper.DarkOrange) + LocalizationManager.GetTermTranslation("Preconditions/NoStacking");
		}
	}
}
