namespace Borodar.FarlandSkies.Core.Json
{
	public sealed class JsonWriterSettings
	{
		private bool indent;

		private string indentChars;

		private string newlineChars;

		internal static JsonWriterSettings DefaultSettings { get; private set; }

		public bool IsReadOnly { get; private set; }

		public bool Indent
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public string IndentChars
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string NewLineChars
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		static JsonWriterSettings()
		{
		}

		public void MarkReadOnly()
		{
		}

		private void CheckReadOnly()
		{
		}

		public void Reset()
		{
		}
	}
}
