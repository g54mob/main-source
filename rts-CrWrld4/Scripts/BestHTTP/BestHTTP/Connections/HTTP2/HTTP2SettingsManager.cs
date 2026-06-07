using System;
using System.Collections.Generic;

namespace BestHTTP.Connections.HTTP2
{
	public sealed class HTTP2SettingsManager
	{
		public static readonly int SettingsCount;

		public HTTP2SettingsRegistry MySettings { get; private set; }

		public HTTP2SettingsRegistry InitiatedMySettings { get; private set; }

		public HTTP2SettingsRegistry RemoteSettings { get; private set; }

		public DateTime SettingsChangesSentAt { get; private set; }

		public HTTP2Handler Parent { get; private set; }

		public HTTP2SettingsManager(HTTP2Handler parentHandler)
		{
		}

		internal void Process(HTTP2FrameHeaderAndPayload frame, List<HTTP2FrameHeaderAndPayload> outgoingFrames)
		{
		}

		internal void SendChanges(List<HTTP2FrameHeaderAndPayload> outgoingFrames)
		{
		}
	}
}
