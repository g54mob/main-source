using System;

namespace Rewired
{
	public struct ControllerIdentifier
	{
		private int JJTApEccBgIfJOWwHYEPwbJOOnbjA;

		private ControllerType FHHqpHICfRrjYzaZOfxGJuaReWmv;

		private Guid ajOkBXCGxlWjiAJvaOHxjyadfWfu;

		private string yEjikqRGUWZMHRDwxsidHYxxAJL;

		private Guid xRlLReFRFhkpEOIYtEoQauXubQsGA;

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
			JJTApEccBgIfJOWwHYEPwbJOOnbjA = 0;
			FHHqpHICfRrjYzaZOfxGJuaReWmv = default(ControllerType);
			ajOkBXCGxlWjiAJvaOHxjyadfWfu = default(Guid);
			yEjikqRGUWZMHRDwxsidHYxxAJL = null;
			xRlLReFRFhkpEOIYtEoQauXubQsGA = default(Guid);
		}
	}
}
