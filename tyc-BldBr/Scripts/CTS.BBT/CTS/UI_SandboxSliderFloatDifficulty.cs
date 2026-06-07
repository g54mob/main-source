using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class UI_SandboxSliderFloatDifficulty : UI_SandboxFloatSlider<DifficultyData>
	{
		[SerializeField]
		private StringKey _difficultyKey;

		protected override DifficultyData GetObject()
		{
			return _profileCreator.DifficultyData;
		}

		protected override float GetValue(DifficultyData obj)
		{
			if (!obj.TryGetValue(_difficultyKey, out var value))
			{
				return 0f;
			}
			return value;
		}

		protected override void SetValue(DifficultyData obj, float value)
		{
			obj.SetValue(_difficultyKey, value);
		}
	}
}
