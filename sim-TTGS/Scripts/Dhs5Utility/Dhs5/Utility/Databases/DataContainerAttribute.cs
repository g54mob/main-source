using System;

namespace Dhs5.Utility.Databases
{
	public class DataContainerAttribute : Attribute
	{
		public readonly Type dataType;

		public readonly bool anyType;

		public DataContainerAttribute()
		{
			anyType = true;
		}

		public DataContainerAttribute(Type dataType)
		{
			this.dataType = dataType;
			anyType = false;
		}
	}
}
