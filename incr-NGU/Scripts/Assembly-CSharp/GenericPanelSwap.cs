using UnityEngine;

public class GenericPanelSwap : MonoBehaviour
{
	public GameObject anchor;

	public GameObject panel;

	private void Start()
	{
		panel.transform.position = anchor.transform.position;
		panel.transform.position = new Vector3(-10000f, -10000f);
	}

	public void movePanelIn()
	{
		panel.transform.position = anchor.transform.position;
		panel.transform.position = anchor.transform.position;
	}

	public void movePanelOut()
	{
		panel.transform.position = new Vector3(-10000f, -10000f);
	}

	public void swap()
	{
		if (panel.transform.position == anchor.transform.position)
		{
			movePanelOut();
		}
		else
		{
			movePanelIn();
		}
	}
}
