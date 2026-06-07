using UnityEngine;

namespace Boxophobic.StyledGUI
{
	public class StyledMessage : PropertyAttribute
	{
		public string Type;

		public string Message;

		public float Top;

		public float Down;

		public StyledMessage(string Type, string Message)
		{
		}

		public StyledMessage(string Type, string Message, float Top, float Down)
		{
		}
	}
}
