using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ComponentInput : MonoBehaviour
{
	private InputField inputField;

	private float min;

	private float max = 1f;

	private string content = "text";

	public GameObject slider;

	private bool drag;

	private Vector3 dragStart;

	private float dragValue;

	private void Awake()
	{
		inputField = GetComponent<InputField>();
	}

	public void SetData(Hashtable h)
	{
		slider.SetActive(value: false);
		if (h["min"] != null)
		{
			min = (float)h["min"];
		}
		if (h["max"] != null)
		{
			max = (float)h["max"];
		}
		if (h["content"] != null)
		{
			content = (string)h["content"];
			if (content == "number")
			{
				inputField.contentType = InputField.ContentType.DecimalNumber;
				slider.SetActive(value: true);
			}
			if (content == "integer")
			{
				inputField.contentType = InputField.ContentType.IntegerNumber;
				slider.SetActive(value: true);
			}
		}
	}

	public void ValueChanged(Transform t)
	{
		GetComponent<ComponentBase>().Callback(base.name + "Change", inputField.text, t);
	}

	public void EndEdit(Transform t)
	{
		Parse();
		GetComponent<ComponentBase>().Callback(base.name + "Update", inputField.text, t);
	}

	public void Parse()
	{
		if (content == "number" || content == "integer")
		{
			float value = float.Parse(inputField.text);
			value = Mathf.Clamp(value, min, max);
			inputField.text = value.ToString();
		}
	}

	public void SetValue(string s)
	{
		inputField.text = s;
	}

	public void StartDrag()
	{
		drag = true;
		Interface.drag = true;
		dragStart = Input.mousePosition;
		dragValue = float.Parse(inputField.text);
		Interface.SetCursor("drag");
	}

	private void Update()
	{
		if (drag)
		{
			Vector3 vector = Input.mousePosition - dragStart;
			float f = dragValue + vector.x / 100f;
			if (inputField.contentType == InputField.ContentType.IntegerNumber)
			{
				f = Mathf.Round(f);
				inputField.text = f.ToString();
			}
			else
			{
				inputField.text = f.ToString("F1");
			}
			EndEdit(base.transform);
			if (Input.GetMouseButtonUp(0))
			{
				drag = false;
				Interface.drag = false;
				Interface.SetCursor();
			}
		}
	}
}
