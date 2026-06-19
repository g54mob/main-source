using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblAchievementRequirement
	{
		public string Id { get; }

		public string CurrentProgressValue { get; }

		public string TargetProgressValue { get; }

		internal XblAchievementRequirement(XGamingRuntime.Interop.XblAchievementRequirement interopRequirement)
		{
			Id = interopRequirement.id.GetString();
			CurrentProgressValue = interopRequirement.currentProgressValue.GetString();
			TargetProgressValue = interopRequirement.targetProgressValue.GetString();
		}
	}
}
