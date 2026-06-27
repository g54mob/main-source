using Helpers.Events;
using UnityEngine.Events;

namespace Helpers.Singletons
{
	public abstract class SingletonBase<T> where T : class, new()
	{
		public static readonly UnityEvent<T> OnInstanceChanged = new UnityEventConcrete<T>();

		protected static T instance = null;

		public static bool IsInstanced => instance != null;

		public static T Instance
		{
			get
			{
				if (!IsInstanced)
				{
					Instance = new T();
				}
				return instance;
			}
			protected set
			{
				instance = value;
				OnInstanceChanged.Invoke(instance);
			}
		}

		public static void Erase()
		{
			if (IsInstanced)
			{
				instance = null;
			}
		}
	}
}
