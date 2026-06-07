using System;
using Rewired.Utils.Attributes;

namespace Rewired.Data.Mapping
{
	[Serializable]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = false)]
	[Preserve]
	[CustomObfuscation(rename = false)]
	internal class ControllerTemplateYokeMapping : ControllerTemplateSpecialElementMapping
	{
		public int eid_axisX;

		public int eid_axisZ;
	}
}
