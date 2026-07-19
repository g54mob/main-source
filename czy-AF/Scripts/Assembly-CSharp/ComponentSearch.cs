using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ComponentSearch : MonoBehaviour
{
	public Transform remove;

	public Transform target;

	public string function;

	private void Start()
	{
		UpdateSearch("");
	}

	public void Clear()
	{
		GetComponent<InputField>().text = "";
	}

	public void UpdateSearch(string s)
	{
		if (GetComponent<InputField>().text != "")
		{
			remove.gameObject.SetActive(value: true);
		}
		else
		{
			remove.gameObject.SetActive(value: false);
		}
		if (target != null)
		{
			target.gameObject.SendMessage(function, s);
		}
		GetComponent<ComponentBase>().Callback(base.name + "Change", s, base.transform);
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Right)
		{
			Clear();
		}
	}

	public void SetTarget(Transform t)
	{
		target = t;
	}

	public void SetFunction(string f)
	{
		function = f;
	}
}
