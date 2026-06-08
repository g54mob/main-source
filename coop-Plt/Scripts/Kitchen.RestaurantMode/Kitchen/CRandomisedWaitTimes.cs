using KitchenData;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public struct CRandomisedWaitTimes : ICustomerProperty, IComponentData, IAttachmentLogic, IAttachableProperty
	{
		public float MinimumMultiplier;

		public float MaximumMultiplier;

		public void Attach(EntityManager em, EntityCommandBuffer ecb, Entity e)
		{
			if (!em.RequireComponent<CCustomerSettings>(e, out var component))
			{
				PatienceValues basePatience = component.BasePatience;
				basePatience.Thinking *= Random.Range(MinimumMultiplier, MaximumMultiplier);
				basePatience.Eating *= Random.Range(MinimumMultiplier, MaximumMultiplier);
				component.BasePatience = basePatience;
			}
		}
	}
}
