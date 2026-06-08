namespace Amazon.Runtime.Endpoints
{
	public class ServiceOperationEndpointParameters
	{
		public AmazonWebServiceRequest Request { get; }

		public RegionEndpoint AlternateEndpoint { get; }

		public ServiceOperationEndpointParameters(AmazonWebServiceRequest request)
		{
			Request = request;
		}

		public ServiceOperationEndpointParameters(AmazonWebServiceRequest request, RegionEndpoint alternateEndpoint)
			: this(request)
		{
			AlternateEndpoint = alternateEndpoint;
		}
	}
}
