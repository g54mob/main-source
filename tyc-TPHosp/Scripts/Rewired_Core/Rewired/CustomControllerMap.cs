using System;

namespace Rewired
{
	public sealed class CustomControllerMap : ControllerMapWithAxes
	{
		private int ZiORqANABZSuNUOOeVLvtvptERP;

		public int sourceControllerId
		{
			get
			{
				return ZiORqANABZSuNUOOeVLvtvptERP;
			}
			set
			{
				ZiORqANABZSuNUOOeVLvtvptERP = value;
			}
		}

		public CustomControllerMap()
		{
		}

		public CustomControllerMap(CustomControllerMap customControllerMap)
			: base(customControllerMap)
		{
			ZiORqANABZSuNUOOeVLvtvptERP = customControllerMap.ZiORqANABZSuNUOOeVLvtvptERP;
		}

		internal void viTAFDZZNWpqhySlhxkBuvuTuVi(Guid P_0, int P_1, int P_2, int P_3)
		{
			_hardwareGuid = P_0;
			ZiORqANABZSuNUOOeVLvtvptERP = P_1;
			_categoryId = P_2;
			_layoutId = P_3;
		}

		internal static CustomControllerMap cPddxWgeQLKoABjtJFakbMLbPOFb(Guid P_0, int P_1, int P_2, int P_3)
		{
			CustomControllerMap customControllerMap = new CustomControllerMap();
			customControllerMap._hardwareGuid = P_0;
			customControllerMap.ZiORqANABZSuNUOOeVLvtvptERP = P_1;
			customControllerMap._sourceMapId = -1;
			customControllerMap._categoryId = P_2;
			customControllerMap._layoutId = P_3;
			return customControllerMap;
		}
	}
}
