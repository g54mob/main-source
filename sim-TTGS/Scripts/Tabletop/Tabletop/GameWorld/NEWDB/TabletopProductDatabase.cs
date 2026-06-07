using Simulator.GameWorld;

namespace Tabletop.GameWorld.NEWDB
{
	public class TabletopProductDatabase : ProductDatabase
	{
		protected override ProductData InstanceGet(int uid)
		{
			if (!m_runtimeProducts.ContainsKey(uid) && uid < 0)
			{
				MiniatureProductData miniatureProductData = Collection.GetMiniatureProductData(uid);
				m_runtimeProducts[uid] = miniatureProductData;
				return miniatureProductData;
			}
			return base.InstanceGet(uid);
		}
	}
}
