using System;
using System.Collections.Generic;
using Michsky.DreamOS;
using UnityEngine;

namespace Data
{
	[Serializable]
	public class MailObject
	{
		public string Title;

		public MailItem.MailFolder MailFolder;

		public string Subject = "Subject";

		public string From = "from@mail.com";

		public string FromName = "Butters Stotch";

		public string To = "to@mail.com";

		public string Time = "12:00";

		public string Date = "2022.01.01";

		public Sprite ContactImage;

		public bool UseCustomContent;

		[TextArea(3, 10)]
		public string MailContent = "";

		public GameObject CustomContentPrefab;

		public string CustomContentAddressableKey;

		public string MissionId;

		public List<MailItem.AttachmentItem> Attachments = new List<MailItem.AttachmentItem>();

		public string SubjectKey;

		public string ContentKey;
	}
}
