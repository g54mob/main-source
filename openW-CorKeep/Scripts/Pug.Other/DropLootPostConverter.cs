using Pug.Conversion;
using Unity.Entities;
using UnityEngine;

public class DropLootPostConverter : PostConverter
{
	public override void PostConvert(GameObject authoring)
	{
		Entity entity = GetEntity(authoring);
		if (base.EntityManager.HasComponent<DiggableCD>(entity) || base.EntityManager.HasComponent<MineableCD>(entity) || base.EntityManager.HasComponent<ContainedObjectsBuffer>(entity) || base.EntityManager.HasComponent<DropsLootBuffer>(entity) || base.EntityManager.HasComponent<PlantCD>(entity) || base.EntityManager.HasComponent<TileCD>(entity) || base.EntityManager.HasComponent<SpawnEntityOnDeathCD>(entity) || base.EntityManager.HasComponent<SpawnTileOnDeathCD>(entity) || base.EntityManager.HasComponent<RemoveTileOnDeathCD>(entity) || base.EntityManager.HasComponent<DropsLootFromLootTableCD>(entity) || base.EntityManager.HasComponent<SeasonalLootCD>(entity))
		{
			base.EntityManager.AddComponentData(entity, default(StartDroppingLootCD));
			base.EntityManager.SetComponentEnabled<StartDroppingLootCD>(entity, value: false);
			base.EntityManager.AddComponentData(entity, default(FinishedDroppingLootCD));
			base.EntityManager.SetComponentEnabled<FinishedDroppingLootCD>(entity, value: false);
			base.EntityManager.AddComponentData(entity, default(DontDropLootCD));
			DontDropContainedAuthoring component;
			bool value = base.EntityManager.HasComponent<MerchantCD>(entity) || authoring.TryGetComponent<DontDropContainedAuthoring>(out component);
			base.EntityManager.SetComponentEnabled<DontDropLootCD>(entity, value);
			base.EntityManager.AddComponentData(entity, default(DontDropSelfCD));
			DontDropSelfAuthoring component2;
			bool value2 = authoring.TryGetComponent<DontDropSelfAuthoring>(out component2);
			base.EntityManager.SetComponentEnabled<DontDropSelfCD>(entity, value2);
		}
	}
}
