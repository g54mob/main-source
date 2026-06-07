using System;

namespace VoxelBusters.CoreLibrary
{
	public class VBException : Exception
	{
		public string Domain { get; private set; }

		public int ErrorCode { get; private set; }

		public VBException(string message, int errorCode = -1, Exception innerException = null)
		{
		}

		public VBException(string message, Exception innerException)
		{
		}

		public static VBException NotImplemented(string messsage = "Not implemented.")
		{
			return null;
		}

		public static VBException NotSupported(string messsage = "Not supported.")
		{
			return null;
		}

		public static VBException InvalidOperation(string messsage = "Invalid operation.")
		{
			return null;
		}

		public static VBException ArgumentNull(string property)
		{
			return null;
		}

		public static VBException SwitchCaseNotImplemented(object value)
		{
			return null;
		}
	}
}
