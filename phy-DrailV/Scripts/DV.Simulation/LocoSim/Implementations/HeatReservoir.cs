using System.Linq;
using DV.JObjectExtstensions;
using LocoSim.Definitions;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace LocoSim.Implementations
{
	public class HeatReservoir : SimComponent
	{
		private const string TEMPERATURE_SAVE_KEY = "temp";

		public readonly float heatCapacity;

		public readonly float overheatingTemperatureThreshold;

		public readonly float maxTemperature;

		public readonly Port temperature;

		public readonly PortReference[] inputs;

		public override bool HasSaveData => true;

		public HeatReservoir(HeatReservoirDefinition hrDef)
			: base(hrDef.ID)
		{
			heatCapacity = hrDef.heatCapacity;
			overheatingTemperatureThreshold = hrDef.overheatingTemperatureThreshold;
			maxTemperature = hrDef.maxTemperature;
			temperature = AddPort(hrDef.temperature, 25f);
			inputs = hrDef.inputs.Select((PortReferenceDefinition prDef) => AddPortReference(prDef)).ToArray();
		}

		public override void Tick(float delta)
		{
			float num = 0f;
			for (int i = 0; i < inputs.Length; i++)
			{
				num += inputs[i].Value;
			}
			float a = temperature.Value + num * delta / heatCapacity;
			a = Mathf.Min(a, gameParams.OverheatingAllowed ? maxTemperature : overheatingTemperatureThreshold);
			temperature.Value = a;
		}

		public override JObject GetSaveStateData()
		{
			JObject jObject = new JObject();
			jObject.SetFloat("temp", temperature.Value);
			return jObject;
		}

		public override void SetSaveStateData(JObject savedData)
		{
			float? num = savedData.GetFloat("temp");
			if (num.HasValue)
			{
				temperature.Value = num.Value;
			}
			else
			{
				Debug.LogError("Unexpected state: Missing data for " + id + ".TEMPERATURE_SAVE_KEY. Loading ignored for this parameter.");
			}
		}
	}
}
