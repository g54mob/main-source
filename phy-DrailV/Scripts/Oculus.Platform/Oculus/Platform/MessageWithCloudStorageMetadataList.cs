using System;
using Oculus.Platform.Models;

namespace Oculus.Platform
{
	public class MessageWithCloudStorageMetadataList : Message<CloudStorageMetadataList>
	{
		public MessageWithCloudStorageMetadataList(IntPtr c_message)
			: base(c_message)
		{
		}

		public override CloudStorageMetadataList GetCloudStorageMetadataList()
		{
			return base.Data;
		}

		protected override CloudStorageMetadataList GetDataFromMessage(IntPtr c_message)
		{
			return new CloudStorageMetadataList(CAPI.ovr_Message_GetCloudStorageMetadataArray(CAPI.ovr_Message_GetNativeMessage(c_message)));
		}
	}
}
