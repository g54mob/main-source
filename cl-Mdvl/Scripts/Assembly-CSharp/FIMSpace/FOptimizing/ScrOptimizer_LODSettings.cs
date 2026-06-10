using System.Collections.Generic;
using UnityEngine;

namespace FIMSpace.FOptimizing
{
	public class ScrOptimizer_LODSettings : ScriptableObject
	{
		public List<ScrLOD_Base> LevelOfDetailSets;

		public ScrOptimizer_LODSettings()
		{
			LevelOfDetailSets = new List<ScrLOD_Base>();
		}

		public ScrOptimizer_LODSettings CreateCopy()
		{
			ScrOptimizer_LODSettings scrOptimizer_LODSettings = ScriptableObject.CreateInstance<ScrOptimizer_LODSettings>();
			for (int i = 0; i < LevelOfDetailSets.Count; i++)
			{
				scrOptimizer_LODSettings.LevelOfDetailSets.Add(LevelOfDetailSets[i].CreateNewScrCopy());
			}
			return scrOptimizer_LODSettings;
		}
	}
}
