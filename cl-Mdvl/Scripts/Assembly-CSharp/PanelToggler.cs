using UnityEngine;

public class PanelToggler : MonoBehaviour
{
	[SerializeField]
	private GameObject panel;

	public void OpenPanel()
	{
		if (panel == null)
		{
			return;
		}
		if (panel.activeSelf)
		{
			panel.SetActive(value: false);
			return;
		}
		panel.SetActive(value: true);
		for (int i = 0; i < panel.transform.parent.transform.childCount; i++)
		{
			Transform child = panel.transform.parent.transform.GetChild(i);
			if (!child.name.Equals(panel.name))
			{
				child.gameObject.SetActive(value: false);
			}
		}
	}
}
