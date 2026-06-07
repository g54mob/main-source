using System;
using Steamworks;

namespace Assets.Nimbatus.Scripts.Workshop
{
	[Serializable]
	public class CreateWorkshopItemInformation
	{
		public PublishedFileId_t Id { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }

		public string Language { get; set; }

		public EWorkshopTag Tag { get; set; }

		public string ChangeNote { get; set; }
	}
}
