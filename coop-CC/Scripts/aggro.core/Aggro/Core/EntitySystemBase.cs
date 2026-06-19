using System;
using Unity.Profiling;
using UnityEngine;

namespace Aggro.Core
{
	public abstract class EntitySystemBase
	{
		private ProfilerMarker _updateMarker;

		private bool _hasSentStartRunning;

		public int systemId { get; internal set; }

		public bool enabled { get; set; } = true;

		public uint version { get; private set; }

		public EntityManager entityManager { get; internal set; }

		public EntityEventManager eventManager { get; internal set; }

		public EntityWorld world { get; internal set; }

		public virtual string systemName => GetType().Name;

		public virtual Color systemColor => Color.white;

		public static event Action<Type> OnPreUpdate;

		public static event Action<Type> OnPostUpdate;

		internal void Created()
		{
			_updateMarker = new ProfilerMarker(ProfilerCategory.Scripts, GetProfilerMarkerLabel());
			OnCreateSystem();
		}

		internal void Destroyed()
		{
			OnDestroySystem();
		}

		public void Update()
		{
			if (enabled)
			{
				version++;
				if (!_hasSentStartRunning)
				{
					_hasSentStartRunning = true;
					OnStartRunning();
				}
				if (EntitySystemBase.OnPreUpdate != null)
				{
					EntitySystemBase.OnPreUpdate(GetType());
				}
				OnUpdateSystem();
				if (EntitySystemBase.OnPostUpdate != null)
				{
					EntitySystemBase.OnPostUpdate(GetType());
				}
			}
		}

		protected virtual string GetProfilerMarkerLabel()
		{
			return TypeUtil.GetFriendlyName(GetType()) + ".OnUpdateSystem";
		}

		protected virtual void OnCreateSystem()
		{
		}

		protected virtual void OnDestroySystem()
		{
		}

		protected virtual void OnStartRunning()
		{
		}

		protected abstract void OnUpdateSystem();
	}
}
