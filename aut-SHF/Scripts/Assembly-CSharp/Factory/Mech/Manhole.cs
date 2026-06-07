using System.Collections.Generic;
using Factory.FieldData;

namespace Factory.Mech
{
	public class Manhole : MechBase
	{
		private List<PipeLinkPairInMechBase> pipeLinkPair;

		private List<ILiquidCarrier> liquidCarriers;

		public Manhole(Structure[] structures)
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
	}
}
