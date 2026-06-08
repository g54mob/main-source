using System.Collections.Generic;

namespace NSubstitute.Core
{
	public interface ICustomHandlers
	{
		IReadOnlyCollection<ICallHandler> Handlers { get; }

		void AddCustomHandlerFactory(CallHandlerFactory factory);
	}
}
