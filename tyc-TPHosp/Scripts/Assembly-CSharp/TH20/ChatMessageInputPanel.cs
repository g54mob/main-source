using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class ChatMessageInputPanel : MonoBehaviour
	{
		public Action<string> OnChatMessageRequest;

		[SerializeField]
		private InputField _inputField;

		[SerializeField]
		private Button _postButton;

		[SerializeField]
		private TMP_Text _characterCountLabel;

		[SerializeField]
		private Color _messageInBudgetColor;

		[SerializeField]
		private Color _messageOverBudgetColor;
	}
}
