using CTS.Core;

namespace CTS
{
	public class SaveMaeve : SaveMonoSingleton<MaeveExtermination>
	{
		public override void Save(ES3Settings settings)
		{
			if (MonoSingleton<MaeveExtermination>.InstanceExists())
			{
				ES3.Save("MaeveExtermination", MonoSingleton<MaeveExtermination>.Instance.Save(), settings);
			}
		}

		public override void LoadPost(ES3Settings settings)
		{
			if (MonoSingleton<MaeveExtermination>.InstanceExists())
			{
				MonoSingleton<MaeveExtermination>.Instance.Load(ES3.Load("MaeveExtermination", default(MaeveSaveData), settings));
			}
		}
	}
}
