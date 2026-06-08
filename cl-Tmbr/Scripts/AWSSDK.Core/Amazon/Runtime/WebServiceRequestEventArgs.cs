using System;
using System.Collections.Generic;
using Amazon.Runtime.Internal;

namespace Amazon.Runtime
{
	public class WebServiceRequestEventArgs : RequestEventArgs
	{
		public IDictionary<string, string> Headers { get; protected set; }

		public ParameterCollection ParameterCollection { get; protected set; }

		public string ServiceName { get; protected set; }

		public Uri Endpoint { get; protected set; }

		public AmazonWebServiceRequest Request { get; protected set; }

		protected WebServiceRequestEventArgs()
		{
		}

		internal static WebServiceRequestEventArgs Create(IRequest request)
		{
			return new WebServiceRequestEventArgs
			{
				Headers = request.Headers,
				ParameterCollection = request.ParameterCollection,
				ServiceName = request.ServiceName,
				Endpoint = request.Endpoint,
				Request = request.OriginalRequest
			};
		}
	}
}
