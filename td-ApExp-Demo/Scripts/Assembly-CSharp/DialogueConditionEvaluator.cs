using System.Collections.Generic;

public static class DialogueConditionEvaluator
{
	private static Dictionary<string, object> context = new Dictionary<string, object> { 
	{
		"TotalCores",
		SaveManager.Instance.TotalCores
	} };

	public static bool Evaluate(string expression)
	{
		return ConditionEvaluator.Evaluate(expression, context);
	}
}
