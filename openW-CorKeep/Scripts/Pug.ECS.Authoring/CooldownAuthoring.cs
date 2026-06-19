using UnityEngine;

[DisallowMultipleComponent]
public class CooldownAuthoring : MonoBehaviour
{
	public SharedCooldownIdentifier sharedCooldownIdentifier;

	public float cooldown;

	public bool casualCharacterIgnoresCustomCooldown;
}
