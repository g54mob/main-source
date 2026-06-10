using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.UI.Utils;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.Model.SecondMap
{
	[Serializable]
	public class SecondMapSaveInfo : NSEipix.Base.Model
	{
		[SerializeField]
		private string name;

		[SerializeField]
		private string fileName;

		[NonSerialized]
		private string originalFolderName;

		[NonSerialized]
		private string originalFileName;

		[SerializeField]
		private int type;

		[SerializeField]
		private int raidPoints;

		[SerializeField]
		private string id = string.Empty;

		[SerializeField]
		private List<SpawnPoint> spawnPoints;

		[SerializeField]
		private string biomeType;

		[SerializeField]
		private LocKeys[] locKeys;

		[SerializeField]
		private bool hasHostiles;

		[SerializeField]
		private string[] hasUniqueResources;

		private Dictionary<int, Dictionary<SpawnPointType, List<SpawnPoint>>> spawnPointsBySet;

		private SecondMapType cachedType;

		public string Id
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

		public string Name
		{
			get
			{
				return name;
			}
			set
			{
				name = value;
			}
		}

		public string FileName
		{
			get
			{
				return fileName;
			}
			set
			{
				fileName = value;
			}
		}

		public string OriginalFolderName
		{
			get
			{
				return originalFolderName;
			}
			set
			{
				originalFolderName = value;
			}
		}

		public string OriginalFileName
		{
			get
			{
				return originalFileName;
			}
			set
			{
				originalFileName = value;
			}
		}

		public SecondMapType Type
		{
			get
			{
				if (cachedType == SecondMapType.None)
				{
					cachedType = (SecondMapType)type;
				}
				return cachedType;
			}
		}

		public int RawType
		{
			get
			{
				return type;
			}
			set
			{
				type = value;
				cachedType = (SecondMapType)value;
			}
		}

		public int RaidPoints
		{
			get
			{
				return raidPoints;
			}
			set
			{
				raidPoints = value;
			}
		}

		public string BiomeType
		{
			get
			{
				return biomeType;
			}
			set
			{
				biomeType = value;
			}
		}

		public bool HasHostiles
		{
			get
			{
				return hasHostiles;
			}
			set
			{
				hasHostiles = value;
			}
		}

		public IEnumerable<SpawnPoint> AllSpawnPoints => spawnPoints;

		public string LoadingScreenTitle => LocKeyUtils.GetName(locKeys);

		public string LoadingScreenDescription => LocKeyUtils.GetDescription(locKeys);

		public string[] HasUniqueResources => hasUniqueResources;

		public List<SpawnPoint> GetSpawnPoints(SpawnPointType type, int setIndex = 0)
		{
			if (spawnPointsBySet == null)
			{
				RebuildSpawnPointDictionary();
			}
			return spawnPointsBySet.GetValueOrDefault(setIndex).GetValueOrDefault(type);
		}

		public bool HasSpawnPointsType(SpawnPointType type, int setIndex = 0)
		{
			if (spawnPointsBySet == null)
			{
				RebuildSpawnPointDictionary();
			}
			if (spawnPointsBySet == null || !spawnPointsBySet.ContainsKey(setIndex))
			{
				return false;
			}
			Dictionary<SpawnPointType, List<SpawnPoint>> dictionary = spawnPointsBySet[setIndex];
			if (dictionary.ContainsKey(type))
			{
				return dictionary[type].Count > 0;
			}
			return false;
		}

		public bool HasSpawnPointsSet(int setIndex = 0)
		{
			if (spawnPointsBySet == null)
			{
				RebuildSpawnPointDictionary();
			}
			if (spawnPointsBySet.ContainsKey(setIndex))
			{
				return spawnPointsBySet[setIndex].Count > 0;
			}
			return false;
		}

		public int GetSetsCount()
		{
			if (spawnPointsBySet == null)
			{
				RebuildSpawnPointDictionary();
			}
			return spawnPointsBySet.Count;
		}

		public override string GetID()
		{
			return id;
		}

		public void SetSpawnPoints(List<SpawnPoint> spawnPoints)
		{
			this.spawnPoints = spawnPoints;
		}

		private void RebuildSpawnPointDictionary()
		{
			spawnPointsBySet = new Dictionary<int, Dictionary<SpawnPointType, List<SpawnPoint>>>();
			if (spawnPoints.Count == 0)
			{
				spawnPointsBySet[0] = new Dictionary<SpawnPointType, List<SpawnPoint>>();
				SpawnPointType[] spawnPointTypes = EnumValues.SpawnPointTypes;
				foreach (SpawnPointType key in spawnPointTypes)
				{
					spawnPointsBySet[0][key] = new List<SpawnPoint>();
				}
				return;
			}
			foreach (SpawnPoint spawnPoint in spawnPoints)
			{
				if (!spawnPointsBySet.ContainsKey(spawnPoint.SetIndex))
				{
					spawnPointsBySet[spawnPoint.SetIndex] = new Dictionary<SpawnPointType, List<SpawnPoint>>();
					SpawnPointType[] spawnPointTypes = EnumValues.SpawnPointTypes;
					foreach (SpawnPointType key2 in spawnPointTypes)
					{
						spawnPointsBySet[spawnPoint.SetIndex][key2] = new List<SpawnPoint>();
					}
				}
				spawnPointsBySet[spawnPoint.SetIndex][spawnPoint.Type].Add(spawnPoint);
			}
		}
	}
}
