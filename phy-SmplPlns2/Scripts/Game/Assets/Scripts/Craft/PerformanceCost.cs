using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers;

namespace Assets.Scripts.Craft
{
	public class PerformanceCost
	{
		public static float CalculateCost(AircraftData aircraft)
		{
			float num = 0f;
			foreach (PartData part in aircraft.Assembly.Parts)
			{
				num += CalculateCost(part);
			}
			if (num == 0f)
			{
				num = 1f;
			}
			return num;
		}

		public static float CalculateCost(PartData part)
		{
			float num = 0f;
			if (part != null)
			{
				num += part.PartType.PerformanceCost;
				foreach (PartModifierData modifier in part.Modifiers)
				{
					num += modifier.PerformanceCost;
				}
			}
			return num;
		}
	}
}
