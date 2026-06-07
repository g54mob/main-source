using DV.ThingTypes;
using UnityEngine;

public class StorageAccessPointLostAndFound : StorageAccessPointBase
{
	[SerializeField]
	private PointOnPlane transformValueRandomizer;

	public override StorageType AccessPointStorageType => StorageType.LostAndFound;

	protected override void Start()
	{
		base.Start();
		transformValueRandomizer = GetComponentInChildren<PointOnPlane>();
	}
}
