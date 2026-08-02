using UnityEngine;

public class AnimalPoint : MonoBehaviour
{
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(base.transform.position, 0.5f);
		Gizmos.DrawLine(base.transform.position, base.transform.position + Vector3.up * 2f);
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = new Color(0f, 1f, 0f, 0.3f);
		Gizmos.DrawSphere(base.transform.position, 1f);
	}
}
