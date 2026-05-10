using System;
using CTS.Core;
using ES3Internal;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	public class ES3UserType_StringKeyScriptable : ES3GenericType
	{
		public override Type GetGenericType()
		{
			return typeof(StringKey<>);
		}

		public override Type GetGenericES3Type()
		{
			return typeof(ES3UserType_StringKey<>);
		}
	}
}
