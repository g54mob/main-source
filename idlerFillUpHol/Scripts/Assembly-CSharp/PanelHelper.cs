using UnityEngine;

public static class PanelHelper
{
	public static void SetSize(MonoBehaviour go)
	{
		float num = Camera.main.orthographicSize / 7f;
		go.transform.localScale = new Vector3(num, num, 1f);
	}
}
