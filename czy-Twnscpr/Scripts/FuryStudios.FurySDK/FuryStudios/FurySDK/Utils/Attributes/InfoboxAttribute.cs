using UnityEngine;

namespace FuryStudios.FurySDK.Utils.Attributes
{
	public class InfoboxAttribute : PropertyAttribute
	{
		public HelpType type;

		public string message;

		public InfoboxAttribute(string message, HelpType type = HelpType.None)
		{
		}
	}
}
