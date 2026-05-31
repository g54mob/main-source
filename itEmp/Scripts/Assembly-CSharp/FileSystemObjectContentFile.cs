using System;
using System.Collections.Generic;

[Serializable]
public class FileSystemObjectContentFile
{
	public string text;

	public List<PDFPage> pdf;

	public override bool Equals(object obj)
	{
		return false;
	}

	public override int GetHashCode()
	{
		return 0;
	}
}
