using Aux;
using UnityEngine;

public class LidarTutorialHelper : MonoBehaviour
{
	public RectTransform downToThisObj;

	private RectTransform selfRect;

	private void Start()
	{
		selfRect = base.gameObject.GetComponent<RectTransform>();
	}

	private void Update()
	{
		Vector3[] worldCorners = Helper.GetWorldCorners(downToThisObj);
		float num = downToThisObj.sizeDelta.y / Mathf.Abs(worldCorners[0].y - worldCorners[1].y);
		Vector3[] worldCorners2 = Helper.GetWorldCorners(selfRect);
		worldCorners2[0].y = worldCorners[1].y;
		worldCorners2[3].y = worldCorners[2].y;
		Vector2 sizeDelta = selfRect.sizeDelta;
		Debug.Log(num);
		sizeDelta.y = Mathf.Abs(worldCorners2[0].y - worldCorners2[1].y) * num;
		selfRect.sizeDelta = sizeDelta;
	}
}
