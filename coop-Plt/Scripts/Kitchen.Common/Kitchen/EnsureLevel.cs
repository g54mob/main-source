using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public class EnsureLevel : GenericSystemBase
	{
		private EntityQuery PlayerLevels;

		protected override void Initialise()
		{
			base.Initialise();
			PlayerLevels = GetEntityQuery(typeof(SPlayerLevel));
		}

		protected override void OnUpdate()
		{
			if (PlayerLevels.CalculateEntityCount() == 1)
			{
				return;
			}
			if (PlayerLevels.IsEmpty)
			{
				base.EntityManager.CreateEntity(typeof(SPlayerLevel), typeof(CPersistThroughSceneChanges));
				return;
			}
			using NativeArray<SPlayerLevel> nativeArray = PlayerLevels.ToComponentDataArray<SPlayerLevel>(Allocator.Temp);
			SPlayerLevel componentData = default(SPlayerLevel);
			foreach (SPlayerLevel item in nativeArray)
			{
				componentData.Level = Mathf.Max(item.Level, componentData.Level);
				componentData.ExpProgress = Mathf.Max(item.ExpProgress, componentData.ExpProgress);
			}
			base.EntityManager.DestroyEntity(PlayerLevels);
			Entity entity = base.EntityManager.CreateEntity(typeof(SPlayerLevel), typeof(CPersistThroughSceneChanges));
			base.EntityManager.SetComponentData(entity, componentData);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
