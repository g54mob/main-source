using System.Text;

namespace AeLa.EasyFeedback
{
	public class ReportSection
	{
		public string Title;

		private StringBuilder sectionText;

		public int SortOrder;

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
