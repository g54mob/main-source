using System.Collections.Generic;
using CTS.BBT;
using CTS.BBT.AI;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { })]
	public class ES3UserType_StationMorgue : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_StationMorgue()
			: base(typeof(StationMorgue))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			StationMorgue stationMorgue = (StationMorgue)obj;
			writer.WriteProperty("Bodies", stationMorgue.DeadBodies.Copy());
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			StationMorgue objectContainingField = (StationMorgue)obj;
			foreach (string property in reader.Properties)
			{
				if (!(property == "_deadBodyList"))
				{
					if (property == "Bodies")
					{
						reader.SetPrivateField("_deadBodies", reader.Read<List<DeadBodyData>>(), objectContainingField);
					}
					else
					{
						reader.Skip();
					}
					continue;
				}
				List<Customer> list = reader.Read<List<Customer>>();
				List<DeadBodyData> list2 = new List<DeadBodyData>();
				foreach (Customer item in list)
				{
					list2.Add(new DeadBodyData(item));
				}
				reader.SetPrivateField("_deadBodies", list2, objectContainingField);
			}
		}
	}
}
