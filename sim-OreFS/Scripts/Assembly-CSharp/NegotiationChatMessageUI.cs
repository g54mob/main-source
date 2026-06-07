using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NegotiationChatMessageUI : MonoBehaviour
{
	[Header("UI Elements")]
	[Tooltip("Mesaj metni")]
	[SerializeField]
	private TextMeshProUGUI messageText;

	[Tooltip("Mesaj balonu background")]
	[SerializeField]
	private Image bubbleBackground;

	private bool _isSeller;

	private string _message;

	public bool IsSeller => _isSeller;

	public string Message => _message;

	public void Initialize(string message, bool isSeller)
	{
		_message = message;
		_isSeller = isSeller;
		UpdateUI();
	}

	private void UpdateUI()
	{
		if (messageText != null)
		{
			messageText.text = _message;
		}
	}
}
