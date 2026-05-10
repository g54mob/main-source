using System;
using CTS.BBT.AI;
using ES3Types;

namespace CTS
{
	public class ES3UserType_GroupOrderArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_GroupOrderArray(Type type)
			: base(typeof(GroupOrder[]), ES3UserType_GroupOrder.Instance)
		{
			Instance = this;
		}
	}
}
