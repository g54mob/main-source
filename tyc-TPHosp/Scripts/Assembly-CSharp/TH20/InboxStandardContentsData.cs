using System;
using TMPro;
using UnityEngine;

namespace TH20
{
	[Serializable]
	public class InboxStandardContentsData
	{
		[SerializeField]
		private TMP_Text _messageText;

		public void Setup(string messageText)
		{
			_messageText.text = messageText.Replace("\\n", "\n");
		}
	}
}
