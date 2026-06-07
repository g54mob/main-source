using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Rewired.Libraries.SharpDX
{
	internal sealed class ResultDescriptor
	{
		private static readonly object LockDescriptor;

		private static readonly List<Type> RegisteredDescriptorProvider;

		private static readonly Dictionary<cIeAnFRbFTxcGmCNQIAyEiQeyPZJ, ResultDescriptor> Descriptors;

		public cIeAnFRbFTxcGmCNQIAyEiQeyPZJ Result { get; private set; }

		public string Module { get; private set; }

		public string NativeApiCode { get; private set; }

		public string ApiCode { get; private set; }

		public string Description { get; set; }

		public ResultDescriptor(cIeAnFRbFTxcGmCNQIAyEiQeyPZJ code, string module, string nativeApiCode, string apiCode, string description = null)
		{
		}

		public bool Equals(ResultDescriptor other)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override string ToString()
		{
			return null;
		}

		public static ResultDescriptor Find(cIeAnFRbFTxcGmCNQIAyEiQeyPZJ result)
		{
			return null;
		}

		private static void AddDescriptorsFromType(Type type)
		{
		}

		private static string GetDescriptionFromResultCode(int resultCode)
		{
			return null;
		}

		[PreserveSig]
		private static extern uint FormatMessageW(int dwFlags, IntPtr lpSource, int dwMessageId, int dwLanguageId, ref IntPtr lpBuffer, int nSize, IntPtr Arguments);
	}
}
