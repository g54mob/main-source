using TMPro;
using UnityEngine;

public class test6 : MonoBehaviour
{
	private void Start()
	{
	}

	private void Update()
	{
		TMP_InputField component = GetComponent<TMP_InputField>();
		Input.GetKeyDown(KeyCode.Z);
		Debug.Log(component.caretPosition + " " + component.stringPosition + " " + component.selectionAnchorPosition + " " + component.selectionFocusPosition + " " + component.selectionStringAnchorPosition + " " + component.selectionStringFocusPosition);
	}
}
