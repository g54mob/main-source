using System.Collections;
using System.Runtime.CompilerServices;

namespace FuryStudios.FurySDK.Internal
{
	public class BaseStorageRequest : AsyncRequest, IAsyncRequest<byte[]>, IAsyncRequest, IEnumerator, IAsyncRequest<string>
	{
		[CompilerGenerated]
		private StorageAccessMode _003CAccess_003Ek__BackingField;

		public string FilePath { get; private set; }

		private StorageAccessMode Access
		{
			[CompilerGenerated]
			set
			{
				_003CAccess_003Ek__BackingField = value;
			}
		}

		protected byte[] Bytes { get; private set; }

		string IAsyncRequest<string>.Result => null;

		byte[] IAsyncRequest<byte[]>.Result => null;

		protected BaseStorageRequest(string filePath, StorageAccessMode access)
		{
		}

		public void SetBytes(byte[] bytes)
		{
		}

		public void SetText(string text)
		{
		}

		public static string ConvertBytesToText(byte[] utf8bytes)
		{
			return null;
		}

		public static byte[] ConvertTextToBytes(string utf8text)
		{
			return null;
		}
	}
}
