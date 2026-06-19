using FullInspector;
using UnityEngine;

namespace TH20
{
	public class LevelPitchOverride
	{
		[SerializeField]
		public SharedInstance<LevelConfig> LevelConfig;

		[SerializeField]
		public float PitchOverride;
	}
}
