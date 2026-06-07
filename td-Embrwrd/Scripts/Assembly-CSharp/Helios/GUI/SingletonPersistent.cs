using UnityEngine;

namespace Helios.GUI
{
	public class SingletonPersistent<T> : MonoBehaviour where T : Component
	{
		private static T instance;

		public static T Instance
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public virtual void Awake()
		{
		}
	}
}
