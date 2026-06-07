using System;
using System.Collections.Generic;
using Factory;
using Factory.Pools;
using FixMath;

namespace Server
{
	public class Simulation : ISimulation, IReusable, ICreatedInScopeHandler, IReleasedFromScopeHandler
	{
		private static readonly Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("Server.Simulation");

		public static readonly Fix64 DefaultTimestep = Fix64.One / (Fix64)10L;

		private readonly Dictionary<Type, List<IModel>> _models = new Dictionary<Type, List<IModel>>();

		[Serialize(false, null)]
		private readonly List<IModel> _graveyard = new List<IModel>();

		private readonly List<IProcess> _processes = new List<IProcess>();

		private readonly List<Command> _commands = new List<Command>();

		[Serialize(false, null)]
		private readonly ObserverList<ISimulationObserver> _observers = new ObserverList<ISimulationObserver>();

		[Serialize(true, null)]
		[Dependency]
		private CommandJournal _journal;

		private bool _isRecordingSimulationCommands;

		[Dependency]
		[Serialize(true, null)]
		private Clock _clock;

		[Serialize(true, null)]
		public Fix64 Timestep { get; private set; } = DefaultTimestep;

		[Serialize(true, null)]
		public bool IsPaused { get; set; }

		[Dependency]
		public IScope Scope { get; private set; }

		public bool HasAnyScheduledCommands => _commands.Count > 0;

		public Command NextScheduledCommand
		{
			get
			{
				if (_commands.Count > 0)
				{
					return _commands[0];
				}
				return null;
			}
		}

		public bool Step()
		{
			ClearGraveyard();
			int i;
			for (i = 0; i < _commands.Count && _commands[i].FrameIndex <= _clock.FrameCount; i++)
			{
				Command command = _commands[i];
				Log.Info("Executing {0} on frame {1}.", command, _clock.FrameCount);
				command.FrameIndex = _clock.FrameCount;
				command.Execute(this);
				if (_isRecordingSimulationCommands)
				{
					_journal.Record(command);
				}
			}
			if (i > 0)
			{
				_commands.RemoveRange(0, i);
			}
			Fix64 fix = ((!IsPaused) ? Timestep : Fix64.Zero);
			_clock.Step(fix);
			ClearGraveyard();
			foreach (IProcess process in _processes)
			{
				process.Step(this, fix);
			}
			return true;
		}

		public bool AddModel(IModel model)
		{
			Type type = model.GetType();
			if (!_models.ContainsKey(type))
			{
				_models[type] = new List<IModel>();
			}
			_models[type].Add(model);
			ObserverList<ISimulationObserver>.Enumerator enumerator = _observers.GetEnumerator();
			while (enumerator.MoveNext())
			{
				enumerator.Current.OnModelAdded(this, model, _clock.Time);
			}
			return true;
		}

		public bool RemoveModel(IModel model)
		{
			_graveyard.Add(model);
			ObserverList<ISimulationObserver>.Enumerator enumerator = _observers.GetEnumerator();
			while (enumerator.MoveNext())
			{
				enumerator.Current.OnModelRemoved(this, model, _clock.Time);
			}
			return true;
		}

		public bool ContainsModel(IModel model)
		{
			if (_models.TryGetValue(model.GetType(), out var value))
			{
				return value.Contains(model);
			}
			return false;
		}

		public T GetModel<T>() where T : class, IModel
		{
			ModelListEnumerator<T> enumerator = GetModels<T>().GetEnumerator();
			if (enumerator.MoveNext())
			{
				return enumerator.Current;
			}
			return null;
		}

		public ModelList<T> GetModels<T>() where T : class, IModel
		{
			List<IModel> models = null;
			Type typeFromHandle = typeof(T);
			if (_models.ContainsKey(typeFromHandle))
			{
				models = _models[typeFromHandle];
			}
			return new ModelList<T>(models);
		}

		public bool AddProcess(IProcess process)
		{
			_processes.Add(process);
			return true;
		}

		public bool ScheduleCommand(Command command)
		{
			if (_commands.Count == 0)
			{
				_commands.Add(command);
				return true;
			}
			int num = _commands.Count - 1;
			while (num > 1 && command.FrameIndex < _commands[num].FrameIndex)
			{
				num--;
			}
			_commands.Insert(num + 1, command);
			return true;
		}

		public void Subscribe(ISimulationObserver observer)
		{
			_observers.Subscribe(observer);
			foreach (List<IModel> value in _models.Values)
			{
				foreach (IModel item in value)
				{
					observer.OnModelAdded(this, item, _clock.Time);
				}
			}
		}

		public bool Unsubscribe(ISimulationObserver observer)
		{
			return _observers.Unsubscribe(observer);
		}

		public void OnCreatedInScope(IScope scope)
		{
			_isRecordingSimulationCommands = false;
			if (FeatureToggle.IsFeatureEnabled(Feature.RecordSimulationJournal))
			{
				_isRecordingSimulationCommands = true;
			}
		}

		public void OnReleasedFromScope(IScope scope)
		{
			_observers.UnsubscribeAll();
			ClearGraveyard();
			if (_models != null)
			{
				foreach (List<IModel> value in _models.Values)
				{
					int num = value.Count - 1;
					while (num >= 0)
					{
						IModel obj = value[num];
						value.RemoveAt(num);
						num--;
						scope.Release(obj);
					}
				}
			}
			if (_commands == null)
			{
				return;
			}
			foreach (Command command in _commands)
			{
				scope.Release(command);
			}
			_commands.Clear();
		}

		public void Reset()
		{
			Timestep = DefaultTimestep;
			IsPaused = false;
			_models.Clear();
			_graveyard.Clear();
			_processes.Clear();
			_commands.Clear();
		}

		private void ClearGraveyard()
		{
			if (_graveyard.Count <= 0)
			{
				return;
			}
			int num = _graveyard.Count - 1;
			while (num >= 0)
			{
				IModel model = _graveyard[num];
				_graveyard.RemoveAt(num);
				num--;
				if (Diagnostics.Verify(_models.TryGetValue(model.GetType(), out var value)))
				{
					value.Remove(model);
				}
				Scope.Release(model);
			}
		}
	}
}
