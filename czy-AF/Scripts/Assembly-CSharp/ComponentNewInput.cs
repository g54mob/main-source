using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ComponentNewInput : MonoBehaviour
{
	public GameObject selection;

	public Image underline;

	public Text inputText;

	public InputField inputField;

	private float valueMin;

	private float valueMax = 1f;

	private string content = "string";

	private string value;

	private string modifier;

	private bool drag;

	private Vector3 dragStart;

	private float dragValue;

	private void Awake()
	{
		SetText();
		inputField.gameObject.SetActive(value: false);
	}

	public void SetData(Hashtable h)
	{
		if (h["min"] != null)
		{
			valueMin = (float)h["min"];
		}
		if (h["max"] != null)
		{
			valueMax = (float)h["max"];
		}
		if (h["modifier"] != null)
		{
			modifier = (string)h["modifier"];
		}
		if (h["content"] != null)
		{
			content = (string)h["content"];
			switch (content)
			{
			case "string":
				inputField.contentType = InputField.ContentType.Standard;
				break;
			case "integer":
				inputField.contentType = InputField.ContentType.IntegerNumber;
				break;
			case "float":
				inputField.contentType = InputField.ContentType.DecimalNumber;
				break;
			}
		}
	}

	public void Select()
	{
		StopDrag();
		inputText.text = "";
		inputField.gameObject.SetActive(value: true);
		inputField.text = value;
		inputField.Select();
		inputField.ActivateInputField();
		selection.SetActive(value: false);
	}

	public void EditedText()
	{
		value = inputField.text;
		SetText();
		inputField.DeactivateInputField();
		inputField.gameObject.SetActive(value: false);
		selection.SetActive(value: true);
	}

	public void SetText()
	{
		inputText.text = $"{value}<b><color=#757591>{modifier}</color></b>";
	}

	public void PointerEnter()
	{
		if (!(content == "string"))
		{
			Interface.SetCursor("drag");
		}
	}

	public void PointerExit()
	{
		Interface.SetCursor();
	}

	public void SetValue(string s)
	{
		value = s;
		SetText();
	}

	public void StartDrag()
	{
		if (!(content == "string"))
		{
			drag = true;
			Interface.drag = true;
			dragStart = Input.mousePosition;
			dragValue = float.Parse(value);
		}
	}

	public void StopDrag()
	{
		drag = false;
		Interface.drag = false;
		Interface.SetCursor();
		inputField.DeactivateInputField();
	}

	public void ValueChanged(Transform t)
	{
		GetComponent<ComponentBase>().Callback(base.name + "Change", inputField.text, t);
	}

	public void EndEdit(Transform t)
	{
		GetComponent<ComponentBase>().Callback(base.name + "Update", inputField.text, t);
	}

	private void Update()
	{
		if (drag)
		{
			Vector3 vector = Input.mousePosition - dragStart;
			if (Mathf.Abs(vector.x) > 1f)
			{
				Interface.SetCursor("drag");
			}
			if (content == "integer")
			{
				int num = Mathf.RoundToInt(dragValue + vector.x / 10f);
				value = Mathf.Clamp(num, (int)valueMin, (int)valueMax).ToString();
			}
			if (content == "float")
			{
				float num2 = dragValue + vector.x / 200f;
				num2 = Mathf.Clamp(num2, valueMin, valueMax);
				value = (Mathf.Round(num2 * 10f) / 10f).ToString();
			}
			inputText.text = value;
			if (Input.GetMouseButtonUp(0))
			{
				StopDrag();
			}
		}
	}
}
