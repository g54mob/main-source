using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class UI_SandboxSliderIntDifficulty : UI_SandboxIntSlider<DifficultyData>
	{
		[SerializeField]
		private StringKey _difficultyKey;

		protected override DifficultyData GetObject()
		{
			return _profileCreator.DifficultyData;
		}

		protected override int GetValue(DifficultyData obj)
		{
			if (!obj.TryGetValue(_difficultyKey, out var value))
			{
				return 0;
			}
			return Mathf.RoundToInt(value);
		}

		protected override void SetValue(DifficultyData obj, int value)
		{
			obj.SetValue(_difficultyKey, value);
		}
	}
}
