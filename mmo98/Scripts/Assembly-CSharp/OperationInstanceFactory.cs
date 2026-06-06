using System;

public static class OperationInstanceFactory
{
	public static OperationInstance Create(OperationData data)
	{
		return data.ID switch
		{
			Operation.None => throw new ArgumentException("Cannot create an OperationInstance for Operation.None"), 
			Operation.LineOfCredit => new LineOfCreditInstance(data), 
			_ => new OperationInstance(data), 
		};
	}

	public static OperationInstance Create(OperationData data, float time, float duration)
	{
		return data.ID switch
		{
			Operation.None => throw new ArgumentException("Cannot create an OperationInstance for Operation.None"), 
			Operation.LineOfCredit => new LineOfCreditInstance(data, time, duration), 
			_ => new OperationInstance(data, time, duration), 
		};
	}
}
