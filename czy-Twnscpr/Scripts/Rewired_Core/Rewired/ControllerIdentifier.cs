using System;

namespace Rewired
{
	public struct ControllerIdentifier
	{
		private int OAqYXyYxxoyErUWWGBOiLsNcUok;

		private ControllerType ODiTVfklXHDoeIfdJEahPbsrzhzs;

		private Guid lajutzcDPrsSwSNdnEBSPcUXtaw;

		private string nbrgCMYAuUfRsiFtxuiXwNSBDYWs;

		private Guid gjIwAQzDxzoikMpsmpvjOOHYbHh;

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

		internal ControllerIdentifier(Controller controller)
		{
			OAqYXyYxxoyErUWWGBOiLsNcUok = 0;
			ODiTVfklXHDoeIfdJEahPbsrzhzs = default(ControllerType);
			lajutzcDPrsSwSNdnEBSPcUXtaw = default(Guid);
			nbrgCMYAuUfRsiFtxuiXwNSBDYWs = null;
			gjIwAQzDxzoikMpsmpvjOOHYbHh = default(Guid);
		}
	}
}
