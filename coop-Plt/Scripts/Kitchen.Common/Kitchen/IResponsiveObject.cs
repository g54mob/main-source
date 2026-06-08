using System;

namespace Kitchen
{
	public interface IResponsiveObject
	{
		Type ResponseType { get; }

		bool HasStateUpdate(out IResponseData state);
	}
}
