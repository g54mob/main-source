using System;
using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;
using LightJson;
using UnityEngine;

namespace Assets.Source.World
{
	public abstract class ConstructionProgress
	{
		private Dictionary<ItemType, int> _requiredMaterials;

		private Dictionary<ItemType, int> _consumedMaterials;

		public float BaseTime { get; private set; }

		public float TimeLeft { get; private set; }

		public IEnumerable<KeyValuePair<ItemType, int>> RequiredMaterials => _requiredMaterials;

		public IEnumerable<KeyValuePair<ItemType, int>> ConsumedMaterials => _consumedMaterials;

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
				float num = 0f;
				float num2 = 0f;
				foreach (int value in _requiredMaterials.Values)
				{
					num += (float)value;
				}
				foreach (int value2 in _consumedMaterials.Values)
				{
					num2 += (float)value2;
				}
				if (num != 0f)
				{
					return num2 / num;
				}
				return 1f;
			}
		}

		public float Progress => MathF.Min(MaterialProgress, TimeProgress);

		public abstract string Name { get; }

		public abstract Sprite Icon { get; }

		public ConstructionProgress()
		{
			_requiredMaterials = new Dictionary<ItemType, int>();
			_consumedMaterials = new Dictionary<ItemType, int>();
		}

		public ConstructionProgress(float time, IEnumerable<KeyValuePair<ItemType, int>> materials)
		{
			BaseTime = time;
			TimeLeft = time;
			_requiredMaterials = new Dictionary<ItemType, int>(materials);
			_consumedMaterials = new Dictionary<ItemType, int>();
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
			foreach (KeyValuePair<ItemType, int> requiredMaterial in _requiredMaterials)
			{
				_consumedMaterials.TryGetValue(requiredMaterial.Key, out var value);
				if (value < requiredMaterial.Value)
				{
					int num = GamePlayer.Current.ConsumeInventoryItem(requiredMaterial.Key, requiredMaterial.Value - value);
					if (num > 0)
					{
						_consumedMaterials[requiredMaterial.Key] = value + num;
					}
				}
			}
			if (Progress == 1f)
			{
				OnConstructionCompleted();
			}
		}

		public int GetConsumedCount(ItemType item)
		{
			_consumedMaterials.TryGetValue(item, out var value);
			return value;
		}

		public int GetRequiredCount(ItemType item)
		{
			_requiredMaterials.TryGetValue(item, out var value);
			return value;
		}

		public void Cancel()
		{
			GamePlayer.Current.RemoveConstruction(this);
			UISounds.TurnPage();
			foreach (KeyValuePair<ItemType, int> consumedMaterial in _consumedMaterials)
			{
				GamePlayer.Current.AddInventoryItem(consumedMaterial.Key, consumedMaterial.Value, addToStats: false);
			}
			OnConstructionCanceled();
		}

		public JsonValue ToJson()
		{
			JsonObject jsonObject = new JsonObject();
			JsonObject jsonObject2 = new JsonObject();
			foreach (KeyValuePair<ItemType, int> requiredMaterial in _requiredMaterials)
			{
				jsonObject[requiredMaterial.Key] = requiredMaterial.Value;
			}
			foreach (KeyValuePair<ItemType, int> consumedMaterial in _consumedMaterials)
			{
				jsonObject2[consumedMaterial.Key] = consumedMaterial.Value;
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
				returned._requiredMaterials[item.Key] = item.Value;
			}
			foreach (KeyValuePair<string, JsonValue> item2 in val["ConsumedMaterials"].AsJsonObject)
			{
				returned._consumedMaterials[item2.Key] = item2.Value;
			}
			return returned;
		}
	}
}
