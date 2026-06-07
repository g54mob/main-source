using UnityEngine;
using UnityEngine.UI;

public class MessageDialog : MonoBehaviour
{
	public delegate void MessageCallback();

	public Text text;

	private MessageCallback callback;

	public void Show(string text, MessageCallback callback)
	{
	}

	public void OnDismiss()
	{
	}
}
