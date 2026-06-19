using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[DisallowMultipleComponent]
public class AffectObjectWhenMelodyPlayedAuthoring : MonoBehaviour
{
	[Tooltip("The prefab will stick with one melody from this list at random")]
	public List<MelodyID> melodyIDList;

	public bool listening;

	[ShowIf("listening")]
	public float hearRange = 10f;

	[ShowIf("listening")]
	[Tooltip("if=0, disables hum.")]
	public float humCooldown = 4f;

	[ShowIf("listening")]
	public bool changeObjectID;

	[ShowIf("listening")]
	public ObjectID newObjectId;

	[ShowIf("listening")]
	public int newVariation;

	[ShowIf("listening")]
	public bool weakenWhenAffected;

	[ShowIf("listening")]
	public bool removeMelodyListener;

	[ShowIf("listening")]
	[Tooltip("may remove old AND new colliders")]
	public bool removeOldColliders = true;

	[ShowIf("listening")]
	public LootTableID tableLoot;

	[ShowIf("listening")]
	public List<ObjectData> customLoot;
}
