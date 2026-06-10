using System;

namespace TwitchSDK.Interop
{
	public interface IMarshallableStartAsync : IMarshallable
	{
		GenericTaskCallback TaskCallback { get; }

		IntPtr TaskCallbackPayload { get; }
	}
}
