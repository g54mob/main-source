using TMPro;
using UnityEngine;

public class ConfirmDialog2 : MonoBehaviour
{
	public delegate void ConfirmCallback(bool val);

	public TextMeshProUGUI text;

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
