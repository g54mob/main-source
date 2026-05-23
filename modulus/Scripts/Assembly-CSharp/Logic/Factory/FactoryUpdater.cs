#define ENABLE_DEBUG_EXCEPTIONS
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.FactoryFloor;
using Data.FactoryFloor.Maps;
using Data.FactoryFloor.Simulation;
using Data.GameState;
using Data.SaveData.PersistentSOs;
using Data.Variables;
using Events;
using Events.FactoryFloor;
using NaughtyAttributes;
using UnityEngine;
using Utils;

namespace Logic.Factory
{
	public class FactoryUpdater : MonoBehaviour
	{
		private struct UpdateIslandContext
		{
			public int Step;

			public int IslandIndex;

			public double CurrentTime;

			public double WaitTime;

			public UpdateIslandContext(int step, int islandIndex, double currentTime, double waitTime)
			{
				Step = step;
				IslandIndex = islandIndex;
				CurrentTime = currentTime;
				WaitTime = waitTime;
			}
		}

		[SerializeField]
		private FactoryUpdaterPersistentSO _factoryUpdaterPersistentSO;

		[SerializeField]
		private FactoryLayer _factoryLayer;

		[SerializeField]
		private IslandLayer _islandLayer;

		[SerializeField]
		private IntVariableSO _globalUpdateMultiplier;

		[SerializeField]
		private IntVariableSO _conveyorUpdateFrequency;

		[SerializeField]
		private IntVariableSO _stepsPerSecond;

		[SerializeField]
		private FactoryStepEvent _factoryStepEvent;

		[SerializeField]
		private PauseStateData _pauseState;

		[SerializeField]
		private BaseEvent _finishedLoadingSaveEvent;

		[SerializeField]
		private BaseEvent _levelClearedEvent;

		[SerializeField]
		private bool _drawGizmos;

		[SerializeField]
		private bool _startOnLevelLoad = true;

		[SerializeField]
		private bool _runOnSingleThread;

		private static FactoryUpdater _instance;

		private bool _isSubscribed;

		private double _waitTime;

		private double _subWaitTime;

		private double _lastStepTime;

		private double _pauseDeltaStepTime;

		private Coroutine _calculatePathsCoroutine;

		private readonly List<FactoryUpdateOrder> _islandUpdateOrders = new List<FactoryUpdateOrder>();

		private bool _initialized;

		private Task _updateTask;

		private readonly List<UpdateIslandContext> _islandUpdateContexts = new List<UpdateIslandContext>();

		private int Step
		{
			get
			{
				return _factoryUpdaterPersistentSO.Step;
			}
			set
			{
				_factoryUpdaterPersistentSO.Step = value;
			}
		}

		private int IslandIndex
		{
			get
			{
				return _factoryUpdaterPersistentSO.IslandIndex;
			}
			set
			{
				_factoryUpdaterPersistentSO.IslandIndex = value;
			}
		}

		public int CurrentStep => Step;

		public static FactoryUpdater Instance => _instance;

		public IntVariableSO ConveyorUpdateFrequency => _conveyorUpdateFrequency;

		public double WaitTime => _waitTime;

		public event Action OnFactorySpeedChanged = delegate
		{
		};

		private void Awake()
		{
			if (_instance != null)
			{
				UnityEngine.Object.Destroy(base.gameObject);
				return;
			}
			_instance = this;
			_globalUpdateMultiplier.ValueChanged += UpdateWaitTime;
			_stepsPerSecond.ValueChanged += UpdateWaitTime;
			_globalUpdateMultiplier.ValueChanged += UpdateConveyorSpeed;
			_conveyorUpdateFrequency.ValueChanged += UpdateConveyorSpeed;
			_pauseState.PauseStateChanged += CallFactorySpeedChanged;
			_stepsPerSecond.ValueChanged += CallFactorySpeedChanged;
			_globalUpdateMultiplier.ValueChanged += CallFactorySpeedChanged;
			UpdateWaitTime(0);
			UpdateConveyorSpeed(0);
			if (_globalUpdateMultiplier.Value == 0)
			{
				this.DevException("Don't start the game with global update multiplier set to 0!!?!", "Awake", 97);
			}
		}

		private void Start()
		{
			_lastStepTime = Time.timeAsDouble;
			_pauseState.PauseStateChanged += PauseStateChanged;
			_levelClearedEvent.Register(UnInit);
			_finishedLoadingSaveEvent.Register(InitializeIslandUpdateOrders);
			if (_startOnLevelLoad)
			{
				_finishedLoadingSaveEvent.Register(Init);
			}
			SubscribeToObjectsInlayerChanged();
		}

		private void OnDestroy()
		{
			_globalUpdateMultiplier.ValueChanged -= UpdateWaitTime;
			_stepsPerSecond.ValueChanged -= UpdateWaitTime;
			_globalUpdateMultiplier.ValueChanged -= UpdateConveyorSpeed;
			_conveyorUpdateFrequency.ValueChanged -= UpdateConveyorSpeed;
			_pauseState.PauseStateChanged -= CallFactorySpeedChanged;
			_stepsPerSecond.ValueChanged -= CallFactorySpeedChanged;
			_globalUpdateMultiplier.ValueChanged -= CallFactorySpeedChanged;
			_pauseState.PauseStateChanged -= PauseStateChanged;
			_levelClearedEvent.UnRegister(UnInit);
			_finishedLoadingSaveEvent.UnRegister(InitializeIslandUpdateOrders);
			_finishedLoadingSaveEvent.UnRegister(Init);
			UnsubscribeFromObjectsInlayerChanged();
		}

		private void CallFactorySpeedChanged(int _)
		{
			this.OnFactorySpeedChanged();
		}

		private void CallFactorySpeedChanged(bool _)
		{
			this.OnFactorySpeedChanged();
		}

		[Button(null, EButtonEnableMode.Always)]
		private void Init()
		{
			_lastStepTime = Time.timeAsDouble;
			_initialized = true;
		}

		[Button(null, EButtonEnableMode.Always)]
		private void UnInit()
		{
			UnsubscribeFromObjectsInlayerChanged();
			_initialized = false;
			_islandUpdateOrders.Clear();
			_islandUpdateContexts.Clear();
		}

		private void InitializeIslandUpdateOrders()
		{
			_islandUpdateOrders.Clear();
			_islandUpdateContexts.Clear();
			List<IslandObject> allIslands = _islandLayer.GetAllIslands();
			for (int i = 0; i < allIslands.Count; i++)
			{
				_islandUpdateOrders.Add(new FactoryUpdateOrder(_factoryLayer, allIslands[i]));
			}
			UpdateWaitTime(0);
			CalculatePaths();
			SubscribeToObjectsInlayerChanged();
		}

		private void SubscribeToObjectsInlayerChanged()
		{
			if (_isSubscribed)
			{
				return;
			}
			foreach (FactoryUpdateOrder islandUpdateOrder in _islandUpdateOrders)
			{
				islandUpdateOrder.Subscribe();
			}
			_isSubscribed = true;
		}

		private void UnsubscribeFromObjectsInlayerChanged()
		{
			if (!_isSubscribed)
			{
				return;
			}
			foreach (FactoryUpdateOrder islandUpdateOrder in _islandUpdateOrders)
			{
				islandUpdateOrder.Unsubscribe();
			}
			_isSubscribed = false;
		}

		private void UpdateWaitTime(int _)
		{
			_waitTime = 1.0 / (double)_stepsPerSecond.Value / (double)_globalUpdateMultiplier.Value;
			_subWaitTime = _waitTime / (double)Mathf.Max(1, _islandUpdateOrders.Count);
		}

		private void UpdateConveyorSpeed(int _)
		{
			Shader.SetGlobalFloat("_ConveyorSpeed", (float)_stepsPerSecond.Value / (float)_conveyorUpdateFrequency.Value * (float)_globalUpdateMultiplier.Value);
		}

		public int GetStepsPerSecond()
		{
			return _stepsPerSecond.Value * _globalUpdateMultiplier.Value;
		}

		public int GetUnscaledStepsPerSecond()
		{
			return _stepsPerSecond.Value;
		}

		public float GetProcessTicksToRealTime(int processTicks)
		{
			return (float)processTicks / (float)GetUnscaledStepsPerSecond();
		}

		private void LateUpdate()
		{
			if (!_initialized || _globalUpdateMultiplier.Value == 0 || _islandUpdateOrders.Count == 0)
			{
				return;
			}
			_islandUpdateContexts.Clear();
			int startIslandIndex = IslandIndex;
			while (Time.timeAsDouble > _lastStepTime + _subWaitTime)
			{
				_islandUpdateContexts.Add(new UpdateIslandContext(Step, IslandIndex, _lastStepTime + _subWaitTime, _waitTime));
				IslandIndex++;
				if (IslandIndex >= _islandUpdateOrders.Count)
				{
					IslandIndex = 0;
					Step++;
				}
				_lastStepTime += _subWaitTime;
			}
			_updateTask = null;
			if (_islandUpdateContexts.Count > 0)
			{
				_updateTask = Task.Run((Func<Task>)ExecuteRunTasksAsync);
			}
			Task ExecuteRunTasksAsync()
			{
				return RunTasksAsync(startIslandIndex);
			}
		}

		private async Task RunTasksAsync(int startIslandIndex)
		{
			List<Task> updateTasks = new List<Task>();
			foreach (UpdateIslandContext islandUpdateContext in _islandUpdateContexts)
			{
				UpdateIslandContext context = islandUpdateContext;
				if (context.IslandIndex == 0)
				{
					Task item = Task.Run((Func<Task>)ExecuteFireFactoryStepEventAsync);
					updateTasks.Add(item);
				}
				if (context.IslandIndex == startIslandIndex && updateTasks.Count > 0)
				{
					Task.WaitAll(updateTasks.ToArray());
					updateTasks.Clear();
				}
				if (_runOnSingleThread)
				{
					await UpdateFactoryIslandAsync(context);
					continue;
				}
				Task item2 = Task.Run((Func<Task>)ExecuteUpdateFactoryIslandAsync);
				updateTasks.Add(item2);
				Task ExecuteFireFactoryStepEventAsync()
				{
					return FireFactoryStepEventAsync(context.Step);
				}
				Task ExecuteUpdateFactoryIslandAsync()
				{
					return UpdateFactoryIslandAsync(context);
				}
			}
		}

		internal void CompleteTasks()
		{
			if (_updateTask != null && !_updateTask.IsCompleted)
			{
				Task.WaitAll(_updateTask);
			}
		}

		private async Task UpdateFactoryIslandAsync(UpdateIslandContext context)
		{
			_islandUpdateOrders[context.IslandIndex].UpdateObjects(context.Step + context.IslandIndex * 5);
			_islandUpdateOrders[context.IslandIndex].SetLastUpdateTime(context.CurrentTime, context.WaitTime);
		}

		private async Task FireFactoryStepEventAsync(int step)
		{
			_factoryStepEvent.Fire(step);
		}

		private void PauseStateChanged(bool paused)
		{
			if (paused)
			{
				_pauseDeltaStepTime = Time.timeAsDouble - _lastStepTime;
			}
			else
			{
				_lastStepTime = Time.timeAsDouble - _pauseDeltaStepTime;
			}
		}

		private void CalculatePaths()
		{
			if (_calculatePathsCoroutine != null)
			{
				StopCoroutine(_calculatePathsCoroutine);
			}
			_calculatePathsCoroutine = StartCoroutine(CalculatePathsAfterDelay());
		}

		private IEnumerator CalculatePathsAfterDelay()
		{
			yield return new WaitForFixedUpdate();
			foreach (FactoryUpdateOrder islandUpdateOrder in _islandUpdateOrders)
			{
				islandUpdateOrder.CalculateUpdateOrder();
			}
		}

		private void OnDrawGizmos()
		{
			if (!_drawGizmos || _islandUpdateOrders.Count <= 0)
			{
				return;
			}
			foreach (FactoryUpdateOrder islandUpdateOrder in _islandUpdateOrders)
			{
				for (int i = 1; i < islandUpdateOrder.UpdateOrder.Count; i++)
				{
					float g = (float)i / (float)islandUpdateOrder.UpdateOrder.Count;
					Gizmos.color = Color.Lerp(new Color(1f, g, 0f), new Color(0f, g, 1f), (float)(i % 10) / 10f);
					Gizmos.DrawLine(islandUpdateOrder.UpdateOrder[i].Position + new Vector3(0.5f, 0.5f, 0.5f), islandUpdateOrder.UpdateOrder[i - 1].Position + new Vector3(0.5f, 0.5f, 0.5f));
					Gizmos.DrawWireSphere(islandUpdateOrder.UpdateOrder[i].Position + new Vector3(0.5f, 0.5f, 0.5f), 0.25f);
				}
			}
		}

		[Button(null, EButtonEnableMode.Always)]
		private void StepForward()
		{
			_factoryStepEvent.Fire(Step);
			foreach (FactoryUpdateOrder islandUpdateOrder in _islandUpdateOrders)
			{
				islandUpdateOrder.UpdateObjects(Step);
				islandUpdateOrder.SetLastUpdateTime(_lastStepTime + _subWaitTime, _waitTime);
			}
			Step++;
		}

		[Button(null, EButtonEnableMode.Always)]
		private void StepForwardConveyorUpdateFrequency()
		{
			for (int i = 0; i < _conveyorUpdateFrequency.Value; i++)
			{
				StepForward();
			}
		}
	}
}
