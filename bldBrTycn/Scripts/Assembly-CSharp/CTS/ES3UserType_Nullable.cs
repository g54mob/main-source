using System;
using ES3Internal;
using ES3Types;
using UnityEngine.Scripting;

namespace CTS
{
	[Preserve]
	public class ES3UserType_Nullable : ES3GenericType
	{
		public override Type GetGenericType()
		{
			return typeof(Nullable<>);
		}

		public override Type GetGenericES3Type()
		{
			return typeof(ES3UserType_Nullable<>);
		}
	}
	[Preserve]
	public class ES3UserType_Nullable<TObj> : ES3Type where TObj : struct
	{
		public ES3UserType_Nullable(Type type)
			: base(type)
		{
		}

		public override void Write(object obj, ES3Writer writer)
		{
			TObj? val = (TObj?)obj;
			writer.WriteProperty("HasValue", val.HasValue, ES3.ReferenceMode.ByValue);
			writer.WriteProperty("Value", val.GetValueOrDefault(), ES3.ReferenceMode.ByValue);
		}

		public override object Read<T>(ES3Reader reader)
		{
			bool flag = false;
			TObj val = default(TObj);
			while (true)
			{
				switch (reader.ReadPropertyName())
				{
				case "Value":
					val = reader.Read<TObj>();
					break;
				case "HasValue":
					flag = reader.Read<bool>();
					break;
				default:
					reader.Skip();
					break;
				case null:
					if (!flag)
					{
						return null;
					}
					return val;
				}
			}
		}
	}
}
