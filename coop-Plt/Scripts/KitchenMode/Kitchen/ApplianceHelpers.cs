using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public static class ApplianceHelpers
	{
		public static void AddApplianceComponents(EntityManager em, EntityCommandBuffer ecb, Entity e, Appliance prop)
		{
			EntityContext ctx = new EntityContext(em, ecb);
			if (!prop.IsNonInteractive)
			{
				ctx.Set(e, new CIsInteractive
				{
					IsLowPriority = (prop.Layer != OccupancyLayer.Default && !prop.ForceHighInteractionPriority)
				});
			}
			else
			{
				ctx.Set(e, default(CDoesNotOccupy));
			}
			if (prop.PreventSale)
			{
				ctx.Set(e, default(CUnsellableAppliance));
			}
			foreach (IApplianceProperty property in prop.Properties)
			{
				if (property is IAttachmentLogic attachmentLogic)
				{
					attachmentLogic.Attach(em, ecb, e);
				}
				else
				{
					ApplianceComponentHelpers.SetDynamic(ctx, e, property);
				}
			}
		}
	}
}
