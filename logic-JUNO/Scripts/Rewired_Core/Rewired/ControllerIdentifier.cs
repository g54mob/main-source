using System;

namespace Rewired
{
	public struct ControllerIdentifier
	{
		private int tRBDKFylgLxhXFQfZkPNxDEliXJT;

		private ControllerType kUxPjZaPDISIQzgFulbeIBEQuMoX;

		private Guid ItKMDmiEHURoJfQjtZlErPItShrb;

		private string NdzDwuSUzyGKZtheraTFmIZZbzwG;

		private Guid JAZHHUexmGtEuPCYHmWnzlLBnXfVA;

		public int controllerId
		{
			get
			{
				return tRBDKFylgLxhXFQfZkPNxDEliXJT;
			}
			set
			{
				tRBDKFylgLxhXFQfZkPNxDEliXJT = value;
			}
		}

		public ControllerType controllerType
		{
			get
			{
				return kUxPjZaPDISIQzgFulbeIBEQuMoX;
			}
			set
			{
				kUxPjZaPDISIQzgFulbeIBEQuMoX = value;
			}
		}

		public Guid hardwareTypeGuid
		{
			get
			{
				return ItKMDmiEHURoJfQjtZlErPItShrb;
			}
			set
			{
				ItKMDmiEHURoJfQjtZlErPItShrb = value;
			}
		}

		public string hardwareIdentifier
		{
			get
			{
				return NdzDwuSUzyGKZtheraTFmIZZbzwG;
			}
			set
			{
				NdzDwuSUzyGKZtheraTFmIZZbzwG = value;
			}
		}

		public Guid deviceInstanceGuid
		{
			get
			{
				return JAZHHUexmGtEuPCYHmWnzlLBnXfVA;
			}
			set
			{
				JAZHHUexmGtEuPCYHmWnzlLBnXfVA = value;
			}
		}

		public static ControllerIdentifier Blank => new ControllerIdentifier
		{
			tRBDKFylgLxhXFQfZkPNxDEliXJT = -1
		};

		internal ControllerIdentifier(Controller P_0)
		{
			tRBDKFylgLxhXFQfZkPNxDEliXJT = P_0.id;
			kUxPjZaPDISIQzgFulbeIBEQuMoX = P_0.type;
			ItKMDmiEHURoJfQjtZlErPItShrb = P_0.gLbADvCdALkEcLIQPhWpjDrhhunKA;
			NdzDwuSUzyGKZtheraTFmIZZbzwG = P_0.hardwareIdentifier;
			JAZHHUexmGtEuPCYHmWnzlLBnXfVA = P_0.deviceInstanceGuid;
		}
	}
}
