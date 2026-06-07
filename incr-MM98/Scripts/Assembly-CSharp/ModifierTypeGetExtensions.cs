using UnityEngine;

public static class ModifierTypeGetExtensions
{
	public static int Int(this ModifierType type)
	{
		return Database.Modifiers.GetInt(type);
	}

	public static float Float(this ModifierType type)
	{
		return Database.Modifiers.GetFloat(type);
	}

	public static double Double(this ModifierType type)
	{
		return Database.Modifiers.GetDouble(type);
	}

	public static int Modified(this ModifierType type, int baseValue)
	{
		return Database.Modifiers.EvaluateInt(type, baseValue);
	}

	public static float Modified(this ModifierType type, float baseValue)
	{
		return Database.Modifiers.EvaluateFloat(type, baseValue);
	}

	public static double Modified(this ModifierType type, double baseValue)
	{
		return Database.Modifiers.EvaluateDouble(type, baseValue);
	}

	public static float SpeedModifier(this Operation operation, float speed)
	{
		return operation switch
		{
			Operation.None => speed, 
			Operation.ReleaseGame => speed, 
			Operation.BuyServerNode => ModifierType.OperationServerNodeSpeed.Modified(speed), 
			Operation.ClusterOverdrive => ModifierType.OperationClusterOverdriveSpeed.Modified(speed), 
			Operation.MarketingBlast => ModifierType.OperationMarketingBlastSpeed.Modified(speed), 
			Operation.LineOfCredit => ModifierType.OperationLineOfCreditSpeed.Modified(speed), 
			_ => NoOperationModifierAssigned(operation), 
		};
	}

	public static double CostModifier(this Operation operation, double cost)
	{
		return operation switch
		{
			Operation.None => cost, 
			Operation.ReleaseGame => cost, 
			Operation.BuyServerNode => ModifierType.OperationServerNodeCost.Modified(cost), 
			Operation.ClusterOverdrive => ModifierType.OperationClusterOverdriveCost.Modified(cost), 
			Operation.MarketingBlast => ModifierType.OperationMarketingBlastCost.Modified(cost), 
			Operation.LineOfCredit => ModifierType.OperationLineOfCreditCost.Modified(cost), 
			_ => NoOperationModifierAssigned(operation), 
		};
	}

	public static float CostScaleModifier(this Operation operation, float costScale)
	{
		return operation switch
		{
			Operation.None => costScale, 
			Operation.ReleaseGame => costScale, 
			Operation.BuyServerNode => ModifierType.OperationServerNodeCostScale.Modified(costScale), 
			Operation.ClusterOverdrive => ModifierType.OperationClusterOverdriveCostScale.Modified(costScale), 
			Operation.MarketingBlast => ModifierType.OperationMarketingBlastCostScale.Modified(costScale), 
			Operation.LineOfCredit => ModifierType.OperationLineOfCreditCostScale.Modified(costScale), 
			_ => NoOperationModifierAssigned(operation), 
		};
	}

	private static float NoOperationModifierAssigned(Operation operation)
	{
		Debug.LogWarning($"Operation {operation} has no linked speed and cost modifiers defined.");
		return 1f;
	}
}
