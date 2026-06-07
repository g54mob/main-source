using System;
using UnityEngine;

[Serializable]
public class AttachableSlots : Slots
{
	protected Transform[] _children;

	public int ChildCount { get; private set; }

	public virtual bool Attach(Transform transform)
	{
		int i;
		return Attach(transform, out i);
	}

	public virtual bool Attach(Transform transform, out int i)
	{
		Initialize();
		for (i = 0; i < base.Count; i++)
		{
			if (Attach(transform, i))
			{
				return true;
			}
		}
		Debug.LogWarning("Tried attaching " + transform.name + " to attachable slot, which was already at capacity.");
		return false;
	}

	public virtual void Detach(Transform transform, Transform newParent)
	{
		if (_children != null)
		{
			for (int i = 0; i < base.Count; i++)
			{
				if (_children[i] == transform)
				{
					_children[i] = null;
					transform.SetParent(newParent, worldPositionStays: true);
					transform.localScale = Vector3.one;
					transform.localRotation = Quaternion.identity;
					return;
				}
			}
		}
		Debug.LogWarning($"Tried detaching {transform.name} from attachable slot, which did not have that as a child.");
	}

	protected virtual void Initialize()
	{
		if (_children == null)
		{
			_children = new Transform[base.Count];
			ChildCount = 0;
		}
	}

	protected bool Attach(Transform transform, int index)
	{
		if (_children[index] == null)
		{
			_children[index] = transform;
			transform.SetParent(Parent, worldPositionStays: true);
			TransformData[index].Apply(transform);
			return true;
		}
		return false;
	}

	public bool IsAttached(Transform transform)
	{
		if (_children != null)
		{
			return _children.Contains(transform);
		}
		return false;
	}

	public virtual bool AreSlotsAvailable()
	{
		if (_children != null)
		{
			return ChildCount < base.Count;
		}
		return true;
	}

	public bool IsEmpty()
	{
		if (_children != null)
		{
			return ChildCount == 0;
		}
		return true;
	}

	public int IndexOf(Transform transform)
	{
		if (_children != null)
		{
			return _children.IndexOf(transform);
		}
		return -1;
	}
}
