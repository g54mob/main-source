using System;

namespace Oculus.Platform
{
	public class RichPresenceOptions
	{
		private IntPtr Handle;

		public RichPresenceOptions()
		{
			Handle = CAPI.ovr_RichPresenceOptions_Create();
		}

		public void SetApiName(string value)
		{
			CAPI.ovr_RichPresenceOptions_SetApiName(Handle, value);
		}

		public void SetCurrentCapacity(uint value)
		{
			CAPI.ovr_RichPresenceOptions_SetCurrentCapacity(Handle, value);
		}

		public void SetDeeplinkMessageOverride(string value)
		{
			CAPI.ovr_RichPresenceOptions_SetDeeplinkMessageOverride(Handle, value);
		}

		public void SetEndTime(DateTime value)
		{
			CAPI.ovr_RichPresenceOptions_SetEndTime(Handle, value);
		}

		public void SetExtraContext(RichPresenceExtraContext value)
		{
			CAPI.ovr_RichPresenceOptions_SetExtraContext(Handle, value);
		}

		public void SetInstanceId(string value)
		{
			CAPI.ovr_RichPresenceOptions_SetInstanceId(Handle, value);
		}

		public void SetIsIdle(bool value)
		{
			CAPI.ovr_RichPresenceOptions_SetIsIdle(Handle, value);
		}

		public void SetIsJoinable(bool value)
		{
			CAPI.ovr_RichPresenceOptions_SetIsJoinable(Handle, value);
		}

		public void SetMaxCapacity(uint value)
		{
			CAPI.ovr_RichPresenceOptions_SetMaxCapacity(Handle, value);
		}

		public void SetStartTime(DateTime value)
		{
			CAPI.ovr_RichPresenceOptions_SetStartTime(Handle, value);
		}

		public static explicit operator IntPtr(RichPresenceOptions options)
		{
			return options?.Handle ?? IntPtr.Zero;
		}

		~RichPresenceOptions()
		{
			CAPI.ovr_RichPresenceOptions_Destroy(Handle);
		}
	}
}
