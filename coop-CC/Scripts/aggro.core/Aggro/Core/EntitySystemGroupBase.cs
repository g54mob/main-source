using System;
using System.Collections.Generic;
using UnityEngine;

namespace Aggro.Core
{
	public abstract class EntitySystemGroupBase : EntitySystemBase
	{
		public struct SystemEntry : IComparable<SystemEntry>
		{
			public EntitySystemBase system;

			public int priority;

			public int CompareTo(SystemEntry other)
			{
				int num = priority.CompareTo(other.priority);
				if (num != 0)
				{
					return num;
				}
				return string.Compare(system.GetType().AssemblyQualifiedName, other.system.GetType().AssemblyQualifiedName, StringComparison.Ordinal);
			}
		}

		private List<SystemEntry> _systems = new List<SystemEntry>();

		private bool _isDirty;

		public override Color systemColor => Color.cyan;

		internal void AddSystem(EntitySystemBase system, int priority)
		{
			SystemEntry item = new SystemEntry
			{
				system = system,
				priority = priority
			};
			_systems.Add(item);
			_isDirty = true;
		}

		public void GetSystems(List<SystemEntry> systems)
		{
			if (_isDirty)
			{
				_systems.Sort();
				_isDirty = false;
			}
			systems.Clear();
			systems.AddRangeNoGarbage(_systems);
		}

		public SystemEntry[] GetSystems()
		{
			if (_isDirty)
			{
				_systems.Sort();
				_isDirty = false;
			}
			return _systems.ToArray();
		}

		protected sealed override void OnUpdateSystem()
		{
			if (!ShouldUpdateGroup())
			{
				return;
			}
			if (_isDirty)
			{
				_systems.Sort();
				_isDirty = false;
			}
			int count = _systems.Count;
			for (int i = 0; i < count; i++)
			{
				SystemEntry systemEntry = _systems[i];
				if (systemEntry.system.enabled)
				{
					try
					{
						systemEntry.system.Update();
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
					}
				}
			}
		}

		protected virtual bool ShouldUpdateGroup()
		{
			return true;
		}
	}
}
