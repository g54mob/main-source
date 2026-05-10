using CTS.BBT;

namespace CTS
{
	public class SaveLevelParameters : SaveCTSSingleton<LevelParameters>
	{
		public override void LoadPost(ES3Settings settings)
		{
			LoadInit(settings);
		}
	}
}
