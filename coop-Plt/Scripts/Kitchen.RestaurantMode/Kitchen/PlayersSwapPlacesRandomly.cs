using KitchenData;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public class PlayersSwapPlacesRandomly : DaySystem
	{
		private struct STimeTracker : IComponentData
		{
			public float LastTime;

			public float Delay;
		}

		private const float TimeBetween = 25f;

		private EntityQuery Players;

		protected override void Initialise()
		{
			base.Initialise();
			Players = GetEntityQuery(new QueryHelper().All(typeof(CPlayer), typeof(CPosition)));
		}

		protected override void OnUpdate()
		{
			if (!HasStatus(RestaurantStatus.HalloweenTrickPlayersSwapPlacesRandomly))
			{
				return;
			}
			STimeTracker orCreate = GetOrCreate<STimeTracker>();
			float totalTime = base.Time.TotalTime;
			if (totalTime - orCreate.LastTime < orCreate.Delay)
			{
				return;
			}
			orCreate.LastTime = totalTime;
			orCreate.Delay = Random.Range(0.75f, 1.5f) * 25f;
			Set(orCreate);
			using NativeArray<Entity> nativeArray = Players.ToEntityArray(Allocator.Temp);
			if (nativeArray.Length >= 2)
			{
				int num = Random.Range(0, nativeArray.Length);
				int index = (num + Random.Range(1, nativeArray.Length - 1)) % nativeArray.Length;
				CPosition component = GetComponent<CPosition>(nativeArray[num]);
				CPosition component2 = GetComponent<CPosition>(nativeArray[index]);
				component.ForceSnap = true;
				component2.ForceSnap = true;
				Set(nativeArray[num], component2);
				Set(nativeArray[index], component);
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
