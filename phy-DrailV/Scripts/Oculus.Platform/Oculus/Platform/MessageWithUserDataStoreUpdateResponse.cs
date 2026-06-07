using System;
using Oculus.Platform.Models;

namespace Oculus.Platform
{
	public class MessageWithUserDataStoreUpdateResponse : Message<UserDataStoreUpdateResponse>
	{
		public MessageWithUserDataStoreUpdateResponse(IntPtr c_message)
			: base(c_message)
		{
		}

		public override UserDataStoreUpdateResponse GetUserDataStoreUpdateResponse()
		{
			return base.Data;
		}

		protected override UserDataStoreUpdateResponse GetDataFromMessage(IntPtr c_message)
		{
			return new UserDataStoreUpdateResponse(CAPI.ovr_Message_GetUserDataStoreUpdateResponse(CAPI.ovr_Message_GetNativeMessage(c_message)));
		}
	}
}
