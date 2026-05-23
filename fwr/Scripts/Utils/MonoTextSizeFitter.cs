using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_InputField))]
public class MonoTextSizeFitter : MonoBehaviour
{
	[SerializeField]
	private float widthMultiplier = 10f;

	private TMP_InputField codeInputField;

	private RectTransform rectTransform;

	private void Awake()
	{
		codeInputField = GetComponent<TMP_InputField>();
		rectTransform = GetComponent<RectTransform>();
	}

	private void OnEnable()
	{
		codeInputField.onValueChanged.AddListener(OnTextChanged);
	}

	private void OnDisable()
	{
		codeInputField.onValueChanged.RemoveListener(OnTextChanged);
	}

	private void OnTextChanged(string text)
	{
		if (rectTransform != null)
		{
			Vector2 sizeDelta = rectTransform.sizeDelta;
			sizeDelta.x = (float)text.Length * widthMultiplier;
			rectTransform.sizeDelta = sizeDelta;
		}
	}
}
