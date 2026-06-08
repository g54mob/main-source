using System.Threading.Tasks;

namespace Amazon.Runtime.Internal
{
	public interface IHttpRequestStreamPublisher
	{
		Task<byte[]> NextBytesAsync();
	}
}
