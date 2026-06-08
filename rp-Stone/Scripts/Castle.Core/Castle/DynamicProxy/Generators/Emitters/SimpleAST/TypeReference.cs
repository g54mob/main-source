using System;

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	public abstract class TypeReference : Reference
	{
		private readonly Type type;

		public Type Type => type;

		protected TypeReference(Type argumentType)
			: this(null, argumentType)
		{
		}

		protected TypeReference(Reference owner, Type type)
			: base(owner)
		{
			this.type = type;
		}
	}
}
