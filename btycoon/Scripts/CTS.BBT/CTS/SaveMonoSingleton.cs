using CTS.Core;

namespace CTS
{
	public class SaveMonoSingleton<TSingleton> : SaveContainer where TSingleton : MonoSingleton<TSingleton>
	{
		public override void Save(ES3Settings settings)
		{
			ES3.Save(typeof(TSingleton).Name, MonoSingleton<TSingleton>.Instance, settings);
		}

		public override void LoadInit(ES3Settings settings)
		{
			LoadInto(typeof(TSingleton).Name, MonoSingleton<TSingleton>.Instance, settings);
		}

		public override void LoadPost(ES3Settings settings)
		{
		}
	}
}
