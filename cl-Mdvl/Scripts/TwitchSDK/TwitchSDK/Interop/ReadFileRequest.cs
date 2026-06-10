using System;
using System.Runtime.InteropServices;

namespace TwitchSDK.Interop
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public class ReadFileRequest : IMarshallableStartAsync, IMarshallable
	{
		internal readonly int TypeCode = -1182308723;

		public string Path;

		public GenericTaskCallback TaskCallback { get; set; }

		public IntPtr TaskCallbackPayload { get; set; }

		public override int GetHashCode()
		{
			return 13 * 7 + Path.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			ReadFileRequest readFileRequest = obj as ReadFileRequest;
			if (readFileRequest == null)
			{
				return false;
			}
			return Path == readFileRequest.Path;
		}

		public static bool operator ==(ReadFileRequest a, ReadFileRequest b)
		{
			return object.Equals(a, b);
		}

		public static bool operator !=(ReadFileRequest a, ReadFileRequest b)
		{
			return !(a == b);
		}
	}
}
