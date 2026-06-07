using System.Collections.Generic;

namespace Logic.Threading.Events
{
	public class MainThreadQueue<T> : IMainThreadQueue where T : IMainThreadEventContext
	{
		public Queue<T> Events = new Queue<T>();

		public void Enqueue(T context)
		{
			Events.Enqueue(context);
		}

		public void DequeueAndFire()
		{
			Events.Dequeue().Fire();
		}
	}
}
