using UnityEngine;

public class LeftAlign : MonoBehaviour
{
	public float Div;

	public float Remove;

	private void Start()
	{
	}

	private void Update()
	{
		base.transform.localPosition = new Vector3(base.transform.localPosition.x, base.transform.localPosition.y, ((float)Screen.width / (float)Screen.height - Remove) / Div);
	}
}
