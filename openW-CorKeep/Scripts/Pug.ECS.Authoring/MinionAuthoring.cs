using NaughtyAttributes;
using UnityEngine;

[DisallowMultipleComponent]
public class MinionAuthoring : MonoBehaviour
{
	public float damageMultiplier = 1f;

	public bool hasMiningAttack;

	[ShowIf("hasMiningAttack")]
	[AllowNesting]
	public float miningDamageMultiplier;
}
