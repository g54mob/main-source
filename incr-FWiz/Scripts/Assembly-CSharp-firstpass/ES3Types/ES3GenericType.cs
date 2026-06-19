using System;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	public abstract class ES3GenericType : ES3Type
	{
		public Type[] genericArguments;

		public ES3Type[] genericArgumentES3Types;

		public ES3GenericType(Type type)
			: base(null)
		{
		}
	}
}
