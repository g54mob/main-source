using System;
using Rewired.Utils.Attributes;

namespace Rewired.Data.Mapping
{
	[Serializable]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = false)]
	[Preserve]
	[CustomObfuscation(rename = false)]
	internal class ControllerTemplateDPadMapping : ControllerTemplateSpecialElementMapping
	{
		public int eid_up;

		public int eid_right;

		public int eid_down;

		public int eid_left;

		public int eid_press;
	}
}
