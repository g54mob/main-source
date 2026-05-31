using System.Collections.Generic;

namespace Photon.Realtime
{
	internal class ErrorInfoCallbacksContainer : List<IErrorInfoCallback>, IErrorInfoCallback
	{
		private LoadBalancingClient client;

		public ErrorInfoCallbacksContainer(LoadBalancingClient client)
		{
		}

		public void OnErrorInfo(ErrorInfo errorInfo)
		{
		}
	}
}
