using KitchenData;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public class CreatePets : FranchiseFirstFrameSystem
	{
		protected override void OnUpdate()
		{
			NewGroup(GetCommandBuffer(ECB.End));
		}

		protected void NewGroup(EntityCommandBuffer ecb)
		{
			Entity entity = ecb.CreateEntity(DefaultArchetype);
			ecb.AddComponent<CCustomerGroup>(entity);
			ecb.AddComponent<CPosition>(entity);
			ecb.AddComponent(entity, new CPatience(PatienceReason.Seating));
			ecb.AddComponent(entity, new CCustomerSettings
			{
				BasePatience = PatienceValues.Default,
				Patience = PatienceValues.Default,
				BaseOrdering = OrderingValues.Default,
				Ordering = OrderingValues.Default
			});
			ecb.AddComponent<CGroupWait>(entity);
			ecb.AddComponent(entity, new CGroupMealPhase
			{
				Phase = MenuPhase.Starter
			});
			ecb.AddComponent<CGroupReward>(entity);
			ecb.AddBuffer<CGroupMember>(entity);
			for (int i = 0; i < 2; i++)
			{
				ecb.AppendToBuffer(entity, (CGroupMember)NewCustomer(ecb, entity));
			}
		}

		protected Entity NewCustomer(EntityCommandBuffer ecb, Entity group)
		{
			Entity entity = ecb.CreateEntity(DefaultArchetype);
			ecb.AddComponent(entity, new CCustomer
			{
				Scale = 1f,
				Speed = 1f
			});
			ecb.AddComponent(entity, new CCustomerState
			{
				CurrentState = CCustomerState.State.Normal
			});
			ecb.AddComponent(entity, new CBelongsToGroup
			{
				Group = group
			});
			ecb.AddComponent(entity, default(CCanBePetted));
			ecb.AddComponent(entity, default(CIsInteractive));
			ecb.AddComponent(entity, new CPosition(new Vector3(5f, 0f, Random.Range(-2, 7))));
			ecb.AddComponent(entity, new CRequiresView
			{
				Type = ViewType.CustomerCat,
				PhysicsDriven = true
			});
			return entity;
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
