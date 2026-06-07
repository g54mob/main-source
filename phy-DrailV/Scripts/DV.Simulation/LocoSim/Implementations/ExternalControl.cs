using DV.JObjectExtstensions;
using LocoSim.Definitions;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace LocoSim.Implementations
{
	public class ExternalControl : SimComponent
	{
		private const string CONTROL_VALUE_SAVE_KEY = "val";

		public readonly Port controlExtIn;

		public readonly bool saveState;

		public override bool HasSaveData => saveState;

		public ExternalControl(ExternalControlDefinition ecDef)
			: base(ecDef.ID)
		{
			controlExtIn = AddPort(ecDef.controlExtIn, ecDef.defaultValue);
			saveState = ecDef.saveState;
		}

		public override void Tick(float delta)
		{
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
				controlExtIn.Value = num.Value;
			}
			else
			{
				Debug.LogError("Unexpected state: Missing data for " + id + ".CONTROL_VALUE_SAVE_KEY. Loading ignored for this parameter.");
			}
		}
	}
}
