using System;

namespace Rewired.Libraries.SharpDX.DirectInput
{
	internal sealed class DataObjectFormatAttribute : Attribute
	{
		public string Name;

		public string Guid;

		public int ArrayCount;

		public zfmdQVcnrkfFEEsXtYFYWXIJYkB TypeFlags;

		public DykeFgHRwqKOxdmmOXFLBiwAuyKC Flags;

		public int InstanceNumber;

		public DataObjectFormatAttribute(string guid, zfmdQVcnrkfFEEsXtYFYWXIJYkB typeFlags, DykeFgHRwqKOxdmmOXFLBiwAuyKC flags)
		{
		}

		public DataObjectFormatAttribute(string guid, int arrayCount, zfmdQVcnrkfFEEsXtYFYWXIJYkB typeFlags, DykeFgHRwqKOxdmmOXFLBiwAuyKC flags)
		{
		}

		public DataObjectFormatAttribute(string guid, int arrayCount, zfmdQVcnrkfFEEsXtYFYWXIJYkB typeFlags)
		{
		}

		public DataObjectFormatAttribute(int arrayCount, zfmdQVcnrkfFEEsXtYFYWXIJYkB typeFlags)
		{
		}
	}
}
