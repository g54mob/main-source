using System;
using System.Collections.Generic;
using UnityEngine;

namespace VampireSurvivors.Data
{
	[Serializable]
	public class PS4BaseGameData
	{
		[Tooltip("This should only ever be updated if we are submitting a new master version. This is for failed initial submissions, or remasters / disc releases.")]
		public string _MasterVersion;

		[Tooltip("This should be updated for each new patch we generate.")]
		public string _ApplicationVersion;

		public List<string> _TrophyPacks;

		public List<PS4TrophyIdMappingData> _TrophyIdMappingFiles;
	}
}
