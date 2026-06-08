using System;

namespace Moq
{
	public interface ITypeMatcher
	{
		bool Matches(Type typeArgument);
	}
}
