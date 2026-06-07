using System.Collections.Generic;
using Factory.FieldData;

namespace Factory.Mech
{
	public class InversionPipe : MechBase
	{
		private List<PipeLinkPairInMechBase> pipeLinkPair0;

		private List<ILiquidCarrier> liquidCarriers0;

		private List<PipeLinkPairInMechBase> pipeLinkPair1;

		private List<ILiquidCarrier> liquidCarriers1;

		private List<MachineInformation.MeasureInfo> measureInfos;

		private MiniLiquidCarrier TankA0 => null;

		private MiniLiquidCarrier TankB0 => null;

		private MiniLiquidCarrier TankA1 => null;

		private MiniLiquidCarrier TankB1 => null;

		public override List<MachineInformation.MeasureInfo> GetMeasureInfos => null;

		public InversionPipe(Structure[] structures)
			: base(null)
		{
		}

		private void _UpdateCircuitData()
		{
		}

		public override void UpdateCircuitData(bool updateAttachment = false)
		{
		}

		public override string ToString()
		{
			return null;
		}

		public override void Update(double deltaTime)
		{
		}

		public override string ToDump()
		{
			return null;
		}
	}
}
