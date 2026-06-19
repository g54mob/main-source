using Pug.UnityExtensions;
using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct AffectObjectWhenMelodyPlayedCD : IComponentData, IQueryTypeParameter
{
	public bool listening;

	public float hearRange;

	public float humCooldown;

	public bool changeObjectID;

	public ObjectID newObjectId;

	public int newVariation;

	public bool removeMelodyListener;

	public bool weakenWhenAffected;

	public bool removeOldColliders;

	public LootTableID tableLoot;

	[GhostField]
	public int melodyProgress;

	[GhostField]
	public int scale;

	[GhostField]
	public bool playerHoldingInstrumentExists;

	[GhostField]
	public MelodyID melodyID;

	[GhostField]
	public TimerSimple timer;

	[GhostField]
	public int humIndex;
}
