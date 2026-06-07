using UnityEngine;

public class ListViewFocus : MonoBehaviour
{
	public static GUIListView ActiveListView;

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			ActiveListView = null;
		}
	}
}
