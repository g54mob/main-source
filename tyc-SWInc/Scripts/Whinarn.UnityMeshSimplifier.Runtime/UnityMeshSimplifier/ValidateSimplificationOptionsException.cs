using System;

namespace UnityMeshSimplifier
{
	public sealed class ValidateSimplificationOptionsException : Exception
	{
		private readonly string propertyName;

		public string PropertyName
		{
			get
			{
				return propertyName;
			}
		}

		public override string Message
		{
			get
			{
				return base.Message + Environment.NewLine + "Property name: " + propertyName;
			}
		}

		public ValidateSimplificationOptionsException(string propertyName, string message)
			: base(message)
		{
			this.propertyName = propertyName;
		}

		public ValidateSimplificationOptionsException(string propertyName, string message, Exception innerException)
			: base(message, innerException)
		{
			this.propertyName = propertyName;
		}
	}
}
