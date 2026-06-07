using System;
using Rewired.Utils.Attributes;

namespace Rewired.Data.Mapping
{
	[Serializable]
	[Preserve]
	[CustomObfuscation]
	[CustomClassObfuscation]
	internal class ControllerTemplateHatMapping : ControllerTemplateSpecialElementMapping
	{
		public int eid_up;

		public int eid_upRight;

		public int eid_right;

		public int eid_downRight;

		public int eid_down;

		public int eid_downLeft;

		public int eid_left;

		public int eid_upLeft;
	}
}
