using System.Runtime.InteropServices;
using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public class GiveChristmasConveyor : DaySystem
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private struct CMarker : IComponentData
		{
		}

		protected override void OnUpdate()
		{
			if (HasStatus(RestaurantStatus.ChristmasConveyors))
			{
				Entity entity = GetEntity<CMarker>();
				Set(entity, new CGrantsExtraBlueprint
				{
					ID = AssetReference.Belt,
					IsFree = false,
					CanBeDuplicated = true
				});
			}
			if (HasStatus(RestaurantStatus.ChristmasBuffets))
			{
				Entity entity2 = GetEntity<CMarker>();
				Set(entity2, new CGrantsExtraBlueprint
				{
					ID = AssetReference.Buffet,
					IsFree = false,
					CanBeDuplicated = true
				});
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
