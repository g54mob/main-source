using NaughtyAttributes;
using UnityEngine;

public class DeathStateAuthoring : MonoBehaviour
{
	public bool overrideTimeBeforeDestroy;

	[ShowIf("overrideTimeBeforeDestroy")]
	public float timeBeforeDestroy;

	public float timeBeforeLootDrop;

	public bool skipDeathAnimation;
}
