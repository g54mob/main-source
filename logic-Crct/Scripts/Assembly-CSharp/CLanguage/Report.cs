using System.Collections.Generic;
using System.IO;
using CLanguage.Syntax;

namespace CLanguage
{
	public class Report
	{
		public class AbstractMessage
		{
			public string MessageType { get; protected set; }

			public Location Location { get; protected set; }

			public Location EndLocation { get; protected set; }

			public bool IsWarning { get; protected set; }

			public bool IsError => false;

			public int Code { get; protected set; }

			public string Text { get; protected set; }

			public AbstractMessage(string type, string text)
			{
			}

			protected AbstractMessage()
			{
			}

			public override bool Equals(object obj)
			{
				return false;
			}

			public override int GetHashCode()
			{
				return 0;
			}

			public override string ToString()
			{
				return null;
			}
		}

		public class ErrorMessage : AbstractMessage
		{
			public ErrorMessage(int code, Location loc, Location endLoc, string error, List<string> extraInformation)
				: base(null, null)
			{
			}
		}

		public class WarningMessage : AbstractMessage
		{
			public WarningMessage(int code, Location loc, Location endLoc, string error, List<string> extraInformation)
				: base(null, null)
			{
			}
		}

		public class Printer
		{
			private int warnings;

			private int errors;

			public int WarningsCount => 0;

			public int ErrorsCount => 0;

			public virtual void Print(AbstractMessage msg)
			{
			}
		}

		public class SavedPrinter : Printer
		{
			public readonly List<AbstractMessage> Messages;

			public override void Print(AbstractMessage msg)
			{
			}
		}

		public class TextWriterPrinter : Printer
		{
			private TextWriter output;

			public TextWriterPrinter(TextWriter output)
			{
			}

			public override void Print(AbstractMessage msg)
			{
			}
		}

		private int _reportingDisabled;

		private List<string> _extraInformation;

		private Printer _printer;

		private Dictionary<AbstractMessage, bool> _previousErrors;

		public IEnumerable<AbstractMessage> Errors => null;

		public Report(Printer? printer = null)
		{
		}

		public void Error(int code, Location loc, Location endLoc, string error)
		{
		}

		public void Warning(int code, Location loc, Location endLoc, string warning)
		{
		}

		public void Error(int code, Location loc, Location endLoc, string format, params object[] args)
		{
		}

		public void Error(int code, string error)
		{
		}

		public void Error(int code, string format, params object[] args)
		{
		}

		public void ErrorCode(int code, Location loc, Location endLoc, params object[] args)
		{
		}

		public void ErrorCode(int code, params object[] args)
		{
		}
	}
}
