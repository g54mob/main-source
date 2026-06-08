using Unity.Entities;

namespace KitchenData
{
	public interface IAttachmentLogic : IAttachableProperty, IComponentData
	{
		void Attach(EntityManager em, EntityCommandBuffer ecb, Entity e);
	}
}
