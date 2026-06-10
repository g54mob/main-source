using NSMedieval.StatsSystem;

namespace NSMedieval.Goap
{
	public interface IHarvestAgent : IStorageAgent
	{
		float GetAttributeValue(AttributeType stat);

		void AddExperience(SkillType skill, float amount, bool isSilent = false);
	}
}
