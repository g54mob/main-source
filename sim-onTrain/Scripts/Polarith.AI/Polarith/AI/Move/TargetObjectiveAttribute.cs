using UnityEngine;

namespace Polarith.AI.Move
{
	public sealed class TargetObjectiveAttribute : PropertyAttribute
	{
		private bool negativeIndex;

		public bool NegativeIndex => negativeIndex;

		public TargetObjectiveAttribute(bool negativeIndex)
		{
			this.negativeIndex = negativeIndex;
		}
	}
}
