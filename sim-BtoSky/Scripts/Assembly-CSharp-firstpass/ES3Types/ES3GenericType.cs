using System;
using ES3Internal;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	public abstract class ES3GenericType : ES3Type
	{
		public Type[] genericArguments;

		public ES3Type[] genericArgumentES3Types;

		public ES3GenericType(Type type)
			: base(type)
		{
			genericArguments = ES3Reflection.GetGenericArguments(type);
			genericArgumentES3Types = new ES3Type[genericArguments.Length];
			for (int i = 0; i < genericArguments.Length; i++)
			{
				genericArgumentES3Types[i] = ES3TypeMgr.GetOrCreateES3Type(genericArguments[i], throwException: false);
				if (genericArgumentES3Types[i] == null || genericArgumentES3Types[i].isUnsupported)
				{
					isUnsupported = true;
				}
			}
		}
	}
}
