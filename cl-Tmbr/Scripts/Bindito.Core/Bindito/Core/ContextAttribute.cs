using System;
using JetBrains.Annotations;

namespace Bindito.Core
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	[MeansImplicitUse(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
	public class ContextAttribute : Attribute
	{
		public string ContextName { get; }

		public ContextAttribute(string contextName)
		{
			ContextName = contextName;
		}
	}
}
