using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using UnityEngine.Scripting;

[UpdateInGroup(typeof(EndPresentationSystemGroup), OrderLast = true)]
[WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
public class EndPresentationEntityCommandBufferSystem : EntityCommandBufferSystem
{
	public struct Singleton : IComponentData, IQueryTypeParameter, IECBSingleton
	{
		internal unsafe UnsafeList<EntityCommandBuffer>* pendingBuffers;

		internal AllocatorManager.AllocatorHandle allocator;

		public unsafe EntityCommandBuffer CreateCommandBuffer(WorldUnmanaged world)
		{
			return EntityCommandBufferSystem.CreateCommandBuffer(ref *pendingBuffers, allocator, world);
		}

		public unsafe void SetPendingBufferList(ref UnsafeList<EntityCommandBuffer> buffers)
		{
			pendingBuffers = (UnsafeList<EntityCommandBuffer>*)UnsafeUtility.AddressOf(ref buffers);
		}

		public void SetAllocator(Allocator allocatorIn)
		{
			allocator = allocatorIn;
		}

		public void SetAllocator(AllocatorManager.AllocatorHandle allocatorIn)
		{
			allocator = allocatorIn;
		}
	}

	[Preserve]
	protected override void OnCreate()
	{
		base.OnCreate();
		this.RegisterSingleton<Singleton>(ref base.PendingBuffers, base.World.Unmanaged);
	}

	[Preserve]
	public EndPresentationEntityCommandBufferSystem()
	{
	}
}
