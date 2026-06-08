using System;
using System.Collections.Generic;
using Amazon.Runtime.Internal.UserAgent;

namespace Amazon.Runtime.Internal
{
	public interface IAmazonWebServiceRequest
	{
		EventHandler<StreamTransferProgressArgs> StreamUploadProgressCallback { get; set; }

		Dictionary<string, object> RequestState { get; }

		SignatureVersion SignatureVersion { get; set; }

		UserAgentDetails UserAgentDetails { get; }

		void AddBeforeRequestHandler(RequestEventHandler handler);

		void RemoveBeforeRequestHandler(RequestEventHandler handler);
	}
}
