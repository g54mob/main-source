using System;
using Oculus.Platform.Models;

namespace Oculus.Platform
{
	public class MessageWithCalApplicationProposed : Message<CalApplicationProposed>
	{
		public MessageWithCalApplicationProposed(IntPtr c_message)
			: base(c_message)
		{
		}

		public override CalApplicationProposed GetCalApplicationProposed()
		{
			return base.Data;
		}

		protected override CalApplicationProposed GetDataFromMessage(IntPtr c_message)
		{
			return new CalApplicationProposed(CAPI.ovr_Message_GetCalApplicationProposed(CAPI.ovr_Message_GetNativeMessage(c_message)));
		}
	}
}
