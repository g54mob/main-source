using System;

namespace Amazon.Runtime.Endpoints
{
	public class StaticEndpointProvider : IEndpointProvider
	{
		private readonly string _url;

		public StaticEndpointProvider(string url)
		{
			if (string.IsNullOrEmpty(url))
			{
				throw new ArgumentNullException("url");
			}
			_url = url;
		}

		public Endpoint ResolveEndpoint(EndpointParameters parameters)
		{
			return new Endpoint(_url);
		}
	}
}
