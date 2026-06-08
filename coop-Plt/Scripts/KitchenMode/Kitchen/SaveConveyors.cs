using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	public class SaveConveyors : GenericSystemBase
	{
		private EntityQuery SmartConveyors;

		private static List<CConveyPushItems> Conveyors = new List<CConveyPushItems>();

		private static List<CPosition> ConveyorPositions = new List<CPosition>();

		protected override void Initialise()
		{
			base.Initialise();
			SmartConveyors = GetEntityQuery(typeof(CConveyPushItems), typeof(CPosition));
		}

		protected override void OnUpdate()
		{
			Conveyors.Clear();
			ConveyorPositions.Clear();
			if (!Has<SPracticeMode>())
			{
				return;
			}
			using NativeArray<CConveyPushItems> nativeArray = SmartConveyors.ToComponentDataArray<CConveyPushItems>(Allocator.Temp);
			using NativeArray<CPosition> nativeArray2 = SmartConveyors.ToComponentDataArray<CPosition>(Allocator.Temp);
			foreach (CConveyPushItems item in nativeArray)
			{
				Conveyors.Add(item);
			}
			foreach (CPosition item2 in nativeArray2)
			{
				ConveyorPositions.Add(item2);
			}
		}

		public override void AfterLoading(SaveSystemType system_type)
		{
			base.AfterLoading(system_type);
			if (Conveyors == null || ConveyorPositions == null)
			{
				return;
			}
			NativeArray<Entity> nativeArray = SmartConveyors.ToEntityArray(Allocator.Temp);
			NativeArray<CConveyPushItems> nativeArray2 = SmartConveyors.ToComponentDataArray<CConveyPushItems>(Allocator.Temp);
			NativeArray<CPosition> nativeArray3 = SmartConveyors.ToComponentDataArray<CPosition>(Allocator.Temp);
			for (int i = 0; i < nativeArray.Length; i++)
			{
				if (!nativeArray2[i].GrabSpecificType)
				{
					continue;
				}
				for (int j = 0; j < Conveyors.Count; j++)
				{
					if ((nativeArray3[i].Position - ConveyorPositions[j].Position).Chebyshev() < 0.1f)
					{
						CConveyPushItems component = nativeArray2[i];
						component.SpecificType = Conveyors[j].SpecificType;
						component.SpecificComponents = Conveyors[j].SpecificComponents;
						SetComponent(nativeArray[i], component);
						break;
					}
				}
			}
			Conveyors.Clear();
			ConveyorPositions.Clear();
			nativeArray.Dispose();
			nativeArray2.Dispose();
			nativeArray3.Dispose();
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
