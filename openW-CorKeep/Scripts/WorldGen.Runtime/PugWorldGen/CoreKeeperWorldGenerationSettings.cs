using System;
using System.Collections.Generic;
using UnityEngine;

namespace PugWorldGen
{
	[Serializable]
	[CreateAssetMenu(menuName = "Pug/World Gen/CoreKeeper/World Generation Settings", fileName = "CoreKeeper World Generation Settings", order = 3)]
	public class CoreKeeperWorldGenerationSettings : ScriptableObject
	{
		public List<LevelWorldGenerationSetting> levelSettings;
	}
}
