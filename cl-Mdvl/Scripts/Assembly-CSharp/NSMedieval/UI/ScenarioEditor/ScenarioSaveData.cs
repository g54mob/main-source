using System;
using System.Collections.Generic;
using NSMedieval.Model;
using UnityEngine;

namespace NSMedieval.UI.ScenarioEditor
{
	[Serializable]
	public class ScenarioSaveData
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private LocKeys[] locKeys;

		[SerializeField]
		private string imageId;

		[SerializeField]
		private string difficulty;

		[SerializeField]
		private int startSeason;

		[SerializeField]
		private int startHour;

		[SerializeField]
		private string startEventId;

		[SerializeField]
		private string startingEventScheduleId;

		[SerializeField]
		private List<string> startMapTypes;

		[SerializeField]
		private Scenario.WorkerConstraints villagerConstraints = Scenario.WorkerConstraints.CreateInstance();

		[SerializeField]
		private List<SerializableIdValuePair> startingResources;

		[SerializeField]
		private List<SerializableIdValuePair> startingEquipment;

		[SerializeField]
		private List<SerializableIdValuePair> startingStructurePiles;

		[SerializeField]
		private List<string> technologyUnlocked;

		[SerializeField]
		private ScenarioAnimalData[] startingAnimals;

		[SerializeField]
		private SerializableIdValuePair[] gameParameters;

		[SerializeField]
		private List<string> allowedObjectives;

		[SerializeField]
		private string modifiedOnVersion;

		public List<string> TechnologyUnlocked
		{
			get
			{
				return technologyUnlocked;
			}
			set
			{
				technologyUnlocked = value;
			}
		}

		public Scenario.WorkerConstraints VillagerConstraints
		{
			get
			{
				return villagerConstraints;
			}
			set
			{
				villagerConstraints = value;
			}
		}

		public List<SerializableIdValuePair> StartingResources
		{
			get
			{
				return startingResources;
			}
			set
			{
				startingResources = value;
			}
		}

		public List<SerializableIdValuePair> StartingEquipment
		{
			get
			{
				return startingEquipment;
			}
			set
			{
				startingEquipment = value;
			}
		}

		public List<SerializableIdValuePair> StartingStructurePiles
		{
			get
			{
				return startingStructurePiles;
			}
			set
			{
				startingStructurePiles = value;
			}
		}

		public string ID
		{
			get
			{
				return id;
			}
			set
			{
				id = value;
			}
		}

		public int StartSeason
		{
			get
			{
				return startSeason;
			}
			set
			{
				startSeason = value;
			}
		}

		public LocKeys[] LocKeys
		{
			get
			{
				return locKeys;
			}
			set
			{
				locKeys = value;
			}
		}

		public ScenarioAnimalData[] StartingAnimals
		{
			get
			{
				return startingAnimals;
			}
			set
			{
				startingAnimals = value;
			}
		}

		public string ModifiedOnGameVersion
		{
			get
			{
				return modifiedOnVersion;
			}
			set
			{
				modifiedOnVersion = value;
			}
		}

		public SerializableIdValuePair[] GameParameters
		{
			get
			{
				return gameParameters;
			}
			set
			{
				gameParameters = value;
			}
		}

		public List<string> AllowedObjectives
		{
			get
			{
				return allowedObjectives;
			}
			set
			{
				allowedObjectives = value;
			}
		}

		public int StartHour
		{
			get
			{
				return startHour;
			}
			set
			{
				startHour = value;
			}
		}

		public string StartEventId
		{
			get
			{
				return startEventId;
			}
			set
			{
				startEventId = value;
			}
		}

		public string StartingEventScheduleId
		{
			get
			{
				return startingEventScheduleId;
			}
			set
			{
				startingEventScheduleId = value;
			}
		}

		public List<string> StartMapTypes
		{
			get
			{
				return startMapTypes;
			}
			set
			{
				startMapTypes = value;
			}
		}

		public string ImageId
		{
			get
			{
				return imageId;
			}
			set
			{
				imageId = value;
			}
		}

		public string Difficulty
		{
			get
			{
				return difficulty;
			}
			set
			{
				difficulty = value;
			}
		}
	}
}
