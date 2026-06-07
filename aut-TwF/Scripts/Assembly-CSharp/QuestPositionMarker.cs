using UnityEngine;

public class QuestPositionMarker : MonoBehaviour
{
	[SerializeField]
	private WorldObjectUI questPositionMarkerArrow;

	private void Start()
	{
		if ((bool)questPositionMarkerArrow)
		{
			questPositionMarkerArrow = Object.Instantiate(questPositionMarkerArrow);
			questPositionMarkerArrow.FollowTarget = base.gameObject;
		}
	}

	private void OnDestroy()
	{
		if ((bool)questPositionMarkerArrow)
		{
			Object.Destroy(questPositionMarkerArrow.gameObject);
		}
	}
}
