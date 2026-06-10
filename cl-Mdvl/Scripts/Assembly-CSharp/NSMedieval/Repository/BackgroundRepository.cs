using NSMedieval.Model;

namespace NSMedieval.Repository
{
	public class BackgroundRepository : BackgroundRepositoryBase<BackgroundRepository, Background>
	{
		protected override string JsonFile()
		{
			return "Worker/Background.json";
		}
	}
}
