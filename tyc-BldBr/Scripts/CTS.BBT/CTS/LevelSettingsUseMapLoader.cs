using CTS.Core;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS
{
	public class LevelSettingsUseMapLoader : LevelSetting
	{
		[field: SerializeField]
		public bool UseMap { get; set; } = true;

		public override void Apply()
		{
			if (!UseMap)
			{
				ComponentGetter.GetComponentSingleSingleton(typeof(AutomaticMapLoader))?.Cast<AutomaticMapLoader>().SetMapToLoad("");
			}
		}
	}
}
