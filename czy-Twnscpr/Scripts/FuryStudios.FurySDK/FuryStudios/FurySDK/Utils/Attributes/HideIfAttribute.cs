using UnityEngine;

namespace FuryStudios.FurySDK.Utils.Attributes
{
	public class HideIfAttribute : PropertyAttribute
	{
		public string[] Variables;

		public HideIfAttribute(params string[] Variables)
		{
		}

		public static bool Validate(object o, params string[] Variables)
		{
			return false;
		}
	}
}
