using Rhizomatic.Pooling;
using UnityEngine;

public class RecyclerListItem : PoolObject
{
	public RectTransform rect;

	protected RecyclerListLoader loader;

	protected object data { get; private set; }

	public int index { get; private set; }

	protected virtual void Setup()
	{
	}

	public virtual void _SetupData(int index, object data)
	{
	}

	protected override void OnCreated()
	{
	}

	protected override void LateUpdate()
	{
	}

	public void _Setup(RecyclerListLoader loader)
	{
	}

	public void _Remove()
	{
	}

	private void Reset()
	{
	}
}
public class RecyclerListItem<T> : RecyclerListItem
{
	public new T data => default(T);
}
