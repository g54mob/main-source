namespace Trivial.CodeSecurity
{
	public struct CodeSecurityLocation
	{
		private string fileLocation;

		private int lineNumber;

		private int columnNumber;

		public static readonly CodeSecurityLocation defaultLocation = new CodeSecurityLocation("Unknown");

		public string FileLocation
		{
			get
			{
				if (fileLocation != null && fileLocation == string.Empty)
				{
					return "Source";
				}
				return fileLocation;
			}
		}

		public int LineNumber => lineNumber;

		public int ColumnNumber => columnNumber;

		public CodeSecurityLocation(string fileLocation)
		{
			this.fileLocation = fileLocation;
			lineNumber = -1;
			columnNumber = -1;
		}

		public CodeSecurityLocation(string fileLocation, int line, int column)
		{
			this.fileLocation = fileLocation;
			lineNumber = line;
			columnNumber = column;
		}

		public override string ToString()
		{
			if (lineNumber != -1)
			{
				return $"{fileLocation}, {lineNumber}, {columnNumber}";
			}
			return fileLocation;
		}
	}
}
