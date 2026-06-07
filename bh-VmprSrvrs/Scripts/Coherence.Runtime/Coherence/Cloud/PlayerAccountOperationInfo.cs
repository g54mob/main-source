using Coherence.Runtime;

namespace Coherence.Cloud
{
	internal readonly struct PlayerAccountOperationInfo<TRequest> where TRequest : struct, IPlayerAccountOperationRequest
	{
		public PlayerAccountOperationType OperationType { get; }

		public TRequest? Request { get; }

		public string BasePath { get; }

		public string PathParams { get; }

		public string Method { get; }

		public PlayerAccountOperationInfo(PlayerAccountOperationType operationType, string basePath, string method, TRequest? request, string pathParams = "")
		{
			OperationType = default(PlayerAccountOperationType);
			Request = null;
			BasePath = null;
			PathParams = null;
			Method = null;
		}
	}
}
