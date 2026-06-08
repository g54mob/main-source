namespace Amazon.Runtime.Internal.Util
{
	public class ChecksumData
	{
		public string SelectedChecksum { get; set; }

		public bool IsMD5Checksum { get; set; }

		public bool? FallbackToMD5 { get; set; }

		public bool IsRequestChecksumRequired { get; set; }

		public string HeaderName { get; set; }

		public ChecksumData(string selectedChecksum, bool MD5Checksum, bool? fallbackToMD5, bool isRequestChecksumRequired, string headerName)
		{
			SelectedChecksum = selectedChecksum;
			IsMD5Checksum = MD5Checksum;
			FallbackToMD5 = fallbackToMD5;
			IsRequestChecksumRequired = isRequestChecksumRequired;
			HeaderName = headerName;
		}
	}
}
