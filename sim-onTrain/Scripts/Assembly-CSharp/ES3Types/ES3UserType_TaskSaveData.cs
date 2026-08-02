using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "taskIndex", "currentProgress", "isCompleted" })]
	public class ES3UserType_TaskSaveData : ES3ObjectType
	{
		public static ES3Type Instance;

		public ES3UserType_TaskSaveData()
			: base(typeof(TaskSaveData))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteObject(object obj, ES3Writer writer)
		{
			TaskSaveData taskSaveData = (TaskSaveData)obj;
			writer.WriteProperty("taskIndex", taskSaveData.taskIndex, ES3Type_int.Instance);
			writer.WriteProperty("currentProgress", taskSaveData.currentProgress, ES3Type_int.Instance);
			writer.WriteProperty("isCompleted", taskSaveData.isCompleted, ES3Type_bool.Instance);
		}

		protected override void ReadObject<T>(ES3Reader reader, object obj)
		{
			TaskSaveData taskSaveData = (TaskSaveData)obj;
			foreach (string property in reader.Properties)
			{
				switch (property)
				{
				case "taskIndex":
					taskSaveData.taskIndex = reader.Read<int>(ES3Type_int.Instance);
					break;
				case "currentProgress":
					taskSaveData.currentProgress = reader.Read<int>(ES3Type_int.Instance);
					break;
				case "isCompleted":
					taskSaveData.isCompleted = reader.Read<bool>(ES3Type_bool.Instance);
					break;
				default:
					reader.Skip();
					break;
				}
			}
		}

		protected override object ReadObject<T>(ES3Reader reader)
		{
			TaskSaveData taskSaveData = new TaskSaveData();
			ReadObject<T>(reader, taskSaveData);
			return taskSaveData;
		}
	}
}
