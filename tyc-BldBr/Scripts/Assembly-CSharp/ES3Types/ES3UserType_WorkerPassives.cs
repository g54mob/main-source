using System.Collections.Generic;
using CTS;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "_agentStatistics", "<CurrentPassives>k__BackingField" })]
	public class ES3UserType_WorkerPassives : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_WorkerPassives()
			: base(typeof(WorkerPassives))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			WorkerPassives workerPassives = (WorkerPassives)obj;
			if (workerPassives.CurrentPassives.Count <= 0)
			{
				return;
			}
			List<AssetRef<StatisticBonusFactory>> list = new List<AssetRef<StatisticBonusFactory>>();
			foreach (StatisticBonusFactory currentPassife in workerPassives.CurrentPassives)
			{
				list.Add(currentPassife);
			}
			if (list.Count > 0)
			{
				writer.WriteProperty("<CurrentPassives>k__BackingField", list);
			}
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			WorkerPassives workerPassives = (WorkerPassives)obj;
			foreach (string property in reader.Properties)
			{
				if (property == "<CurrentPassives>k__BackingField")
				{
					workerPassives.ClearPassives();
					foreach (AssetRef<StatisticBonusFactory> item in reader.Read<List<AssetRef<StatisticBonusFactory>>>())
					{
						if ((bool)item.Asset)
						{
							workerPassives.CurrentPassives.Add(item.Asset);
						}
					}
					workerPassives.ReloadPassives();
				}
				else
				{
					reader.Skip();
				}
			}
		}
	}
}
