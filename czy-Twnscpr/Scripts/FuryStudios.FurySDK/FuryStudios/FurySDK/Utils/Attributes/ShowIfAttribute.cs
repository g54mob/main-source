using UnityEngine;

namespace FuryStudios.FurySDK.Utils.Attributes
{
	public class ShowIfAttribute : PropertyAttribute
	{
		public string[] Variables;

		public ShowIfAttribute(params string[] Variables)
		{
		}

		public static bool Validate(object o, params string[] Variables)
		{
			return false;
		}
	}
}
