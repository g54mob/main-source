using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DV;
using DV.Booklets;
using DV.ThingTypes;
using DV.ThingTypes.TransitionHelpers;
using DV.Utils;
using UnityEngine;

public class LicenseManager : SingletonBehaviour<LicenseManager>
{
	public const int STARTING_TRAIN_LENGTH_MIN = 3;

	public const int STARTING_TRAIN_LENGTH_MAX = 5;

	public const int TRAIN_LENGTH_1_MAX = 10;

	public const int TRAIN_LENGTH_2_MAX = 20;

	private const float MAX_BONUS_TIME_DECREASE_PERCENTAGE = 0.7f;

	private HashSet<GeneralLicenseType_v2> acquiredGeneralLicenses = new HashSet<GeneralLicenseType_v2>();

	private HashSet<JobLicenseType_v2> acquiredJobLicenses = new HashSet<JobLicenseType_v2>();

	private HashSet<GarageType_v2> unlockedGarages = new HashSet<GarageType_v2>();

	private bool unsavedChanges;

	private static readonly Dictionary<JobType, HashSet<JobLicenseType_v2>> JobTypeToLicenseType = new Dictionary<JobType, HashSet<JobLicenseType_v2>>
	{
		{
			JobType.ShuntingLoad,
			new HashSet<JobLicenseType_v2> { JobLicenses.Shunting.ToV2() }
		},
		{
			JobType.ShuntingUnload,
			new HashSet<JobLicenseType_v2> { JobLicenses.Shunting.ToV2() }
		},
		{
			JobType.Transport,
			new HashSet<JobLicenseType_v2> { JobLicenses.FreightHaul.ToV2() }
		},
		{
			JobType.EmptyHaul,
			new HashSet<JobLicenseType_v2> { JobLicenses.LogisticalHaul.ToV2() }
		}
	};

	private static readonly JobLicenseType_v2 TrainLength1License = JobLicenses.TrainLength1.ToV2();

	private static readonly JobLicenseType_v2 TrainLength2License = JobLicenses.TrainLength2.ToV2();

	private static readonly GeneralLicenseType_v2 ConcurrentJobs1License = GeneralLicenseType.ConcurrentJobs1.ToV2();

	private static readonly GeneralLicenseType_v2 ConcurrentJobs2License = GeneralLicenseType.ConcurrentJobs2.ToV2();

	private static readonly HashSet<JobLicenseType_v2> EmptyLicenseSet = new HashSet<JobLicenseType_v2>();

	public static readonly List<GeneralLicenseType_v2> TutorialGeneralLicenses = new List<GeneralLicenseType_v2>
	{
		GeneralLicenseType.TrainDriver.ToV2(),
		GeneralLicenseType.DE2.ToV2()
	};

	public int JobLicensesCount => Globals.G.Types.jobLicenses.Count - (Globals.G.Types.jobLicenses.Contains(JobLicenses.Basic.ToV2()) ? 1 : 0);

	public int GeneralLicensesCount => Globals.G.Types.generalLicenses.Count;

	public int AllLicensesCount => JobLicensesCount + GeneralLicensesCount;

	public float BonusTimeDecreasePercentage { get; private set; }

	public float InsuranceFeeQuota { get; private set; } = 100f;

	public event Action<GeneralLicenseType_v2> LicenseAcquired;

	public event Action<JobLicenseType_v2> JobLicenseAcquired;

	public event Action<GarageType_v2> GarageUnlocked;

	public event Action InsuranceFeeQuotaUpdated;

	public new static string AllowAutoCreate()
	{
		return "[LicenseManager]";
	}

	public HashSet<JobLicenseType_v2> GetRequiredLicensesForJobType(JobType jobType)
	{
		if (JobTypeToLicenseType.TryGetValue(jobType, out var value))
		{
			return value;
		}
		Debug.LogError($"Unexpected job type: {jobType}. Setting no license requirement!");
		return EmptyLicenseSet;
	}

	public HashSet<JobLicenseType_v2> GetRequiredLicensesForCargoTypes(IEnumerable<CargoType> cargoTypes)
	{
		HashSet<JobLicenseType_v2> hashSet = new HashSet<JobLicenseType_v2>();
		foreach (CargoType cargoType in cargoTypes)
		{
			JobLicenseType_v2[] requiredJobLicenses = cargoType.ToV2().requiredJobLicenses;
			foreach (JobLicenseType_v2 jobLicenseType_v in requiredJobLicenses)
			{
				if (jobLicenseType_v != null)
				{
					hashSet.Add(jobLicenseType_v);
				}
			}
		}
		return hashSet;
	}

	public HashSet<JobLicenseType_v2> GetRequiredLicensesForCarTypes(IEnumerable<TrainCarType_v2> carTypes)
	{
		HashSet<JobLicenseType_v2> hashSet = new HashSet<JobLicenseType_v2>();
		foreach (TrainCarType_v2 carType in carTypes)
		{
			if (carType.requiredJobLicenses == null)
			{
				continue;
			}
			JobLicenseType_v2[] requiredJobLicenses = carType.requiredJobLicenses;
			foreach (JobLicenseType_v2 jobLicenseType_v in requiredJobLicenses)
			{
				if (jobLicenseType_v != null)
				{
					hashSet.Add(jobLicenseType_v);
				}
			}
		}
		return hashSet;
	}

	public JobLicenseType_v2 GetRequiredLicenseForNumberOfTransportedCars(int numOfCars)
	{
		if (numOfCars <= 5)
		{
			return null;
		}
		if (numOfCars <= 10)
		{
			return TrainLength1License;
		}
		if (numOfCars <= 20)
		{
			return TrainLength2License;
		}
		Debug.LogWarning(string.Format("Longer train than expected [{0}/{1}], returning {2} license as requirement", numOfCars, 20, "TrainLength2License"));
		return TrainLength2License;
	}

	public int GetNumberOfAcquiredGeneralLicenses()
	{
		return acquiredGeneralLicenses.Count;
	}

	public int GetNumberOfAcquiredJobLicenses()
	{
		return acquiredJobLicenses.Count;
	}

	public HashSet<GeneralLicenseType_v2> GetGeneralAcquiredLicenses()
	{
		return new HashSet<GeneralLicenseType_v2>(acquiredGeneralLicenses);
	}

	public void AcquireGeneralLicense(GeneralLicenseType_v2 license)
	{
		if (!(license == null) && !acquiredGeneralLicenses.Contains(license))
		{
			acquiredGeneralLicenses.Add(license);
			SingletonBehaviour<UnlockablesManager>.Instance.UnlockGeneralLicense(license.id);
			InsuranceFeeQuota += license.insuranceFeeQuotaIncrease;
			this.InsuranceFeeQuotaUpdated?.Invoke();
			BonusTimeDecreasePercentage = Mathf.Clamp(BonusTimeDecreasePercentage + license.bonusTimeDecreasePercentage, -0.7f, 0.7f);
			this.LicenseAcquired?.Invoke(license);
			unsavedChanges = true;
		}
	}

	public bool IsGeneralLicenseAcquired(GeneralLicenseType_v2 license)
	{
		if (!(license == null))
		{
			return acquiredGeneralLicenses.Contains(license);
		}
		return true;
	}

	public bool IsGeneralLicenseObtainable(GeneralLicenseType_v2 license)
	{
		if (license == null || IsGeneralLicenseAcquired(license))
		{
			return false;
		}
		GeneralLicenseType_v2 requiredGeneralLicense = license.requiredGeneralLicense;
		if (requiredGeneralLicense != null)
		{
			return IsGeneralLicenseAcquired(requiredGeneralLicense);
		}
		JobLicenseType_v2 requiredJobLicense = license.requiredJobLicense;
		if (requiredJobLicense != null)
		{
			return IsJobLicenseAcquired(requiredJobLicense);
		}
		return true;
	}

	public int GetNumberOfAllowedConcurrentJobs()
	{
		if (IsGeneralLicenseAcquired(ConcurrentJobs2License))
		{
			return int.MaxValue;
		}
		if (IsGeneralLicenseAcquired(ConcurrentJobs1License))
		{
			return 2;
		}
		return 1;
	}

	public GeneralLicenseType_v2 GetMissingConcurrentJobsLicense()
	{
		if (!IsGeneralLicenseAcquired(ConcurrentJobs1License))
		{
			return ConcurrentJobs1License;
		}
		if (!IsGeneralLicenseAcquired(ConcurrentJobs2License))
		{
			return ConcurrentJobs2License;
		}
		return null;
	}

	public bool IsLicensedForCar(TrainCarLivery carType)
	{
		GeneralLicenseType_v2 requiredLicense = carType.requiredLicense;
		if (requiredLicense == null)
		{
			return true;
		}
		return IsGeneralLicenseAcquired(requiredLicense);
	}

	public void RemoveGeneralLicense(GeneralLicenseType_v2 license)
	{
		if (license != null)
		{
			acquiredGeneralLicenses.Remove(license);
		}
	}

	public HashSet<GarageType_v2> GetUnlockedGarages()
	{
		return new HashSet<GarageType_v2>(unlockedGarages);
	}

	public void UnlockGarage(GarageType_v2 garage)
	{
		SingletonBehaviour<UnlockablesManager>.Instance.UnlockGarage(garage.id);
		if (!unlockedGarages.Contains(garage))
		{
			unlockedGarages.Add(garage);
			this.GarageUnlocked?.Invoke(garage);
			unsavedChanges = true;
		}
	}

	public bool IsGarageUnlocked(GarageType_v2 garage)
	{
		return unlockedGarages.Contains(garage);
	}

	public HashSet<JobLicenseType_v2> GetAcquiredJobLicenses()
	{
		return acquiredJobLicenses;
	}

	public void AcquireJobLicense(IEnumerable<JobLicenseType_v2> newLicenses)
	{
		foreach (JobLicenseType_v2 newLicense in newLicenses)
		{
			AcquireJobLicense(newLicense);
		}
	}

	public void AcquireJobLicense(JobLicenseType_v2 newLicense)
	{
		if (IsJobLicenseAcquired(newLicense))
		{
			Debug.LogWarning($"Player already has the license '{newLicense}'. No new license added.");
			return;
		}
		acquiredJobLicenses.Add(newLicense);
		SingletonBehaviour<UnlockablesManager>.Instance.UnlockJobLicense(newLicense.id);
		InsuranceFeeQuota += newLicense.insuranceFeeQuotaIncrease;
		this.InsuranceFeeQuotaUpdated?.Invoke();
		BonusTimeDecreasePercentage = Mathf.Clamp(BonusTimeDecreasePercentage + newLicense.bonusTimeDecreasePercentage, -0.7f, 0.7f);
		this.JobLicenseAcquired?.Invoke(newLicense);
		unsavedChanges = true;
	}

	public bool IsJobLicenseAcquired(JobLicenseType_v2 license)
	{
		if (!(license == null) && license.v1 != JobLicenses.Basic)
		{
			return acquiredJobLicenses.Contains(license);
		}
		return true;
	}

	public HashSet<JobLicenseType_v2> GetMissingLicensesForJob(IEnumerable<JobLicenseType_v2> licenses)
	{
		if (licenses.Count() == 1 && (licenses.First() == null || licenses.First().v1 == JobLicenses.Basic))
		{
			Debug.LogWarning($"Passed parameter is {JobLicenses.Basic}. Missing license will be {JobLicenses.Basic}. Is this intended?");
		}
		HashSet<JobLicenseType_v2> hashSet = new HashSet<JobLicenseType_v2>();
		foreach (JobLicenseType_v2 license in licenses)
		{
			if (license != null && license.v1 != JobLicenses.Basic && !acquiredJobLicenses.Contains(license))
			{
				hashSet.Add(license);
			}
		}
		return hashSet;
	}

	public HashSet<JobLicenseType_v2> GetAcquiredLicensesForJob(IEnumerable<JobLicenseType_v2> licenses)
	{
		HashSet<JobLicenseType_v2> hashSet = new HashSet<JobLicenseType_v2>();
		foreach (JobLicenseType_v2 license in licenses)
		{
			if (license != null && license.v1 != JobLicenses.Basic && acquiredJobLicenses.Contains(license))
			{
				hashSet.Add(license);
			}
		}
		return hashSet;
	}

	public bool IsLicensedForJob(IEnumerable<JobLicenseType_v2> jobLicenseRequirements)
	{
		foreach (JobLicenseType_v2 jobLicenseRequirement in jobLicenseRequirements)
		{
			if (jobLicenseRequirement != null && jobLicenseRequirement.v1 != JobLicenses.Basic && !acquiredJobLicenses.Contains(jobLicenseRequirement))
			{
				return false;
			}
		}
		return true;
	}

	public bool IsJobLicenseObtainable(JobLicenseType_v2 license)
	{
		if (IsJobLicenseAcquired(license))
		{
			return false;
		}
		GeneralLicenseType_v2 requiredGeneralLicense = license.requiredGeneralLicense;
		if (requiredGeneralLicense != null)
		{
			return IsGeneralLicenseAcquired(requiredGeneralLicense);
		}
		JobLicenseType_v2 requiredJobLicense = license.requiredJobLicense;
		if (requiredJobLicense != null)
		{
			return IsJobLicenseAcquired(requiredJobLicense);
		}
		return true;
	}

	public int GetMaxNumberOfCarsPerJobWithAcquiredJobLicenses()
	{
		if (IsJobLicenseAcquired(TrainLength2License))
		{
			return 20;
		}
		if (IsJobLicenseAcquired(TrainLength1License))
		{
			return 10;
		}
		return 5;
	}

	public void RemoveJobLicense(IEnumerable<JobLicenseType_v2> licenses)
	{
		foreach (JobLicenseType_v2 license in licenses)
		{
			if (license != null)
			{
				acquiredJobLicenses.Remove(license);
			}
		}
	}

	public void SaveData(SaveGameData data)
	{
		if (unsavedChanges)
		{
			data.SetStringArray("Licenses_General", acquiredGeneralLicenses.Select((GeneralLicenseType_v2 l) => l.id).ToArray());
			data.SetStringArray("Licenses_Jobs", acquiredJobLicenses.Select((JobLicenseType_v2 l) => l.id).ToArray());
			data.SetStringArray("Garages", unlockedGarages.Select((GarageType_v2 g) => g.id).ToArray());
			unsavedChanges = false;
		}
	}

	private List<T> ProcessListOfIDs<T>(IEnumerable<string> idList, IEnumerable<T> sourceList) where T : Thing_v2
	{
		if (idList == null)
		{
			return new List<T>();
		}
		List<T> list = new List<T>();
		foreach (string id in idList)
		{
			T val = sourceList.FirstOrDefault((T t) => t.id == id);
			if (val != null)
			{
				list.Add(val);
			}
			else
			{
				Debug.LogError("Unknown thing (" + typeof(T).Name + ") ID in save file: " + id);
			}
		}
		return list;
	}

	public void GrabAllGameModeSpecificUnlockables(string gameMode)
	{
		ProcessListOfIDs(GetAllAvailableForGameMode(Globals.G.Types.generalLicenses, gameMode), Globals.G.Types.generalLicenses).ForEach(delegate(GeneralLicenseType_v2 l)
		{
			AcquireGeneralLicense(l);
		});
		ProcessListOfIDs(GetAllAvailableForGameMode(Globals.G.Types.jobLicenses, gameMode), Globals.G.Types.jobLicenses).ForEach(delegate(JobLicenseType_v2 l)
		{
			AcquireJobLicense(l);
		});
		ProcessListOfIDs(GetAllAvailableForGameMode(Globals.G.Types.garages, gameMode), Globals.G.Types.garages).ForEach(delegate(GarageType_v2 g)
		{
			UnlockGarage(g);
		});
	}

	public static IEnumerable<string> GetAllAvailableForGameMode<T>(IEnumerable<T> thingsCollection, string gameMode) where T : Thing_v2, IFreeRoamAvailability
	{
		List<string> list = new List<string>();
		if (gameMode == "FreeRoam")
		{
			list.AddRange(from t in thingsCollection
				where t.FreeRoamAvailability != FreeRoamAvailability.NEVER && (t.FreeRoamAvailability == FreeRoamAvailability.ALWAYS || SingletonBehaviour<UnlockablesManager>.Instance.IsThingUnlocked(t))
				select t.id);
		}
		return list;
	}

	public void LoadData(SaveGameData data)
	{
		ProcessListOfIDs(data.GetStringArray("Licenses_General"), Globals.G.Types.generalLicenses).ForEach(delegate(GeneralLicenseType_v2 l)
		{
			AcquireGeneralLicense(l);
		});
		ProcessListOfIDs(data.GetStringArray("Licenses_Jobs"), Globals.G.Types.jobLicenses).ForEach(delegate(JobLicenseType_v2 l)
		{
			AcquireJobLicense(l);
		});
		ProcessListOfIDs(data.GetStringArray("Garages"), Globals.G.Types.garages).ForEach(delegate(GarageType_v2 g)
		{
			UnlockGarage(g);
		});
		if (!TutorialHelper.InRestrictedMode)
		{
			foreach (GeneralLicenseType_v2 tutorialGeneralLicense in TutorialGeneralLicenses)
			{
				if (!acquiredGeneralLicenses.Contains(tutorialGeneralLicense) && !TutorialHelper.InRestrictedMode)
				{
					Debug.LogError(tutorialGeneralLicense.name + " is not acquired in savegame. It should be acquired in tutorial. Acquiring in attempt to fix the problem, but something is wrong.");
					AcquireGeneralLicense(tutorialGeneralLicense);
					BookletCreator.CreateLicense(tutorialGeneralLicense, Vector3.zero, Quaternion.identity, WorldMover.OriginShiftParent);
				}
			}
			JobLicenseType_v2 jobLicenseType_v = JobLicenses.FreightHaul.ToV2();
			if (!IsJobLicenseAcquired(jobLicenseType_v))
			{
				Debug.LogError("FreightHaul is not acquired in savegame. It should be acquired in tutorial. Acquiring in attempt to fix the problem.");
				AcquireJobLicense(jobLicenseType_v);
				BookletCreator.CreateLicense(jobLicenseType_v, Vector3.zero, Quaternion.identity, WorldMover.OriginShiftParent);
			}
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("Loaded Licenses and Garages:");
		stringBuilder.Append("GL: ");
		foreach (GeneralLicenseType_v2 generalAcquiredLicense in GetGeneralAcquiredLicenses())
		{
			stringBuilder.Append($"{generalAcquiredLicense}, ");
		}
		stringBuilder.AppendLine();
		stringBuilder.AppendLine($"JL: {GetAcquiredJobLicenses()}");
		foreach (GarageType_v2 unlockedGarage in GetUnlockedGarages())
		{
			stringBuilder.AppendLine($"G: {unlockedGarage}");
		}
		Debug.Log(stringBuilder.ToString());
	}
}
