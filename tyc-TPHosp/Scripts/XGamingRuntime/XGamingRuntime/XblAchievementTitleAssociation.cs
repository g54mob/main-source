using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblAchievementTitleAssociation
	{
		public string Name { get; }

		public uint TitleId { get; }

		internal XblAchievementTitleAssociation(XGamingRuntime.Interop.XblAchievementTitleAssociation interopTitleAssociation)
		{
			Name = interopTitleAssociation.name.GetString();
			TitleId = interopTitleAssociation.titleId;
		}
	}
}
