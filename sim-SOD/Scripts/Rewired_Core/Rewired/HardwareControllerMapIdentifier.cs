using System;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal struct HardwareControllerMapIdentifier
	{
		public readonly Guid guid;

		public readonly InputSource inputSource;

		public readonly InputPlatform actualInputPlatform;

		public readonly int variantIndex;

		public HardwareControllerMapIdentifier(Guid guid, InputSource inputSource, InputPlatform actualInputPlatform, int variantIndex)
		{
			this.guid = default(Guid);
			this.inputSource = default(InputSource);
			this.actualInputPlatform = default(InputPlatform);
			this.variantIndex = 0;
		}
	}
}
