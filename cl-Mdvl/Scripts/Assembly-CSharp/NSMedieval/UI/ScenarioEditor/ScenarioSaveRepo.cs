using System;
using System.Collections.Generic;
using UnityEngine;

namespace NSMedieval.UI.ScenarioEditor
{
	[Serializable]
	public class ScenarioSaveRepo
	{
		[SerializeField]
		private List<ScenarioSaveData> repository = new List<ScenarioSaveData>();

		public ScenarioSaveRepo(ScenarioSaveData scenarioSaveData)
		{
			repository.Add(scenarioSaveData);
		}
	}
}
