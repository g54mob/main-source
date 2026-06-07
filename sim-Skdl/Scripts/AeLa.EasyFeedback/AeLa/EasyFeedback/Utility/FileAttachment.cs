using System;

namespace AeLa.EasyFeedback.Utility
{
	[Serializable]
	public class FileAttachment
	{
		private string name;

		private byte[] data;

		private string mimeType;

		public string Name
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public byte[] Data
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string MimeType
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public FileAttachment(string name, byte[] data, string mimeType = null)
		{
		}

		public FileAttachment(string filePath, string mimeType = null)
		{
		}

		public FileAttachment(string name, string filePath, string mimeType = null)
		{
		}
	}
}
