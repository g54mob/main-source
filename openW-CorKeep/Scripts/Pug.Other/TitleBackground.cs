using UnityEngine;

public class TitleBackground : MonoBehaviour
{
	public Light optionLight;

	private void Start()
	{
	}

	private void Update()
	{
		if (Manager.menu.GetTopMenu() is RadicalMainMenu { selectedIndex: >=0 } radicalMainMenu)
		{
			optionLight.gameObject.SetActive(value: true);
			optionLight.transform.position = new Vector3(optionLight.transform.position.x, radicalMainMenu.GetSelectedMenuOption().transform.position.y, optionLight.transform.position.z);
		}
		else
		{
			optionLight.gameObject.SetActive(value: false);
		}
	}
}
