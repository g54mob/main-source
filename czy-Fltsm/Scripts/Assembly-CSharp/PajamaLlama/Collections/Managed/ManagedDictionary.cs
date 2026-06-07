using System.Collections.Generic;

namespace PajamaLlama.Collections.Managed
{
	public class ManagedDictionary<TKey, TValue> : IManagedCollection
	{
		private Dictionary<TKey, TValue> _instance;

		void IManagedCollection.OnDestroy()
		{
			if (_instance != null)
			{
				_instance.Clear();
				_instance = null;
			}
		}

		public Dictionary<TKey, TValue> Get()
		{
			if (_instance == null)
			{
				CollectionManager.RegisterCollection(this);
				_instance = new Dictionary<TKey, TValue>();
			}
			return _instance;
		}
	}
}
