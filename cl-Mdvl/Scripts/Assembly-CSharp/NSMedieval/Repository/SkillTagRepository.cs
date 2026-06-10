using System.Collections.Generic;
using NSEipix.Repository;
using NSMedieval.Model;
using NSMedieval.StatsSystem;
using NSMedieval.Types;

namespace NSMedieval.Repository
{
	public class SkillTagRepository : DynamicJsonRepository<SkillTagRepository, SkillTag>
	{
		private readonly Dictionary<SkillType, SkillTag> skillTagsByTypeCache = new Dictionary<SkillType, SkillTag>();

		public List<ActionTagType> GetSkillTags(SkillType skillType)
		{
			if (skillTagsByTypeCache.ContainsKey(skillType))
			{
				return skillTagsByTypeCache[skillType].Tags;
			}
			SkillTag first = GetFirst((SkillTag skill) => skill != null && skill.Id.Equals(skillType));
			if (first == null)
			{
				return null;
			}
			skillTagsByTypeCache.Add(skillType, first);
			return first.Tags;
		}

		protected override string JsonFile()
		{
			return "Worker/SkillTag.json";
		}
	}
}
