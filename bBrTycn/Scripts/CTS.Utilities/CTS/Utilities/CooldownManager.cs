using System;
using System.Collections.Generic;
using CTS.Core;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS.Utilities
{
	public class CooldownManager : CTSBehaviour
	{
		[Serializable]
		public struct Cooldown
		{
			public GameTime StartTime;

			public GameTime EndTime;

			public bool IsTimeScaled;

			public float Duration => EndTime - StartTime;

			public float Completion => (IsTimeScaled ? Time.time : Time.unscaledTime) - StartTime;

			public float UnitCompletion => Completion / Duration;

			public Cooldown(float duration, bool isTimeScaled)
			{
				IsTimeScaled = isTimeScaled;
				EndTime = (IsTimeScaled ? (Time.time + duration) : (Time.unscaledTime + duration));
				StartTime = (IsTimeScaled ? Time.time : Time.unscaledTime);
			}

			public bool IsOnCooldown()
			{
				return Completion < Duration;
			}
		}

		[SerializeField]
		private CooldownData _cooldownData;

		private readonly Dictionary<StringKey, Cooldown> _cooldownDictionary = new Dictionary<StringKey, Cooldown>();

		public CooldownData CooldownData => _cooldownData;

		public ReadOnlyDictionary<StringKey, Cooldown> Cooldowns => _cooldownDictionary;

		public event Action<StringKey> CooldownStarted;

		protected override void OnDisabled()
		{
			base.OnDisabled();
			_cooldownDictionary.Clear();
		}

		public void SendEvents()
		{
			foreach (var (stringKey2, _) in _cooldownDictionary)
			{
				if (IsOnCooldown(stringKey2, remove: false))
				{
					this.CooldownStarted?.Invoke(stringKey2);
				}
			}
		}

		public void StartCooldown(StringKey key, bool isTimeScaled = true)
		{
			if ((object)_cooldownData == null)
			{
				Debug.LogException(new NullReferenceException("No cooldown data set"));
				return;
			}
			float cooldown = _cooldownData.GetCooldown(key);
			StartCooldown(key, cooldown, isTimeScaled);
		}

		public void StartCooldown(StringKey key, float duration, bool isTimeScaled = true)
		{
			_cooldownDictionary[key] = new Cooldown(duration, isTimeScaled);
			this.CooldownStarted?.Invoke(key);
		}

		public void StopCooldown(StringKey key)
		{
			_cooldownDictionary.Remove(key);
		}

		public float GetUnitCompletion(StringKey key)
		{
			if (!_cooldownDictionary.TryGetValue(key, out var value))
			{
				return 1f;
			}
			return value.UnitCompletion;
		}

		public bool IsOnCooldown(StringKey key, bool remove = true)
		{
			if (!_cooldownDictionary.TryGetValue(key, out var value))
			{
				return false;
			}
			bool num = value.IsOnCooldown();
			if (!num && remove)
			{
				_cooldownDictionary.Remove(key);
			}
			return num;
		}
	}
}
