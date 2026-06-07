using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Controller.AI
{
	[CreateAssetMenu(menuName = "Malbers Animations/Pluggable AI/Decision/Check Scriptable Variable", order = 6)]
	public class CheckScriptableVar : MAIDecision
	{
		[Tooltip("Check on the Target or Self if it has a Listener Variable Component <Int><Bool><Float> and compares it with the local variable)")]
		public VarType varType;

		[CreateScriptableAsset]
		public BoolVar Bool;

		[CreateScriptableAsset]
		public IntVar Int;

		[CreateScriptableAsset]
		public FloatVar Float;

		public ComparerInt compare;

		public bool boolValue = true;

		public int intValue;

		public float floatValue;

		public override string DisplayName => "Variables/Check Scriptable Variable";

		public override bool Decide(MAnimalBrain brain, int Index)
		{
			return varType switch
			{
				VarType.Bool => Bool != null && Bool.Value == boolValue, 
				VarType.Int => Int != null && CompareInteger(Int.Value), 
				VarType.Float => Float != null && CompareFloat(Float.Value), 
				_ => false, 
			};
		}

		public bool CompareInteger(int IntValue)
		{
			return compare switch
			{
				ComparerInt.Equal => IntValue == intValue, 
				ComparerInt.Greater => IntValue > intValue, 
				ComparerInt.Less => IntValue < intValue, 
				ComparerInt.NotEqual => IntValue != intValue, 
				_ => false, 
			};
		}

		public bool CompareFloat(float IntValue)
		{
			return compare switch
			{
				ComparerInt.Equal => IntValue == floatValue, 
				ComparerInt.Greater => IntValue > floatValue, 
				ComparerInt.Less => IntValue < floatValue, 
				ComparerInt.NotEqual => IntValue != floatValue, 
				_ => false, 
			};
		}
	}
}
