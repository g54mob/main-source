using System.Collections.Generic;
using DV.Utils;
using Unity.Entities;

namespace DV.DopplerEffects
{
	[AlwaysUpdateSystem]
	public class DopplerChangeUpdateTypeSystem : SystemBase
	{
		public static readonly List<(DVConvertToEntity, Doppler.UpdateMode updateMode)> ChangeUpdateModeList = new List<(DVConvertToEntity, Doppler.UpdateMode)>();

		private EndSimulationEntityCommandBufferSystem endSimulationEcbSystem;

		protected override void OnCreate()
		{
			endSimulationEcbSystem = base.World.GetExistingSystem<EndSimulationEntityCommandBufferSystem>();
			UnloadWatcher.UnloadRequested += UnloadRequested;
		}

		protected override void OnDestroy()
		{
			UnloadWatcher.UnloadRequested -= UnloadRequested;
		}

		protected override void OnUpdate()
		{
			if (ChangeUpdateModeList.Count == 0)
			{
				return;
			}
			EntityCommandBuffer entityCommandBuffer = endSimulationEcbSystem.CreateCommandBuffer();
			foreach (var (dVConvertToEntity, updateMode) in ChangeUpdateModeList)
			{
				if ((bool)dVConvertToEntity)
				{
					Entity entity = dVConvertToEntity.Entity;
					entityCommandBuffer.RemoveComponent<Doppler.DopplerUpdateInLateUpdateTag>(entity);
					entityCommandBuffer.RemoveComponent<Doppler.DopplerUpdateInFixedUpdateTag>(entity);
					switch (updateMode)
					{
					case Doppler.UpdateMode.FixedUpdate:
						entityCommandBuffer.AddComponent(entity, default(Doppler.DopplerUpdateInLateUpdateTag));
						break;
					case Doppler.UpdateMode.LateUpdate:
						entityCommandBuffer.AddComponent(entity, default(Doppler.DopplerUpdateInFixedUpdateTag));
						break;
					}
				}
			}
			ChangeUpdateModeList.Clear();
		}

		private void UnloadRequested()
		{
			ChangeUpdateModeList.Clear();
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
