using System;
using System.Collections.Generic;
using CTS.Core;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS.Utilities
{
	[CreateAssetMenu(menuName = "CTS/Cooldown Data")]
	public class CooldownData : ScriptableObject
	{
		[SerializeField]
		private SerializableDictionary<StringKey, Vector2> _cooldowns = new SerializableDictionary<StringKey, Vector2>();

		[SerializeField]
		private List<CooldownData> _fallbackCooldowns = new List<CooldownData>();

		public ReadOnlyDictionary<StringKey, Vector2> Cooldowns => _cooldowns;

		public float GetCooldown(StringKey key)
		{
			if (!key.IsValid())
			{
				Debug.LogException(new Exception("String key not valid"));
				return 0f;
			}
			if (_cooldowns.TryGetValue(key, out var value))
			{
				return value.RandomInRange();
			}
			foreach (CooldownData fallbackCooldown in _fallbackCooldowns)
			{
				if (fallbackCooldown.TryGetCooldown(key, out var outCooldown))
				{
					return outCooldown;
				}
			}
			Debug.LogException(new NullReferenceException("No cooldown could be found for key " + key));
			return 0f;
		}

		public bool TryGetCooldown(StringKey key, out float outCooldown)
		{
			if (!key.IsValid())
			{
				Debug.LogException(new Exception("String key not valid"));
				outCooldown = 0f;
				return false;
			}
			if (_cooldowns.TryGetValue(key, out var value))
			{
				outCooldown = value.RandomInRange();
				return true;
			}
			foreach (CooldownData fallbackCooldown in _fallbackCooldowns)
			{
				if (fallbackCooldown.TryGetCooldown(key, out outCooldown))
				{
					return true;
				}
			}
			outCooldown = 0f;
			return false;
		}
	}
}
