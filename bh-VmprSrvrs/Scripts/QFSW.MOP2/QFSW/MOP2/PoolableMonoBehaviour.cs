using UnityEngine;

namespace QFSW.MOP2
{
	public class PoolableMonoBehaviour : GameMonoBehaviour, IPoolable
	{
		[SerializeField]
		[HideInInspector]
		private ObjectPool _parentPool;

		public bool PoolReady => false;

		void IPoolable.InitializeTemplate(ObjectPool pool)
		{
		}

		public void Release()
		{
		}
	}
}
