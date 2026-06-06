using UnityEngine;

namespace MalbersAnimations.Scriptables
{
	[CreateAssetMenu(menuName = "Malbers Animations/Variables/Int Range", order = 1000)]
	public class IntRangeVar : FloatVar
	{
		public IntReference minValue;

		public IntReference maxValue;

		public override float Value
		{
			get
			{
				return Random.Range(minValue, (int)maxValue + 1);
			}
			set
			{
			}
		}
	}
}
