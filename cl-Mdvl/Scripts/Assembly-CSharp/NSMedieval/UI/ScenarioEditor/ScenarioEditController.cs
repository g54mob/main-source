using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.Tools;
using UnityEngine;

namespace NSMedieval.UI.ScenarioEditor
{
	[Serializable]
	public class ScenarioEditController : MonoSingleton<ScenarioEditController>
	{
		[SerializeField]
		private List<ScenarioSaveData> repository = new List<ScenarioSaveData>();

		public ScenarioSaveData Data
		{
			get
			{
				if (repository.Count < 1)
				{
					repository.Add(new ScenarioSaveData());
				}
				return repository.First();
			}
		}

		public void CreateNewScenario()
		{
			string text = Path.Combine(Application.persistentDataPath, VillageSaveData.CustomScenarioDirectory + "/" + Data.ID + ".json");
			FilePathUtils.CheckAndCreatePath(text);
			string data = JsonUtility.ToJson(this, prettyPrint: true);
			FileUtils.SafeWriteAllText(text, data);
			MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(Repository<ScenarioRepository, Scenario>.Instance.Reload);
		}
	}
}
