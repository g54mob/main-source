using UnityEngine;

namespace Simulator.GameWorld
{
	public enum ECashAmount
	{
		[InspectorName("50$")]
		FiftyDollar = 0,
		[InspectorName("20$")]
		TwentyDollar = 1,
		[InspectorName("10$")]
		TenDollar = 2,
		[InspectorName("5$")]
		FiveDollar = 3,
		[InspectorName("1$")]
		OneDollar = 4,
		[InspectorName("50c")]
		FiftyCent = 5,
		[InspectorName("25c")]
		TwentyFiveCent = 6,
		[InspectorName("10c")]
		TenCent = 7,
		[InspectorName("5c")]
		FiveCent = 8,
		[InspectorName("1c")]
		OneCent = 9
	}
}
