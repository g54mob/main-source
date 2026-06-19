using Pug.UnityExtensions;
using UnityEngine;

public abstract class PoolableSimple : MonoBehaviour, IPoolable
{
	private IPoolSystem _pool;

	public bool isPooled => _pool != null;

	public bool isFree => _pool.IsFree(base.gameObject);

	public void OnAllocation(IPoolSystem pool)
	{
		_pool = pool;
	}

	public virtual void OnOccupied()
	{
	}

	public virtual void OnFree()
	{
	}

	public virtual void Free()
	{
		if (isPooled)
		{
			_pool.Free(base.gameObject);
			return;
		}
		OnFree();
		base.gameObject.Destroy_Clean();
	}

	public virtual void OnDestroy()
	{
	}
}
