using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CSoundEvent : IComponentData
	{
		public SoundEvent Event;

		public static Entity Create(EntityCommandBuffer ecb, SoundEvent e)
		{
			Entity entity = ecb.CreateEntity();
			ecb.AddComponent(entity, new CSoundEvent
			{
				Event = e
			});
			ecb.AddComponent(entity, new CRequiresView
			{
				Type = ViewType.SoundEvent
			});
			ecb.AddComponent(entity, default(CPosition));
			return entity;
		}

		public static Entity Create(EntityManager em, SoundEvent e)
		{
			Entity entity = em.CreateEntity();
			em.AddComponentData(entity, new CSoundEvent
			{
				Event = e
			});
			em.AddComponentData(entity, new CRequiresView
			{
				Type = ViewType.SoundEvent
			});
			em.AddComponentData(entity, default(CPosition));
			return entity;
		}
	}
}
