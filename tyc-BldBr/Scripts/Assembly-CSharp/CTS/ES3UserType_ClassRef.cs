using System;
using ES3Internal;
using ES3Types;
using UnityEngine.Scripting;

namespace CTS
{
	[Preserve]
	public class ES3UserType_ClassRef : ES3GenericType
	{
		public override Type GetGenericType()
		{
			return typeof(ClassRef<>);
		}

		public override Type GetGenericES3Type()
		{
			return typeof(ES3UserType_ClassRef<>);
		}
	}
	[Preserve]
	public class ES3UserType_ClassRef<T> : ES3Type where T : class
	{
		public ES3UserType_ClassRef(Type type)
			: base(type)
		{
			isPrimitive = true;
		}

		public override void Write(object obj, ES3Writer writer)
		{
			writer.Write(((ClassRef<T>)obj).Ref.ToString(), ES3Type_string.Instance);
		}

		public override object Read<T1>(ES3Reader reader)
		{
			Guid guid = Guid.Parse(reader.Read<string>(ES3Type_string.Instance));
			return (ClassRef<T>)reader.SetPrivateField("Ref", guid, default(ClassRef<T>));
		}
	}
}
