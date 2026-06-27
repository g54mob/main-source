using System;

namespace Restory.Gameplay.EmailSystems
{
	[Serializable]
	public class EmailLetterRecordInFolder
	{
		public IEmailLetterRecord Email;

		public EmailFolders Folder;
	}
}
