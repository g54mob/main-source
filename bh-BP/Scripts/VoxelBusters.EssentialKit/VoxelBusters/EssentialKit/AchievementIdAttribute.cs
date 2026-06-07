using VoxelBusters.CoreLibrary;

namespace VoxelBusters.EssentialKit
{
	public class AchievementIdAttribute : StringPopupAttribute
	{
		private string[] m_options;

		public AchievementIdAttribute()
			: base((string)null, false, (string[])null)
		{
		}

		private static string[] GetAchievementIds()
		{
			return null;
		}

		protected override string[] GetDynamicOptions()
		{
			return null;
		}
	}
}
