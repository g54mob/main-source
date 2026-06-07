using UnityEngine;

namespace MyBox
{
	public class FoldoutAttribute : PropertyAttribute
	{
		public readonly string Name;

		public readonly bool FoldEverything;

		public FoldoutAttribute(string name, bool foldEverything = false)
		{
		}
	}
}
