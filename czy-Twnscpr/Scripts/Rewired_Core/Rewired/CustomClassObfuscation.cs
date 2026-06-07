using System;

namespace Rewired
{
	internal sealed class CustomClassObfuscation : Attribute
	{
		public bool renamePubIntMembers;

		public bool renamePrivateMembers;
	}
}
