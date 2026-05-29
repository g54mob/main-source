using System.Collections.Generic;
using AeLa.EasyFeedback.APIs;
using AeLa.EasyFeedback.Utility;

namespace AeLa.EasyFeedback
{
	public class Report
	{
		private const int MAX_ATTACHMENTS = 99;

		public readonly List<Label> Labels;

		private readonly Dictionary<string, ReportSection> info;

		public List List;

		public string Title;

		public List<FileAttachment> Attachments { get; }

		public ReportSection this[string sectionTitle]
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public void AddSection(string title, int sortOrder = 0)
		{
		}

		public void AddSection(ReportSection section)
		{
		}

		public void RemoveSection(string title)
		{
		}

		public bool HasSection(string title)
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}

		public string GetLocalFileText()
		{
			return null;
		}

		public void AttachFile(FileAttachment file)
		{
		}

		public void AttachFile(string name, string filePath)
		{
		}

		public void AttachFile(string name, byte[] data)
		{
		}

		public void AddLabel(Label label)
		{
		}

		public bool HasLabel(Label label)
		{
			return false;
		}
	}
}
