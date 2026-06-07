using UnityEngine;

namespace MalbersAnimations.Scriptables
{
	[CreateAssetMenu(menuName = "Malbers Animations/Variables/Float Range", order = 1000)]
	public class FloatRangeVar : FloatVar
	{
		public FloatReference minValue;

		public FloatReference maxValue;

		public override float Value
		{
			get
			{
				return Random.Range(minValue, maxValue);
			}
			set
			{
			}
		}
	}
}
