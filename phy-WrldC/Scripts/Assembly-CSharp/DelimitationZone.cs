using UnityEngine;

public class DelimitationZone : MonoBehaviour
{
	[SerializeField]
	private BoxCollider insideBoxCollider;

	public bool IsAnyBlockBodyOutside(CreationView creationView)
	{
		bool result = false;
		foreach (BlockView allBlockView in creationView.GetAllBlockViews())
		{
			foreach (BlockBodyView allBlockBodyView in allBlockView.GetAllBlockBodyViews())
			{
				Vector3 normalized = (base.gameObject.transform.position - allBlockBodyView.transform.position).normalized;
				Ray ray = new Ray(allBlockBodyView.transform.position, normalized);
				if (insideBoxCollider.Raycast(ray, out var _, 1000f))
				{
					result = true;
					break;
				}
			}
		}
		return result;
	}
}
