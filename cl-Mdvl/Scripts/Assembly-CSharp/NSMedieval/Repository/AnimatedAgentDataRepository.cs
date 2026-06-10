using NSEipix.Repository;
using NSMedieval.Model;

namespace NSMedieval.Repository
{
	public class AnimatedAgentDataRepository : JsonRepository<AnimatedAgentDataRepository, AnimatedAgentData>
	{
		public AnimatedAgentData GetData(string id)
		{
			if (TryGetValue(id, out var model))
			{
				return model;
			}
			return GetByID("Default");
		}

		protected override string JsonFile()
		{
			return "Animation/AnimatedAgent.json";
		}
	}
}
