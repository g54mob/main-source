using CTS;
using CTS.BBT;
using CTS.BBT.AI;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "<CurrentChore>k__BackingField", "InsideFurniture" })]
	public class ES3UserType_JunkObject : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_JunkObject()
			: base(typeof(JunkObject))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			JunkObject junkObject = (JunkObject)obj;
			writer.WritePrivateField("<CurrentChore>k__BackingField", junkObject);
			writer.WriteProperty("InsideFurniture", junkObject.InsideFurniture, ES3.ReferenceMode.ByRef);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			JunkObject junkObject = (JunkObject)obj;
			foreach (string property in reader.Properties)
			{
				if (!(property == "<CurrentChore>k__BackingField"))
				{
					if (property == "InsideFurniture")
					{
						junkObject.InsideFurniture = reader.Read<Furniture>(ES3UserType_Furniture.Instance);
					}
					else
					{
						reader.Skip();
					}
				}
				else
				{
					junkObject = (JunkObject)reader.SetPrivateField("<CurrentChore>k__BackingField", reader.Read<WorkerChoreDiscardJunk>(), junkObject);
				}
			}
		}
	}
}
