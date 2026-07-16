using UnityEngine;

public class SpeedDial : MonoBehaviour
{
	private RectTransform rt;

	private void Awake()
	{
		rt = GetComponent<RectTransform>();
	}

	public void SetRot01(float rot01)
	{
		float z = Mathf.Lerp(0f, -180f, rot01);
		rt.localRotation = Quaternion.Euler(0f, 0f, z);
	}
}
