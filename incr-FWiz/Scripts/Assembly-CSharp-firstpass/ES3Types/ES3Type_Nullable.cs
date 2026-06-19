using System;
using ES3Internal;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	public class ES3Type_Nullable : ES3Type
	{
		public ES3Type argumentES3Type;

		public Type genericArgument;

		private ES3Reflection.ES3ReflectedMember hasValueProperty;

		private ES3Reflection.ES3ReflectedMember valueProperty;

		public ES3Type_Nullable()
			: base(null)
		{
		}

		public ES3Type_Nullable(Type type)
			: base(null)
		{
		}

		public override void Write(object obj, ES3Writer writer)
		{
		}

		public override object Read<T>(ES3Reader reader)
		{
			return null;
		}
	}
}
