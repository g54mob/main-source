using System;

namespace Rewired
{
	public struct ControllerIdentifier
	{
		private int HOfXKstauKwTqpMsyTWXViZIbgl;

		private ControllerType VkxeQjDVSfumjFSZdzmQHhgPgAwE;

		private Guid whqrPnRNEDctHvdjThUpHsqpUGr;

		private string oSsXVIxBbudLtgkNLcagZTIlYpFG;

		private Guid daDenESRsNYcblpUGKfMATRkvCo;

		public int controllerId
		{
			get
			{
				return HOfXKstauKwTqpMsyTWXViZIbgl;
			}
			set
			{
				HOfXKstauKwTqpMsyTWXViZIbgl = value;
			}
		}

		public ControllerType controllerType
		{
			get
			{
				return VkxeQjDVSfumjFSZdzmQHhgPgAwE;
			}
			set
			{
				VkxeQjDVSfumjFSZdzmQHhgPgAwE = value;
			}
		}

		public Guid hardwareTypeGuid
		{
			get
			{
				return whqrPnRNEDctHvdjThUpHsqpUGr;
			}
			set
			{
				whqrPnRNEDctHvdjThUpHsqpUGr = value;
			}
		}

		public string hardwareIdentifier
		{
			get
			{
				return oSsXVIxBbudLtgkNLcagZTIlYpFG;
			}
			set
			{
				oSsXVIxBbudLtgkNLcagZTIlYpFG = value;
			}
		}

		public Guid deviceInstanceGuid
		{
			get
			{
				return daDenESRsNYcblpUGKfMATRkvCo;
			}
			set
			{
				daDenESRsNYcblpUGKfMATRkvCo = value;
			}
		}

		public static ControllerIdentifier Blank => new ControllerIdentifier
		{
			HOfXKstauKwTqpMsyTWXViZIbgl = -1
		};

		internal ControllerIdentifier(Controller controller)
		{
			HOfXKstauKwTqpMsyTWXViZIbgl = controller.id;
			VkxeQjDVSfumjFSZdzmQHhgPgAwE = controller.type;
			whqrPnRNEDctHvdjThUpHsqpUGr = controller.whqrPnRNEDctHvdjThUpHsqpUGr;
			oSsXVIxBbudLtgkNLcagZTIlYpFG = controller.hardwareIdentifier;
			daDenESRsNYcblpUGKfMATRkvCo = controller.deviceInstanceGuid;
		}
	}
}
