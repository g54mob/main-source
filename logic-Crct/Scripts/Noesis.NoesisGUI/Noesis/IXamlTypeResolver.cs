using System;

namespace Noesis
{
	public interface IXamlTypeResolver
	{
		Type Resolve(string qualifiedTypeName);
	}
}
