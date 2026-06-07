using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class LogText : MonoBehaviour
{
	private Text _text;

	private void Start()
	{
		_text = GetComponent<Text>();
	}

	public void AddMessage(string msg)
	{
		Text text = _text;
		text.text = text.text + msg + "\n";
	}
}
