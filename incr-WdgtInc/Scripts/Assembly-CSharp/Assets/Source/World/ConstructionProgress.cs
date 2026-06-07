using System;
using System.Collections.Generic;
using System.Numerics;
using Assets.Source.Item;
using Assets.Source.Player;
using Assets.Source.Util;
using LightJson;
using UnityEngine;

namespace Assets.Source.World
{
	public abstract class ConstructionProgress
	{
		private Dictionary<ItemType, BigInteger> _requiredMaterials;

		private Dictionary<ItemType, BigInteger> _consumedMaterials;

		public float BaseTime { get; private set; }

		public float TimeLeft { get; private set; }

		public IEnumerable<KeyValuePair<ItemType, BigInteger>> RequiredMaterials => _requiredMaterials;

		public IEnumerable<KeyValuePair<ItemType, BigInteger>> ConsumedMaterials => _consumedMaterials;

		public float TimeProgress
		{
			get
			{
				if (BaseTime != 0f)
				{
					return Mathf.Clamp01(1f - TimeLeft / BaseTime);
				}
				return 1f;
			}
		}

		public float MaterialProgress
		{
			get
			{
				BigInteger bigInteger = 0;
				BigInteger numerator = 0;
				foreach (BigInteger value in _requiredMaterials.Values)
				{
					bigInteger += value;
				}
				foreach (BigInteger value2 in _consumedMaterials.Values)
				{
					numerator += value2;
				}
				if (!(bigInteger == 0L))
				{
					return GameMath.Clamp01(numerator, bigInteger);
				}
				return 1f;
			}
		}

		public float Progress => MathF.Min(MaterialProgress, TimeProgress);

		public abstract string Name { get; }

		public abstract Sprite Icon { get; }

		public ConstructionProgress()
		{
			_requiredMaterials = new Dictionary<ItemType, BigInteger>();
			_consumedMaterials = new Dictionary<ItemType, BigInteger>();
		}

		public ConstructionProgress(float time, IEnumerable<KeyValuePair<ItemType, BigInteger>> materials)
		{
			BaseTime = time;
			TimeLeft = time;
			_requiredMaterials = new Dictionary<ItemType, BigInteger>(materials);
			_consumedMaterials = new Dictionary<ItemType, BigInteger>();
		}

		protected abstract void OnConstructionCompleted();

		protected abstract void OnConstructionCanceled();

		public virtual bool CanProceedConstruction()
		{
			return true;
		}

		public void Update(float delta)
		{
			if (!CanProceedConstruction())
			{
				return;
			}
			TimeLeft -= delta;
			foreach (KeyValuePair<ItemType, BigInteger> requiredMaterial in _requiredMaterials)
			{
				_consumedMaterials.TryGetValue(requiredMaterial.Key, out var value);
				if (value < requiredMaterial.Value)
				{
					BigInteger bigInteger = GamePlayer.Current.ConsumeInventoryItem(requiredMaterial.Key, requiredMaterial.Value - value);
					if (bigInteger > 0L)
					{
						_consumedMaterials[requiredMaterial.Key] = value + bigInteger;
					}
				}
			}
			if (Progress == 1f)
			{
				OnConstructionCompleted();
			}
		}

		public BigInteger GetConsumedCount(ItemType item)
		{
			_consumedMaterials.TryGetValue(item, out var value);
			return value;
		}

		public BigInteger GetRequiredCount(ItemType item)
		{
			_requiredMaterials.TryGetValue(item, out var value);
			return value;
		}

		public void Cancel()
		{
			GamePlayer.Current.RemoveConstruction(this);
			UISounds.TurnPage();
			foreach (KeyValuePair<ItemType, BigInteger> consumedMaterial in _consumedMaterials)
			{
				GamePlayer.Current.AddInventoryItem(consumedMaterial.Key, consumedMaterial.Value, addToStats: false);
			}
			OnConstructionCanceled();
		}

		public JsonValue ToJson()
		{
			JsonObject jsonObject = new JsonObject();
			JsonObject jsonObject2 = new JsonObject();
			foreach (KeyValuePair<ItemType, BigInteger> requiredMaterial in _requiredMaterials)
			{
				jsonObject[requiredMaterial.Key] = requiredMaterial.Value.ToString();
			}
			foreach (KeyValuePair<ItemType, BigInteger> consumedMaterial in _consumedMaterials)
			{
				jsonObject2[consumedMaterial.Key] = consumedMaterial.Value.ToString();
			}
			return new JsonObject
			{
				{ "BaseTime", BaseTime },
				{ "TimeLeft", TimeLeft },
				{ "RequiredMaterials", jsonObject },
				{ "ConsumedMaterials", jsonObject2 }
			};
		}

		public static ConstructionProgress FromJson(JsonValue val, ConstructionProgress returned)
		{
			returned.BaseTime = (float)val["BaseTime"].AsNumber;
			returned.TimeLeft = (float)val["TimeLeft"].AsNumber;
			foreach (KeyValuePair<string, JsonValue> item in val["RequiredMaterials"].AsJsonObject)
			{
				returned._requiredMaterials[item.Key] = BigInteger.Parse(item.Value.AsString ?? "0");
			}
			foreach (KeyValuePair<string, JsonValue> item2 in val["ConsumedMaterials"].AsJsonObject)
			{
				returned._consumedMaterials[item2.Key] = BigInteger.Parse(item2.Value.AsString ?? "0");
			}
			return returned;
		}
	}
}
