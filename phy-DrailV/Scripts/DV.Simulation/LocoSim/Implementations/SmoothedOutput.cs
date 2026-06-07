using LocoSim.Definitions;
using UnityEngine;

namespace LocoSim.Implementations
{
	public class SmoothedOutput : SimComponent
	{
		public readonly float smoothTime;

		public readonly FuseReference powerFuseRef;

		public readonly PortReference control;

		public readonly Port outReadOut;

		private float smoothTimeVelocity;

		public SmoothedOutput(SmoothedOutputDefinition soDef)
			: base(soDef.ID)
		{
			smoothTime = soDef.smoothTime;
			if (!string.IsNullOrEmpty(soDef.powerFuseId))
			{
				powerFuseRef = AddFuseReference(soDef.powerFuseId);
			}
			control = AddPortReference(soDef.control);
			outReadOut = AddPort(soDef.outReadOut);
		}

		public override void Tick(float delta)
		{
			float value = control.Value;
			float value2 = outReadOut.Value;
			float num = ((powerFuseRef == null) ? value : powerFuseRef.ProcessInput(value));
			if (smoothTime > 0f)
			{
				if (num == 0f && value2 < 0.001f)
				{
					value2 = 0f;
					smoothTimeVelocity = 0f;
				}
				else
				{
					value2 = Mathf.SmoothDamp(value2, num, ref smoothTimeVelocity, smoothTime, float.PositiveInfinity, delta);
				}
			}
			else
			{
				value2 = num;
			}
			outReadOut.Value = value2;
		}
	}
}
