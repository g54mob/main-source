using System;
using NSEipix.Base;
using UnityEngine;

namespace NSMedieval.Testing.Autoplay
{
	[Serializable]
	public class AutoplayConfig : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private bool flattenMap;

		[SerializeField]
		private bool spawnResources = true;

		[SerializeField]
		private bool dontDisposeResource;

		[SerializeField]
		private bool disableWorkerStats;

		[SerializeField]
		private bool disableWorkerSkills;

		[SerializeField]
		private bool disablePlants;

		[SerializeField]
		private bool disableFish;

		[SerializeField]
		private bool disableAnimals;

		[SerializeField]
		private int workerMovementSpeed;

		[SerializeField]
		private int workerConstructionSpeed;

		[SerializeField]
		private string mapType;

		[SerializeField]
		private string mapSize;

		public bool FlattenMap => flattenMap;

		public bool SpawnResources => spawnResources;

		public bool DontDisposeResource => dontDisposeResource;

		public bool DisableWorkerStats => disableWorkerStats;

		public bool DisableWorkerSkills => disableWorkerSkills;

		public bool DisablePlants => disablePlants;

		public bool DisableFish => disableFish;

		public bool DisableAnimals => disableAnimals;

		public int WorkerMovementSpeed => workerMovementSpeed;

		public int WorkerConstructionSpeed => workerConstructionSpeed;

		public string MapType => mapType;

		public string MapSize => mapSize;

		public override string GetID()
		{
			return id;
		}
	}
}
