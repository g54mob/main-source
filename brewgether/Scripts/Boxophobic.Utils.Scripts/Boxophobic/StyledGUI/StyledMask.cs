using UnityEngine;

namespace Boxophobic.StyledGUI
{
	public class StyledMask : PropertyAttribute
	{
		public string display;

		public string file;

		public string options;

		public int top;

		public int down;

		public StyledMask(string file, string options, int top, int down)
		{
		}

		public StyledMask(string display, string file, string options, int top, int down)
		{
		}
	}
}
