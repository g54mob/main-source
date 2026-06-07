using System;
using Rewired.Utils.Attributes;

namespace Rewired.Data.Mapping
{
	[Serializable]
	[CustomObfuscation]
	[Preserve]
	[CustomClassObfuscation]
	internal class ControllerTemplateThumbStickMapping : ControllerTemplateSpecialElementMapping
	{
		public int eid_axisX;

		public int eid_axisY;

		public int eid_button;
	}
}
