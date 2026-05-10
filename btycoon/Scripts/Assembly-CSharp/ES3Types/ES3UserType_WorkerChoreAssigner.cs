using System.Collections.Generic;
using CTS.BBT;
using CTS.BBT.AI;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "_priorities", "_prioritiesStatus", "IsLocked" })]
	public class ES3UserType_WorkerChoreAssigner : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_WorkerChoreAssigner()
			: base(typeof(WorkerChoreAssigner))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			WorkerChoreAssigner workerChoreAssigner = (WorkerChoreAssigner)obj;
			writer.WritePrivateField("_priorities", workerChoreAssigner);
			writer.WritePrivateField("_prioritiesStatus", workerChoreAssigner);
			writer.WritePrivateProperty("IsLocked", workerChoreAssigner);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			WorkerChoreAssigner workerChoreAssigner = (WorkerChoreAssigner)obj;
			bool flag = false;
			foreach (string property in reader.Properties)
			{
				switch (property)
				{
				case "_priorities":
					workerChoreAssigner = (WorkerChoreAssigner)reader.SetPrivateField("_priorities", reader.Read<List<ChoreCategory>>(), workerChoreAssigner);
					break;
				case "_prioritiesStatus":
					workerChoreAssigner = (WorkerChoreAssigner)reader.SetPrivateField("_prioritiesStatus", reader.Read<Dictionary<ChoreCategory, bool>>(), workerChoreAssigner);
					break;
				case "IsLocked":
					flag = reader.Read<bool>();
					break;
				default:
					reader.Skip();
					break;
				}
			}
			if (flag)
			{
				workerChoreAssigner.SetActive(value: false);
			}
		}
	}
}
