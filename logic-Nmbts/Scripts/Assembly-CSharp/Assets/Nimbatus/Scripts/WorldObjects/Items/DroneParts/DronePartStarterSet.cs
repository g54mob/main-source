using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts
{
	public class DronePartStarterSet : SerializedScriptableObject
	{
		public bool AllPartsUnlocked;

		public List<DronePartStack> StartingParts = new List<DronePartStack>();

		public List<WeaponStack> Weapons = new List<WeaponStack>();

		public bool Contains(NimbatusItem part)
		{
			return StartingParts.Any((DronePartStack sp) => sp.ContainsPart(part));
		}

		public int GetStackSize(DronePart part)
		{
			if (part != null)
			{
				DronePartStack dronePartStack = StartingParts.FirstOrDefault((DronePartStack sp) => sp.ContainsPart(part));
				if (dronePartStack != null)
				{
					return dronePartStack.Amount;
				}
			}
			return 0;
		}

		public IEnumerable<DronePart> GetDroneParts()
		{
			List<DronePart> list = new List<DronePart>();
			foreach (DronePartStack startingPart in StartingParts)
			{
				if (startingPart.CombinedParts)
				{
					list.AddRange(startingPart.DronePartList);
				}
				else
				{
					list.Add(startingPart.DronePart);
				}
			}
			return list;
		}
	}
}
