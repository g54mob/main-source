using System;
using System.Reflection;

namespace Castle.DynamicProxy.Generators
{
	public abstract class MetaTypeElement
	{
		protected readonly Type sourceType;

		internal bool CanBeImplementedExplicitly
		{
			get
			{
				if (sourceType != null)
				{
					return sourceType.GetTypeInfo().IsInterface;
				}
				return false;
			}
		}

		protected MetaTypeElement(Type sourceType)
		{
			this.sourceType = sourceType;
		}

		internal abstract void SwitchToExplicitImplementation();
	}
}
