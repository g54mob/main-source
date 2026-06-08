using System;
using System.Net;

namespace Amazon.Runtime.Internal.Transform
{
	public interface IResponseUnmarshaller<T, R>
	{
		AmazonServiceException UnmarshallException(R input, Exception innerException, HttpStatusCode statusCode);

		T Unmarshall(R input);
	}
}
