using UnityEngine;

namespace Boxophobic.StyledGUI
{
	public class StyledEnum : PropertyAttribute
	{
		public string display;

		public string file;

		public string options;

		public int top;

		public int down;

		public StyledEnum(string file, string options, int top, int down)
		{
		}

		public StyledEnum(string display, string file, string options, int top, int down)
		{
		}
	}
}
