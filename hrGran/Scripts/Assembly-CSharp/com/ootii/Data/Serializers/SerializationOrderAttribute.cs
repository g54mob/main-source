using System;

namespace com.ootii.Data.Serializers
{
	public class SerializationOrderAttribute : Attribute
	{
		protected int mValue;

		public int Value => 0;

		public SerializationOrderAttribute(int rValue)
		{
		}
	}
}
