using System;

namespace MathNet.Numerics
{
	[Serializable]
	public class SingularUMatrixException : NativeInterfaceException
	{
		public SingularUMatrixException()
			: base("U is singular, and the inversion could not be completed.")
		{
		}

		public SingularUMatrixException(int element)
			: base($"U is singular, and the inversion could not be completed. The {element}-th diagonal element of the factor U is zero.")
		{
		}

		public SingularUMatrixException(int element, Exception innerException)
			: base($"U is singular, and the inversion could not be completed. The {element}-th diagonal element of the factor U is zero.", innerException)
		{
		}
	}
}
