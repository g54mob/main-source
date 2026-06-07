using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace SimulationScripts
{
	[CreateAssetMenu(fileName = "MatterMaterial", menuName = "ScriptableObjects/MatterMaterial", order = 1)]
	public class MatterMaterial : ScriptableObject
	{
		public string Name;

		[FormerlySerializedAs("Hardness")]
		public float Cohesiveness;

		public float MassDensity;

		public float EnergyDensity;

		[FormerlySerializedAs("DigestionRate")]
		public float Reactivity;

		public float MinConversionEfficiency;

		public float MaxConversionEfficiency;

		public bool decay;

		[FormerlySerializedAs("perishableFactor")]
		public float freshTime;

		public float decayRate;

		public Sprite defaultSprite;

		public const float NormalAmountAtScale1 = 20f;

		public const float NormalRadiusAtScale1 = 2.5f;

		public float NormalEnergyAtScale1 => EnergyDensity * 20f;

		public float ConversionEfficiency(float affinity)
		{
			return MinConversionEfficiency + Mathf.Clamp01(affinity) * (MaxConversionEfficiency - MinConversionEfficiency);
		}

		public float EnergyOfAmount(float amount)
		{
			return amount * EnergyDensity;
		}

		public float AmountOfEnergy(float energy)
		{
			return energy / EnergyDensity;
		}

		public float RadiusOfAmount(float amount)
		{
			return Mathf.Sqrt(amount / MathF.PI);
		}

		public float AmountOfRadius(float radius)
		{
			return MathF.PI * radius * radius;
		}
	}
}
