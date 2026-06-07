using System.Collections.Generic;

public record NavigationContext
{
	public NavigationAwaitOperation AwaitOperation { get; set; }

	public Dictionary<object, object> Parameters { get; set; } = new Dictionary<object, object>();

	public static NavigationContext Sequential
	{
		get
		{
			sequentialContext.Parameters.Clear();
			return sequentialContext;
		}
	}

	public static NavigationContext Drop
	{
		get
		{
			dropContext.Parameters.Clear();
			return dropContext;
		}
	}

	public static NavigationContext Error
	{
		get
		{
			errorContext.Parameters.Clear();
			return errorContext;
		}
	}

	private static readonly NavigationContext sequentialContext = new NavigationContext();

	private static readonly NavigationContext dropContext = new NavigationContext();

	private static readonly NavigationContext errorContext = new NavigationContext();
}
