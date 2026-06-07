using System.Collections.ObjectModel;

namespace Jundroo.SocialPlatforms.Steam
{
	public interface IPublishWorkshopItemOperation
	{
		string Description { get; }

		string FolderPath { get; }

		string Language { get; }

		string ModName { get; }

		bool MustAcceptLicenseAgreement { get; }

		string PreviewPath { get; }

		ulong? PublishedFileId { get; }

		PublishWorkshopItemOperationStatus Status { get; }

		string StatusDetails { get; }

		ReadOnlyCollection<string> Tags { get; }

		string Title { get; }

		SteamVisibility Visibility { get; }

		void OpenWorkshopBrowserPage();

		void PublishAsync();

		void UpdateStatus();
	}
}
