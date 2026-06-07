using UnityEngine;

namespace Boxophobic.StyledGUI
{
	public class StyledButton : PropertyAttribute
	{
		public string Text;

		public float Top;

		public float Down;

		public StyledButton(string Text)
		{
		}

		public StyledButton(string Text, float Top, float Down)
		{
		}
	}
}
