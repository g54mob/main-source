using System.Runtime.InteropServices;
using KitchenData;
using Platforms;
using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	[UpdateAfter(typeof(CreateCustomerGroup))]
	[UpdateInGroup(typeof(CustomerCreationGroup))]
	public class AttachCustomerProperties : RestaurantSystem
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct CAttached : IComponentData
		{
		}

		public EntityQuery Unattached;

		protected override void Initialise()
		{
			base.Initialise();
			Unattached = GetEntityQuery(new QueryHelper().All(typeof(CCustomerGroup), typeof(CCustomerType)).None(typeof(CAttached)));
		}

		protected override void OnUpdate()
		{
			using NativeArray<Entity> nativeArray = Unattached.ToEntityArray(Allocator.Temp);
			EntityCommandBuffer ecb = new EntityCommandBuffer(Allocator.Temp);
			foreach (Entity item in nativeArray)
			{
				base.EntityManager.AddComponent<CAttached>(item);
				if (!Require<CCustomerType>(item, out CCustomerType comp) || !base.Data.TryGet<CustomerType>(comp.Type, out var output))
				{
					continue;
				}
				if (RequireBuffer(item, out DynamicBuffer<CGroupMember> comp2))
				{
					foreach (CGroupMember item2 in comp2)
					{
						ecb.AddComponent<CAttached>(item2);
						Attach(ecb, item2, output);
					}
				}
				Attach(ecb, item, output);
			}
			ecb.Playback(base.EntityManager);
			ecb.Dispose();
		}

		public void Attach(EntityCommandBuffer ecb, Entity e, CustomerType type)
		{
			foreach (ICustomerProperty property in type.Properties)
			{
				if (property is IAttachmentLogic attachmentLogic)
				{
					attachmentLogic.Attach(base.EntityManager, ecb, e);
				}
				else if (!PlatformSettings.AllowsDynamicVariables)
				{
					if (property is CRandomisedWaitTimes component)
					{
						ecb.AddComponent(e, component);
					}
					else
					{
						EntityCommandBufferManagedComponentExtensions.AddComponent(ecb, e, property);
					}
				}
				else
				{
					ecb.AddComponent(e, (dynamic)property);
				}
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
