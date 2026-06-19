using System;
using Michsky.DreamOS;

namespace Data.Save
{
	[Serializable]
	public struct MailItemSaveData
	{
		public string Title;

		public string From;

		public string FromName;

		public string To;

		public string Subject;

		public string MailContent;

		public string Date;

		public string Time;

		public MailItem.MailFolder MailFolder;

		public string CustomContentAddressable;

		public string MissionId;
	}
}
