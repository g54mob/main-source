using System;
using Oculus.Platform.Models;

namespace Oculus.Platform
{
	public class MessageWithCloudStorageData : Message<CloudStorageData>
	{
		public MessageWithCloudStorageData(IntPtr c_message)
			: base(c_message)
		{
		}

		public override CloudStorageData GetCloudStorageData()
		{
			return base.Data;
		}

		protected override CloudStorageData GetDataFromMessage(IntPtr c_message)
		{
			return new CloudStorageData(CAPI.ovr_Message_GetCloudStorageData(CAPI.ovr_Message_GetNativeMessage(c_message)));
		}
	}
}
