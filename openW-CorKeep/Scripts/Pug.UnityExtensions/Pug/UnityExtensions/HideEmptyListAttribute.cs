using UnityEngine;

namespace Pug.UnityExtensions
{
	public class HideEmptyListAttribute : PropertyAttribute
	{
		public string listToHide;

		public HideEmptyListAttribute(string listToHide)
		{
			this.listToHide = listToHide;
		}
	}
}
