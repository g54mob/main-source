using System;
using System.Collections.Generic;

namespace VampireSurvivors.Data;

[Serializable]
public class PS4BaseGameData
{
	public string _MasterVersion = "01.00";

	public string _ApplicationVersion = "01.00";

	public List<string> _TrophyPacks;

	public List<PS4TrophyIdMappingData> _TrophyIdMappingFiles;

	public PS4BaseGameData()
	{
		List<string> trophyPacks = new List<string>();
		_TrophyPacks = trophyPacks;
		List<PS4TrophyIdMappingData> trophyIdMappingFiles = new List<PS4TrophyIdMappingData>();
		_TrophyIdMappingFiles = trophyIdMappingFiles;
	}
}
