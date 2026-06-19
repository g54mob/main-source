using System;
using UnityEngine;

public abstract class ManagerBase : MonoBehaviour, IComparable<ManagerBase>
{
	public virtual int InitOrder { get; }

	public virtual bool Setup()
	{
		return true;
	}

	public abstract bool Init();

	public virtual void Deinit()
	{
	}

	protected virtual void Awake()
	{
	}

	protected virtual void Start()
	{
	}

	public int CompareTo(ManagerBase other)
	{
		if ((object)this == other)
		{
			return 0;
		}
		if ((object)other == null)
		{
			return 1;
		}
		return InitOrder.CompareTo(other.InitOrder);
	}
}
