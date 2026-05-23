using System.Collections.Generic;
using Factory.FieldData;
using Libs;

namespace Factory.Mech
{
	public class BridgePipe : MechBase
	{
		private List<PipeLinkPairInMechBase> pipeLinkPair;

		private List<ILiquidCarrier> liquidCarriers;

		public BridgePipe(Structure[] structures)
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

		public static Vector2IntBundle? GetVector2IntBundleFromSerializableStructures(List<SerializableStructure> sames, Dir.Rot rot)
		{
			return null;
		}

		public override string ToDump()
		{
			return null;
		}
	}
}
