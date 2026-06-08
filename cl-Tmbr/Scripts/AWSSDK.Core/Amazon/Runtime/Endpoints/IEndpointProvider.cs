namespace Amazon.Runtime.Endpoints
{
	public interface IEndpointProvider
	{
		Endpoint ResolveEndpoint(EndpointParameters parameters);
	}
}
