using CTS.Core;

namespace CTS
{
	public class SaveVigilanceGraph : SaveMonoSingleton<UI_VigilanceStatsPanel>
	{
		public override void Save(ES3Settings settings)
		{
			ES3.Save("UI_VigilanceStatsPanel", UI_VigilanceStatsPanel.Save(), settings);
			ES3.Save("UI_VigilanceGraph", MonoSingleton<UI_VigilanceGraph>.Instance.SaveGraph(), settings);
		}

		public override void LoadPost(ES3Settings settings)
		{
			UI_VigilanceStatsPanel.Load(ES3.Load("UI_VigilanceStatsPanel", default(VigilanceStatsSaveStruct), settings));
			MonoSingleton<UI_VigilanceGraph>.Instance.LoadGraph(ES3.Load("UI_VigilanceGraph", default(GraphSaveStruct), settings));
		}
	}
}
