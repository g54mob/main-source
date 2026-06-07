using System;

namespace Tabletop.GameWorld
{
	public class TabletopGenericProductData : TabletopProductData
	{
		public override string DataNamePrefix
		{
			get
			{
				return "Generic/" + base.Type;
			}
			set
			{
				throw new Exception("Can't set Product Data prefix");
			}
		}
	}
}
