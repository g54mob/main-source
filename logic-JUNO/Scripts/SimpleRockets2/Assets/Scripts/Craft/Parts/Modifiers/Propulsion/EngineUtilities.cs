using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Craft.Propulsion;

namespace Assets.Scripts.Craft.Parts.Modifiers.Propulsion
{
	public class EngineUtilities
	{
		public static bool ConnectedWithFuelLine(PartConnection partConnection, PartData part, PartData otherPart)
		{
			if (part.Config.FuelLineOverride || otherPart.Config.FuelLineOverride)
			{
				return true;
			}
			foreach (PartConnection.Attachment attachment in partConnection.Attachments)
			{
				if (attachment.AttachPointA.FuelLine || attachment.AttachPointB.FuelLine)
				{
					return true;
				}
			}
			return false;
		}

		public static FuelTankData GetFuelTank(IPartScript partScript, int attachPoint, FuelType fuelType)
		{
			FuelTankData result = null;
			PartData data = partScript.Data;
			if (data.AttachPoints.Count > attachPoint && data.AttachPoints[attachPoint].PartConnections.Count == 1)
			{
				return GetFuelTank(data.AttachPoints[attachPoint].PartConnections[0].GetOtherPart(data), data, fuelType);
			}
			return result;
		}

		public static FuelTankData GetFuelTank(PartData startingPart, PartData ignorePart, FuelType fuelType)
		{
			PartLookup visitedParts = null;
			return GetFuelTankRecursive(startingPart, ignorePart, ref visitedParts, fuelType);
		}

		public static void UpdateAutoFuelTypeFuelTanks(FuelTankData fuelTank, FuelType fuelType)
		{
			if (fuelTank != null)
			{
				PartLookup visitedParts = new PartLookup();
				UpdateAutoFuelTypeFuelTanksRecursive(fuelTank.Part, visitedParts, fuelType);
			}
		}

		private static FuelTankData GetFuelTankRecursive(PartData part, PartData originalPart, ref PartLookup visitedParts, FuelType fuelType)
		{
			if (visitedParts == null || !visitedParts.ContainsPart(part))
			{
				bool flag = true;
				FuelTankData modifier = part.GetModifier<FuelTankData>();
				if (modifier != null)
				{
					if (modifier.AutoFuelType || fuelType == null || fuelType.Id == modifier.FuelType.Id)
					{
						return modifier;
					}
					flag = modifier.FuelType == FuelType.Battery || modifier.FuelType == FuelType.None;
				}
				if (visitedParts == null)
				{
					visitedParts = new PartLookup();
					visitedParts.AddPart(originalPart);
				}
				visitedParts.AddPart(part);
				if (flag)
				{
					foreach (PartConnection partConnection in part.PartConnections)
					{
						PartData otherPart = partConnection.GetOtherPart(part);
						if (ConnectedWithFuelLine(partConnection, part, otherPart))
						{
							modifier = GetFuelTankRecursive(otherPart, originalPart, ref visitedParts, fuelType);
							if (modifier != null)
							{
								return modifier;
							}
						}
					}
				}
			}
			return null;
		}

		private static void UpdateAutoFuelTypeFuelTanksRecursive(PartData part, PartLookup visitedParts, FuelType fuelType)
		{
			if (visitedParts.ContainsPart(part))
			{
				return;
			}
			visitedParts.AddPart(part);
			FuelTankData modifier = part.GetModifier<FuelTankData>();
			if (modifier == null || !modifier.AutoFuelType)
			{
				return;
			}
			modifier.ChangeFuelType(fuelType);
			foreach (PartConnection partConnection in part.PartConnections)
			{
				PartData otherPart = partConnection.GetOtherPart(part);
				if (ConnectedWithFuelLine(partConnection, part, otherPart))
				{
					UpdateAutoFuelTypeFuelTanksRecursive(otherPart, visitedParts, fuelType);
				}
			}
		}
	}
}
