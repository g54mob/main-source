using System;

namespace Rewired
{
	public struct ControllerIdentifier
	{
		private int OnhMqFsqbqzjeIcymxQRqzgUNhLO;

		private ControllerType ZXTSBVkNSjYfvoaMVfRqFYkfbwwq;

		private Guid lhwbzJdyFpFTHmiPWRlfUmdMemtZA;

		private string skPIasOfqRoEwmpbGxAPfGlaRRmV;

		private Guid mlpmAKbbynWNzJRgecnJypCorcnd;

		public int controllerId
		{
			get
			{
				return OnhMqFsqbqzjeIcymxQRqzgUNhLO;
			}
			set
			{
				OnhMqFsqbqzjeIcymxQRqzgUNhLO = value;
			}
		}

		public ControllerType controllerType
		{
			get
			{
				return ZXTSBVkNSjYfvoaMVfRqFYkfbwwq;
			}
			set
			{
				ZXTSBVkNSjYfvoaMVfRqFYkfbwwq = value;
			}
		}

		public Guid hardwareTypeGuid
		{
			get
			{
				return lhwbzJdyFpFTHmiPWRlfUmdMemtZA;
			}
			set
			{
				lhwbzJdyFpFTHmiPWRlfUmdMemtZA = value;
			}
		}

		public string hardwareIdentifier
		{
			get
			{
				return skPIasOfqRoEwmpbGxAPfGlaRRmV;
			}
			set
			{
				skPIasOfqRoEwmpbGxAPfGlaRRmV = value;
			}
		}

		public Guid deviceInstanceGuid
		{
			get
			{
				return mlpmAKbbynWNzJRgecnJypCorcnd;
			}
			set
			{
				mlpmAKbbynWNzJRgecnJypCorcnd = value;
			}
		}

		public static ControllerIdentifier Blank => new ControllerIdentifier
		{
			OnhMqFsqbqzjeIcymxQRqzgUNhLO = -1
		};

		internal ControllerIdentifier(Controller P_0)
		{
			OnhMqFsqbqzjeIcymxQRqzgUNhLO = P_0.id;
			ZXTSBVkNSjYfvoaMVfRqFYkfbwwq = P_0.type;
			lhwbzJdyFpFTHmiPWRlfUmdMemtZA = P_0.XoTulHbRfmGIRZBImccjILWCKOlE;
			skPIasOfqRoEwmpbGxAPfGlaRRmV = P_0.hardwareIdentifier;
			mlpmAKbbynWNzJRgecnJypCorcnd = P_0.deviceInstanceGuid;
		}
	}
}
