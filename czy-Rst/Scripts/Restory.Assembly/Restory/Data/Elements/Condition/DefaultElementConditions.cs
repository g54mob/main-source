using UnityEngine;

namespace Restory.Data.Elements.Condition
{
	[CreateAssetMenu(menuName = "Restory/Elements/Condition/DefaultElementConditions", fileName = "DefaultElementConditions")]
	public sealed class DefaultElementConditions : ScriptableObject
	{
		[SerializeField]
		private PerfectElementCondition perfectElementCondition;

		[SerializeField]
		private DirtyElementCondition dirtyElementCondition;

		[SerializeField]
		private DamagedElementCondition damagedElementCondition;

		[SerializeField]
		private BurntElementCondition burntElementCondition;

		public PerfectElementCondition PerfectElementCondition => perfectElementCondition;

		public DirtyElementCondition DirtyElementCondition => dirtyElementCondition;

		public DamagedElementCondition DamagedElementCondition => damagedElementCondition;

		public BurntElementCondition BurntElementCondition => burntElementCondition;
	}
}
