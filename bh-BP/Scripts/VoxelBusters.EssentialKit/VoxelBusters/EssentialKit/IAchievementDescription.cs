using VoxelBusters.CoreLibrary;

namespace VoxelBusters.EssentialKit
{
	public interface IAchievementDescription
	{
		string Id { get; }

		string PlatformId { get; }

		string Title { get; }

		string UnachievedDescription { get; }

		string AchievedDescription { get; }

		long MaximumPoints { get; }

		int NumberOfStepsRequiredToUnlockAchievement { get; }

		bool IsHidden { get; }

		bool IsReplayable { get; }

		void LoadIncompleteAchievementImage(EventCallback<TextureData> callback);

		void LoadImage(EventCallback<TextureData> callback);
	}
}
