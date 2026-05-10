using System.Text;

namespace AeLa.EasyFeedback
{
	public class ReportSection
	{
		public string Title;

		public int SortOrder;

		private StringBuilder sectionText;

		public ReportSection(string title, int sortOrder = 0)
		{
		}

		public ReportSection(string title, string text)
		{
		}

		public void Append(string text)
		{
		}

		public void AppendLine(string line)
		{
		}

		public void SetText(string text)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
