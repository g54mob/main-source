using System;
using System.Collections.Generic;
using BestHTTP.Logger;

namespace BestHTTP.Connections.HTTP2
{
	public sealed class HTTP2Stream
	{
		private HTTP2StreamStates _state;

		private DateTime lastStateChangedAt;

		private bool isStreamedDownload;

		private uint downloaded;

		private HTTPRequest.UploadStreamInfo uploadStreamInfo;

		private HTTP2SettingsManager settings;

		private HPACKEncoder encoder;

		private Queue<HTTP2FrameHeaderAndPayload> outgoing;

		private Queue<HTTP2FrameHeaderAndPayload> incomingFrames;

		private FramesAsStreamView headerView;

		private FramesAsStreamView dataView;

		private uint localWindow;

		private long remoteWindow;

		private uint windowUpdateThreshold;

		private uint sentData;

		private bool isRSTFrameSent;

		private bool isEndSTRReceived;

		private HTTP2Response response;

		private HTTP2Handler parent;

		private int lastReadCount;

		public uint Id { get; private set; }

		public HTTP2StreamStates State
		{
			get
			{
				return default(HTTP2StreamStates);
			}
			private set
			{
			}
		}

		public bool HasFrameToSend => false;

		public HTTPRequest AssignedRequest { get; private set; }

		public LoggingContext Context { get; private set; }

		public HTTP2Stream(uint id, HTTP2Handler parentHandler, HTTP2SettingsManager registry, HPACKEncoder hpackEncoder)
		{
		}

		public void Assign(HTTPRequest request)
		{
		}

		public void Process(List<HTTP2FrameHeaderAndPayload> outgoingFrames)
		{
		}

		public void AddFrame(HTTP2FrameHeaderAndPayload frame, List<HTTP2FrameHeaderAndPayload> outgoingFrames)
		{
		}

		public void Abort(string msg)
		{
		}

		private void ProcessIncomingFrames(List<HTTP2FrameHeaderAndPayload> outgoingFrames)
		{
		}

		private void ProcessState(List<HTTP2FrameHeaderAndPayload> outgoingFrames)
		{
		}

		private void OnRemoteSettingChanged(HTTP2SettingsRegistry registry, HTTP2Settings setting, uint oldValue, uint newValue)
		{
		}

		private static void FinishRequest(HTTP2Stream stream, FramesAsStreamView dataStream)
		{
		}

		public void Removed()
		{
		}
	}
}
