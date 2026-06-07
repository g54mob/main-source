using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Factory
{
	public class Scope : IScope
	{
		private class Allocation
		{
			public object obj;

			public StackTrace stackTrace;
		}

		private IScope _parentScope;

		private readonly Dictionary<object, IScope> _establishingObjectToChildScopes = new Dictionary<object, IScope>();

		private readonly object _establishingObject;

		private readonly Assembler _assembler;

		private readonly Dictionary<Type, object> _typeToBoundVariables = new Dictionary<Type, object>();

		private readonly ObserverList<IScopeObserver> _observers = new ObserverList<IScopeObserver>();

		private Dictionary<Type, int> _outstandingAllocationCountsByType;

		private Dictionary<Type, List<Allocation>> _outstandingAllocationsByType;

		private static readonly Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("Scope");

		public IScope ParentScope
		{
			get
			{
				return _parentScope;
			}
			set
			{
				_ = _parentScope;
				_parentScope = value;
			}
		}

		public Assembler Assembler => _assembler;

		public Scope(Assembler assembler, object establishingObject = null)
		{
			_assembler = assembler;
			_establishingObject = establishingObject;
			Set<IScope>(this);
			Set<Scope>(this);
			Set<Assembler>(_assembler);
			if (FeatureToggle.IsFeatureEnabled(Feature.TrackScopedAllocations))
			{
				_outstandingAllocationCountsByType = new Dictionary<Type, int>();
				if (FeatureToggle.IsFeatureEnabled(Feature.RecordStackTracesForScopedAllocations))
				{
					_outstandingAllocationsByType = new Dictionary<Type, List<Allocation>>();
				}
			}
		}

		public void AddChildScope(IScope childScope, object establishingObject)
		{
			_establishingObjectToChildScopes[establishingObject] = childScope;
		}

		public object Get(Type type)
		{
			if (_typeToBoundVariables.TryGetValue(type, out var value))
			{
				return value;
			}
			object obj = _assembler.Create(type, this);
			if (obj != null)
			{
				if (_outstandingAllocationCountsByType != null)
				{
					Type type2 = obj.GetType();
					if (_outstandingAllocationCountsByType.TryGetValue(type2, out var value2))
					{
						_outstandingAllocationCountsByType[type2] = value2 + 1;
					}
					else
					{
						_outstandingAllocationCountsByType.Add(type2, 1);
					}
					if (_outstandingAllocationsByType != null)
					{
						if (!_outstandingAllocationsByType.ContainsKey(type2))
						{
							_outstandingAllocationsByType[type2] = new List<Allocation>();
						}
						_outstandingAllocationsByType[type2].Add(new Allocation
						{
							obj = obj,
							stackTrace = new StackTrace(2, fNeedFileInfo: true)
						});
					}
				}
				return obj;
			}
			if (_parentScope != null)
			{
				obj = _parentScope.Get(type);
				if (obj != null)
				{
					return obj;
				}
			}
			Diagnostics.FailAssert("Unable to find assembler for type '{0}' anywhere in scope.", type);
			return null;
		}

		public T Get<T>() where T : class
		{
			return Get(typeof(T)) as T;
		}

		public void Assemble(object unboundObject)
		{
			_assembler.Assemble(unboundObject, this);
		}

		public bool Release()
		{
			Log.Info("Releasing scope using assembler {0}.", Assembler.Name);
			_typeToBoundVariables.Remove(typeof(IScope));
			_typeToBoundVariables.Remove(typeof(Scope));
			_typeToBoundVariables.Remove(typeof(Assembler));
			if (_establishingObject != null)
			{
				List<Type> list = null;
				foreach (KeyValuePair<Type, object> typeToBoundVariable in _typeToBoundVariables)
				{
					if (typeToBoundVariable.Value == _establishingObject)
					{
						if (list == null)
						{
							list = new List<Type>();
						}
						list.Add(typeToBoundVariable.Key);
					}
				}
				if (list != null)
				{
					foreach (Type item in list)
					{
						_typeToBoundVariables.Remove(item);
					}
				}
			}
			for (int i = 0; i < 2; i++)
			{
				if (_typeToBoundVariables.Count <= 0)
				{
					continue;
				}
				foreach (object item2 in new HashSet<object>(_typeToBoundVariables.Values))
				{
					Release(item2);
				}
			}
			ParentScope = null;
			ObserverList<IScopeObserver>.Enumerator enumerator4 = _observers.GetEnumerator();
			while (enumerator4.MoveNext())
			{
				enumerator4.Current.OnScopeReleased(this);
			}
			if (_outstandingAllocationsByType != null)
			{
				if (_outstandingAllocationsByType.Count > 0)
				{
					Log.Warn("Outstanding allocations in {0}:", this);
					foreach (List<Allocation> value in _outstandingAllocationsByType.Values)
					{
						foreach (Allocation item3 in value)
						{
							Log.Warn("{0}{1}", item3.obj, item3.stackTrace);
						}
					}
				}
				_outstandingAllocationsByType = null;
			}
			else if (_outstandingAllocationCountsByType != null && _outstandingAllocationCountsByType.Count > 0)
			{
				Log.Warn("Outstanding allocations in {0}:", this);
				foreach (Type key in _outstandingAllocationCountsByType.Keys)
				{
					int num = _outstandingAllocationCountsByType[key];
					Log.Warn("{0} instance{1} of {2}", num, (num == 1) ? "" : "s", key);
				}
			}
			return true;
		}

		public void Set(Type type, object variable)
		{
			_typeToBoundVariables[type] = variable;
		}

		public void Set<T>(object variable)
		{
			Set(typeof(T), variable);
		}

		public void Unset(Type type)
		{
			_typeToBoundVariables.Remove(type);
		}

		public T Import<T>(BinaryReader reader) where T : class
		{
			object obj = _assembler.Import(new ImportContext(reader, this));
			if (obj != null && !typeof(T).IsAssignableFrom(obj.GetType()))
			{
				Log.Warn("Deserialisation of expected type {0} failed; got {1} instead.", typeof(T), obj.GetType());
				Release(obj);
				obj = null;
			}
			return obj as T;
		}

		public object Import(BinaryReader reader)
		{
			return _assembler.Import(new ImportContext(reader, this));
		}

		public bool Export(object obj, BinaryWriter writer)
		{
			return _assembler.Export(obj, new ExportContext(writer, this));
		}

		public void Subscribe(IScopeObserver newObserver)
		{
			_observers.Subscribe(newObserver);
		}

		public void Unsubscribe(IScopeObserver oldObserver)
		{
			_observers.Unsubscribe(oldObserver);
		}

		public bool Release(object obj)
		{
			if (!Diagnostics.Verify(obj != null, "Please do not attempt to release a null object."))
			{
				return false;
			}
			bool flag = true;
			if (!_assembler.Release(obj, this))
			{
				flag = _parentScope != null && _parentScope.Release(obj);
			}
			if (_establishingObjectToChildScopes.ContainsKey(obj))
			{
				_establishingObjectToChildScopes[obj].Release();
				_establishingObjectToChildScopes.Remove(obj);
			}
			if (_outstandingAllocationCountsByType != null)
			{
				Type type = obj.GetType();
				if (_outstandingAllocationCountsByType.TryGetValue(type, out var value))
				{
					if (value == 1)
					{
						_outstandingAllocationCountsByType.Remove(type);
					}
					else
					{
						_outstandingAllocationCountsByType[type] = value - 1;
					}
				}
				if (_outstandingAllocationsByType != null && _outstandingAllocationsByType.ContainsKey(type))
				{
					List<Allocation> list = _outstandingAllocationsByType[type];
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].obj == obj)
						{
							list.RemoveAt(i);
							break;
						}
					}
					if (list.Count == 0)
					{
						_outstandingAllocationsByType.Remove(type);
					}
				}
			}
			if (!flag)
			{
				Log.Error("Failed to release object {0} from scope with assembler '{1}'.", obj, _assembler.Name);
			}
			return flag;
		}
	}
}
