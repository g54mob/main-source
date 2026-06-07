using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Gh.Tk
{
	[PersistenceOptIn]
	public class EventManager : IPersistable
	{
		[PersistenceOptIn]
		internal List<GameEvent> _events;

		public static EventManager Instance => null;

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

		public static event EventHandler<EventArgs<GameEvent>> EventAdded
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

		public static event EventHandler<EventArgs<GameEvent>> EventRemoved
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

		private EventManager()
		{
		}

		private void UpdateRouteMarkers(object sender, EventArgs e)
		{
		}

		public void Reset()
		{
		}

		public void AddEvent(GameEvent @event)
		{
		}

		public void RemoveEvent(GameEvent @event)
		{
		}

		public GameEvent GetEvent(int id)
		{
			return null;
		}

		public void Update()
		{
		}
	}
}
