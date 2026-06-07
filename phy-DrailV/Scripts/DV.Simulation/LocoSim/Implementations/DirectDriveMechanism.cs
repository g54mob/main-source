using System;
using LocoSim.Definitions;

namespace LocoSim.Implementations
{
	public class DirectDriveMechanism : SimComponent
	{
		public readonly PortReference throttleReader;

		public readonly PortReference throttlingInOppositeMovementDirectionReader;

		public readonly PortReference reverserReader;

		public readonly PortReference engineRpmReader;

		public readonly PortReference engineInNeutralReader;

		public readonly Port powerIn;

		public readonly Port engineBrakingTorqueIn;

		public readonly Port engineBrakingActiveReadOut;

		public readonly Port torqueOut;

		public DirectDriveMechanism(DirectDriveMechanismDefinition ddmDef)
			: base(ddmDef.ID)
		{
			throttleReader = AddPortReference(ddmDef.throttleReader);
			throttlingInOppositeMovementDirectionReader = AddPortReference(ddmDef.throttlingInOppositeMovementDirectionReader);
			reverserReader = AddPortReference(ddmDef.reverserReader);
			engineRpmReader = AddPortReference(ddmDef.engineRpmReader);
			engineInNeutralReader = AddPortReference(ddmDef.engineInNeutralReader);
			powerIn = AddPort(ddmDef.powerIn);
			engineBrakingTorqueIn = AddPort(ddmDef.engineBrakingTorqueIn);
			engineBrakingActiveReadOut = AddPort(ddmDef.engineBrakingActiveReadOut);
			torqueOut = AddPort(ddmDef.torqueOut);
		}

		public override void Tick(float delta)
		{
			float num = 0f;
			float value = powerIn.Value;
			float value2 = engineBrakingTorqueIn.Value;
			float value3 = throttleReader.Value;
			float value4 = reverserReader.Value;
			if (engineInNeutralReader.Value != 1f && (value > 0f || value2 > 0f))
			{
				if (value > 0f && value3 > 0f)
				{
					float num2 = (float)Math.PI * 2f * engineRpmReader.Value / 60f;
					num = value / num2;
				}
				num -= value2;
			}
			bool flag = num < 0f;
			engineBrakingActiveReadOut.Value = (flag ? 1f : 0f);
			if (flag && throttlingInOppositeMovementDirectionReader.Value == 1f)
			{
				num = 0f - num;
			}
			torqueOut.Value = num * value4;
		}
	}
}
