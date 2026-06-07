using System;
using Oculus.Platform.Models;

namespace Oculus.Platform
{
	public class MessageWithCloudStorageConflictMetadata : Message<CloudStorageConflictMetadata>
	{
		public MessageWithCloudStorageConflictMetadata(IntPtr c_message)
			: base(c_message)
		{
		}

		public override CloudStorageConflictMetadata GetCloudStorageConflictMetadata()
		{
			return base.Data;
		}

		protected override CloudStorageConflictMetadata GetDataFromMessage(IntPtr c_message)
		{
			return new CloudStorageConflictMetadata(CAPI.ovr_Message_GetCloudStorageConflictMetadata(CAPI.ovr_Message_GetNativeMessage(c_message)));
		}
	}
}
