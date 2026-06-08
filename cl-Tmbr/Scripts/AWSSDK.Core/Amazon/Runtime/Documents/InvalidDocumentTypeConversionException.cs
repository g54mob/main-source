using System;

namespace Amazon.Runtime.Documents
{
	public class InvalidDocumentTypeConversionException : Exception
	{
		public InvalidDocumentTypeConversionException(DocumentType expected, DocumentType actual)
			: base($"Cannot Convert DocumentType to {expected} because it is {actual}")
		{
		}
	}
}
