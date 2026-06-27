using System.Threading.Tasks;

namespace FluentAssertions.Formatting
{
	public class TaskFormatter : IValueFormatter
	{
		public bool CanHandle(object value)
		{
			return value is Task;
		}

		public void Format(object value, FormattedObjectGraph formattedGraph, FormattingContext context, FormatChild formatChild)
		{
			Task task = (Task)value;
			formatChild("type", task.GetType(), formattedGraph);
			formattedGraph.AddFragment($" {{Status={task.Status}}}");
		}
	}
}
