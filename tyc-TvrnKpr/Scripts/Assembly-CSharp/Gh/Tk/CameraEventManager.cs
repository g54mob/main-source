using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Gh.Tk
{
	[PersistenceOptIn]
	public class CameraEventManager : IPersistable
	{
		[PersistenceOptIn]
		internal List<CameraEvent> _events;

		public static CameraEventManager Instance => null;

		public static event EventHandler EventsChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler<EventArgs<CameraEvent>> EventAdded
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler<EventArgs<CameraEvent>> EventRemoved
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		private CameraEventManager()
		{
		}

		private void OnGameObjectXDestroyed(object sender, EventArgs<GameObjectX> e)
		{
		}

		public void Reset()
		{
		}

		public void AddEvent(CameraEvent @event)
		{
		}

		public void RemoveEvent(CameraEvent @event)
		{
		}

		public CameraEvent GetEvent(int id)
		{
			return null;
		}

		public void Update()
		{
		}
	}
}
