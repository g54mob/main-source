using System;
using System.Collections.Generic;

namespace BestHTTP.Connections.HTTP2
{
	public sealed class HTTP2SettingsRegistry
	{
		public Action<HTTP2SettingsRegistry, HTTP2Settings, uint, uint> OnSettingChangedEvent;

		private uint[] values;

		private bool[] changeFlags;

		private HTTP2SettingsManager _parent;

		public bool IsReadOnly { get; private set; }

		public uint Item
		{
			get
			{
				return 0u;
			}
			set
			{
			}
		}

		public bool IsChanged { get; private set; }

		public HTTP2SettingsRegistry(HTTP2SettingsManager parent, bool readOnly, bool treatItAsAlreadyChanged)
		{
		}

		public void Merge(List<KeyValuePair<HTTP2Settings, uint>> settings)
		{
		}

		public void Merge(HTTP2SettingsRegistry from)
		{
		}

		internal HTTP2FrameHeaderAndPayload CreateFrame()
		{
			return default(HTTP2FrameHeaderAndPayload);
		}
	}
}
