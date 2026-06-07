using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ModApi.GameLoop;
using ModApi.GameLoop.Interfaces;
using UnityEngine;

namespace Assets.Scripts.GameLoop
{
	public abstract class GameLoopBase : MonoBehaviour, IGameLoop
	{
		protected const int DefaultParallelBatchSize = 2;

		protected const int DefaultParallelThreshold = 8;

		[SerializeField]
		private List<UpdateGroupDebugData> _debugData;

		[SerializeField]
		private bool _debugExecutionOrder;

		private int _debugExecutionOrderLastFrameCount;

		private Coroutine _endOfFrameCoroutine;

		private WaitForEndOfFrame _endOfFrameYieldInstruction;

		protected virtual void Awake()
		{
			_debugData = new List<UpdateGroupDebugData>();
		}

		protected abstract void EndOfFrame();

		protected abstract void FixedUpdate();

		protected UpdateGroupDebugCallback GetDebugCallback()
		{
			if (!_debugExecutionOrder)
			{
				return null;
			}
			return LogInspectorData;
		}

		protected abstract void LateUpdate();

		protected virtual void OnDisable()
		{
			CustomPlayerLoop.ClearUpdateActions();
			if (_endOfFrameCoroutine != null)
			{
				StopCoroutine(_endOfFrameCoroutine);
			}
			_endOfFrameCoroutine = null;
		}

		protected virtual void OnEnable()
		{
			CustomPlayerLoop.SetUpdateActions(PreFixedUpdate, PostFixedUpdate, PreUpdate, PostUpdate, PreLateUpdate, PostLateUpdate);
			_endOfFrameCoroutine = StartCoroutine(EndOfFrameCoroutine());
		}

		protected abstract void PostFixedUpdate();

		protected abstract void PostLateUpdate();

		protected abstract void PostUpdate();

		protected abstract void PreFixedUpdate();

		protected abstract void PreLateUpdate();

		protected abstract void PreUpdate();

		protected virtual void Start()
		{
		}

		protected abstract void Update();

		private IEnumerator EndOfFrameCoroutine()
		{
			_endOfFrameYieldInstruction = new WaitForEndOfFrame();
			while (true)
			{
				yield return _endOfFrameYieldInstruction;
				EndOfFrame();
			}
		}

		private void LogInspectorData(string name, bool parallel, int executionOrder, IEnumerable<IGameLoopItem> items)
		{
			if (Time.frameCount != _debugExecutionOrderLastFrameCount)
			{
				_debugData.Clear();
			}
			_debugData.Add(new UpdateGroupDebugData
			{
				Name = name,
				ExecutionOrderName = ExecutionOrder.FindName(executionOrder),
				MultipleThreads = parallel,
				ExecutionOrder = executionOrder,
				Items = items.Select((IGameLoopItem x) => x as MonoBehaviour).ToArray()
			});
			_debugExecutionOrderLastFrameCount = Time.frameCount;
		}
	}
}
