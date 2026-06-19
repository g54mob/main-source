using UnityEngine;

namespace Loxodon.Framework.ObjectPool
{
	internal class PooledUnityObject : MonoBehaviour, IPooledObject
	{
		internal IObjectPool pool;

		internal object target;

		public void Free()
		{
			if (pool != null)
			{
				pool.Free(target);
			}
		}
	}
}
