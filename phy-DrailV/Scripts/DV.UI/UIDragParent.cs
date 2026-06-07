using UnityEngine;

public class UIDragParent : MonoBehaviour
{
	[SerializeField]
	private Transform customDragParent;

	public Transform DragParent
	{
		get
		{
			if (!(customDragParent != null))
			{
				return base.transform;
			}
			return customDragParent;
		}
	}
}
