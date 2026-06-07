using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(InputField))]
public class InputFieldContentTypeExtension : MonoBehaviour
{
	internal enum ContentTypes
	{
		UnsignedInteger = 0
	}

	[SerializeField]
	private ContentTypes ContentType;

	private InputField _inputField;

	private Regex _regularExpression;

	private void Awake()
	{
		_inputField = GetComponent<InputField>();
		_inputField.onValueChanged.AddListener(OnValueChanged);
		if (ContentType == ContentTypes.UnsignedInteger)
		{
			_regularExpression = new Regex("^\\d{0," + _inputField.characterLimit + "}");
		}
	}

	private void OnDestroy()
	{
		_inputField.onValueChanged.RemoveListener(OnValueChanged);
	}

	private void OnValueChanged(string value)
	{
		if (ContentType == ContentTypes.UnsignedInteger && _regularExpression.IsMatch(value))
		{
			_inputField.text = _regularExpression.Match(value).Value;
		}
	}
}
