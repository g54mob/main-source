namespace Amazon.Runtime.SharedInterfaces.Internal
{
	public interface IChecksumProvider
	{
		string Crc32(byte[] source);

		uint Crc32(byte[] source, uint previous);

		string Crc32C(byte[] source);

		uint Crc32C(byte[] source, uint previous);

		string Crc64NVME(byte[] source);

		ulong Crc64NVME(byte[] source, ulong previous);
	}
}
