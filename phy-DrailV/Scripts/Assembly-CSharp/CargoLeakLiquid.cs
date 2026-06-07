using UnityEngine;

public class CargoLeakLiquid : CargoLeakBase
{
	private static readonly Vector3 DEFAULT_LEAK_COLLIDER_SIZE = new Vector3(1f, 4f, 0f);

	private static readonly Vector3 DEFAULT_LEAK_COLLIDER_CENTER = new Vector3(0f, -1.75f, 0f);

	protected override void SetupLeakColliders(GameObject colliderGO)
	{
		leakCollider = colliderGO.AddComponent<BoxCollider>();
		leakCollider.isTrigger = true;
		maxLeakColliderSize = 5.5f;
		ResetLeakColliders();
	}

	protected override void ManageColliders()
	{
		if (isLeaking)
		{
			float num = leakFlow / maxLeakFlow;
			leakColliderSize.z = maxLeakColliderSize * num;
			leakColliderCenter.z = maxLeakColliderSize * 0.5f * num;
			leakCollider.center = leakColliderCenter;
			leakCollider.size = leakColliderSize;
			if (!leakCollider.enabled)
			{
				leakCollider.enabled = true;
			}
		}
		else if (leakCollider.enabled)
		{
			leakCollider.enabled = false;
		}
	}

	protected override void ResetLeakColliders()
	{
		leakCollider.enabled = false;
		leakColliderSize = DEFAULT_LEAK_COLLIDER_SIZE;
		leakColliderCenter = DEFAULT_LEAK_COLLIDER_CENTER;
	}

	protected override void CalculateLeakedMass()
	{
		cargoMassLeaked += leakFlow * Time.deltaTime;
	}
}
