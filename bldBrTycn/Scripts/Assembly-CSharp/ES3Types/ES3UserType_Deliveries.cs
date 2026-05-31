using System.Collections.Generic;
using CTS;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "_currentDeliveries", "_deliveriesThisFrame" })]
	public class ES3UserType_Deliveries : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_Deliveries()
			: base(typeof(Deliveries))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			Deliveries objectContainingField = (Deliveries)obj;
			writer.WritePrivateField("_currentDeliveries", objectContainingField);
			writer.WritePrivateField("_deliveriesThisFrame", objectContainingField);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			Deliveries objectContainingField = (Deliveries)obj;
			foreach (string property in reader.Properties)
			{
				if (!(property == "_currentDeliveries"))
				{
					if (property == "_deliveriesThisFrame")
					{
						objectContainingField = (Deliveries)reader.SetPrivateField("_deliveriesThisFrame", reader.Read<Dictionary<float, Delivery>>(), objectContainingField);
					}
					else
					{
						reader.Skip();
					}
				}
				else
				{
					objectContainingField = (Deliveries)reader.SetPrivateField("_currentDeliveries", reader.Read<List<Delivery>>(), objectContainingField);
				}
			}
		}
	}
}
