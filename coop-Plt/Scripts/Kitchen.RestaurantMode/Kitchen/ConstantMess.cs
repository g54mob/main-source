using KitchenData;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public class ConstantMess : DaySystem
	{
		private struct STimeTracker : IComponentData
		{
			public float LastTime;
		}

		private const float TimeBetween = 5f;

		protected override void OnUpdate()
		{
			if (HasStatus(RestaurantStatus.HalloweenTrickConstantMess))
			{
				STimeTracker orCreate = GetOrCreate<STimeTracker>();
				float totalTime = base.Time.TotalTime;
				if (!(totalTime - orCreate.LastTime < 5f))
				{
					orCreate.LastTime = totalTime;
					Set(orCreate);
					Bounds bounds = base.Bounds;
					Vector3 position = bounds.center + new Vector3(bounds.extents.x * (float)Random.Range(-1, 1), 0f, bounds.extents.z * (float)Random.Range(-1, 1));
					position.y = 0f;
					Entity entity = base.EntityManager.CreateEntity();
					base.EntityManager.AddComponentData(entity, new CPosition(position));
					base.EntityManager.AddComponentData(entity, new CMessRequest
					{
						ID = AssetReference.CustomerMess
					});
					CSoundEvent.Create(base.EntityManager, SoundEvent.MessCreated);
				}
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
