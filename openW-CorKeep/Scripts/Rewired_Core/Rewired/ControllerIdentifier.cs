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
				return bLRVTeIGKwveFMgJTmbRjnJZikQhA;
			}
			set
			{
				bLRVTeIGKwveFMgJTmbRjnJZikQhA = value;
			}
		}

		public ControllerType controllerType
		{
			get
			{
				return wtdxRmQbbvJrQgvXmqBkULzyrRfE;
			}
			set
			{
				wtdxRmQbbvJrQgvXmqBkULzyrRfE = value;
			}
		}

		public Guid hardwareTypeGuid
		{
			get
			{
				return CmAhSsEeajYQuwvkvQEldWENQrex;
			}
			set
			{
				CmAhSsEeajYQuwvkvQEldWENQrex = value;
			}
		}

		public string hardwareIdentifier
		{
			get
			{
				return DjdhRLFoBLdJHrsUjkbPeaEBdQfNb;
			}
			set
			{
				DjdhRLFoBLdJHrsUjkbPeaEBdQfNb = value;
			}
		}

		public Guid deviceInstanceGuid
		{
			get
			{
				return VgFTIjBgGzHPcPmeDQJdhHQlxsgM;
			}
			set
			{
				VgFTIjBgGzHPcPmeDQJdhHQlxsgM = value;
			}
		}

		public static ControllerIdentifier Blank => new ControllerIdentifier
		{
			bLRVTeIGKwveFMgJTmbRjnJZikQhA = -1
		};

		internal ControllerIdentifier(Controller P_0)
		{
			bLRVTeIGKwveFMgJTmbRjnJZikQhA = P_0.id;
			wtdxRmQbbvJrQgvXmqBkULzyrRfE = P_0.type;
			CmAhSsEeajYQuwvkvQEldWENQrex = P_0.savDJAJJykdFgIDmPSBdENeZaLumA;
			DjdhRLFoBLdJHrsUjkbPeaEBdQfNb = P_0.hardwareIdentifier;
			VgFTIjBgGzHPcPmeDQJdhHQlxsgM = P_0.deviceInstanceGuid;
		}
	}
}
