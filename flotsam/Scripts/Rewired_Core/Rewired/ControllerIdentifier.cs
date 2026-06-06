using System;

namespace Rewired
{
	public struct ControllerIdentifier
	{
		private int znLsRlcUoahcddXjSAowymPaupGu;

		private ControllerType iyvfrnkpTbPtiJHZfhUTNNDXilbl;

		private Guid QsWGMniqYfgIKgLQJgJEViMeicuTB;

		private string XJbELUSOdHGRzjDasnmclxOOTZfbA;

		private Guid HcJDHkdgAbXjKsgGMSiYqmUQpcgl;

		public int controllerId
		{
			get
			{
				return znLsRlcUoahcddXjSAowymPaupGu;
			}
			set
			{
				znLsRlcUoahcddXjSAowymPaupGu = value;
			}
		}

		public ControllerType controllerType
		{
			get
			{
				return iyvfrnkpTbPtiJHZfhUTNNDXilbl;
			}
			set
			{
				iyvfrnkpTbPtiJHZfhUTNNDXilbl = value;
			}
		}

		public Guid hardwareTypeGuid
		{
			get
			{
				return QsWGMniqYfgIKgLQJgJEViMeicuTB;
			}
			set
			{
				QsWGMniqYfgIKgLQJgJEViMeicuTB = value;
			}
		}

		public string hardwareIdentifier
		{
			get
			{
				return XJbELUSOdHGRzjDasnmclxOOTZfbA;
			}
			set
			{
				XJbELUSOdHGRzjDasnmclxOOTZfbA = value;
			}
		}

		public Guid deviceInstanceGuid
		{
			get
			{
				return HcJDHkdgAbXjKsgGMSiYqmUQpcgl;
			}
			set
			{
				HcJDHkdgAbXjKsgGMSiYqmUQpcgl = value;
			}
		}

		public static ControllerIdentifier Blank => new ControllerIdentifier
		{
			znLsRlcUoahcddXjSAowymPaupGu = -1
		};

		internal ControllerIdentifier(Controller P_0)
		{
			znLsRlcUoahcddXjSAowymPaupGu = P_0.id;
			iyvfrnkpTbPtiJHZfhUTNNDXilbl = P_0.type;
			QsWGMniqYfgIKgLQJgJEViMeicuTB = P_0.qapLJarKYePKdgQROGMwYujqCcvB;
			XJbELUSOdHGRzjDasnmclxOOTZfbA = P_0.hardwareIdentifier;
			HcJDHkdgAbXjKsgGMSiYqmUQpcgl = P_0.deviceInstanceGuid;
		}
	}
}
