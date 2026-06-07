using System;
using Oculus.Platform.Models;

namespace Oculus.Platform
{
	public class MessageWithCalApplicationFinalized : Message<CalApplicationFinalized>
	{
		public MessageWithCalApplicationFinalized(IntPtr c_message)
			: base(c_message)
		{
		}

		public override CalApplicationFinalized GetCalApplicationFinalized()
		{
			return base.Data;
		}

		protected override CalApplicationFinalized GetDataFromMessage(IntPtr c_message)
		{
			return new CalApplicationFinalized(CAPI.ovr_Message_GetCalApplicationFinalized(CAPI.ovr_Message_GetNativeMessage(c_message)));
		}
	}
}
