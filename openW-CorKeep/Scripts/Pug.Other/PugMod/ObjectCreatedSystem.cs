using Unity.Collections;
using Unity.Entities;
using UnityEngine.Scripting;

namespace PugMod
{
	[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
	[UpdateInGroup(typeof(SimulationSystemGroup), OrderFirst = true)]
	[UpdateBefore(typeof(BeginSimulationEntityCommandBufferSystem))]
	public class ObjectCreatedSystem : SystemBase
	{
		private EntityQuery _objectCreatedQuery;

		private EntityQuery _objectRemovedQuery;

		[Preserve]
		protected override void OnCreate()
		{
			EntityQueryDesc entityQueryDesc = new EntityQueryDesc();
			entityQueryDesc.All = new ComponentType[1] { typeof(IsObjectCD) };
			entityQueryDesc.None = new ComponentType[1] { typeof(ObjectCreatedCalledCD) };
			entityQueryDesc.Options = EntityQueryOptions.IncludeDisabledEntities;
			EntityQueryDesc entityQueryDesc2 = entityQueryDesc;
			_objectCreatedQuery = GetEntityQuery(entityQueryDesc2);
			entityQueryDesc = new EntityQueryDesc();
			entityQueryDesc.All = new ComponentType[1] { typeof(ObjectCreatedCalledCD) };
			entityQueryDesc.None = new ComponentType[1] { typeof(IsObjectCD) };
			entityQueryDesc.Options = EntityQueryOptions.IncludeDisabledEntities;
			EntityQueryDesc entityQueryDesc3 = entityQueryDesc;
			_objectRemovedQuery = GetEntityQuery(entityQueryDesc3);
			base.Enabled = Manager.mod.Server.HasObjectCreatedSubscribers || Manager.mod.Server.HasObjectDestroyedSubscribers;
			base.OnCreate();
		}

		[Preserve]
		protected override void OnUpdate()
		{
			if (Manager.mod.Server.HasObjectCreatedSubscribers)
			{
				using NativeArray<Entity> nativeArray = _objectCreatedQuery.ToEntityArray(Allocator.Temp);
				foreach (Entity item in nativeArray)
				{
					Manager.mod.Server.ObjectCreated(item, base.EntityManager);
				}
			}
			base.EntityManager.AddComponent<ObjectCreatedCalledCD>(_objectCreatedQuery);
			if (Manager.mod.Server.HasObjectDestroyedSubscribers)
			{
				using NativeArray<Entity> nativeArray2 = _objectRemovedQuery.ToEntityArray(Allocator.Temp);
				foreach (Entity item2 in nativeArray2)
				{
					Manager.mod.Server.ObjectDestroyed(item2, base.EntityManager);
				}
			}
			base.EntityManager.RemoveComponent<ObjectCreatedCalledCD>(_objectRemovedQuery);
		}

		[Preserve]
		public ObjectCreatedSystem()
		{
		}
	}
}
