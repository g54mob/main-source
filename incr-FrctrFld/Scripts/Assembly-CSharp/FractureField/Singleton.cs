using UnityEngine;

namespace FractureField
{
	public class Singleton<T> : MonoBehaviour where T : Singleton<T>
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

		protected virtual void Awake()
		{
		}

		private void CheckDuplicate()
		{
		}
	}
}
