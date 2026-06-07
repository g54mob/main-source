using System;

namespace CTS.Core
{
	[AttributeUsage(AttributeTargets.Field)]
	public class TypeAttribute : Attribute
	{
		public Type BaseType { get; }

		public bool AllowEditor { get; }

		public bool AllowGenerics { get; }

		public bool AllowPrivates { get; }

		public bool AllowAbstracts { get; }

		public TypeAttribute(Type baseType = null, bool allowEditor = false, bool allowGenerics = false, bool allowPrivates = false, bool allowAbstracts = true)
		{
			BaseType = baseType;
			AllowEditor = allowEditor;
			AllowGenerics = allowGenerics;
			AllowPrivates = allowPrivates;
			AllowAbstracts = allowAbstracts;
		}
	}
}
