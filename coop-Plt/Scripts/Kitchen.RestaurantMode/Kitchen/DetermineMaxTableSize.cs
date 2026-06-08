using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	public class DetermineMaxTableSize : RestaurantSystem
	{
		private EntityQuery TableSets;

		private EntityQuery _SingletonEntityQuery_SLargestTableSize_61;

		protected override void Initialise()
		{
			base.Initialise();
			TableSets = GetEntityQuery(typeof(CTableSet));
		}

		protected override void OnUpdate()
		{
			NativeArray<CTableSet> nativeArray = TableSets.ToComponentDataArray<CTableSet>(Allocator.Temp);
			int num = 0;
			foreach (CTableSet item in nativeArray)
			{
				if (!item.IsWaitingTable && item.ChairCount > num)
				{
					num = item.ChairCount;
				}
			}
			_SingletonEntityQuery_SLargestTableSize_61.SetSingleton(new SLargestTableSize
			{
				LargestTableSize = num
			});
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_SLargestTableSize_61 = GetEntityQuery(ComponentType.ReadWrite<SLargestTableSize>());
		}
	}
}
