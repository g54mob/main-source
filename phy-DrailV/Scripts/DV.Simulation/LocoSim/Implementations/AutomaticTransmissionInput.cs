using LocoSim.Definitions;
using UnityEngine;

namespace LocoSim.Implementations
{
	public class AutomaticTransmissionInput : SimComponent
	{
		private const float GEAR_CHANGE_BLOCK_DURATION = 1f;

		public readonly float gearUpRpmThreshold = 800f;

		public readonly float gearDownRpmThreshold = 120f;

		public readonly PortReference rpmIndicatorReader;

		public readonly PortReference numOfGearsReader;

		public readonly Port gearReadOut;

		private int currentGear;

		private float gearChangeBlockedTimer;

		public AutomaticTransmissionInput(AutomaticTransmissionInputDefinition atiDef)
			: base(atiDef.ID)
		{
			gearUpRpmThreshold = atiDef.gearUpRpmThreshold;
			gearDownRpmThreshold = atiDef.gearDownRpmThreshold;
			currentGear = 0;
			rpmIndicatorReader = AddPortReference(atiDef.rpmIndicatorReader);
			numOfGearsReader = AddPortReference(atiDef.numOfGearsReader);
			gearReadOut = AddPort(atiDef.gearReadOut);
		}

		public override void Tick(float delta)
		{
			if (gearChangeBlockedTimer > 0f)
			{
				gearChangeBlockedTimer -= delta;
				return;
			}
			float num = Mathf.Abs(rpmIndicatorReader.Value);
			int num2 = -1;
			if ((float)currentGear < numOfGearsReader.Value - 1f && num > gearUpRpmThreshold)
			{
				num2 = currentGear + 1;
			}
			else if (currentGear > 0 && num < gearDownRpmThreshold)
			{
				num2 = currentGear - 1;
			}
			if (num2 >= 0 && currentGear != num2)
			{
				currentGear = num2;
				gearReadOut.Value = currentGear;
				gearChangeBlockedTimer = 1f;
			}
		}
	}
}
