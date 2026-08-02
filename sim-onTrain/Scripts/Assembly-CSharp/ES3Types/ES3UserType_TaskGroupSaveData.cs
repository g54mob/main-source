using System.Collections.Generic;
using ES3Internal;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "groupIndex", "tasksProgress" })]
	public class ES3UserType_TaskGroupSaveData : ES3ObjectType
	{
		public static ES3Type Instance;

		public ES3UserType_TaskGroupSaveData()
			: base(typeof(TaskGroupSaveData))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteObject(object obj, ES3Writer writer)
		{
			TaskGroupSaveData taskGroupSaveData = (TaskGroupSaveData)obj;
			writer.WriteProperty("groupIndex", taskGroupSaveData.groupIndex, ES3Type_int.Instance);
			writer.WriteProperty("tasksProgress", taskGroupSaveData.tasksProgress, ES3TypeMgr.GetOrCreateES3Type(typeof(List<TaskSaveData>)));
		}

		protected override void ReadObject<T>(ES3Reader reader, object obj)
		{
			TaskGroupSaveData taskGroupSaveData = (TaskGroupSaveData)obj;
			foreach (string property in reader.Properties)
			{
				if (!(property == "groupIndex"))
				{
					if (property == "tasksProgress")
					{
						taskGroupSaveData.tasksProgress = reader.Read<List<TaskSaveData>>();
					}
					else
					{
						reader.Skip();
					}
				}
				else
				{
					taskGroupSaveData.groupIndex = reader.Read<int>(ES3Type_int.Instance);
				}
			}
		}

		protected override object ReadObject<T>(ES3Reader reader)
		{
			TaskGroupSaveData taskGroupSaveData = new TaskGroupSaveData();
			ReadObject<T>(reader, taskGroupSaveData);
			return taskGroupSaveData;
		}
	}
}
