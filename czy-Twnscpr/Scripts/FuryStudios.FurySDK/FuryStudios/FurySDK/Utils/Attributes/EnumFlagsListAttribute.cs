using UnityEngine;

namespace FuryStudios.FurySDK.Utils.Attributes
{
	public class EnumFlagsListAttribute : PropertyAttribute
	{
		public bool showCompositeFlags;

		public EnumFlagsListAttribute(bool showCompositeFlags = false)
		{
		}
	}
}
