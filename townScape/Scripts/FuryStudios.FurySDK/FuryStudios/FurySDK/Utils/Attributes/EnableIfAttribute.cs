using UnityEngine;

namespace FuryStudios.FurySDK.Utils.Attributes
{
	public class EnableIfAttribute : PropertyAttribute
	{
		public string[] Variables;

		public EnableIfAttribute(params string[] Variables)
		{
		}
	}
}
