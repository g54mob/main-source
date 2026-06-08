using System.Collections.Generic;
using UnityEngine;

public class AnimalPathPoint : MonoBehaviour
{
	public bool hidingSpot;

	private Animal _003COccupiedBy_003Ek__BackingField;

	public bool hasRestrictedNeighborPathPoints;

	public List<AnimalPathPoint> neighborPathPoints;

	public Animal OccupiedBy
	{
		get
		{
			return _003COccupiedBy_003Ek__BackingField;
		}
		private set
		{
			_003COccupiedBy_003Ek__BackingField = value;
		}
	}

	private void Awake()
	{
		base.gameObject.SetActive(value: false);
	}

	public void OccupyBy(Animal newOccupier)
	{
		if (!hidingSpot)
		{
			OccupiedBy = newOccupier;
		}
	}
}
