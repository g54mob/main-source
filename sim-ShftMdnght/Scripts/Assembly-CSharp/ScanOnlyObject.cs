using Pathfinding;
using UnityEngine;

public class ScanOnlyObject : MonoBehaviour
{
	[SerializeField]
	private Collider targetCollider;

	[SerializeField]
	private float boundsPadding = 0.1f;

	public void InvokeUpd()
	{
		Invoke("UpdateAroundTarget", 6f);
	}

	public void UpdateAroundTarget()
	{
		if (!(AstarPath.active == null) && !(targetCollider == null))
		{
			bool activeInHierarchy = targetCollider.gameObject.activeInHierarchy;
			Bounds bounds = targetCollider.bounds;
			bounds.Expand(boundsPadding);
			GraphUpdateObject ob = new GraphUpdateObject(bounds)
			{
				modifyWalkability = true,
				setWalkability = !activeInHierarchy,
				updateErosion = true,
				requiresFloodFill = true
			};
			AstarPath.active.UpdateGraphs(ob);
			AstarPath.active.FlushGraphUpdates();
		}
	}

	private void OnEnable()
	{
		UpdateAroundTarget();
	}

	private void OnDisable()
	{
		UpdateAroundTarget();
	}
}
