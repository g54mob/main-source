using System;

namespace Rewired
{
	public sealed class CustomControllerMap : ControllerMapWithAxes
	{
		private int pVkDZeuroSeLJETezpLqWjQXPZxE;

		public int sourceControllerId
		{
			get
			{
				return pVkDZeuroSeLJETezpLqWjQXPZxE;
			}
			set
			{
				pVkDZeuroSeLJETezpLqWjQXPZxE = value;
			}
		}

		public CustomControllerMap()
		{
		}

		public CustomControllerMap(CustomControllerMap customControllerMap)
			: base(customControllerMap)
		{
			pVkDZeuroSeLJETezpLqWjQXPZxE = customControllerMap.pVkDZeuroSeLJETezpLqWjQXPZxE;
		}

		internal void RcfaEbycwVRZfrTukoZSsFIdNiG(Guid P_0, int P_1, int P_2, int P_3)
		{
			_hardwareGuid = P_0;
			pVkDZeuroSeLJETezpLqWjQXPZxE = P_1;
			_categoryId = P_2;
			_layoutId = P_3;
		}

		internal static CustomControllerMap SYXlQmHOzCKJIifRKNsrYHodbMla(Guid P_0, int P_1, int P_2, int P_3)
		{
			CustomControllerMap customControllerMap = new CustomControllerMap();
			customControllerMap._hardwareGuid = P_0;
			customControllerMap.pVkDZeuroSeLJETezpLqWjQXPZxE = P_1;
			customControllerMap._sourceMapId = -1;
			customControllerMap._categoryId = P_2;
			customControllerMap._layoutId = P_3;
			return customControllerMap;
		}
	}
}
