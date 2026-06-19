using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class FinanceModifier : IPriceModifier
	{
		public enum EType
		{
			None = 0,
			ArcadeMachine = 1,
			VendingMachine_Drink = 2,
			VendingMachine_Snack = 3,
			Shop = 4
		}

		[SerializeField]
		private int Amount;

		public int EnergyCost;

		[InspectorTooltip("Used for analytics tracking")]
		public EType Type;

		public int GetBaseCost()
		{
			return Amount;
		}

		public int GetCost(float multiplier)
		{
			return (int)((float)Amount * multiplier);
		}
	}
}
