using System;

namespace com.ootii.Data.Serializers
{
	public class SerializationNameAttribute : Attribute
	{
		protected string mValue;

		public string Value => null;

		public SerializationNameAttribute(string rValue)
		{
		}
	}
}
