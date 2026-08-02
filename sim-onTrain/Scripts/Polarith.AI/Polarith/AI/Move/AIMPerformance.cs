using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Threading;
using UnityEngine;

namespace Polarith.AI.Move
{
	[AddComponentMenu("Polarith AI » Move/System/AIM Performance")]
	[HelpURL("http://docs.polarith.com/ai/component-aim-performance.html")]
	[DisallowMultipleComponent]
	public sealed class AIMPerformance : AIMContextEvaluation
	{
		private sealed class EvaluationWorker
		{
			public int FirstContext;

			public int LastContext;

			private ReadOnlyCollection<Context> threadedContexts;

			private AutoResetEvent startEvent = new AutoResetEvent(initialState: false);

			private AutoResetEvent doneEvent = new AutoResetEvent(initialState: false);

			private Thread thread;

			private bool running = true;

			private bool done = true;

			public bool Done => done;

			public EvaluationWorker(ReadOnlyCollection<Context> threadedContexts)
			{
				this.threadedContexts = threadedContexts;
				thread = new Thread(Work);
				thread.Start();
			}

			public void Terminate()
			{
				running = false;
				startEvent.Set();
				thread.Join();
			}

			public void ResetEvents()
			{
				startEvent.Reset();
				doneEvent.Reset();
			}

			public void StartWork()
			{
				startEvent.Set();
			}

			public void WaitUntilWorkIsDone()
			{
				doneEvent.WaitOne();
			}

			private void Work()
			{
				while (true)
				{
					startEvent.WaitOne();
					done = false;
					if (!running)
					{
						break;
					}
					if (LastContext <= threadedContexts.Count - 1)
					{
						for (int i = FirstContext; i <= LastContext; i++)
						{
							threadedContexts[i].Evaluate();
						}
					}
					done = true;
					doneEvent.Set();
				}
			}
		}

		[Tooltip("Determines the optimization method to be used for agent updates. This setting affects bothmultithreaded and non-multithreaded agents.\n\n'Synchronous': All agents marked as 'Threaded' are multithreaded on the set 'Threads', whereby the main thread blocks until the work of the sub-threads is done. Non-threaded agents are updated withina coroutine with the specified 'Update Frequency' instead.\n\n'Asynchronous': Just like 'Synchronous' but the main thread is non-blocking concerning the workload of the sub-threads.\n\n'Load Balanced': For non-threaded agents, everything that needs to be calculated on the main thread is distributed equally over the available frames resulting in extra smooth frame rates even in single-threaded applications.")]
		public PerformanceType Performance = PerformanceType.LoadBalanced;

		[Tooltip("Determines how much threads should be used. Note that the number of threads which are actually used cannot be greater than the number of (virtual) processors. Moreover, a change of this value is only recognized at start or when this component gets disabled and re-enabled again.")]
		[Range(1f, 64f)]
		public int Threads = 4;

		[Tooltip("Specifies how often agents should be updated per second. Note, if 'Asynchronous' multithreading is set, this frequency simply specifies how often the system checks whether the sub-threads have finished their work and if they should be restarted.")]
		[Range(0f, 1000f)]
		public float UpdateFrequency = 20f;

		[Tooltip("A value used as a reference for the 'Load Balancing' feature. It is needed to calculate how many agents can be processed per update. If the actual update rate drops below this value, the number of agents per update remains. However, then it is not possible to keep the actual update frequency, lowering it effectively. That means that all agents are still updated as fast as possible, though not as often as defined by the parameters.")]
		[Range(1E-06f, 1000f)]
		public float TargetFps = 60f;

		private ReadOnlyCollection<AIMContext> nonThreadedComponents;

		private ReadOnlyCollection<AIMContext> threadedComponents;

		private ReadOnlyCollection<Context> threadedContexts;

		private EvaluationWorker[] evaluationWorkers;

		private WaitForSeconds waitForSeconds;

		private float oldUpdateFrequency = float.PositiveInfinity;

		private float agentsPerUpdateSingle;

		private float accuUpdateSingle;

		private int usedThreads;

		private int perWorker;

		private int residual;

		private int curIndexSingle;

		private bool updateRoutineRunning;

		private bool updateRoutineSingleRunning;

		private bool wasAsynchronous;

		private void Prepare()
		{
			for (int i = 0; i < threadedComponents.Count; i++)
			{
				threadedComponents[i].ObtainEvaluatedResults();
				threadedComponents[i].PrepareEvaluation();
			}
		}

		private void EvaluateContexts()
		{
			if (wasAsynchronous && Performance == PerformanceType.Synchronous)
			{
				for (int i = 0; i < evaluationWorkers.Length; i++)
				{
					evaluationWorkers[i].WaitUntilWorkIsDone();
				}
			}
			wasAsynchronous = Performance != PerformanceType.Synchronous;
			if (Performance != PerformanceType.Synchronous)
			{
				for (int j = 0; j < evaluationWorkers.Length; j++)
				{
					if (!evaluationWorkers[j].Done)
					{
						return;
					}
				}
				for (int k = 0; k < evaluationWorkers.Length; k++)
				{
					evaluationWorkers[k].ResetEvents();
				}
			}
			Prepare();
			if (threadedContexts.Count == 0)
			{
				for (int l = 0; l < evaluationWorkers.Length; l++)
				{
					evaluationWorkers[l].FirstContext = 0;
					evaluationWorkers[l].LastContext = 0;
					evaluationWorkers[l].StartWork();
				}
			}
			else if (evaluationWorkers.Length != 0 && threadedContexts.Count <= evaluationWorkers.Length)
			{
				for (int m = 0; m < threadedContexts.Count; m++)
				{
					evaluationWorkers[m].FirstContext = m;
					evaluationWorkers[m].LastContext = m;
					evaluationWorkers[m].StartWork();
				}
				if (Performance == PerformanceType.Synchronous)
				{
					for (int n = 0; n < threadedContexts.Count; n++)
					{
						evaluationWorkers[n].WaitUntilWorkIsDone();
					}
				}
			}
			else
			{
				if (evaluationWorkers.Length == 0)
				{
					return;
				}
				perWorker = threadedContexts.Count / evaluationWorkers.Length;
				residual = threadedContexts.Count % evaluationWorkers.Length;
				for (int num = 0; num < evaluationWorkers.Length; num++)
				{
					if (num == 0)
					{
						evaluationWorkers[num].FirstContext = 0;
					}
					else
					{
						evaluationWorkers[num].FirstContext = evaluationWorkers[num - 1].LastContext + 1;
					}
					evaluationWorkers[num].LastContext = evaluationWorkers[num].FirstContext + perWorker - 1;
					if (num < residual)
					{
						evaluationWorkers[num].LastContext++;
					}
					for (int num2 = evaluationWorkers[num].FirstContext; num2 < evaluationWorkers[num].LastContext; num2++)
					{
						threadedComponents[num2].UpdateIndicator();
					}
					evaluationWorkers[num].StartWork();
				}
				if (Performance == PerformanceType.Synchronous)
				{
					for (int num3 = 0; num3 < evaluationWorkers.Length; num3++)
					{
						evaluationWorkers[num3].WaitUntilWorkIsDone();
					}
				}
			}
		}

		private void Awake()
		{
			nonThreadedComponents = AIMContext.NonThreadedComponents;
			threadedComponents = AIMContext.ThreadedComponents;
			threadedContexts = AIMContext.ThreadedContexts;
		}

		private void OnEnable()
		{
			usedThreads = Math.Min(Threads, SystemInfo.processorCount);
			evaluationWorkers = new EvaluationWorker[usedThreads];
			for (int i = 0; i < evaluationWorkers.Length; i++)
			{
				evaluationWorkers[i] = new EvaluationWorker(threadedContexts);
			}
			AIMContextEvaluation.instancesCount++;
		}

		private void OnDisable()
		{
			for (int i = 0; i < evaluationWorkers.Length; i++)
			{
				evaluationWorkers[i].Terminate();
			}
			updateRoutineRunning = false;
			AIMContextEvaluation.instancesCount--;
		}

		private void OnDestroy()
		{
			AIMContextEvaluation.instancesCount--;
		}

		private void Update()
		{
			if (UpdateFrequency != oldUpdateFrequency && UpdateFrequency >= 1E-06f)
			{
				waitForSeconds = new WaitForSeconds(1f / UpdateFrequency);
			}
			oldUpdateFrequency = UpdateFrequency;
			if (AIMContextEvaluation.instancesCount > 1)
			{
				Debug.LogWarning("(" + typeof(AIMPerformance).Name + ") " + base.name + ": multiple 'AIMPerformance' instances within the scene");
			}
			if (Threads <= 0)
			{
				Debug.LogError("(" + typeof(AIMPerformance).Name + ") " + base.name + ": number of 'Threads' needs to be positive and greater than 0");
			}
			UpdateSingle();
			if (UpdateFrequency < 1E-06f)
			{
				EvaluateContexts();
			}
			else if (!updateRoutineRunning && UpdateFrequency >= 1E-06f)
			{
				StartCoroutine(UpdateRoutine());
			}
		}

		private void UpdateSingle()
		{
			if (nonThreadedComponents.Count == 0)
			{
				return;
			}
			if (Performance == PerformanceType.LoadBalanced)
			{
				if (UpdateFrequency < 1E-06f)
				{
					agentsPerUpdateSingle = nonThreadedComponents.Count;
				}
				else
				{
					agentsPerUpdateSingle = (float)nonThreadedComponents.Count * (UpdateFrequency / ((TargetFps >= 1E-06f) ? TargetFps : 1E-06f));
				}
				if (agentsPerUpdateSingle > (float)nonThreadedComponents.Count)
				{
					agentsPerUpdateSingle = nonThreadedComponents.Count;
				}
				if (accuUpdateSingle < 0.999999f)
				{
					accuUpdateSingle += agentsPerUpdateSingle;
				}
				if (accuUpdateSingle >= 0.999999f)
				{
					int num = curIndexSingle;
					for (int i = 0; (float)i < accuUpdateSingle; i++)
					{
						num = curIndexSingle;
						num %= nonThreadedComponents.Count;
						nonThreadedComponents[num].Evaluate();
						curIndexSingle++;
					}
					accuUpdateSingle = 0f;
				}
			}
			else
			{
				if (Performance == PerformanceType.LoadBalanced)
				{
					return;
				}
				if (UpdateFrequency >= 1E-06f && !updateRoutineSingleRunning)
				{
					StartCoroutine(UpdateRoutineSingle());
				}
				if (UpdateFrequency < 1E-06f)
				{
					for (int j = 0; j < nonThreadedComponents.Count; j++)
					{
						nonThreadedComponents[j].Evaluate();
					}
				}
			}
		}

		private IEnumerator UpdateRoutine()
		{
			updateRoutineRunning = true;
			while (base.enabled && UpdateFrequency >= 1E-06f)
			{
				EvaluateContexts();
				yield return waitForSeconds;
			}
			updateRoutineRunning = false;
			yield return null;
		}

		private IEnumerator UpdateRoutineSingle()
		{
			updateRoutineSingleRunning = true;
			while (base.enabled && UpdateFrequency >= 1E-06f && Performance != PerformanceType.LoadBalanced)
			{
				for (int i = 0; i < nonThreadedComponents.Count; i++)
				{
					nonThreadedComponents[i].Evaluate();
				}
				yield return waitForSeconds;
			}
			updateRoutineSingleRunning = false;
			yield return null;
		}
	}
}
