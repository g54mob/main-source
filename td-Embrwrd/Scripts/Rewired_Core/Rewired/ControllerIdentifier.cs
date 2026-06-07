using System;

namespace Rewired
{
	public struct ControllerIdentifier
	{
		private int nijfNNPuecUfsdTnBxkvJllsDwcD;

		private ControllerType wWBcFNRwTxwddNpfqboYeEvRSOBW;

		private Guid MluiPPDSCvepRLDkhMlVZbemIfSI;

		private string RdXtMqfHxLfPoNOGnzkpAFcOppRF;

		private Guid FGbMhOUpcxidJcQkBINFPDmStJUo;

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
			nijfNNPuecUfsdTnBxkvJllsDwcD = 0;
			wWBcFNRwTxwddNpfqboYeEvRSOBW = default(ControllerType);
			MluiPPDSCvepRLDkhMlVZbemIfSI = default(Guid);
			RdXtMqfHxLfPoNOGnzkpAFcOppRF = null;
			FGbMhOUpcxidJcQkBINFPDmStJUo = default(Guid);
		}
	}
}
