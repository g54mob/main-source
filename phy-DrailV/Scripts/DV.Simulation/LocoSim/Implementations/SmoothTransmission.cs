using LocoSim.Definitions;
using UnityEngine;

namespace LocoSim.Implementations
{
	public class SmoothTransmission : SimComponent
	{
		public readonly float transitionTime;

		public readonly float[] gearRatios;

		public readonly float transmissionEfficiency;

		public AnimationCurve gearChangeEaseCurve;

		public float powerShiftRpmThreshold;

		public float powerShiftDamage;

		public readonly PortReference gearReader;

		public readonly PortReference throttleReader;

		public readonly PortReference retarderReader;

		public readonly PortReference engineRpmReader;

		public readonly Port torqueIn;

		public readonly Port torqueOut;

		public readonly Port numOfGearsReadOut;

		public readonly Port gearRatioReadOut;

		public readonly Port gearChangeInProgressReadOut;

		public readonly Port generatedDamageReadOut;

		private int numOfGears;

		private float currentGearRatio;

		private int currentGear;

		private float transitionTimer;

		private float prevGearRatio;

		public SmoothTransmission(SmoothTransmissionDefinition stDef)
			: base(stDef.ID)
		{
			transitionTime = stDef.transitionTime;
			gearRatios = stDef.gearRatios;
			numOfGears = gearRatios.Length;
			transmissionEfficiency = stDef.transmissionEfficiency;
			gearChangeEaseCurve = stDef.gearChangeEaseCurve;
			powerShiftRpmThreshold = stDef.powerShiftRpmThreshold;
			powerShiftDamage = stDef.powerShiftDamage;
			gearReader = AddPortReference(stDef.gearReader);
			throttleReader = AddPortReference(stDef.throttleReader);
			retarderReader = AddPortReference(stDef.retarderReader);
			engineRpmReader = AddPortReference(stDef.engineRpmReader);
			torqueIn = AddPort(stDef.torqueIn);
			torqueOut = AddPort(stDef.torqueOut);
			numOfGearsReadOut = AddPort(stDef.numOfGearsReadOut, numOfGears);
			gearRatioReadOut = AddPort(stDef.gearRatioReadOut);
			gearChangeInProgressReadOut = AddPort(stDef.gearChangeInProgressReadOut);
			generatedDamageReadOut = AddPort(stDef.generatedDamageReadOut);
			currentGear = 0;
			currentGearRatio = gearRatios[currentGear];
		}

		public override void Tick(float delta)
		{
			int num = Mathf.Clamp(Mathf.RoundToInt(gearReader.Value), 0, numOfGears - 1);
			generatedDamageReadOut.Value = 0f;
			if (currentGear != num)
			{
				currentGear = num;
				if (transitionTime > 0f)
				{
					prevGearRatio = currentGearRatio;
					transitionTimer = transitionTime;
					gearChangeInProgressReadOut.Value = 1f;
				}
				else
				{
					currentGearRatio = gearRatios[currentGear];
				}
				if (engineRpmReader.Value > powerShiftRpmThreshold && (throttleReader.Value > 0f || retarderReader.Value > 0f))
				{
					generatedDamageReadOut.Value = powerShiftDamage;
				}
			}
			if (transitionTimer > 0f)
			{
				transitionTimer = Mathf.Clamp(transitionTimer - delta, 0f, float.PositiveInfinity);
				float num2 = 1f - transitionTimer / transitionTime;
				float b = gearRatios[currentGear];
				float t = gearChangeEaseCurve.Evaluate(num2);
				currentGearRatio = Mathf.Lerp(prevGearRatio, b, t);
				if (num2 == 1f)
				{
					gearChangeInProgressReadOut.Value = 0f;
				}
			}
			torqueOut.Value = torqueIn.Value * currentGearRatio * transmissionEfficiency;
			gearRatioReadOut.Value = currentGearRatio;
		}
	}
}
