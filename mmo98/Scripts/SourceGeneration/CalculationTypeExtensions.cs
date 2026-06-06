using System.Collections.Generic;

public static class CalculationTypeExtensions
{
	private static readonly Dictionary<CalculationType, CalculationOperation> operations = new Dictionary<CalculationType, CalculationOperation>
	{
		{
			CalculationType.Addition,
			Add
		},
		{
			CalculationType.Multiplication,
			Multiply
		}
	};

	public static CalculationOperation GetOperation(this CalculationType calculation)
	{
		return operations[calculation];
	}

	private static double Add(double baseValue, double modifierValue)
	{
		return baseValue + modifierValue;
	}

	private static double Multiply(double baseValue, double modifierValue)
	{
		return baseValue * modifierValue;
	}
}
