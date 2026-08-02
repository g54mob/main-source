using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "fullRatio", "isResearched", "isLearned" })]
	public class ES3UserType_CollectableItemData : ES3ScriptableObjectType
	{
		public static ES3Type Instance;

		public ES3UserType_CollectableItemData()
			: base(typeof(CollectableItemData))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteScriptableObject(object obj, ES3Writer writer)
		{
			CollectableItemData collectableItemData = (CollectableItemData)obj;
			writer.WriteProperty("fullRatio", collectableItemData.fullRatio, ES3Type_float.Instance);
			writer.WriteProperty("isResearched", collectableItemData.isResearched, ES3Type_bool.Instance);
			writer.WriteProperty("isLearned", collectableItemData.isLearned, ES3Type_bool.Instance);
		}

		protected override void ReadScriptableObject<T>(ES3Reader reader, object obj)
		{
			CollectableItemData collectableItemData = (CollectableItemData)obj;
			foreach (string property in reader.Properties)
			{
				switch (property)
				{
				case "fullRatio":
					collectableItemData.fullRatio = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "isResearched":
					collectableItemData.isResearched = reader.Read<bool>(ES3Type_bool.Instance);
					break;
				case "isLearned":
					collectableItemData.isLearned = reader.Read<bool>(ES3Type_bool.Instance);
					break;
				default:
					reader.Skip();
					break;
				}
			}
		}
	}
}
