using NSEipix.Repository;

namespace NSMedieval.Research
{
	public class ResearchRepository : DynamicJsonRepository<ResearchRepository, ResearchModel>
	{
		protected override string JsonFile()
		{
			return "Research/Research.json";
		}
	}
}
