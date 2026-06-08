using System.Runtime.InteropServices;
using KitchenData;
using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	public class SpawnPracticeCats : GameSystemBase
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private struct CPracticeCustomer : IComponentData
		{
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct CRequestNewPracticeCustomers : IComponentData
		{
		}

		private EntityQuery ScheduledCustomers;

		private EntityQuery CurrentCustomers;

		private EntityQuery ScheduledPracticeCustomers;

		private EntityQuery Requests;

		private CustomerType GenericCustomerType;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SKitchenParameters_41;

		protected override void Initialise()
		{
			base.Initialise();
			ScheduledCustomers = GetEntityQuery(new QueryHelper().All(typeof(CScheduledCustomer)).None(typeof(CPracticeCustomer)));
			ScheduledPracticeCustomers = GetEntityQuery(new QueryHelper().All(typeof(CScheduledCustomer), typeof(CPracticeCustomer)));
			CurrentCustomers = GetEntityQuery(typeof(CCustomerGroup));
			Requests = GetEntityQuery(typeof(CRequestNewPracticeCustomers));
		}

		private void FindCustomerType()
		{
			if (GenericCustomerType != null)
			{
				return;
			}
			foreach (CustomerType item in base.Data.Get<CustomerType>())
			{
				if (item.IsGenericGroup)
				{
					GenericCustomerType = item;
					break;
				}
			}
		}

		protected override void OnUpdate()
		{
			FindCustomerType();
			if (!Has<SPracticeMode>())
			{
				base.EntityManager.DestroyEntity(ScheduledPracticeCustomers);
				return;
			}
			base.EntityManager.DestroyEntity(ScheduledCustomers);
			if (!Requests.IsEmpty || (ScheduledCustomers.IsEmpty && CurrentCustomers.IsEmpty))
			{
				KitchenParameters parameters = _SingletonEntityQuery_SKitchenParameters_41.GetSingleton<SKitchenParameters>().Parameters;
				Entity entity = base.EntityManager.CreateEntity(typeof(CScheduledCustomer));
				base.EntityManager.AddComponentData(entity, new CScheduledCustomer
				{
					GroupSize = parameters.MaximumGroupSize,
					TimeOfDay = -0.01f,
					IsCat = true
				});
				base.EntityManager.AddComponentData(entity, new CCustomerType
				{
					Type = GenericCustomerType.ID
				});
				base.EntityManager.DestroyEntity(Requests);
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_SKitchenParameters_41 = GetEntityQuery(ComponentType.ReadOnly<SKitchenParameters>());
		}
	}
}
