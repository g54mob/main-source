using System.Collections.Generic;
using ES3Internal;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "currentGroupIndex", "taskGroupsProgress" })]
	public class ES3UserType_TutorialSaveData : ES3ObjectType
	{
		public static ES3Type Instance;

		public ES3UserType_TutorialSaveData()
			: base(typeof(TutorialSaveData))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteObject(object obj, ES3Writer writer)
		{
			TutorialSaveData tutorialSaveData = (TutorialSaveData)obj;
			writer.WriteProperty("currentGroupIndex", tutorialSaveData.currentGroupIndex, ES3Type_int.Instance);
			writer.WriteProperty("taskGroupsProgress", tutorialSaveData.taskGroupsProgress, ES3TypeMgr.GetOrCreateES3Type(typeof(List<TaskGroupSaveData>)));
		}

		protected override void ReadObject<T>(ES3Reader reader, object obj)
		{
			TutorialSaveData tutorialSaveData = (TutorialSaveData)obj;
			foreach (string property in reader.Properties)
			{
				if (!(property == "currentGroupIndex"))
				{
					if (property == "taskGroupsProgress")
					{
						tutorialSaveData.taskGroupsProgress = reader.Read<List<TaskGroupSaveData>>();
					}
					else
					{
						reader.Skip();
					}
				}
				else
				{
					tutorialSaveData.currentGroupIndex = reader.Read<int>(ES3Type_int.Instance);
				}
			}
		}

		protected override object ReadObject<T>(ES3Reader reader)
		{
			TutorialSaveData tutorialSaveData = new TutorialSaveData();
			ReadObject<T>(reader, tutorialSaveData);
			return tutorialSaveData;
		}
	}
}
