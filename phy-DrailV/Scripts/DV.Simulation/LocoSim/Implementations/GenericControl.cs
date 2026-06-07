using DV.JObjectExtstensions;
using LocoSim.Definitions;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace LocoSim.Implementations
{
	public class GenericControl : SimComponent
	{
		private const string CONTROL_VALUE_SAVE_KEY = "val";

		public readonly float smoothTime;

		public readonly bool saveState;

		public readonly Port controlExtIn;

		public readonly Port controlReadOut;

		private float smoothedControl;

		private float smoothedControlVelocity;

		public override bool HasSaveData => saveState;

		public GenericControl(GenericControlDefinition gcDef)
			: base(gcDef.ID)
		{
			controlExtIn = AddPort(gcDef.controlExtIn, gcDef.defaultValue);
			smoothedControl = gcDef.defaultValue;
			controlReadOut = AddPort(gcDef.controlReadOut);
			smoothTime = gcDef.smoothTime;
			saveState = gcDef.saveState;
		}

		public override void Tick(float delta)
		{
			if (smoothTime > 0f)
			{
				smoothedControl = Mathf.SmoothDamp(smoothedControl, Mathf.Clamp01(controlExtIn.Value), ref smoothedControlVelocity, smoothTime, float.PositiveInfinity, delta);
				if (controlExtIn.Value == 0f && (double)smoothedControl < 0.001)
				{
					smoothedControl = 0f;
				}
			}
			else
			{
				smoothedControl = Mathf.Clamp01(controlExtIn.Value);
			}
			controlReadOut.Value = smoothedControl;
		}

		public override JObject GetSaveStateData()
		{
			JObject jObject = new JObject();
			jObject.SetFloat("val", controlExtIn.Value);
			return jObject;
		}

		public override void SetSaveStateData(JObject savedData)
		{
			float? num = savedData.GetFloat("val");
			if (num.HasValue)
			{
				Port port = controlExtIn;
				float value = (controlReadOut.Value = (smoothedControl = num.Value));
				port.Value = value;
			}
			else
			{
				Debug.LogError("Unexpected state: Missing data for " + id + ".CONTROL_VALUE_SAVE_KEY. Loading ignored for this parameter.");
			}
		}
	}
}
