namespace Simulator.GameWorld
{
	public static class OperatorResult
	{
		public static float ComputeValue(float initValue, float addedValue, EValueType addedValueType, EOperator operatorValue)
		{
			return operatorValue switch
			{
				EOperator.ADD => (addedValueType == EValueType.INT) ? (initValue + addedValue) : (initValue * (1f + addedValue / 100f)), 
				EOperator.SUBTRACT => (addedValueType == EValueType.INT) ? (initValue - addedValue) : (initValue * (1f - addedValue / 100f)), 
				EOperator.MULTIPLY => (addedValueType == EValueType.INT) ? (initValue * addedValue) : (initValue * (addedValue / 100f)), 
				EOperator.DIVIDE => (addedValueType == EValueType.INT) ? (initValue * addedValue) : (initValue / (addedValue / 100f)), 
				_ => initValue, 
			};
		}
	}
}
