using LocoSim.Definitions;
using UnityEngine;

namespace LocoSim.Implementations
{
	public class ElectricBell : SimComponent
	{
		public readonly float smoothDownTime;

		public readonly FuseReference powerFuse;

		public readonly PortReference bellControl;

		public readonly Port bellNormalizedReadOut;

		private float bellSmoothVelocity;

		public ElectricBell(ElectricBellDefinition ebDef)
			: base(ebDef.ID)
		{
			smoothDownTime = ebDef.smoothDownTime;
			if (!string.IsNullOrEmpty(ebDef.powerFuseId))
			{
				powerFuse = AddFuseReference(ebDef.powerFuseId);
			}
			bellControl = AddPortReference(ebDef.bellControl);
			bellNormalizedReadOut = AddPort(ebDef.bellNormalizedReadOut);
		}

		public override void Tick(float delta)
		{
			float value = bellNormalizedReadOut.Value;
			if ((powerFuse == null || powerFuse.State) && bellControl.Value > 0f)
			{
				value = 1f;
				bellSmoothVelocity = 0f;
			}
			else if (value > 0f && value < 0.001f)
			{
				value = 0f;
				bellSmoothVelocity = 0f;
			}
			else
			{
				value = Mathf.SmoothDamp(value, 0f, ref bellSmoothVelocity, smoothDownTime, float.PositiveInfinity, delta);
			}
			bellNormalizedReadOut.Value = value;
		}
	}
}
