using UnityEngine;
using UnityEngine.UI;

public class ConfirmDialog : MonoBehaviour
{
	public delegate void ConfirmCallback(bool val);

	public Text text;

	private ConfirmCallback callback;

	public void Confirm(string text, ConfirmCallback callback)
	{
	}

	public void OnYes()
	{
	}

	public void OnNo()
	{
	}
}
