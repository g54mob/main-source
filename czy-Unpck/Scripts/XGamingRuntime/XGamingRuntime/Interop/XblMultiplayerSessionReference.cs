namespace XGamingRuntime.Interop
{
	internal struct XblMultiplayerSessionReference
	{
		private unsafe fixed byte Scid[40];

		private unsafe fixed byte SessionTemplateName[100];

		private unsafe fixed byte SessionName[100];

		internal unsafe string GetScid()
		{
			fixed (byte* scid = Scid)
			{
				return Converters.BytePointerToString(scid, 40);
			}
		}

		internal unsafe string GetSessionTemplateName()
		{
			fixed (byte* sessionTemplateName = SessionTemplateName)
			{
				return Converters.BytePointerToString(sessionTemplateName, 100);
			}
		}

		internal unsafe string GetSessionName()
		{
			fixed (byte* sessionName = SessionName)
			{
				return Converters.BytePointerToString(sessionName, 100);
			}
		}

		internal unsafe XblMultiplayerSessionReference(XGamingRuntime.XblMultiplayerSessionReference publicObject)
		{
			fixed (byte* scid = Scid)
			{
				Converters.StringToNullTerminatedUTF8FixedPointer(publicObject.Scid, scid, 40);
			}
			fixed (byte* sessionTemplateName = SessionTemplateName)
			{
				Converters.StringToNullTerminatedUTF8FixedPointer(publicObject.SessionTemplateName, sessionTemplateName, 100);
			}
			fixed (byte* sessionName = SessionName)
			{
				Converters.StringToNullTerminatedUTF8FixedPointer(publicObject.SessionName, sessionName, 100);
			}
		}
	}
}
