using Controllers;
using Kitchen.Modules;
using KitchenData;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Kitchen
{
	public abstract class TutorialSystem : GameSystemBase
	{
		private EntityQuery _SingletonEntityQuery_STutorialSystemMarker_4;

		protected override void Initialise()
		{
			base.Initialise();
			RequireSingletonForUpdate<STutorialSystemMarker>();
		}

		protected Entity Create(Item ingredient, Vector3 location, Vector3 facing)
		{
			int iD = ((ingredient.DedicatedProvider == null) ? base.Data.ReferableObjects.DefaultProvider.ID : ingredient.DedicatedProvider.ID);
			EntityManager entityManager = base.EntityManager;
			Entity entity = entityManager.CreateEntity(typeof(CCreateAppliance), typeof(CPosition), typeof(CItemProvider));
			entityManager.SetComponentData(entity, new CCreateAppliance
			{
				ID = iD
			});
			entityManager.SetComponentData(entity, CItemProvider.InfiniteItemProvider(ingredient.ID));
			entityManager.SetComponentData(entity, new CPosition(location, quaternion.LookRotation(facing, new float3(0f, 1f, 0f))));
			base.TileManager.SetOccupant(location, entity);
			return entity;
		}

		protected Entity Create(int appliance, Vector3 location, Vector3 facing)
		{
			EntityManager entityManager = base.EntityManager;
			Entity entity = entityManager.CreateEntity(typeof(CCreateAppliance), typeof(CPosition));
			entityManager.SetComponentData(entity, new CCreateAppliance
			{
				ID = appliance
			});
			entityManager.SetComponentData(entity, new CPosition(location, quaternion.LookRotation(facing, new float3(0f, 1f, 0f))));
			base.TileManager.SetOccupant(location, entity);
			return entity;
		}

		protected Entity Create(Appliance appliance, Vector3 location, Vector3 facing)
		{
			EntityManager entityManager = base.EntityManager;
			Entity entity = entityManager.CreateEntity(typeof(CCreateAppliance), typeof(CPosition));
			entityManager.SetComponentData(entity, new CCreateAppliance
			{
				ID = appliance.ID
			});
			entityManager.SetComponentData(entity, new CPosition(location, quaternion.LookRotation(facing, new float3(0f, 1f, 0f))));
			base.TileManager.SetOccupant(location, entity);
			return entity;
		}

		protected void MoveToStage(TutorialStage stage)
		{
			_SingletonEntityQuery_STutorialSystemMarker_4.SetSingleton(new STutorialSystemMarker
			{
				Stage = stage
			});
			base.EntityManager.DestroyEntity(GetEntityQuery(typeof(CTutorialBubble)));
			base.World.Add<STutorialStageRequireSetup>();
		}

		protected void CreatePopup(Vector3 location, TutorialMessage text, Button prompt, InputPromptAnimation animation = InputPromptAnimation.Attention)
		{
			Entity entity = base.EntityManager.CreateEntity(typeof(CRequiresView), typeof(CPosition), typeof(CTutorialBubble));
			base.EntityManager.SetComponentData(entity, new CRequiresView
			{
				Type = ViewType.TutorialBubble,
				ViewMode = ViewMode.WorldToScreen
			});
			base.EntityManager.SetComponentData(entity, new CPosition(location));
			base.EntityManager.SetComponentData(entity, new CTutorialBubble
			{
				Text = text,
				ButtonPrompt = prompt,
				Animation = animation
			});
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_STutorialSystemMarker_4 = GetEntityQuery(ComponentType.ReadWrite<STutorialSystemMarker>());
		}
	}
}
