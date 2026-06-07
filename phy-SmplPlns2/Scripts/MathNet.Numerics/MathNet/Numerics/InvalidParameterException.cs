using System;

namespace MathNet.Numerics
{
	[Serializable]
	public class InvalidParameterException : NativeInterfaceException
	{
		public InvalidParameterException()
			: base("An invalid parameter was passed to a native method.")
		{
		}

		public InvalidParameterException(int parameter)
			: base($"An invalid parameter was passed to a native method, parameter number : {parameter}")
		{
		}

		public InvalidParameterException(int parameter, Exception innerException)
			: base($"An invalid parameter was passed to a native method, parameter number : {parameter}", innerException)
		{
		}
	}
}
