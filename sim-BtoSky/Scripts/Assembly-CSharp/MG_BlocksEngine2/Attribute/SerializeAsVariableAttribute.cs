using System;

namespace MG_BlocksEngine2.Attribute
{
	public class SerializeAsVariableAttribute : System.Attribute
	{
		public Type variablesManagerType;

		public SerializeAsVariableAttribute(Type variablesManagerType)
		{
			this.variablesManagerType = variablesManagerType;
		}
	}
}
