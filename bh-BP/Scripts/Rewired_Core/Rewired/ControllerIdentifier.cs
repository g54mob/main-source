using System;

namespace Rewired
{
	public struct ControllerIdentifier
	{
		private int bLRVTeIGKwveFMgJTmbRjnJZikQhA;

		private ControllerType wtdxRmQbbvJrQgvXmqBkULzyrRfE;

		private Guid CmAhSsEeajYQuwvkvQEldWENQrex;

		private string DjdhRLFoBLdJHrsUjkbPeaEBdQfNb;

		private Guid VgFTIjBgGzHPcPmeDQJdhHQlxsgM;

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
			bLRVTeIGKwveFMgJTmbRjnJZikQhA = 0;
			wtdxRmQbbvJrQgvXmqBkULzyrRfE = default(ControllerType);
			CmAhSsEeajYQuwvkvQEldWENQrex = default(Guid);
			DjdhRLFoBLdJHrsUjkbPeaEBdQfNb = null;
			VgFTIjBgGzHPcPmeDQJdhHQlxsgM = default(Guid);
		}
	}
}
