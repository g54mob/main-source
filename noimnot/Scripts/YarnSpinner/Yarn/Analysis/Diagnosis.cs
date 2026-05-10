namespace Yarn.Analysis
{
	public class Diagnosis
	{
		public enum Severity
		{
			Error = 0,
			Warning = 1,
			Note = 2
		}

		public string message;

		public string nodeName;

		public int lineNumber;

		public int columnNumber;

		public Severity severity;

		public Diagnosis(string message, Severity severity, string nodeName = null, int lineNumber = -1, int columnNumber = -1)
		{
		}

		public override string ToString()
		{
			return null;
		}

		public string ToString(bool showSeverity)
		{
			return null;
		}
	}
}
