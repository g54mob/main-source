using UnityEngine;

public class ComponentCheckbox : MonoBehaviour
{
	public GameObject toggle;

	public void Toggle()
	{
		toggle.SetActive(!toggle.activeSelf);
		GetComponent<ComponentBase>().Callback(base.name + "Toggle", toggle.activeSelf, base.transform);
	}

	public void SetValue(bool b)
	{
		toggle.SetActive(b);
	}

	public void SetValue(string b)
	{
		toggle.SetActive(b == "true" || b == "True" || b == "1");
	}
}
