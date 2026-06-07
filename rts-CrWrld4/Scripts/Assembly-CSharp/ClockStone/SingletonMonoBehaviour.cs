using UnityEngine;

namespace ClockStone
{
	public abstract class SingletonMonoBehaviour<T> : MonoBehaviour, ISingletonMonoBehaviour where T : MonoBehaviour
	{
		public static T Instance => null;

		public virtual bool isSingletonObject => false;

		public static T DoesInstanceExist()
		{
			return null;
		}

		public static void ActivateSingletonInstance()
		{
		}

		public static void SetSingletonAutoCreate(GameObject autoCreatePrefab)
		{
		}

		protected virtual void Awake()
		{
		}

		protected virtual void OnDestroy()
		{
		}
	}
}
