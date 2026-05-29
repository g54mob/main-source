using UnityEngine;

namespace CTS
{
	public abstract class LevelSetting : ScriptableObject
	{
		[field: SerializeField]
		public LevelSetting DemoOverride { get; private set; }

		public abstract void Apply();
	}
}
