using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class VersionInfo : MonoBehaviour
{
	public string Date = "<DATE>";

	private TextMeshProUGUI _textComponent;

	private void Start()
	{
		_textComponent = GetComponent<TextMeshProUGUI>();
		_textComponent.text = _textComponent.text.Replace("%VERSION%", "v" + Application.version);
	}

	public static string CompleteVersion()
	{
		return "";
	}
}
