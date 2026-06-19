using Pug.UnityExtensions;
using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct BossStatueCD : IComponentData, IQueryTypeParameter
{
	public ObjectID acceptsCrystalID;

	[GhostField]
	public bool doneLoadingUp;

	[GhostField]
	public bool hasCrystal;

	[GhostField]
	public float electricityLoadUpTimer;

	public ThreadSafeTimerSimple delayedActivationTimer;
}
