namespace CTS
{
	public class SaveAchievementProgess : SaveMonoSingleton<AchievementWatchers>
	{
		public override void Save(ES3Settings settings)
		{
			ES3.Save("AchievementWatchers", AchievementWatchers.SavingSaveProgres(), settings);
		}

		public override void LoadPost(ES3Settings settings)
		{
			AchievementWatchers.LoadSavePogress(ES3.Load("AchievementWatchers", default(AchievementWatchers.ProgressSaveSucess), settings));
		}
	}
}
