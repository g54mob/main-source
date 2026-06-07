using Dhs5.Utility.Databases;

namespace Dhs5.Utility.Debuggers
{
	[Database("Debugger", typeof(DebuggerDatabaseElement))]
	public class DebuggerDatabase : EnumDatabase
	{
		public static DebuggerDatabaseElement GetAtIndex(int index)
		{
			return Database.Get<DebuggerDatabase>().GetDataAtIndex(index) as DebuggerDatabaseElement;
		}
	}
}
