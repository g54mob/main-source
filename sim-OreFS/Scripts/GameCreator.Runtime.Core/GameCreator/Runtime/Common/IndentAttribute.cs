using UnityEngine;

namespace GameCreator.Runtime.Common
{
	public class IndentAttribute : PropertyAttribute
	{
		public int Level { get; }

		public IndentAttribute(int level = 1)
		{
			Level = level;
		}
	}
}
