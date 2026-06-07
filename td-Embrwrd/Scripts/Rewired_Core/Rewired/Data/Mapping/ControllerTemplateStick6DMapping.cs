using System;
using Rewired.Utils.Attributes;

namespace Rewired.Data.Mapping
{
	[Serializable]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = false)]
	[Preserve]
	[CustomObfuscation(rename = false)]
	internal class ControllerTemplateStick6DMapping : ControllerTemplateSpecialElementMapping
	{
		public int eid_positionX;

		public int eid_positionY;

		public int eid_positionZ;

		public int eid_rotationX;

		public int eid_rotationY;

		public int eid_rotationZ;
	}
}
