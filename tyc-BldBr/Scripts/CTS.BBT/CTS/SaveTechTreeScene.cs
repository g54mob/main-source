using CTS.BBT.TechTree;
using CTS.Core;
using CTS.TechTree;

namespace CTS
{
	public class SaveTechTreeScene : SaveContainer
	{
		public override void Save(ES3Settings settings)
		{
			ES3.Save("TechPoints", TechTreeManager.GetCurrentPoints, settings);
		}

		public override void LoadInit(ES3Settings settings)
		{
		}

		public override void LoadPost(ES3Settings settings)
		{
			CTSSingleton<TechTreePoints>.Instance.LoadPoints(ES3.Load("TechPoints", 0, settings));
		}
	}
}
