using System;

namespace Kitchen
{
	public interface IHandleStateUpdates
	{
		Type HandleType { get; }

		void HandleStateUpdate(ViewIdentifier view_source, IResponseData status);
	}
}
