using System;

namespace FullSerializerSave
{
	public sealed class fsMissingVersionConstructorException : Exception
	{
		public fsMissingVersionConstructorException(Type versionedType, Type constructorType)
			: base(versionedType?.ToString() + " is missing a constructor for previous model type " + constructorType)
		{
		}
	}
}
