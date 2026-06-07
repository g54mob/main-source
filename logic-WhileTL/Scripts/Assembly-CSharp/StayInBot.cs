using UnityEngine;

public class StayInBot : MonoBehaviour
{
	private void Start()
	{
	}

	private void Update()
	{
		base.transform.localPosition = new Vector3(0f, (0f - base.gameObject.transform.parent.GetComponent<RectTransform>().rect.height) / 2f + base.gameObject.GetComponent<RectTransform>().rect.height, 0f);
	}
}
