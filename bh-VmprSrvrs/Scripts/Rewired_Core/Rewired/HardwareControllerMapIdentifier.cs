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

		public HardwareControllerMapIdentifier(Guid P_0, InputSource P_1, InputPlatform P_2, int P_3)
		{
			guid = default(Guid);
			inputSource = default(InputSource);
			actualInputPlatform = default(InputPlatform);
			variantIndex = 0;
		}

		public static bool Matches(HardwareControllerMapIdentifier a, HardwareControllerMapIdentifier b)
		{
			return false;
		}
	}
}
