namespace Amazon.Runtime.Endpoints
{
	public interface IGlobalEndpointProvider
	{
		Endpoint ResolveEndpoint(string serviceId, EndpointParameters parameters);
	}
}
