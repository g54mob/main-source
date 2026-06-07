using System;
using System.Linq;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using Sirenix.OdinInspector;

namespace Assets.Nimbatus.Scripts.Receivables.ReceivableSettings
{
	public class DronePartReceivableSettings : BaseReceivableSettings
	{
		public EReceivableDronePartType PartTypes = EReceivableDronePartType.Specific;

		[ShowIf("PartTypes", EReceivableDronePartType.OfType, true)]
		public EDronePartType PartType;

		[ShowIf("PartTypes", EReceivableDronePartType.Specific, true)]
		public DronePart DronePart;

		public override BaseReceivable CreateReceivable(int seed, int amount)
		{
			Random random = new Random(seed);
			DronePart dronePart;
			if (PartTypes == EReceivableDronePartType.Specific)
			{
				dronePart = DronePart;
			}
			else
			{
				EDronePartType partType = PartType;
				if (PartTypes == EReceivableDronePartType.Random)
				{
					partType = EnumHelper.GetRandomEnumValue<EDronePartType>(random, 1);
				}
				dronePart = (DronePart)(from p in SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.GetBuyableDroneParts(partType, 1, random)
					where p is DronePart
					select p).ToList().FirstOrDefault();
			}
			if (dronePart == null)
			{
				throw new Exception("no suitable part found");
			}
			return new DronePartReceivable
			{
				Reward = dronePart.UniqueId,
				Amount = amount
			};
		}
	}
}
