using System.Collections.Generic;
using Unity.Entities;

namespace Kitchen
{
	public class BufferContainerSystem : ComponentSystemBase
	{
		protected Dictionary<ECB, EntityCommandBufferSystem> ECBs;

		private Dictionary<ECB, EntityCommandBuffer> Buffers = new Dictionary<ECB, EntityCommandBuffer>();

		public void ReportECBUse(ECB ecb)
		{
			Buffers.Remove(ecb);
		}

		public EntityCommandBuffer GetCommandBuffer(ECB ecb)
		{
			if (!Buffers.TryGetValue(ecb, out var value) || !value.IsCreated || !value.ShouldPlayback)
			{
				value = ECBs[ecb].CreateCommandBuffer();
				Buffers[ecb] = value;
			}
			return value;
		}

		protected override void OnCreate()
		{
			GroupedEntityCommandBufferSystem[] array = new GroupedEntityCommandBufferSystem[6]
			{
				base.World.GetOrCreateSystem<EndSimBarrier>(),
				base.World.GetOrCreateSystem<PostInteractionBarrier>(),
				base.World.GetOrCreateSystem<CustomerStateChangesBarrier>(),
				base.World.GetOrCreateSystem<DestructionGroupBarrier>(),
				base.World.GetOrCreateSystem<PostCreationBarrier>(),
				base.World.GetOrCreateSystem<PostViewSystemsBarrier>()
			};
			ECBs = new Dictionary<ECB, EntityCommandBufferSystem>(array.Length);
			GroupedEntityCommandBufferSystem[] array2 = array;
			foreach (GroupedEntityCommandBufferSystem groupedEntityCommandBufferSystem in array2)
			{
				ECBs.Add(groupedEntityCommandBufferSystem.ECB, groupedEntityCommandBufferSystem);
			}
		}

		public override void Update()
		{
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
