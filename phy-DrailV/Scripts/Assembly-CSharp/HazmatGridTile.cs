using System;
using System.Collections.Generic;
using System.IO;
using DV.Hazmat;
using DV.ThingTypes;
using DV.Utils;
using UnityEngine;

public class HazmatGridTile
{
	public int gridPosition;

	public bool fullyInitialized;

	public float flowHeight;

	public float terrainHeight;

	public Vector3 terrainNormal;

	public Vector2Int terrainGridPosition;

	public Dictionary<CargoType, float> liquidContent = new Dictionary<CargoType, float>();

	public float currentWeight;

	public float previousWeight;

	public float burnTime;

	public HashSet<HazmatGridTile> neighbouringLiquidSources = new HashSet<HazmatGridTile>();

	public HazmatTerrainEffectsController terrainFireEffects;

	public HazmatTerrainEffectsController terrainCorrosiveEffects;

	public HazmatTerrainEffectsController terrainBiohazardEffects;

	public float reactionModifier;

	private bool igniteSignal;

	private float nextIgnitionTime;

	private const float BURN_SPEED = 25f;

	private const float CORROSION_EVAPORATION_SPEED = 25f;

	private const float BIOHAZARD_EVAPORATION_SPEED = 10f;

	private const float RADIATION_EVAPORATION_SPEED = 1f;

	private const float IGNITION_CHANCE_MODIFIER = 33f;

	private const float IGNITION_DELAY_MIN = 2f;

	private const float IGNITION_DELAY_MAX = 3f;

	private const float WETNESS_INHIBITING_SPEED = 0.01f;

	private const float WETNESS_DRYING_SPEED = 0.01f;

	private const float CHEMICAL_CLEARING_SPEED = 0.1f;

	private List<CargoType> flammables = new List<CargoType>();

	private List<CargoType> corrosives = new List<CargoType>();

	private float currentReactionValue;

	private float wetnessInhibition;

	private float externalReactivityModifier;

	private float currentRadiationValue;

	private float minIgnitionValue = float.PositiveInfinity;

	private float maxIgnitionValue = float.PositiveInfinity;

	public static readonly CargoType[] CARGO_TYPES = (CargoType[])Enum.GetValues(typeof(CargoType));

	private const byte IGNITED_FLAG = 1;

	private const byte CORRODED_FLAG = 2;

	private const byte DEFILED_FLAG = 4;

	private const byte RADIATED_FLAG = 8;

	public float ReactionValue => currentReactionValue + ReactivityModifier;

	public bool IsIgnited { get; private set; }

	public bool IsCorroded { get; private set; }

	public bool IsDefiled { get; private set; }

	public bool IsRadiated { get; private set; }

	private float ReactivityModifier => 0f - wetnessInhibition + externalReactivityModifier;

	public HazmatGridTile(int gridPosition, float flowHeight, float terrainHeight, Vector3 terrainNormal, Vector2Int terrainGridPosition)
	{
		this.gridPosition = gridPosition;
		this.terrainNormal = terrainNormal;
		this.flowHeight = flowHeight;
		this.terrainHeight = terrainHeight;
		this.terrainGridPosition = terrainGridPosition;
		fullyInitialized = true;
	}

	public void SerializeData(BinaryWriter bw)
	{
		foreach (KeyValuePair<CargoType, float> item in liquidContent)
		{
			if (item.Value > 0f)
			{
				bw.Write((byte)item.Key);
				bw.Write(item.Value);
			}
		}
		bw.Write(byte.MaxValue);
		byte b = 0;
		if (IsIgnited)
		{
			b |= 1;
		}
		if (IsCorroded)
		{
			b |= 2;
		}
		if (IsDefiled)
		{
			b |= 4;
		}
		if (IsRadiated)
		{
			b |= 8;
		}
		bw.Write(b);
		bw.Write(reactionModifier);
		bw.Write((byte)(wetnessInhibition * 255f));
		bw.Write(burnTime);
		bw.Write(currentRadiationValue);
	}

	public void DeserializeData(BinaryReader br, int version)
	{
		if (version < 2)
		{
			return;
		}
		while (true)
		{
			byte b = br.ReadByte();
			if (b == byte.MaxValue)
			{
				break;
			}
			float value = br.ReadSingle();
			liquidContent.Add((CargoType)b, value);
		}
		byte b2 = br.ReadByte();
		IsIgnited = (b2 & 1) != 0;
		IsCorroded = (b2 & 2) != 0;
		IsDefiled = (b2 & 4) != 0;
		IsRadiated = (b2 & 8) != 0;
		reactionModifier = br.ReadSingle();
		wetnessInhibition = (float)(int)br.ReadByte() / 255f;
		burnTime = br.ReadSingle();
		currentRadiationValue = br.ReadSingle();
		UpdateCurrentWeight();
	}

	public void AddLiquidAmount(CargoType cargoType, float amountToAdd)
	{
		if (liquidContent.ContainsKey(cargoType))
		{
			liquidContent[cargoType] += amountToAdd;
		}
		else
		{
			liquidContent[cargoType] = amountToAdd;
		}
		if (liquidContent[cargoType] < 0f)
		{
			Debug.Log($"Liquid of type '{cargoType}' is no longer present on tile with coordinates '{gridPosition}'. Removing it from the tile.");
			RemoveLiquidFromTile(cargoType);
		}
	}

	public void AddRadiation(float amountToAdd)
	{
		currentRadiationValue = Mathf.Max(currentRadiationValue, amountToAdd);
	}

	public void RemoveLiquidFromTile(CargoType cargoType)
	{
		if (liquidContent.TryGetValue(cargoType, out var value))
		{
			currentWeight -= value;
			currentWeight = Mathf.Max(value, 0f);
			liquidContent.Remove(cargoType);
			if (flammables.Contains(cargoType))
			{
				flammables.Remove(cargoType);
			}
			if (corrosives.Contains(cargoType))
			{
				corrosives.Remove(cargoType);
			}
		}
	}

	public void UpdateCurrentWeight()
	{
		currentWeight = 0f;
		foreach (KeyValuePair<CargoType, float> item in liquidContent)
		{
			currentWeight += item.Value;
		}
	}

	private float GetTotalFluidWeight()
	{
		float num = 0f;
		foreach (KeyValuePair<CargoType, float> item in liquidContent)
		{
			num += item.Value;
		}
		return num;
	}

	public void ProcessIgnition()
	{
		if (IsIgnited && burnTime > nextIgnitionTime)
		{
			nextIgnitionTime = burnTime + UnityEngine.Random.Range(2f, 3f);
			float num = 8f * Mathf.Sqrt(2f) * 0.5f;
			Igniter.Ignite(SingletonBehaviour<HazmatTileManager>.Instance.GetWorldPositionFromGridTileWithHeight(this) + Vector3.up * num, 1f, num, null, 0f);
		}
	}

	public void ProcessReaction(float elapsedTime, float wetness)
	{
		if (liquidContent.Count <= 0)
		{
			IsIgnited = false;
			reactionModifier = 0f;
			currentReactionValue = 0f;
			return;
		}
		if (igniteSignal)
		{
			igniteSignal = false;
			IsIgnited = true;
			nextIgnitionTime = UnityEngine.Random.Range(2f, 3f);
		}
		bool flag = ContainsCorosive();
		bool flag2 = ContainsBioHazard();
		if (flag)
		{
			if (!IsCorroded)
			{
				IsCorroded = true;
			}
			for (int num = corrosives.Count - 1; num >= 0; num--)
			{
				if (liquidContent.ContainsKey(corrosives[num]))
				{
					liquidContent[corrosives[num]] -= 25f * elapsedTime;
					if (liquidContent[corrosives[num]] <= float.Epsilon)
					{
						RemoveLiquidFromTile(corrosives[num]);
					}
				}
				else
				{
					corrosives.Remove(corrosives[num]);
				}
			}
		}
		else
		{
			IsCorroded = false;
		}
		if (flag2)
		{
			if (!IsDefiled)
			{
				IsDefiled = true;
			}
			liquidContent[CargoType.Biohazard] -= 10f * elapsedTime;
			if (liquidContent[CargoType.Biohazard] <= float.Epsilon)
			{
				RemoveLiquidFromTile(CargoType.Biohazard);
			}
		}
		else
		{
			IsDefiled = false;
		}
		if (IsIgnited)
		{
			for (int num2 = flammables.Count - 1; num2 >= 0; num2--)
			{
				if (liquidContent.ContainsKey(flammables[num2]))
				{
					liquidContent[flammables[num2]] -= 25f * elapsedTime;
					if (liquidContent[flammables[num2]] <= float.Epsilon)
					{
						liquidContent.Remove(flammables[num2]);
					}
				}
				else
				{
					flammables.Remove(flammables[num2]);
				}
			}
			burnTime += elapsedTime;
		}
		else if (burnTime > float.Epsilon)
		{
			burnTime = 0f;
		}
		if (IsIgnited || flag || flag2)
		{
			UpdateCurrentWeight();
		}
		if (!IsIgnited && ReactionValue > minIgnitionValue)
		{
			float num3 = Mathf.InverseLerp(minIgnitionValue, maxIgnitionValue, ReactionValue) * 33f;
			int num4 = UnityEngine.Random.Range(0, 100);
			if (num3 > (float)num4)
			{
				nextIgnitionTime = UnityEngine.Random.Range(2f, 3f);
				IsIgnited = true;
			}
		}
		else if (IsIgnited && ReactionValue <= 0f)
		{
			IsIgnited = false;
			reactionModifier = 0f;
			currentReactionValue = 0f;
		}
		if (IsIgnited)
		{
			wetnessInhibition = Mathf.Clamp01(wetnessInhibition + elapsedTime * wetness * 0.01f);
		}
		else
		{
			wetnessInhibition = Mathf.Clamp01(wetnessInhibition - elapsedTime * Mathf.Clamp01(1f - wetness) * 0.01f);
		}
		if (externalReactivityModifier > 0f)
		{
			externalReactivityModifier = Mathf.Clamp(externalReactivityModifier - elapsedTime * 0.1f, -1f, 1f);
		}
		else if (externalReactivityModifier < 0f)
		{
			externalReactivityModifier = Mathf.Clamp(externalReactivityModifier + elapsedTime * 0.1f, -1f, 1f);
		}
	}

	public void AddExternalReactivityModifier(float amount)
	{
		externalReactivityModifier = Mathf.Clamp(externalReactivityModifier + amount, -1f, 1f);
	}

	public void ProcessRadiation(float elapsedTime)
	{
		if (ContainsRadiation())
		{
			if (!IsRadiated)
			{
				IsRadiated = true;
			}
			currentRadiationValue -= 1f * elapsedTime;
		}
		else
		{
			IsRadiated = false;
		}
	}

	public bool Ignite(float ignitionStrength)
	{
		if (!igniteSignal && !IsIgnited && ignitionStrength > minIgnitionValue - ReactivityModifier)
		{
			igniteSignal = true;
			return true;
		}
		return false;
	}

	public void ReCalculateReactionValues()
	{
		flammables.Clear();
		corrosives.Clear();
		currentReactionValue = 0f;
		if (!(currentWeight > float.Epsilon) || liquidContent.Count <= 0)
		{
			return;
		}
		float num = currentWeight;
		_ = liquidContent.Count;
		foreach (KeyValuePair<CargoType, float> item in liquidContent)
		{
			CargoType key = item.Key;
			float value = item.Value;
			CargoReactionProperties value2;
			float num2 = ((!TrainCarAndCargoDamageProperties.CargoReactionProperties.TryGetValue(key, out value2)) ? TrainCarAndCargoDamageProperties.StandardReactionProperties.reactivity : value2.reactivity);
			currentReactionValue += num2 * Mathf.Clamp01(value / currentWeight);
			if (!TrainCarAndCargoDamageProperties.IsCargoFlammableLiquid(key))
			{
				num -= value;
			}
			else
			{
				flammables.Add(key);
			}
			if (TrainCarAndCargoDamageProperties.IsCargoCorrosiveLiquid(key))
			{
				corrosives.Add(key);
			}
		}
		if (flammables.Count <= 0)
		{
			minIgnitionValue = float.PositiveInfinity;
			maxIgnitionValue = float.PositiveInfinity;
			return;
		}
		minIgnitionValue = 0f;
		maxIgnitionValue = 0f;
		currentReactionValue += reactionModifier;
		reactionModifier = 0f;
		foreach (CargoType flammable in flammables)
		{
			minIgnitionValue += TrainCarAndCargoDamageProperties.CargoReactionProperties[flammable].ignitionReactivityMin * liquidContent[flammable] / num;
			maxIgnitionValue += TrainCarAndCargoDamageProperties.CargoReactionProperties[flammable].ignitionReactivityMax * liquidContent[flammable] / num;
		}
	}

	public bool ContainsCorosive()
	{
		return corrosives.Count > 0;
	}

	public bool ContainsBioHazard()
	{
		return liquidContent.ContainsKey(CargoType.Biohazard);
	}

	public bool ContainsRadiation()
	{
		return currentRadiationValue > 0f;
	}

	public float GetRadiation()
	{
		return currentRadiationValue;
	}

	public void UpdateEffectsPositionAndRotation((Vector3 position, Quaternion rotation) transformValues)
	{
		if (terrainFireEffects != null)
		{
			terrainFireEffects.transform.SetPositionAndRotation(transformValues.position, transformValues.rotation);
		}
		if (terrainCorrosiveEffects != null)
		{
			terrainCorrosiveEffects.transform.SetPositionAndRotation(transformValues.position, transformValues.rotation);
		}
		if (terrainBiohazardEffects != null)
		{
			terrainBiohazardEffects.transform.SetPositionAndRotation(transformValues.position, transformValues.rotation);
		}
	}
}
