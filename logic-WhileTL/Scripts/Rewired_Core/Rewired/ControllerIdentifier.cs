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
				return JJTApEccBgIfJOWwHYEPwbJOOnbjA;
			}
			set
			{
				JJTApEccBgIfJOWwHYEPwbJOOnbjA = value;
			}
		}

		public ControllerType controllerType
		{
			get
			{
				return FHHqpHICfRrjYzaZOfxGJuaReWmv;
			}
			set
			{
				FHHqpHICfRrjYzaZOfxGJuaReWmv = value;
			}
		}

		public Guid hardwareTypeGuid
		{
			get
			{
				return ajOkBXCGxlWjiAJvaOHxjyadfWfu;
			}
			set
			{
				ajOkBXCGxlWjiAJvaOHxjyadfWfu = value;
			}
		}

		public string hardwareIdentifier
		{
			get
			{
				return yEjikqRGUWZMHRDwxsidHYxxAJL;
			}
			set
			{
				yEjikqRGUWZMHRDwxsidHYxxAJL = value;
			}
		}

		public Guid deviceInstanceGuid
		{
			get
			{
				return xRlLReFRFhkpEOIYtEoQauXubQsGA;
			}
			set
			{
				xRlLReFRFhkpEOIYtEoQauXubQsGA = value;
			}
		}

		public static ControllerIdentifier Blank => new ControllerIdentifier
		{
			JJTApEccBgIfJOWwHYEPwbJOOnbjA = -1
		};

		internal ControllerIdentifier(Controller P_0)
		{
			JJTApEccBgIfJOWwHYEPwbJOOnbjA = P_0.id;
			FHHqpHICfRrjYzaZOfxGJuaReWmv = P_0.type;
			ajOkBXCGxlWjiAJvaOHxjyadfWfu = P_0.ajOkBXCGxlWjiAJvaOHxjyadfWfu;
			yEjikqRGUWZMHRDwxsidHYxxAJL = P_0.hardwareIdentifier;
			xRlLReFRFhkpEOIYtEoQauXubQsGA = P_0.deviceInstanceGuid;
		}
	}
}
