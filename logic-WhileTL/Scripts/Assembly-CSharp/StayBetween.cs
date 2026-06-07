using UnityEngine;

public class StayBetween : MonoBehaviour
{
	public GameObject obj1;

	public GameObject obj2;

	public bool correctWidth;

	private RectTransform selfRect;

	private void Start()
	{
		selfRect = base.gameObject.GetComponent<RectTransform>();
	}

	private void Update()
	{
		if (!(obj1 == null) && !(obj2 == null))
		{
			base.transform.position = (obj1.transform.position + obj2.transform.position) / 2f;
			if (correctWidth)
			{
				Vector2 sizeDelta = selfRect.sizeDelta;
				sizeDelta.x = Mathf.Abs(obj1.transform.position.x - obj2.transform.position.x);
				selfRect.sizeDelta = sizeDelta;
			}
		}
	}
}
