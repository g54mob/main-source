using System;

[AttributeUsage(AttributeTargets.Interface)]
internal class hFtBUHwCFYxSLNEjhJfIrXUEuTED : Attribute
{
	private Type QsOEUnYlxkSoznrJjBmFZKUyOFIs;

	public Type EeipOhVjORMBBeBVZOLNijWzMalw => QsOEUnYlxkSoznrJjBmFZKUyOFIs;

	public hFtBUHwCFYxSLNEjhJfIrXUEuTED(Type P_0)
	{
		QsOEUnYlxkSoznrJjBmFZKUyOFIs = P_0;
	}

	public static hFtBUHwCFYxSLNEjhJfIrXUEuTED mZmqGAaqwvVMugMhumuHUJtJDvLHA(Type P_0)
	{
		object[] customAttributes = P_0.GetCustomAttributes(typeof(hFtBUHwCFYxSLNEjhJfIrXUEuTED), inherit: false);
		if (customAttributes.Length == 0)
		{
			return null;
		}
		return (hFtBUHwCFYxSLNEjhJfIrXUEuTED)customAttributes[0];
	}
}
