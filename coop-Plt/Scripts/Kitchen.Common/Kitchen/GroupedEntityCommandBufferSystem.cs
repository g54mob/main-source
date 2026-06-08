using Unity.Entities;

namespace Kitchen
{
	public abstract class GroupedEntityCommandBufferSystem : EntityCommandBufferSystem
	{
		public abstract ECB ECB { get; }

		protected override void OnUpdate()
		{
			base.OnUpdate();
			base.World.GetOrCreateSystem<BufferContainerSystem>().ReportECBUse(ECB);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
