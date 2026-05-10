using CTS;
using CTS.Core.Utilities;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	public class ES3UserType_MainQuest10 : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_MainQuest10()
			: base(typeof(MainQuest10))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			MainQuest10 mainQuest = (MainQuest10)obj;
			writer.WriteProperty("DeliveryComplete", mainQuest.DeliveryComplete);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			MainQuest10 objectContainingField = (MainQuest10)obj;
			foreach (string property in reader.Properties)
			{
				if (property == "DeliveryComplete")
				{
					reader.SetPrivateField("DeliveryComplete".ToBackingField(), reader.Read<bool>(), objectContainingField);
				}
				else
				{
					reader.Skip();
				}
			}
		}
	}
}
