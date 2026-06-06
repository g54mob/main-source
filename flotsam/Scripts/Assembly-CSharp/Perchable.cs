using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Perchable : BuildableExtendableBase
{
	[SerializeField]
	[FormerlySerializedAs("_perchSpots")]
	public ReservableAttachableSlots PerchSpots;

	private static List<Perchable> _allPerchables;

	public event UnityAction Deconstructed;

	public override void Finish(bool restored = false)
	{
		if (_allPerchables == null)
		{
			_allPerchables = new List<Perchable>();
		}
		_allPerchables.Add(this);
	}

	public override void OnDeconstruct()
	{
		_allPerchables?.Remove(this);
		this.Deconstructed?.Invoke();
	}

	public static bool TryReturnClosestPerchable(Vector3 position, out Perchable closestPerchable)
	{
		closestPerchable = null;
		if (_allPerchables.IsNullOrEmpty())
		{
			return false;
		}
		float num = float.MaxValue;
		foreach (Perchable allPerchable in _allPerchables)
		{
			if (allPerchable.IsAccessible())
			{
				float num2 = Vector3.Distance(position, allPerchable.transform.position);
				if (num2 < num)
				{
					num = num2;
					closestPerchable = allPerchable;
				}
			}
		}
		return closestPerchable != null;
	}

	public bool IsAccessible()
	{
		if ((bool)base.Buildable && base.Buildable.BuildPhase == BuildPhase.Finished)
		{
			return PerchSpots.AreSlotsAvailable();
		}
		return false;
	}
}
