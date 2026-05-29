using CTS.Core;

namespace CTS
{
	public class SaveCTSSingleton<TSingleton> : SaveContainer where TSingleton : CTSSingleton<TSingleton>
	{
		public override void Save(ES3Settings settings)
		{
			ES3.Save(typeof(TSingleton).Name, CTSSingleton<TSingleton>.Instance, settings);
		}

		public override void LoadInit(ES3Settings settings)
		{
			LoadInto(typeof(TSingleton).Name, CTSSingleton<TSingleton>.Instance, settings);
		}

		public override void LoadPost(ES3Settings settings)
		{
		}
	}
}
