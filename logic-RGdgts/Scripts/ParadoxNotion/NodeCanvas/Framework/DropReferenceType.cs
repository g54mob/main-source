using System;

namespace NodeCanvas.Framework
{
	public class DropReferenceType : Attribute
	{
		public readonly Type type;

		public DropReferenceType(Type type)
		{
		}
	}
}
