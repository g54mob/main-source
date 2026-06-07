using ES3Internal;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "type", "rotateSpeed", "isActive" })]
	public class ES3UserType_QuestIndicator : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_QuestIndicator()
			: base(typeof(QuestIndicator))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			QuestIndicator questIndicator = (QuestIndicator)obj;
			writer.WriteProperty("type", questIndicator.type, ES3TypeMgr.GetOrCreateES3Type(typeof(QuestType)));
			writer.WriteProperty("rotateSpeed", questIndicator.rotateSpeed, ES3Type_float.Instance);
			writer.WritePrivateField("isActive", questIndicator);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			QuestIndicator questIndicator = (QuestIndicator)obj;
			foreach (string property in reader.Properties)
			{
				switch (property)
				{
				case "type":
					questIndicator.type = reader.Read<QuestType>();
					break;
				case "rotateSpeed":
					questIndicator.rotateSpeed = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "isActive":
					questIndicator = (QuestIndicator)reader.SetPrivateField("isActive", reader.Read<bool>(), questIndicator);
					break;
				default:
					reader.Skip();
					break;
				}
			}
		}
	}
}
