using System.Collections.Generic;
using Data;
using Michsky.DreamOS;
using UnityEngine;

namespace Computer.Services
{
	public class MailService : IMailService
	{
		private readonly MailManager _mailManager;

		public Dictionary<string, string> CustomContentKeys { get; private set; }

		public Dictionary<string, string> MissionIDs { get; private set; }

		public Dictionary<string, GameObject> CustomContentInstances { get; private set; }

		public MailService(MailManager mailManager)
		{
			CustomContentKeys = new Dictionary<string, string>();
			MissionIDs = new Dictionary<string, string>();
			CustomContentInstances = new Dictionary<string, GameObject>();
			_mailManager = mailManager;
		}

		void IMailService.SendMail(MailObject mailObject)
		{
			MailManager.MailAsset mailAsset = new MailManager.MailAsset();
			MailItem mailItem = ScriptableObject.CreateInstance<MailItem>();
			mailItem.time = mailObject.Time;
			mailItem.date = mailObject.Date;
			mailItem.from = mailObject.From;
			mailItem.fromName = mailObject.FromName;
			mailItem.to = mailObject.To;
			mailItem.subject = mailObject.Subject;
			mailItem.contactImage = mailObject.ContactImage;
			mailItem.attachments = mailObject.Attachments;
			mailItem.useCustomContent = mailObject.UseCustomContent;
			mailItem.mailContent = mailObject.MailContent;
			mailItem.customContentPrefab = mailObject.CustomContentPrefab;
			mailItem.mailFolder = mailObject.MailFolder;
			mailItem.contentKey = mailObject.ContentKey;
			mailItem.subjectKey = mailObject.SubjectKey;
			mailAsset.itemTitle = mailObject.Title;
			mailAsset.mailAsset = mailItem;
			string key = mailObject.Subject + mailObject.Date;
			if (mailObject.UseCustomContent && !string.IsNullOrEmpty(mailObject.CustomContentAddressableKey))
			{
				CustomContentKeys[key] = mailObject.CustomContentAddressableKey;
			}
			if (!string.IsNullOrEmpty(mailObject.MissionId))
			{
				MissionIDs[key] = mailObject.MissionId;
			}
			_mailManager.AddMailItem(mailAsset);
		}
	}
}
