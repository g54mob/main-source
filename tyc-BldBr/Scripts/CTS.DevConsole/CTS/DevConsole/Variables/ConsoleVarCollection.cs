namespace CTS.DevConsole.Variables
{
	public abstract class ConsoleVarCollection : ConsoleVar
	{
		internal override bool IsArgumentIndexOutOfBounds(int argIndex)
		{
			if (argIndex >= 0)
			{
				return argIndex > 2;
			}
			return true;
		}
	}
}
