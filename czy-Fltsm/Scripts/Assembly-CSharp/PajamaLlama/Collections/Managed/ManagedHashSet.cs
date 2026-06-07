using System.Collections.Generic;

namespace PajamaLlama.Collections.Managed
{
	public class ManagedHashSet<T> : IManagedCollection
	{
		private HashSet<T> _instance;

		void IManagedCollection.OnDestroy()
		{
			if (_instance != null)
			{
				_instance.Clear();
				_instance = null;
			}
		}

		public HashSet<T> Get()
		{
			if (_instance == null)
			{
				CollectionManager.RegisterCollection(this);
				_instance = new HashSet<T>();
			}
			return _instance;
		}
	}
}
