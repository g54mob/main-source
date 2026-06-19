using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

namespace Michsky.DreamOS
{
	[CreateAssetMenu(fileName = "New Item", menuName = "DreamOS/New Mail Item")]
	public class MailItem : ScriptableObject
	{
		[Serializable]
		public class AttachmentItem
		{
			public string attachmentTitle = "Subject";

			public Attachment attachmentType;

			public AudioClip musicAttachment;

			public Sprite pictureAttachment;

			public VideoClip videoAttachment;

			[TextArea]
			public string noteAttachment;
		}

		public enum MailFolder
		{
			Inbox = 0,
			Sent = 1,
			Junk = 2
		}

		public enum Attachment
		{
			Music = 0,
			Note = 1,
			Picture = 2,
			Video = 3
		}

		public MailFolder mailFolder;

		public string subject = "Subject";

		public string from = "from@mail.com";

		public string fromName = "Butters Stotch";

		public string to = "to@mail.com";

		public string time = "12:00";

		public string date = "2022.01.01";

		public Sprite contactImage;

		public bool useCustomContent;

		[TextArea(3, 10)]
		public string mailContent = "";

		public GameObject customContentPrefab;

		public List<AttachmentItem> attachments = new List<AttachmentItem>();

		public string subjectKey;

		public string contentKey;
	}
}
