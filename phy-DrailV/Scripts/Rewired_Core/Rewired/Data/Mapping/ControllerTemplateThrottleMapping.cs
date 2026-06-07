using System;
using Rewired.Utils.Attributes;

namespace Rewired.Data.Mapping
{
	[Serializable]
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = false)]
	[Preserve]
	internal class ControllerTemplateThrottleMapping : ControllerTemplateSpecialElementMapping
	{
		public int eid_axis = -1;

		public int eid_minDetent = -1;
	}
}
