using NSEipix.Repository;
using NSMedieval.GameEventSystem;

namespace NSMedieval.Repository
{
	public class ReleasePrisonersFriendlinessBuffByMoodData : DynamicSettingsData<ReleasePrisonersFriendlinessBuffByMoodData, InterpolatedValueList>
	{
		protected override string JsonFile()
		{
			return "Settings/ReleasePrisonersFriendlinessBuffByMood.json";
		}
	}
}
