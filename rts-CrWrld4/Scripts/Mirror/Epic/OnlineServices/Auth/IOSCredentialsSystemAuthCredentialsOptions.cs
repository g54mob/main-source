using System;

namespace Epic.OnlineServices.Auth
{
	public class IOSCredentialsSystemAuthCredentialsOptions : ISettable
	{
		public IntPtr PresentationContextProviding { get; set; }

		internal void Set(IOSCredentialsSystemAuthCredentialsOptionsInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
