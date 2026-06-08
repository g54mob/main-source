using Amazon.Runtime.Internal.Transform;

namespace Amazon.Runtime.Internal
{
	public abstract class InvokeOptionsBase
	{
		private IMarshaller<IRequest, AmazonWebServiceRequest> _requestMarshaller;

		private ResponseUnmarshaller _responseUnmarshaller;

		private IMarshaller<EndpointDiscoveryDataBase, AmazonWebServiceRequest> _endpointDiscoveryMarshaller;

		private EndpointOperationDelegate _endpointOperation;

		public virtual IMarshaller<IRequest, AmazonWebServiceRequest> RequestMarshaller
		{
			get
			{
				return _requestMarshaller;
			}
			set
			{
				_requestMarshaller = value;
			}
		}

		public virtual ResponseUnmarshaller ResponseUnmarshaller
		{
			get
			{
				return _responseUnmarshaller;
			}
			set
			{
				_responseUnmarshaller = value;
			}
		}

		public virtual IMarshaller<EndpointDiscoveryDataBase, AmazonWebServiceRequest> EndpointDiscoveryMarshaller
		{
			get
			{
				return _endpointDiscoveryMarshaller;
			}
			set
			{
				_endpointDiscoveryMarshaller = value;
			}
		}

		public virtual EndpointOperationDelegate EndpointOperation
		{
			get
			{
				return _endpointOperation;
			}
			set
			{
				_endpointOperation = value;
			}
		}
	}
}
