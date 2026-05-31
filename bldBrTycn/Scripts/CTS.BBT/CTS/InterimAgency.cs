using System;
using System.Collections.Generic;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.Utilities;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class InterimAgency : MonoSingleton<InterimAgency>
	{
		[SerializeField]
		private CameraFadeTraveling cameraBar;

		[SerializeField]
		private int maxSpawnCount = 4;

		[SerializeField]
		private int _defaultRefreshCooldown = 10;

		[SerializeField]
		private Transform[] barEntranceSpawnPoints;

		[SerializeField]
		private bool _debug;

		private GameObject _barUI;

		[SerializeField]
		private StringKey[] _canvasesToClose;

		private SpawnPoint[] _spawnPoints;

		private List<SpawnPoint> freeSpawnPoints = new List<SpawnPoint>();

		private Dictionary<Worker, SpawnPoint> spawnedWorkers = new Dictionary<Worker, SpawnPoint>();

		private int _currentUsedBarSpawnpoint;

		private CameraFadeTraveling _cameraAgency;

		private LockToggle _timeScaleToggler;

		private LockToggle _agentStatsLock = new LockToggle();

		private static int _hiringMultiplier;

		[field: SerializeField]
		public WorkerParameters Parameters { get; private set; }

		public bool isInAgnecy { get; private set; }

		public int RefreshCooldown { get; private set; } = 1;

		public ReadOnlyDictionary<Worker, SpawnPoint> SpawnedWorkers => spawnedWorkers;

		public static int HiringMultiplier => _hiringMultiplier;

		public int NextRefresh { get; private set; }

		public static bool IsWorkerSalaryFree { get; private set; }

		public static event Action SwitchingScene;

		public event Action OnInterimEnter;

		public event Action OnInterimExit;

		public static event Action OnAgencyEnter;

		public static event Action OnAgencyQuit;

		public static event Action OnInterimHiringAlterationChanged;

		public static event Action RefreshChanged;

		protected override void SingletonAwake()
		{
			_hiringMultiplier = 0;
			IsWorkerSalaryFree = false;
			SetRefreshCooldown(_defaultRefreshCooldown);
		}

		protected override void OnSingletonDestroy()
		{
			if (isInAgnecy && MonoSingleton<CameraTravelingHandler>.InstanceExists())
			{
				MonoSingleton<CameraTravelingHandler>.Instance.LockAll(p_toLockAll: false);
			}
			CalendarHandlers.NewDay -= OnNewDay;
		}

		private void Start()
		{
			_agentStatsLock.Lock();
			_timeScaleToggler = new LockToggle(MonoSingleton<TimeController>.Instance);
			_cameraAgency = GetComponentInChildren<CameraFadeTraveling>();
			_barUI = GameObject.Find("BarUI");
			_spawnPoints = GetComponentsInChildren<SpawnPoint>();
			FullfillSpawnPoint();
			MonthlyRefresh();
			CalendarHandlers.NewDay += OnNewDay;
			for (int i = 0; i < _spawnPoints.Length; i++)
			{
				Transform child = _spawnPoints[i].transform.GetChild(0);
				if (child != null)
				{
					UnityEngine.Object.Destroy(child.gameObject);
				}
			}
		}

		private void OnNewDay()
		{
			SetNextRefresh(NextRefresh - 1);
		}

		public void SetRefreshCooldown(int dayCount)
		{
			dayCount = Math.Max(1, dayCount);
			if (RefreshCooldown != dayCount)
			{
				int num = RefreshCooldown - dayCount;
				RefreshCooldown = dayCount;
				SetNextRefresh(NextRefresh - num);
			}
		}

		public void ResetRefreshCooldown()
		{
			SetRefreshCooldown(_defaultRefreshCooldown);
		}

		public void SetNextRefresh(int count)
		{
			count = Math.Max(0, count);
			if (count != NextRefresh)
			{
				NextRefresh = count;
				InterimAgency.RefreshChanged?.Invoke();
				if (NextRefresh <= 0)
				{
					MonthlyRefresh();
				}
			}
		}

		public Transform GetCurrentBarSpawnpoint()
		{
			Transform result = barEntranceSpawnPoints[_currentUsedBarSpawnpoint];
			_currentUsedBarSpawnpoint++;
			if (_currentUsedBarSpawnpoint >= barEntranceSpawnPoints.Length)
			{
				_currentUsedBarSpawnpoint = 0;
			}
			return result;
		}

		public static int GetWorkerCost(Worker worker)
		{
			if (IsWorkerSalaryFree)
			{
				return 0;
			}
			int num = Mathf.FloorToInt((float)worker.Salary * worker.WorkerParameters.EngageCostMultiplier);
			num += HiringMultiplier;
			return Math.Max(0, num);
		}

		public void GoToAgency()
		{
			if (isInAgnecy)
			{
				return;
			}
			InterimAgency.SwitchingScene?.Invoke();
			_currentUsedBarSpawnpoint = 0;
			_timeScaleToggler.Lock();
			CameraFadeTraveling cameraFadeTraveling = cameraBar;
			cameraFadeTraveling.onFinishedMovement = (Action)Delegate.Combine(cameraFadeTraveling.onFinishedMovement, new Action(OnBarCameraGoToAgency));
			cameraBar.TestTravelingStart();
			StringKey[] canvasesToClose = _canvasesToClose;
			foreach (StringKey exclusivityKey in canvasesToClose)
			{
				CanvasExclusivity.Close(null, exclusivityKey);
			}
			foreach (Worker key in spawnedWorkers.Keys)
			{
				for (int j = 0; j < key.BarVisuals.Length; j++)
				{
					key.BarVisuals[j].SetVisible(p_visible: true);
				}
			}
			this.OnInterimEnter?.Invoke();
		}

		public void QuitAgency()
		{
			if (isInAgnecy)
			{
				InterimAgency.SwitchingScene?.Invoke();
				MonoSingleton<AgentPanelGroup>.Instance.HidePanel();
				SetIsInAgency(p_inAgency: false);
				CameraFadeTraveling cameraAgency = _cameraAgency;
				cameraAgency.onFinishedMovement = (Action)Delegate.Combine(cameraAgency.onFinishedMovement, new Action(OnAgencyCameraGoToBar));
				_cameraAgency.TestBackTraveling();
				this.OnInterimExit?.Invoke();
			}
		}

		private void SetIsInAgency(bool p_inAgency)
		{
			isInAgnecy = p_inAgency;
		}

		public void Clear()
		{
			foreach (var (worker2, _) in spawnedWorkers)
			{
				if (worker2 != null)
				{
					UnityEngine.Object.Destroy(worker2.gameObject);
				}
			}
			spawnedWorkers.Clear();
			FullfillSpawnPoint();
		}

		public void Import(Worker worker)
		{
			if (worker == null)
			{
				Debug.LogException(new NullReferenceException("Cannot import a null worker"));
				return;
			}
			if (!worker.IsEngaged)
			{
				_agentStatsLock.Add(worker.Statistics);
				worker.SetEngagable();
			}
			else
			{
				WorkerList.Add(worker);
			}
			SpawnPoint[] spawnPoints = _spawnPoints;
			foreach (SpawnPoint spawnPoint in spawnPoints)
			{
				if (Vector3.Distance(worker.transform.position, spawnPoint.transform.position) <= 0.1f)
				{
					spawnedWorkers.Add(worker, spawnPoint);
					freeSpawnPoints.Remove(spawnPoint);
					break;
				}
			}
		}

		public void RemoveWorker(Worker p_worker, bool p_destroy = false)
		{
			if (spawnedWorkers.ContainsKey(p_worker))
			{
				freeSpawnPoints.Add(spawnedWorkers[p_worker]);
				spawnedWorkers.Remove(p_worker);
				_agentStatsLock.Remove(p_worker.Statistics);
			}
			if (!p_destroy)
			{
				SetHiringCostMultiplier(0);
				SetWorkerSalaryFree(isFree: false);
			}
			else if (p_worker != null)
			{
				UnityEngine.Object.Destroy(p_worker.gameObject);
			}
		}

		public void SetHiringCostMultiplier(int value)
		{
			_hiringMultiplier = value;
			InterimAgency.OnInterimHiringAlterationChanged?.Invoke();
		}

		public void SetWorkerSalaryFree(bool isFree)
		{
			IsWorkerSalaryFree = isFree;
			InterimAgency.OnInterimHiringAlterationChanged?.Invoke();
		}

		private void OnBarCameraGoToAgency()
		{
			InterimAgency.OnAgencyEnter?.Invoke();
			WorldSelector.DeselectAll();
			cameraBar.TeleportMeToMainCamera();
			_cameraAgency.TeleportMainCameraHere();
			CameraFadeTraveling cameraAgency = _cameraAgency;
			cameraAgency.onFinishedMovement = (Action)Delegate.Combine(cameraAgency.onFinishedMovement, new Action(OnCameraAgentEnterInAgency));
			_cameraAgency.TestTravelingStart();
			_barUI.SetActive(value: false);
			CameraFadeTraveling cameraFadeTraveling = cameraBar;
			cameraFadeTraveling.onFinishedMovement = (Action)Delegate.Remove(cameraFadeTraveling.onFinishedMovement, new Action(OnBarCameraGoToAgency));
		}

		private void OnCameraAgentEnterInAgency()
		{
			SetIsInAgency(p_inAgency: true);
			CameraFadeTraveling cameraAgency = _cameraAgency;
			cameraAgency.onFinishedMovement = (Action)Delegate.Remove(cameraAgency.onFinishedMovement, new Action(OnCameraAgentEnterInAgency));
		}

		public void OnAgencyCameraGoToBar()
		{
			cameraBar.TeleportMainCameraHere();
			_barUI.SetActive(value: true);
			cameraBar.TestBackTraveling();
			_timeScaleToggler.Unlock();
			CameraFadeTraveling cameraAgency = _cameraAgency;
			cameraAgency.onFinishedMovement = (Action)Delegate.Remove(cameraAgency.onFinishedMovement, new Action(OnAgencyCameraGoToBar));
			InterimAgency.OnAgencyQuit?.Invoke();
			WorldSelector.DeselectAll();
		}

		private void FullfillSpawnPoint()
		{
			freeSpawnPoints.Clear();
			freeSpawnPoints.AddRange(_spawnPoints);
		}

		private SpawnPoint GetFreeSpawnPoint()
		{
			if (freeSpawnPoints.Count == 0)
			{
				return null;
			}
			int index = UnityEngine.Random.Range(0, freeSpawnPoints.Count);
			SpawnPoint result = freeSpawnPoints[index];
			freeSpawnPoints.RemoveAt(index);
			return result;
		}

		[Button(null, EButtonEnableMode.Always)]
		private void MonthlyRefresh()
		{
			List<Worker> list = new List<Worker>();
			List<int> list2 = new List<int>();
			list2.Add(5);
			list2.Add(3);
			list2.Add(2);
			list2.Add(2);
			list2.Add(1);
			list2.Add(1);
			list2.Add(1);
			foreach (Worker key in spawnedWorkers.Keys)
			{
				list.Add(key);
			}
			for (int i = 0; i < list.Count; i++)
			{
				RemoveWorker(list[i], p_destroy: true);
			}
			int num = 0;
			if (maxSpawnCount > _spawnPoints.Length)
			{
				maxSpawnCount = _spawnPoints.Length;
			}
			for (int j = spawnedWorkers.Count; j < maxSpawnCount; j++)
			{
				SpawnPoint freeSpawnPoint = GetFreeSpawnPoint();
				if (freeSpawnPoint == null)
				{
					break;
				}
				Worker worker = MonoSingleton<WorkerSpawner>.Instance.Spawn(freeSpawnPoint.transform, list2[num], Parameters);
				spawnedWorkers.Add(worker, freeSpawnPoint);
				_agentStatsLock.Add(worker.Statistics);
				num++;
			}
			SetNextRefresh(RefreshCooldown);
		}
	}
}
