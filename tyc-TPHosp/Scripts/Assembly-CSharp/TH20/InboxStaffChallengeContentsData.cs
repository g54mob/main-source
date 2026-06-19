using System;
using TMPro;
using UnityEngine;

namespace TH20
{
	[Serializable]
	public class InboxStaffChallengeContentsData
	{
		[SerializeField]
		private TMP_Text _messageText;

		[SerializeField]
		private TMP_Text _challengeText;

		public void Setup(NotificationStaffChallenge message)
		{
			_messageText.text = message.GetFlavourText();
			_challengeText.text = message.GetChallengeText();
		}
	}
}
