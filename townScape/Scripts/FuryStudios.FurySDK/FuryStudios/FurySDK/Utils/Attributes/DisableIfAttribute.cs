using UnityEngine;

namespace FuryStudios.FurySDK.Utils.Attributes
{
	public class DisableIfAttribute : PropertyAttribute
	{
		public string[] Variables;

		public DisableIfAttribute(params string[] Variables)
		{
		}
	}
}
