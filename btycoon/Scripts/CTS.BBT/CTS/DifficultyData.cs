using System;
using CTS.Core;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/Difficulty Data")]
	public class DifficultyData : ScriptableObject
	{
		[SerializeField]
		private SerializableDictionary<StringKey, float> _difficulty = new SerializableDictionary<StringKey, float>();

		[SerializeField]
		private DifficultyData[] _fallbacks = Array.Empty<DifficultyData>();

		public ReadOnlyDictionary<StringKey, float> Difficulty => _difficulty;

		public void SetValue(StringKey key, float value)
		{
			_difficulty[key] = value;
		}

		public void Clear()
		{
			_difficulty.Clear();
		}

		public bool TryGetValue(StringKey key, out float value)
		{
			if (_difficulty.TryGetValue(key, out value))
			{
				return true;
			}
			DifficultyData[] fallbacks = _fallbacks;
			for (int i = 0; i < fallbacks.Length; i++)
			{
				if (fallbacks[i].TryGetValue(key, out value))
				{
					return true;
				}
			}
			return false;
		}

		public float GetMultiplicativeDifficulty(StringKey key)
		{
			if (TryGetValue(key, this, out var outValue))
			{
				return outValue;
			}
			return 1f;
		}

		public float GetAdditiveDifficulty(StringKey key)
		{
			if (TryGetValue(key, this, out var outValue))
			{
				return outValue;
			}
			return 0f;
		}

		private static bool TryGetValue(StringKey key, DifficultyData data, out float outValue)
		{
			if (data._difficulty.TryGetValue(key, out outValue))
			{
				return true;
			}
			DifficultyData[] fallbacks = data._fallbacks;
			foreach (DifficultyData data2 in fallbacks)
			{
				if (TryGetValue(key, data2, out outValue))
				{
					return true;
				}
			}
			return false;
		}
	}
}
