using TMPro;
using UnityEngine;

[ExecuteAlways]
public class InputFieldObjectActivator : MonoBehaviour
{
	[SerializeField]
	public TMP_InputField inputField;

	[SerializeField]
	public RectTransform targetObject;

	public bool Reverse;

	private void OnValidate()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnTextChanged(string text)
	{
	}

	private void Update()
	{
	}
}
