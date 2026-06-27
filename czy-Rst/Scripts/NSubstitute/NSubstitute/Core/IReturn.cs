using System;

namespace NSubstitute.Core
{
	public interface IReturn
	{
		object? ReturnFor(CallInfo info);

		Type? TypeOrNull();

		bool CanBeAssignedTo(Type t);
	}
}
