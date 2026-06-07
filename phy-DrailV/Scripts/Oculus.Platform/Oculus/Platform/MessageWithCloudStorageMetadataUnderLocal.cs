using System;
using Oculus.Platform.Models;

namespace Oculus.Platform
{
	public class MessageWithCloudStorageMetadataUnderLocal : Message<CloudStorageMetadata>
	{
		public MessageWithCloudStorageMetadataUnderLocal(IntPtr c_message)
			: base(c_message)
		{
		}

		public override CloudStorageMetadata GetCloudStorageMetadata()
		{
			return base.Data;
		}

		protected override CloudStorageMetadata GetDataFromMessage(IntPtr c_message)
		{
			return new CloudStorageMetadata(CAPI.ovr_Message_GetCloudStorageMetadata(CAPI.ovr_Message_GetNativeMessage(c_message)));
		}
	}
}
