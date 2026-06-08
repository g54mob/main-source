using Unity.Entities;

namespace Kitchen
{
	public static class HolderHelpers
	{
		public static bool GoHome(EntityManager em, Entity e)
		{
			EntityContext entityContext = new EntityContext(em);
			if (!entityContext.Require<CHeldBy>(e, out var comp))
			{
				return false;
			}
			if (comp.Holder == Entity.Null)
			{
				return false;
			}
			if (!entityContext.Require<CHome>(e, out var comp2))
			{
				return false;
			}
			if (comp2.Holder == Entity.Null || comp.Holder == comp2.Holder)
			{
				return false;
			}
			if (entityContext.Require<CItemHolder>(comp2.Holder, out var comp3) && comp3.HeldItem != Entity.Null && !GoHome(em, comp3.HeldItem))
			{
				return false;
			}
			entityContext.Set(comp.Holder, default(CItemHolder));
			entityContext.Set(comp2.Holder, (CItemHolder)e);
			entityContext.Set(e, (CHeldBy)comp2.Holder);
			return true;
		}
	}
}
