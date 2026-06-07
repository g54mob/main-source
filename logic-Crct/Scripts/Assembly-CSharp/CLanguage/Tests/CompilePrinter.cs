using System.Collections.Generic;
using System.Text;

namespace CLanguage.Tests
{
	internal class CompilePrinter : Report.Printer
	{
		private int[] expectedErrors;

		public List<int> errorCodes;

		public StringBuilder errorStringBuilder;

		public CompilePrinter(params int[] expectedErrors)
		{
		}

		public override void Print(Report.AbstractMessage msg)
		{
		}

		public void CheckForErrors()
		{
		}
	}
}
