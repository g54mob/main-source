using System;
using Rewired.Utils.Attributes;

namespace Rewired.Data.Mapping
{
	[Serializable]
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = false)]
	[Preserve]
	internal class ControllerTemplateStickMapping : ControllerTemplateSpecialElementMapping
	{
		public int eid_axisX = -1;

		public int eid_axisY = -1;

		public int eid_axisZ = -1;
	}
}
