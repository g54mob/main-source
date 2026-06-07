using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using DV.Common;
using DV.Localization;
using DV.Scenarios;
using DV.Scenarios.Common;
using DV.ThingTypes;
using DV.UserManagement;
using DV.UserManagement.Data;
using DV.UserManagement.Storage.Implementation;
using DV.Utils;
using UnityEngine;

namespace DV.UI
{
	public class ScenarioProvider : AScenarioProvider
	{
		public DVObjectModel dvObjectModel;

		public List<ScenarioEditorStationMapping> stationMappings;

		public override bool IsVR => VRManager.IsVREnabled();

		public override DVObjectModel GetObjectModel()
		{
			return dvObjectModel;
		}

		public override List<ScenarioEditorStationMapping> GetStationMappings()
		{
			return stationMappings;
		}

		public override HashSet<GeneralLicenseType_v2> GetUnlockedLicenses()
		{
			return new HashSet<GeneralLicenseType_v2>((from licenseName in SingletonBehaviour<UnlockablesManager>.Instance.UnlockedGeneralLicenses
				where !string.IsNullOrWhiteSpace(licenseName)
				select dvObjectModel.generalLicenses.FirstOrDefault((GeneralLicenseType_v2 l) => l != null && l.id.ToLower() == licenseName.ToLower()) into license
				where license != null
				select license).ToList());
		}

		public override HashSet<GarageType_v2> GetUnlockedGarages()
		{
			return new HashSet<GarageType_v2>((from garageName in SingletonBehaviour<UnlockablesManager>.Instance.UnlockedGarages
				where !string.IsNullOrWhiteSpace(garageName)
				select dvObjectModel.garages.FirstOrDefault((GarageType_v2 l) => l != null && l.id.ToLower() == garageName.ToLower()) into garage
				where garage != null
				select garage).ToList());
		}

		public override bool TrainTooLongForStartingTrack(IScenario scenario)
		{
			return false;
		}

		public override bool TrainTooLongForDestinationTrack(IScenario scenario)
		{
			return false;
		}

		protected override void CreateNewIScenarioCRUDInstance()
		{
			UserManager instance = SingletonBehaviour<UserManager>.Instance;
			string text = Path.Combine(Application.persistentDataPath, instance.CurrentUser.GameDataPath, "assets").Replace('\\', '/');
			Debug.Log("Using ScenarioCRUD path '" + text + "'");
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			foreach (KeyValuePair<string, string> lOCALIZATION_KEY in DifficultyExtensions.LOCALIZATION_KEYS)
			{
				dictionary.Add(lOCALIZATION_KEY.Key, LocalizationAPI.L(lOCALIZATION_KEY.Value));
			}
			List<IDifficulty> predefinedDifficulties = GetPredefinedDifficulties();
			base.CRUD = new ScenarioCRUD(new FileSystemStorage(text), predefinedScenarios: GetPredefinedScenarios(), predefinedTrains: GetPredefinedTrains(), predefinedDifficulties: predefinedDifficulties, difficultyUpgraders: DifficultyDataUtils.DifficultyUpgraders, scenarioUpgraders: DifficultyDataUtils.ScenarioUpgraders, trainUpgraders: DifficultyDataUtils.TrainUpgraders, difficultyPresetRemappings: null, scenarioLocalization: null, trainLocalization: null, difficultyLocalization: dictionary);
			Debug.Log("Check for unsaved difficulties...");
			bool flag = false;
			User currentUser = SingletonBehaviour<UserManager>.Instance.CurrentUser;
			HashSet<string> hashSet = new HashSet<string>(base.CRUD.Difficulties.Select((IDifficulty d) => d.Name));
			foreach (ReadOnlyObservableCollection<IGameSession> value in currentUser.Sessions.Values)
			{
				foreach (IGameSession item in value)
				{
					IDifficulty difficulty = item.GetDifficulty(autoFill: false);
					IDifficulty difficulty2 = null;
					for (int num = 0; num < base.CRUD.Difficulties.Count; num++)
					{
						if (base.CRUD.Difficulties[num].Equals(difficulty))
						{
							difficulty2 = base.CRUD.Difficulties[num];
							break;
						}
					}
					if (difficulty2 == null && predefinedDifficulties.Any((IDifficulty d) => d.Name == difficulty.Name))
					{
						difficulty.Name += " (Custom)";
						for (int num2 = 0; num2 < base.CRUD.Difficulties.Count; num2++)
						{
							if (base.CRUD.Difficulties[num2].Equals(difficulty))
							{
								difficulty2 = base.CRUD.Difficulties[num2];
								item.SetDifficulty(base.CRUD.Difficulties[num2]);
								break;
							}
						}
					}
					if (difficulty2 == null)
					{
						for (int num3 = 0; num3 < base.CRUD.Difficulties.Count; num3++)
						{
							if (Thing.GetMatchScore((Thing)base.CRUD.Difficulties[num3], (Thing)difficulty) > 0)
							{
								difficulty2 = base.CRUD.Difficulties[num3];
								item.SetDifficulty(base.CRUD.Difficulties[num3]);
								break;
							}
						}
					}
					if (difficulty2 == null)
					{
						difficulty.Name = ScenarioCRUD.GetUniqueName(difficulty.Name, hashSet);
						Debug.LogWarning("Session " + item.Name + " (" + item.GameMode + ") has an unknown difficulty " + difficulty.Name + ", saving to file");
						difficulty.SyncState = SyncState.Fresh;
						base.CRUD.Difficulties.Add(difficulty);
						item.SetDifficulty(difficulty);
						hashSet.Add(difficulty.Name);
						flag = true;
					}
				}
			}
			if (flag)
			{
				Debug.Log("There were difficulty files extracted, flushing CRUD...");
				base.CRUD.Flush();
			}
			Debug.Log("Unsaved difficulties phase done.");
		}

		private List<ITrain> GetPredefinedTrains()
		{
			ITrain item = DifficultyParamsSetter.DefaultTrain(new Train());
			return new List<ITrain> { item };
		}

		private List<IScenario> GetPredefinedScenarios()
		{
			IScenario item = DifficultyParamsSetter.Default1(new Scenario(), this);
			return new List<IScenario> { item };
		}

		private List<IDifficulty> GetPredefinedDifficulties()
		{
			return new List<IDifficulty>(DifficultyParamsSetter.PredefinedDifficulties);
		}
	}
}
