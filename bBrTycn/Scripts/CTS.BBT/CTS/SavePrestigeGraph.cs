using System;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class SavePrestigeGraph : SaveMonoSingleton<UI_PrestigeGraph>
	{
		public override void Save(ES3Settings settings)
		{
			if (MonoSingleton<UI_PrestigeGraph>.InstanceExists())
			{
				ES3.Save("UI_PrestigeGraph", MonoSingleton<UI_PrestigeGraph>.Instance.SaveData(), settings);
			}
		}

		public override void LoadPost(ES3Settings settings)
		{
			if (!MonoSingleton<UI_PrestigeGraph>.InstanceExists())
			{
				return;
			}
			try
			{
				MonoSingleton<UI_PrestigeGraph>.Instance.LoadData(ES3.Load("UI_PrestigeGraph", default(GraphSaveStruct), settings));
				Debug.Log("Load New Save...");
			}
			catch (Exception)
			{
			}
		}
	}
}
