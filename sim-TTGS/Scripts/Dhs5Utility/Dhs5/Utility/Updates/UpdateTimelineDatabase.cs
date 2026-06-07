using Dhs5.Utility.Databases;

namespace Dhs5.Utility.Updates
{
	[Database("Update/Timelines", typeof(UpdateTimelineObject))]
	public class UpdateTimelineDatabase : ScriptableDataContainer
	{
	}
}
