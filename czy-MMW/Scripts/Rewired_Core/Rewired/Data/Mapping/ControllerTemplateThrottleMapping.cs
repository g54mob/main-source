using System;
using Rewired.Utils.Attributes;

namespace Rewired.Data.Mapping
{
	[Serializable]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = false)]
	[CustomObfuscation(rename = false)]
	[Preserve]
	internal class ControllerTemplateThrottleMapping : ControllerTemplateSpecialElementMapping
	{
		public int eid_axis = -1;

		public int eid_minDetent = -1;
	}
}
