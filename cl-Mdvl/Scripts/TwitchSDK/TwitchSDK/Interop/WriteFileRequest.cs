using System;
using System.Runtime.InteropServices;

namespace TwitchSDK.Interop
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public class WriteFileRequest : IMarshallableStartAsync, IMarshallable
	{
		internal readonly int TypeCode = -1420421173;

		public string Path;

		public string Data;

		public GenericTaskCallback TaskCallback { get; set; }

		public IntPtr TaskCallbackPayload { get; set; }

		public override int GetHashCode()
		{
			return (13 * 7 + Path.GetHashCode()) * 7 + Data.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			WriteFileRequest writeFileRequest = obj as WriteFileRequest;
			if (writeFileRequest == null)
			{
				return false;
			}
			if (Path == writeFileRequest.Path)
			{
				return Data == writeFileRequest.Data;
			}
			return false;
		}

		public static bool operator ==(WriteFileRequest a, WriteFileRequest b)
		{
			return object.Equals(a, b);
		}

		public static bool operator !=(WriteFileRequest a, WriteFileRequest b)
		{
			return !(a == b);
		}
	}
}
