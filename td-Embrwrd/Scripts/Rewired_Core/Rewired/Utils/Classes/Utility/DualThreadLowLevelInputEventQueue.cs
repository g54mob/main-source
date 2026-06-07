using System;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class DualThreadLowLevelInputEventQueue : IDisposable
	{
		private class XZnARoNlVaTbIMGdRpeDehoFkeII : LockedObject<LowLevelInputEvent>, INewEventWrapper, IDisposable
		{
			public LowLevelInputEvent Event
			{
				get
				{
					return default(LowLevelInputEvent);
				}
				set
				{
				}
			}

			public XZnARoNlVaTbIMGdRpeDehoFkeII(object P_0)
			{
			}
		}

		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		public interface INewEventWrapper : IDisposable
		{
			LowLevelInputEvent Event { get; set; }
		}

		private readonly LowLevelInputEventQueue oaFxzAvcJZybAjFXycKdkQycFRCbb;

		private readonly LowLevelInputEventQueue fRqhAqvGKlVKeSPmkqzCMVaBENc;

		private readonly object qLnFNQgXENrptctEKVMcBNqxTZLk;

		private uint YAqaCVJYIeNISvGiUnJbVKInKCpfb;

		private bool MpZGWITjXjnbbVcOnApTtFiTgRZP;

		private int LsSAZktKOLfayWmxPyVEHaHNIQEy;

		private int ZkBxwYLjthLLFgJBMZLhVjsODvXK;

		private XZnARoNlVaTbIMGdRpeDehoFkeII RzamFcWhrgkIIeAsoorjlMEQmBXw;

		public LowLevelInputEvent currentEvent;

		private bool xloerzJtEwNQFGyltINJumrVLteJ;

		public uint lastProcessedEventId => 0u;

		public int count => 0;

		public int capacity => 0;

		public int capacityBytes => 0;

		public DualThreadLowLevelInputEventQueue(int P_0, int P_1, int P_2, int P_3)
		{
		}

		public INewEventWrapper T_CreateEvent()
		{
			return null;
		}

		public void Update()
		{
		}

		public void Clear()
		{
		}

		public bool ProcessNewEvents()
		{
			return false;
		}

		public void StopProcessingEvents()
		{
		}

		public void ImportAll(DualThreadLowLevelInputEventQueue other)
		{
		}

		public void Dispose()
		{
		}

		~DualThreadLowLevelInputEventQueue()
		{
		}

		protected void Dispose(bool disposing)
		{
		}
	}
}
