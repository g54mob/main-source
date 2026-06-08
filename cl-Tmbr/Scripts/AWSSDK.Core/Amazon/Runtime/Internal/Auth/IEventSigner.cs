using System.Threading.Tasks;

namespace Amazon.Runtime.Internal.Auth
{
	public interface IEventSigner
	{
		Task<byte[]> SignEventAsync(byte[] eventBytes);
	}
}
