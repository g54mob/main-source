using System;

namespace Epic.OnlineServices.Platform
{
	public class AndroidInitializeOptionsSystemInitializeOptions : ISettable
	{
		public IntPtr Reserved { get; set; }

		public string OptionalInternalDirectory { get; set; }

		public string OptionalExternalDirectory { get; set; }

		internal void Set(AndroidInitializeOptionsSystemInitializeOptionsInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
