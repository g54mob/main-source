using System.Runtime.CompilerServices;
using Unity.Entities;
using Unity.Mathematics;

public struct ObjectLookupWriterCD : IComponentData, IQueryTypeParameter
{
	public EntityArchetype addToLookupArchetype;

	public EntityArchetype removeFromLookupArchetype;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Add(EntityCommandBuffer ecb, ObjectID objectID, int variation, float3 position, bool hasDirection, DirectionCD directionCD)
	{
		Entity e = ecb.CreateEntity(addToLookupArchetype);
		ecb.SetComponent(e, new AddToObjectLookupTriggerCD
		{
			position = position,
			objectID = objectID,
			variation = variation,
			hasDirection = hasDirection,
			directionCD = directionCD
		});
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Add(EntityCommandBuffer.ParallelWriter ecb, int index, ObjectID objectID, int variation, float3 position, bool hasDirection, DirectionCD directionCD)
	{
		Entity e = ecb.CreateEntity(index, addToLookupArchetype);
		ecb.SetComponent(index, e, new AddToObjectLookupTriggerCD
		{
			position = position,
			objectID = objectID,
			variation = variation,
			hasDirection = hasDirection,
			directionCD = directionCD
		});
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Remove(EntityCommandBuffer ecb, ObjectID objectID, int variation, float3 position, bool hasDirection, DirectionCD directionCD)
	{
		Entity e = ecb.CreateEntity(removeFromLookupArchetype);
		ecb.SetComponent(e, new RemoveFromObjectsLookupTriggerCD
		{
			position = position,
			objectID = objectID,
			variation = variation,
			hasDirection = hasDirection,
			directionCD = directionCD
		});
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Remove(EntityCommandBuffer.ParallelWriter ecb, int index, ObjectID objectID, int variation, float3 position, bool hasDirection, DirectionCD directionCD)
	{
		Entity e = ecb.CreateEntity(index, removeFromLookupArchetype);
		ecb.SetComponent(index, e, new RemoveFromObjectsLookupTriggerCD
		{
			position = position,
			objectID = objectID,
			variation = variation,
			hasDirection = hasDirection,
			directionCD = directionCD
		});
	}
}
