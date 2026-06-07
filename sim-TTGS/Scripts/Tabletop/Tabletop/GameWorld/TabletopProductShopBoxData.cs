using Simulator.GameWorld;
using UnityEngine;

namespace Tabletop.GameWorld
{
	public class TabletopProductShopBoxData : ProductShopBoxData
	{
		[SerializeField]
		private ELicense m_license;

		public bool HasLicense(out ELicense license)
		{
			license = m_license;
			return license != ELicense.NONE;
		}
	}
}
