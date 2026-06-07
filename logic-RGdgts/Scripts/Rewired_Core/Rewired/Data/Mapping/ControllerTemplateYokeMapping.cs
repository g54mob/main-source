using System;
using Rewired.Utils.Attributes;

namespace Rewired.Data.Mapping
{
	[Serializable]
	[Preserve]
	[CustomClassObfuscation]
	[CustomObfuscation]
	internal class ControllerTemplateYokeMapping : ControllerTemplateSpecialElementMapping
	{
		public int eid_axisX;

		public int eid_axisZ;
	}
}
