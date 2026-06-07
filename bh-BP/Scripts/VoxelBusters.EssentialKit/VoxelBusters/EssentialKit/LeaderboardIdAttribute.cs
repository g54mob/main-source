using VoxelBusters.CoreLibrary;

namespace VoxelBusters.EssentialKit
{
	public class LeaderboardIdAttribute : StringPopupAttribute
	{
		private string[] m_options;

		public LeaderboardIdAttribute()
			: base((string)null, false, (string[])null)
		{
		}

		private static string[] GetLeaderboardIds()
		{
			return null;
		}

		protected override string[] GetDynamicOptions()
		{
			return null;
		}
	}
}
