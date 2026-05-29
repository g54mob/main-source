using System;
using Rewired.Utils.Attributes;

namespace Rewired.Data.Mapping
{
	[Serializable]
	[CustomObfuscation]
	[CustomClassObfuscation]
	[Preserve]
	internal class ControllerTemplateYokeMapping : ControllerTemplateSpecialElementMapping
	{
		public int eid_axisX;

		public int eid_axisZ;
	}
}
