namespace Kitchen.NetworkSupport
{
	public class AggregateEventLog : EventLog
	{
		public AggregateEventLog(params EventLog[] aggregates)
			: base("*")
		{
			for (int i = 0; i < aggregates.Length; i++)
			{
				aggregates[i].OnReport += delegate(LoggedEvent<string> e)
				{
					PerformReport(e, silent: true);
				};
			}
		}
	}
}
