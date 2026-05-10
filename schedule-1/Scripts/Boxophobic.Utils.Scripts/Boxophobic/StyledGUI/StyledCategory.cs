using UnityEngine;

namespace Boxophobic.StyledGUI
{
	public class StyledCategory : PropertyAttribute
	{
		public string category;

		public float top;

		public float down;

		public bool colapsable;

		public StyledCategory(string category)
		{
		}

		public StyledCategory(string category, bool colapsable)
		{
		}

		public StyledCategory(string category, float top, float down)
		{
		}

		public StyledCategory(string category, int top, int down, bool colapsable)
		{
		}
	}
}
