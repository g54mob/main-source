using System;

namespace UniJSON
{
	public class JsonSchemaValidationException : Exception
	{
		public Exception Error { get; private set; }

		public JsonSchemaValidationException(JsonSchemaValidationContext context, string msg)
			: base($"[{context}] {msg}")
		{
		}

		public JsonSchemaValidationException(JsonSchemaValidationContext context, Exception ex)
			: base($"[{context}] {ex}")
		{
			Error = ex;
		}
	}
}
