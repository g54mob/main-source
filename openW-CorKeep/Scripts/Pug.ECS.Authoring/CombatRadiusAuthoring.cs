using UnityEngine;

[DisallowMultipleComponent]
public class CombatRadiusAuthoring : MonoBehaviour
{
	public float radius = 0.5f;

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(Vector3.zero, radius);
	}
}
