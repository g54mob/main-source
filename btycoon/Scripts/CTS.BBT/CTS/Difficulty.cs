using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class Difficulty : CTSSingleton<Difficulty>
	{
		[SerializeField]
		private StringKey _defaultDifficulty;

		[SerializeField]
		private SerializableDictionary<StringKey, DifficultyData> _presets;

		private DifficultyData _currentDifficulty;

		public StringKey CurrentDifficulty { get; private set; }

		public DifficultyData CustomDifficulty { get; set; }

		protected override void SingletonAwake()
		{
			ResetDifficulty();
		}

		protected override void OnSingletonDestroy()
		{
		}

		public void SetCurrentDifficulty(StringKey difficulty)
		{
			if (!(CurrentDifficulty == difficulty))
			{
				CurrentDifficulty = difficulty;
				_currentDifficulty = _presets[difficulty];
			}
		}

		public void ResetDifficulty()
		{
			SetCurrentDifficulty(_defaultDifficulty);
		}

		public static float GetMultiplicativeDifficulty(StringKey key)
		{
			if (!CTSSingleton<Difficulty>.InstanceExists())
			{
				return 1f;
			}
			return CTSSingleton<Difficulty>.Instance.GetMultiplicativeDifficulty_Instance(key);
		}

		private float GetMultiplicativeDifficulty_Instance(StringKey difficulty)
		{
			if ((object)CustomDifficulty != null && CustomDifficulty.TryGetValue(difficulty, out var value))
			{
				return value;
			}
			return _currentDifficulty.GetMultiplicativeDifficulty(difficulty);
		}

		public static float GetAdditiveDifficulty(StringKey key)
		{
			if (!CTSSingleton<Difficulty>.InstanceExists())
			{
				return 0f;
			}
			return CTSSingleton<Difficulty>.Instance.GetAdditiveDifficulty_Instance(key);
		}

		private float GetAdditiveDifficulty_Instance(StringKey difficulty)
		{
			if ((object)CustomDifficulty != null && CustomDifficulty.TryGetValue(difficulty, out var value))
			{
				return value;
			}
			return _currentDifficulty.GetAdditiveDifficulty(difficulty);
		}
	}
}
