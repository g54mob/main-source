using Newtonsoft.Json.Linq;
using ScriptHelpers;
using UnityEngine;

namespace SimulationScripts.BibiteScripts
{
	public struct StomachContent : ISaveable
	{
		public MatterMaterial material;

		public float amount;

		public float digestionRate;

		public float lastConversionEfficiency;

		public float averageChunkAmount;

		public float efficiency;

		public float mass => amount * material.MassDensity;

		public float approximateN
		{
			get
			{
				if (!(averageChunkAmount > 0f))
				{
					return 1f;
				}
				return Mathf.Max(1f, amount / averageChunkAmount);
			}
		}

		public float energyGainRate => digestionRate * material.EnergyDensity * lastConversionEfficiency;

		public float affinity
		{
			set
			{
				efficiency = material.ConversionEfficiency(value);
			}
		}

		public void Reset()
		{
		}

		public JObject SaveState()
		{
			return new JObject
			{
				["material"] = material.Name,
				["amount"] = amount,
				["averageChunkAmount"] = averageChunkAmount
			};
		}

		public void LoadState(JObject state)
		{
			material = MatterMaterialManager.FindMaterial(state["material"].ToString());
			amount = state["amount"]?.ToObject<float>() ?? 0.0001f;
			averageChunkAmount = Mathf.Max(0f, state["averageChunkAmount"]?.ToObject<float>() ?? amount);
		}
	}
}
