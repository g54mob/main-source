using System;

namespace Steamworks
{
	internal class CallbackIdentityAttribute : Attribute
	{
		public int Identity { get; set; }

		public CallbackIdentityAttribute(int callbackNum)
		{
		}
	}
}
