using System;
using UnityEngine;

[Serializable]
public class LandmarkMooringPointPersistentData : PersistentReference<LandmarkMooringPoint>
{
	public int MooringPointIndex;

	public PersistentReference<Boat>.Reference MooredBoat;

	public LandmarkMooringPointPersistentData(LandmarkMooringPoint mooringPoint, int index)
		: base(mooringPoint)
	{
		base.Instance = mooringPoint;
		MooringPointIndex = index;
	}

	public void PopulateReferences()
	{
		MooredBoat = (((bool)base.Instance && (bool)base.Instance.MooredBoat) ? base.Instance.MooredBoat : null);
	}

	public void Restore(LandmarkMooringPoint[] mooringPoints)
	{
		base.Restore();
		if (MooringPointIndex < mooringPoints.Length)
		{
			base.Instance = mooringPoints[MooringPointIndex];
		}
		else
		{
			Debug.LogError("Landmark mooring point index out of bounds! Unable to moor boat!");
		}
	}

	private void RestoreReferences()
	{
		if (!(base.Instance == null) && !MooredBoat.IsNull())
		{
			base.Instance.MoorBoat(MooredBoat, restore: true);
		}
	}

	public static void RestoreMooredBoats()
	{
		foreach (LandmarkMooringPointPersistentData reference in PersistentReference<LandmarkMooringPoint>._references)
		{
			reference?.RestoreReferences();
		}
	}
}
