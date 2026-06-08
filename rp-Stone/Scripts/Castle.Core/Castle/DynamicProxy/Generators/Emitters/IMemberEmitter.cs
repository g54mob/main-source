using System;
using System.Reflection;

namespace Castle.DynamicProxy.Generators.Emitters
{
	public interface IMemberEmitter
	{
		MemberInfo Member { get; }

		Type ReturnType { get; }

		void EnsureValidCodeBlock();

		void Generate();
	}
}
