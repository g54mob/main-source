using System;
using Newtonsoft.Json.Linq;
using ScriptHelpers;
using UnityEngine;

namespace SimulationScripts
{
	public class Matter : ISaveable
	{
		public MatterMaterial Material;

		public float Amount;

		public float MaxAmount = float.PositiveInfinity;

		public float fullness => Mathf.Max(Amount / MaxAmount, 0f);

		public bool isEmpty => Mathf.Approximately(Amount, 0f);

		public bool isFull => Mathf.Approximately(available, 0f);

		public float overflow => Mathf.Max(Amount - MaxAmount, 0f);

		public float available => Mathf.Max(MaxAmount - Amount, 0f);

		public float radius => Mathf.Sqrt(Amount / MathF.PI);

		public float cohesiveness => Material.Cohesiveness;

		public float EnergyDensity => Material.EnergyDensity;

		public float mass => Amount * Material.MassDensity;

		public float energy
		{
			get
			{
				return Amount * Material.EnergyDensity;
			}
			set
			{
				_ = Amount;
				Amount = value / Material.EnergyDensity;
			}
		}

		public float ConvertToMaterial(MatterMaterial to, bool withLosses = false, float affinityFrom = 1f, float affinityTo = 1f)
		{
			return energy / to.EnergyDensity * (withLosses ? (Material.ConversionEfficiency(affinityFrom) * to.ConversionEfficiency(affinityTo)) : 1f);
		}

		public float ConvertToFromEnergy(float amount, float affinity)
		{
			amount = ((amount > 0f) ? Mathf.Min(amount, MaxAmount - Amount) : Mathf.Max(amount, 0f - Amount));
			Amount += amount;
			return (0f - amount) * Material.EnergyDensity * ((amount > 0f) ? (1f / Material.ConversionEfficiency(affinity)) : Material.ConversionEfficiency(affinity));
		}

		public virtual JObject SaveState()
		{
			return new JObject
			{
				["material"] = Material.Name,
				["amount"] = Amount
			};
		}

		public virtual void LoadState(JObject state)
		{
			Material = MatterMaterialManager.FindMaterial(state["material"].ToString());
			Amount = state["amount"].ToObject<float>();
		}
	}
}
