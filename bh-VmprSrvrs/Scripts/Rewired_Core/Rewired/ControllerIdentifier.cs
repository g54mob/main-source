using System;

namespace Rewired
{
	public struct ControllerIdentifier
	{
		private int jUJshdoGNBDmgGaWJHvSqYllMReT;

		private ControllerType mMxzWrghwOjmdereoymlHYbWcSLX;

		private Guid GuYAnbiRbQLdXwCbbAIiimuloMESA;

		private string HjksUgSECyyorkLjrnUytodPlFob;

		private Guid LZJkwwhrDSsmBVsdLFNgBuiLkJQLA;

		public int controllerId
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public ControllerType controllerType
		{
			get
			{
				return default(ControllerType);
			}
			set
			{
			}
		}

		public Guid hardwareTypeGuid
		{
			get
			{
				return default(Guid);
			}
			set
			{
			}
		}

		public string hardwareIdentifier
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Guid deviceInstanceGuid
		{
			get
			{
				return default(Guid);
			}
			set
			{
			}
		}

		public static ControllerIdentifier Blank => default(ControllerIdentifier);

		internal ControllerIdentifier(Controller P_0)
		{
			jUJshdoGNBDmgGaWJHvSqYllMReT = 0;
			mMxzWrghwOjmdereoymlHYbWcSLX = default(ControllerType);
			GuYAnbiRbQLdXwCbbAIiimuloMESA = default(Guid);
			HjksUgSECyyorkLjrnUytodPlFob = null;
			LZJkwwhrDSsmBVsdLFNgBuiLkJQLA = default(Guid);
		}
	}
}
