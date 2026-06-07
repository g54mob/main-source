using LocoSim.Definitions;
using UnityEngine;

namespace LocoSim.Implementations
{
	public class Horn : SimComponent
	{
		public readonly bool controlNeutralAt0;

		public readonly FuseReference powerFuseRef;

		public readonly PortReference hornControlReader;

		public readonly Port hornReadOut;

		public Horn(HornDefinition hDef)
			: base(hDef.ID)
		{
			controlNeutralAt0 = hDef.controlNeutralAt0;
			powerFuseRef = AddFuseReference(hDef.powerFuseId);
			hornControlReader = AddPortReference(hDef.hornControlReader);
			hornReadOut = AddPort(hDef.hornReadOut);
		}

		public override void Tick(float delta)
		{
			float num = hornControlReader.Value;
			if (!controlNeutralAt0)
			{
				num = Mathf.Abs(num * 2f - 1f);
			}
			hornReadOut.Value = powerFuseRef.ProcessInput(num);
		}
	}
}
