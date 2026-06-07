using System.Collections.Generic;
using CTS;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "_deliverables", "ArrivalTime" })]
	public class ES3UserType_Delivery : ES3ObjectType
	{
		public static ES3Type Instance;

		public ES3UserType_Delivery()
			: base(typeof(Delivery))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteObject(object obj, ES3Writer writer)
		{
			Delivery delivery = (Delivery)obj;
			writer.WritePrivateField("_deliverables", delivery);
			writer.WriteProperty("ArrivalTime", delivery.ArrivalTime, ES3Type_float.Instance);
		}

		protected override void ReadObject<T>(ES3Reader reader, object obj)
		{
			Delivery delivery = (Delivery)obj;
			foreach (string property in reader.Properties)
			{
				if (!(property == "_deliverables"))
				{
					if (property == "ArrivalTime")
					{
						delivery.ArrivalTime = reader.Read<float>(ES3Type_float.Instance);
					}
					else
					{
						reader.Skip();
					}
				}
				else
				{
					delivery = (Delivery)reader.SetPrivateField("_deliverables", reader.Read<List<StockStack>>(), delivery);
				}
			}
		}

		protected override object ReadObject<T>(ES3Reader reader)
		{
			Delivery delivery = new Delivery();
			ReadObject<T>(reader, delivery);
			return delivery;
		}
	}
}
