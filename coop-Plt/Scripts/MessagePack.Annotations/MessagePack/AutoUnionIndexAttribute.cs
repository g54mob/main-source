using System;

namespace MessagePack
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface, AllowMultiple = false, Inherited = false)]
	public class AutoUnionIndexAttribute : Attribute
	{
		public int Index;

		public AutoUnionIndexAttribute(int i)
		{
			Index = i;
		}
	}
}
