namespace CTS
{
	public class SavePrestigeStats : SaveMonoSingleton<UI_PrestigeStatsPanel>
	{
		public override void Save(ES3Settings settings)
		{
			ES3.Save("UI_PrestigeStatsPanel", UI_PrestigeStatsPanel.Save(), settings);
		}

		public override void LoadPost(ES3Settings settings)
		{
			UI_PrestigeStatsPanel.Load(ES3.Load("UI_PrestigeStatsPanel", default(StatsSaveStruct), settings));
		}
	}
}
