using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	public class SaveRotatingConveyors : GameSystemBase
	{
		private EntityQuery RotatableConveyors;

		private static List<CConveyPushRotatable> Conveyors = new List<CConveyPushRotatable>();

		private static List<CPosition> ConveyorPositions = new List<CPosition>();

		protected override void Initialise()
		{
			base.Initialise();
			RotatableConveyors = GetEntityQuery(typeof(CConveyPushRotatable), typeof(CPosition));
		}

		protected override void OnUpdate()
		{
			if (!Has<SPracticeMode>())
			{
				return;
			}
			using NativeArray<CConveyPushRotatable> nativeArray = RotatableConveyors.ToComponentDataArray<CConveyPushRotatable>(Allocator.Temp);
			using NativeArray<CPosition> nativeArray2 = RotatableConveyors.ToComponentDataArray<CPosition>(Allocator.Temp);
			Conveyors.Clear();
			ConveyorPositions.Clear();
			foreach (CConveyPushRotatable item in nativeArray)
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
			NativeArray<Entity> nativeArray = RotatableConveyors.ToEntityArray(Allocator.Temp);
			NativeArray<CConveyPushRotatable> nativeArray2 = RotatableConveyors.ToComponentDataArray<CConveyPushRotatable>(Allocator.Temp);
			NativeArray<CPosition> nativeArray3 = RotatableConveyors.ToComponentDataArray<CPosition>(Allocator.Temp);
			for (int i = 0; i < nativeArray.Length; i++)
			{
				for (int j = 0; j < Conveyors.Count; j++)
				{
					if ((nativeArray3[i].Position - ConveyorPositions[j].Position).Chebyshev() < 0.1f)
					{
						CConveyPushRotatable component = nativeArray2[i];
						component.Target = Conveyors[j].Target;
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
