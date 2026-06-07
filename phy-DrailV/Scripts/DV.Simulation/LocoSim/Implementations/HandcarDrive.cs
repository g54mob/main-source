using LocoSim.Definitions;
using UnityEngine;

namespace LocoSim.Implementations
{
	public class HandcarDrive : SimComponent
	{
		private const float ACTING_AGAINST_MULTIPLIER = 1.5f;

		public readonly float maxTorqueProduction;

		public AnimationCurve positionDiffToTorque;

		public readonly Port handcarBarExtIn;

		public readonly Port handleEngagedExtIn;

		public readonly Port torqueOut;

		public readonly Port currentPositionOut;

		public readonly Port engagedHandlePositionOut;

		public readonly Port directionOut;

		public readonly Port actingAgainstOut;

		public readonly PortReference wheelRpm;

		public readonly PortReference gearRatio;

		private int direction = 1;

		private float currentPosition;

		private float engagedHandlePosition;

		public HandcarDrive(HandcarDriveDefinition hdd)
			: base(hdd.ID)
		{
			maxTorqueProduction = hdd.maxTorqueProduction;
			positionDiffToTorque = hdd.positionDiffToTorque;
			handcarBarExtIn = AddPort(hdd.handcarBarExtIn);
			handleEngagedExtIn = AddPort(hdd.handleEngagedExtIn);
			torqueOut = AddPort(hdd.torqueOut);
			currentPositionOut = AddPort(hdd.currentPositionOut);
			engagedHandlePositionOut = AddPort(hdd.engagedHandlePositionOut);
			directionOut = AddPort(hdd.directionOut);
			actingAgainstOut = AddPort(hdd.actingAgainstOut);
			wheelRpm = AddPortReference(hdd.wheelRpm);
			gearRatio = AddPortReference(hdd.gearRatio);
		}

		public void SetHandlebarPosition(float position)
		{
			position = Mathf.Clamp(position, -1f, 1f);
			handcarBarExtIn.Value = position * 0.5f + 0.5f;
			currentPosition = position;
		}

		public override void Tick(float delta)
		{
			float num = wheelRpm.Value / 60f * gearRatio.Value;
			currentPosition += num * (float)direction * delta;
			if (currentPosition >= 1f || currentPosition <= -1f)
			{
				direction *= -1;
			}
			directionOut.Value = direction;
			currentPosition = Mathf.Clamp(currentPosition, -1f, 1f);
			currentPositionOut.Value = currentPosition;
			if (handleEngagedExtIn.Value > 0f)
			{
				engagedHandlePosition = handcarBarExtIn.Value * 2f - 1f;
				float f = (engagedHandlePosition - currentPosition) / 2f;
				float num2 = positionDiffToTorque.Evaluate(Mathf.Abs(f)) * maxTorqueProduction * Mathf.Sign(f) * (float)direction;
				bool flag = Mathf.Sign(num2) != Mathf.Sign(num);
				if (flag)
				{
					num2 *= 1.5f;
				}
				torqueOut.Value = num2;
				actingAgainstOut.Value = (flag ? 1f : 0f);
			}
			else
			{
				torqueOut.Value = 0f;
				actingAgainstOut.Value = 0f;
			}
			engagedHandlePositionOut.Value = engagedHandlePosition;
		}
	}
}
