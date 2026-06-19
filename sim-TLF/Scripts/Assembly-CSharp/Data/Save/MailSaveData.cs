using System;
using System.Collections.Generic;

namespace Data.Save
{
	[Serializable]
	public struct MailSaveData
	{
		public List<MailItemSaveData> Mails;
	}
}
