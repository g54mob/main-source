using System;

namespace Kitchen
{
	public interface ISpecificViewResponse
	{
		void SetCallback(Action<IResponseData, Type> callback);
	}
}
