using UnityEngine;

public class UI_RebindMenu : MonoBehaviour
{
	[SerializeField]
	private GameObject[] Rebindings;

	public void ActivateRebindings()
	{
		GameObject[] rebindings = Rebindings;
		foreach (GameObject obj in rebindings)
		{
			obj.SetActive(!obj.activeSelf);
		}
	}
}
