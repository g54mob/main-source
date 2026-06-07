using UnityEngine;

public class DebugBuildingDestroyer : MonoBehaviour
{
	public LayerMask interactionLayer;

	public float interactionRadius = 4f;

	private void Update()
	{
		Collider[] array = Physics.OverlapSphere(base.transform.position, interactionRadius, interactionLayer);
		Hp hp = null;
		float num = float.PositiveInfinity;
		Collider[] array2 = array;
		foreach (Collider collider in array2)
		{
			Hp componentInParent = collider.GetComponentInParent<Hp>();
			if (!(componentInParent.gameObject == base.gameObject) && (bool)componentInParent)
			{
				float num2 = Vector3.Distance(base.transform.position, collider.ClosestPoint(base.transform.position));
				if (num2 < num)
				{
					hp = componentInParent;
					num = num2;
				}
			}
		}
		if ((bool)hp && Input.GetKeyDown(KeyCode.LeftShift))
		{
			hp.TakeDamage(hp.maxHp);
		}
	}
}
