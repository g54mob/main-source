using System;
using System.Reflection;

namespace Trivial.Mono.Cecil
{
	public interface IReflectionImporter
	{
		TypeReference ImportReference(Type type, IGenericParameterProvider context);

		FieldReference ImportReference(FieldInfo field, IGenericParameterProvider context);

		MethodReference ImportReference(MethodBase method, IGenericParameterProvider context);
	}
}
