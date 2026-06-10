using NSMedieval.Model;

namespace NSMedieval.Repository
{
	public class BackStoryRepository : BackgroundRepositoryBase<BackStoryRepository, BackStory>
	{
		protected override string JsonFile()
		{
			return "Worker/BackStory.json";
		}
	}
}
