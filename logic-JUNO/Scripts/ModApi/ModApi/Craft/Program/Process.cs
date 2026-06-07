using System.Collections.Generic;
using System.Xml.Linq;
using ModApi.Craft.Program.Craft;
using ModApi.Craft.Program.Instructions;
using UnityEngine;

namespace ModApi.Craft.Program
{
	public class Process
	{
		public const string ProcessElementName = "Process";

		private List<Thread> _deadThreads = new List<Thread>();

		private Queue<ThreadContext> _newThreadContexts = new Queue<ThreadContext>();

		private int _startThreadIndex;

		private List<Thread> _threads = new List<Thread>();

		public Thread ActiveThread { get; private set; }

		public ICraftService CraftService { get; }

		public ProgramEventHandler EventHandler { get; private set; }

		public VariableSet GlobalVariables { get; private set; }

		public ILogService LogService { get; private set; }

		public int MaxCallStackSize { get; set; } = 100;

		public int MaxThreads { get; private set; }

		public FlightProgram Program { get; }

		public IReadOnlyList<Thread> Threads => _threads;

		public Process(FlightProgram program, ILogService logService, ICraftService craftService, int maxThreads)
		{
			Program = program;
			LogService = logService;
			EventHandler = new ProgramEventHandler(this);
			CraftService = craftService;
			MaxThreads = maxThreads;
		}

		public ThreadContext CreateThread(ProgramInstruction startInstruction)
		{
			if (_newThreadContexts.Count < MaxThreads)
			{
				ThreadContext threadContext = new ThreadContext(Program, GlobalVariables, startInstruction);
				threadContext.NextInstruction = startInstruction;
				threadContext.MaxCallStackSize = MaxCallStackSize;
				_newThreadContexts.Enqueue(threadContext);
				return threadContext;
			}
			return null;
		}

		public void Deserialize(XElement xml)
		{
			GlobalVariables = new VariableSet(xml.Element("Variables"));
			foreach (XElement item2 in xml.Elements("Thread"))
			{
				ThreadContext item = ThreadContext.Deserialize(item2, Program, GlobalVariables, LogService);
				_newThreadContexts.Enqueue(item);
			}
			StartNewThreads();
		}

		public XElement Serialize()
		{
			XElement xElement = new XElement("Process");
			xElement.Add(GlobalVariables.Serialize());
			foreach (Thread thread in _threads)
			{
				xElement.Add(thread.Context.Serialize());
			}
			return xElement;
		}

		public void Start()
		{
			GlobalVariables = Program.GlobalVariables.Clone();
			EventHandler.OnFlightStart();
		}

		public int Update(double deltaTime, int maxInstructions)
		{
			StartNewThreads();
			int count = _threads.Count;
			int num = 0;
			if (count > 0)
			{
				int num2 = maxInstructions;
				int num3 = _startThreadIndex;
				for (int i = 0; i < count; i++)
				{
					if (num >= maxInstructions)
					{
						break;
					}
					num3 %= count;
					ActiveThread = _threads[num3];
					ActiveThread.Context.DeltaTime = deltaTime;
					LogService.ActiveThreadId = ActiveThread.DebugId;
					int num4 = ActiveThread.ProcessNext(num2);
					LogService.ActiveThreadId = null;
					num2 -= num4;
					if (num2 < 0)
					{
						Debug.LogErrorFormat("Remaining instructions is < 0: {0}, thread processed {1}", num2, num4);
					}
					num += num4;
					if (ActiveThread.IsDone)
					{
						_deadThreads.Add(ActiveThread);
					}
					ActiveThread = null;
					num3++;
				}
				_startThreadIndex = num3;
			}
			RemoveOldThreads();
			return num;
		}

		private void RemoveOldThreads()
		{
			if (_deadThreads.Count <= 0)
			{
				return;
			}
			foreach (Thread deadThread in _deadThreads)
			{
				int num = _deadThreads.IndexOf(deadThread);
				if (_startThreadIndex > num)
				{
					_startThreadIndex--;
				}
				_threads.Remove(deadThread);
			}
			_deadThreads.Clear();
		}

		private void StartNewThreads()
		{
			while (_newThreadContexts.Count > 0 && _threads.Count < MaxThreads)
			{
				ThreadContext threadContext = _newThreadContexts.Dequeue();
				threadContext.Craft = CraftService;
				threadContext.Log = LogService;
				Thread item = new Thread(threadContext);
				_threads.Add(item);
			}
		}
	}
}
