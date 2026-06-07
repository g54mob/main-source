using VoxelBusters.CoreLibrary;
using VoxelBusters.CoreLibrary.NativePlugins;

namespace VoxelBusters.EssentialKit.GameServicesCore
{
	public abstract class AchievementDescriptionBase : NativeObjectBase, IAchievementDescription
	{
		public string Id { get; internal set; }

		public string PlatformId { get; private set; }

		public string Title => null;

		public string UnachievedDescription => null;

		public string AchievedDescription => null;

		public long MaximumPoints => 0L;

		public int NumberOfStepsRequiredToUnlockAchievement { get; private set; }

		public bool IsHidden => false;

		public bool IsReplayable => false;

		protected AchievementDescriptionBase(string id, string platformId, int numOfStepsToUnlock)
		{
		}

		protected abstract string GetTitleInternal();

		protected abstract string GetUnachievedDescriptionInternal();

		protected abstract string GetAchievedDescriptionInternal();

		protected abstract long GetMaximumPointsInternal();

		protected abstract bool GetIsHiddenInternal();

		protected abstract bool GetIsReplayableInternal();

		protected abstract void LoadIncompleteAchievementImageInternal(LoadImageInternalCallback callback);

		protected abstract void LoadImageInternal(LoadImageInternalCallback callback);

		public override string ToString()
		{
			return null;
		}

		public void LoadIncompleteAchievementImage(EventCallback<TextureData> callback)
		{
		}

		public void LoadImage(EventCallback<TextureData> callback)
		{
		}
	}
}
