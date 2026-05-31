using System;
using System.Collections.Generic;
using CTS.BBT;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "_furnitures" })]
	public class ES3UserType_BarFurnitures : ES3ObjectType
	{
		public static ES3Type Instance;

		public ES3UserType_BarFurnitures()
			: base(typeof(BarFurnitures))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteObject(object obj, ES3Writer writer)
		{
			BarFurnitures objectContainingField = (BarFurnitures)obj;
			writer.WritePrivateField("_furnitures", objectContainingField);
		}

		protected override void ReadObject<T>(ES3Reader reader, object obj)
		{
			BarFurnitures objectContainingField = (BarFurnitures)obj;
			foreach (string property in reader.Properties)
			{
				if (property == "_furnitures")
				{
					objectContainingField = (BarFurnitures)reader.SetPrivateField("_furnitures", reader.Read<Dictionary<Type, List<Furniture>>>(), objectContainingField);
				}
				else
				{
					reader.Skip();
				}
			}
		}

		protected override object ReadObject<T>(ES3Reader reader)
		{
			BarFurnitures barFurnitures = new BarFurnitures();
			ReadObject<T>(reader, barFurnitures);
			return barFurnitures;
		}
	}
}
