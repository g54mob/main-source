using System;
using System.Reflection;

namespace Castle.DynamicProxy.Generators.Emitters
{
	internal interface IMemberEmitter
	{
		MemberInfo Member { get; }

		Type ReturnType { get; }

		void EnsureValidCodeBlock();

		void Generate();
	}
}
