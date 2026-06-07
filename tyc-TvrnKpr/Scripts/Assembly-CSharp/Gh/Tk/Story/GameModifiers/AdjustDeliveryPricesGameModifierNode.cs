using UnityEngine;

namespace Gh.Tk.Story.GameModifiers
{
	public class AdjustDeliveryPricesGameModifierNode : TemporaryGameModifierNode
	{
		[Range(-50f, 100f)]
		public int changeInDeliveryPricePercentage;

		public static int AdjustDeliveryCost(int originalCost)
		{
			return 0;
		}
	}
}
