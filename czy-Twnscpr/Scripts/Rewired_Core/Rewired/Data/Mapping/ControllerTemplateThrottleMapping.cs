using System;
using Rewired.Utils.Attributes;

namespace Rewired.Data.Mapping
{
	[Serializable]
	[CustomObfuscation]
	[CustomClassObfuscation]
	[Preserve]
	internal class ControllerTemplateThrottleMapping : ControllerTemplateSpecialElementMapping
	{
		public int eid_axis;

		public int eid_minDetent;
	}
}
