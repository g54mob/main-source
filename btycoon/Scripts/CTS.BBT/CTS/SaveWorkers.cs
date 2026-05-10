using System;
using System.Collections.Generic;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.Pooling;
using CTS.Core.Utilities;
using CTS.Utilities;
using UnityEngine;

namespace CTS
{
	public class SaveWorkers : SaveContainer
	{
		private const string WorkerPath = "Assets/Prefabs/Units/Worker.prefab";

		private static readonly Addressable<Worker> _workerPrefab = "Assets/Prefabs/Units/Worker.prefab";

		private static readonly HashSet<(int, Worker)> _loadedWorkers = new HashSet<(int, Worker)>();

		public override void Save(ES3Settings settings)
		{
			List<GameObject> workerList = new List<GameObject>();
			AddWorkersToList<ReadOnlyHashSet<Worker>>(WorkerList.All);
			AddWorkersToList<Dictionary<Worker, SpawnPoint>.KeyCollection>(MonoSingleton<InterimAgency>.Instance.SpawnedWorkers.Keys);
			ES3.Save("AgencyRefreshCooldown", MonoSingleton<InterimAgency>.Instance.RefreshCooldown, settings);
			ES3.Save("AgencyRefreshCooldownProgress", MonoSingleton<InterimAgency>.Instance.NextRefresh, settings);
			ES3.Save("Discount", InterimAgency.HiringMultiplier, settings);
			ES3.Save("FreeSalary", InterimAgency.IsWorkerSalaryFree, settings);
			ES3.Save("WorkerCount", workerList.Count, settings);
			for (int i = 0; i < workerList.Count; i++)
			{
				ES3.Save("Worker" + i, workerList[i], settings);
			}
			void AddWorkersToList<T>(T list) where T : IEnumerable<Worker>
			{
				foreach (Worker item in list)
				{
					if (item == null)
					{
						Debug.LogException(new NullReferenceException($"Trying to save a null worker, unity null? {(object)item != null}"));
					}
					else if (item.gameObject.activeSelf && !workerList.Contains(item.gameObject))
					{
						workerList.Add(item.gameObject);
					}
				}
			}
		}

		public override void Clear()
		{
			MonoSingleton<InterimAgency>.Instance.Clear();
		}

		public override void LoadInit(ES3Settings settings)
		{
			_loadedWorkers.Clear();
			MonoSingleton<InterimAgency>.Instance.Clear();
			int num = ES3.Load("WorkerCount", 0, settings);
			for (int i = 0; i < num; i++)
			{
				Worker worker = Pooler.Pull(_workerPrefab.Value, active: true);
				_loadedWorkers.Add((i, worker));
				ES3.LoadInto("Worker" + i, worker.gameObject, settings);
			}
		}

		public override void LoadPost(ES3Settings settings)
		{
			foreach (var (num, worker) in _loadedWorkers)
			{
				ES3.LoadInto("Worker" + num, worker.gameObject, settings);
				MonoSingleton<InterimAgency>.Instance.Import(worker);
			}
			foreach (var loadedWorker in _loadedWorkers)
			{
				Worker item = loadedWorker.Item2;
				if (item.Health.CurrentHealth <= 0)
				{
					item.Health.ForceDeath();
				}
			}
			MonoSingleton<InterimAgency>.Instance.SetHiringCostMultiplier(ES3.Load("Discount", 0, settings));
			MonoSingleton<InterimAgency>.Instance.SetWorkerSalaryFree(ES3.Load("FreeSalary", defaultValue: false, settings));
			_loadedWorkers.Clear();
			int refreshCooldown = ES3.Load("AgencyRefreshCooldown", 1, settings);
			MonoSingleton<InterimAgency>.Instance.SetRefreshCooldown(refreshCooldown);
			int nextRefresh = ES3.Load("AgencyRefreshCooldownProgress", 0, settings);
			MonoSingleton<InterimAgency>.Instance.SetNextRefresh(nextRefresh);
		}
	}
}
