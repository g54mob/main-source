using System;
using UnityEngine;

[Serializable]
public class ReservableAttachableSlots : AttachableSlots
{
	private int _reservedCount;

	private Transform[] _reservingTransforms;

	public override bool Attach(Transform transform)
	{
		if (AttachReserved(transform) || base.Attach(transform))
		{
			return true;
		}
		Debug.LogWarning($"Tried attaching {transform.name} to reservable slot, which was not reserved.");
		return false;
	}

	public override void Detach(Transform transform, Transform newParent)
	{
		if (!Unreserve(transform))
		{
			base.Detach(transform, newParent);
		}
	}

	public bool Reserve(Transform transform, out Vector3 worldPosition)
	{
		int i;
		return Reserve(transform, out i, out worldPosition);
	}

	public bool Reserve(Transform transform, out int index)
	{
		Vector3 worldPosition;
		return Reserve(transform, out index, out worldPosition);
	}

	public bool Unreserve(Transform transform)
	{
		if (Unreserve(transform, out var _))
		{
			return true;
		}
		Debug.LogWarning("Tried unreserving " + transform.name + " from reservable slot, which was not reserved.");
		return false;
	}

	protected override void Initialize()
	{
		base.Initialize();
		if (_reservingTransforms == null)
		{
			_reservingTransforms = new Transform[base.Count];
		}
	}

	private bool Reserve(Transform transform, out int i, out Vector3 worldPosition)
	{
		worldPosition = Parent.position;
		Initialize();
		for (i = 0; i < base.Count; i++)
		{
			if (_children[i] == null && _reservingTransforms[i] == null)
			{
				_reservingTransforms[i] = transform;
				_reservedCount++;
				worldPosition = Parent.position + TransformData[i].Position;
				return true;
			}
		}
		Debug.LogWarning("Tried reserving " + transform.name + " to reservable slot, which has no available slots.");
		return false;
	}

	private bool Unreserve(Transform transform, out int i)
	{
		if (_reservingTransforms != null)
		{
			for (i = 0; i < base.Count; i++)
			{
				if (_reservingTransforms[i] == transform)
				{
					_reservingTransforms[i] = null;
					_reservedCount--;
					return true;
				}
			}
		}
		i = -1;
		return false;
	}

	private bool AttachReserved(Transform transform)
	{
		if (Unreserve(transform, out var i))
		{
			return Attach(transform, i);
		}
		return false;
	}

	public override bool AreSlotsAvailable()
	{
		return base.ChildCount + _reservedCount < TransformData.Length;
	}
}
