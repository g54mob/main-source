using TMPro;
using UnityEngine;

public class ToastMessage : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _messageText;

	public void SetMessage(string message)
	{
		_messageText.text = message;
	}

	public void DestroyToast()
	{
		Object.Destroy(base.gameObject);
	}
}
