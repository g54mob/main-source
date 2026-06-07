using Simulator.GameWorld;

namespace Tabletop.GameWorld
{
	public class TabletopProduct : Product
	{
		private TabletopProductData m_tabletopData;

		public TabletopProductData TabletopData
		{
			get
			{
				if (m_tabletopData == null)
				{
					m_tabletopData = base.ProductData as TabletopProductData;
				}
				return m_tabletopData;
			}
		}
	}
}
