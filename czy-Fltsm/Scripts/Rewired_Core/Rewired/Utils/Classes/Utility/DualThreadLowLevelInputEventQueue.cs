using System;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class DualThreadLowLevelInputEventQueue : IDisposable
	{
		private class BbXmmWmhboIhXGJaSYwGNkOBNSsQ : LockedObject<LowLevelInputEvent>, INewEventWrapper, IDisposable
		{
			LowLevelInputEvent INewEventWrapper.Event
			{
				get
				{
					return item;
				}
				set
				{
					item = value;
				}
			}

			public BbXmmWmhboIhXGJaSYwGNkOBNSsQ(object P_0)
				: base(P_0)
			{
			}
		}

		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		public interface INewEventWrapper : IDisposable
		{
			LowLevelInputEvent Event { get; set; }
		}

		private readonly LowLevelInputEventQueue iTndViQCZZJTJretflFctvOultoQ;

		private readonly LowLevelInputEventQueue EdZQAVJhzKbVWDkivorfmjqozjyhA;

		private readonly object wgJztoJCOHVbmqmcBZmzmJQxdSdI;

		private uint YCUguhlFMuggVSiWRWFqnfsbBoZr;

		private bool QwbdeyIaflSPynFksMJKLSGTstvbA;

		private int HtkUnOIGYDRSvOIVSCxDdmbJTsmTA;

		private int NjhCHuDalfSjYMmtFJMwoqGKypvIA;

		private BbXmmWmhboIhXGJaSYwGNkOBNSsQ VeQeOCAvlcDeHFeWAbikRYiNOfbub;

		public LowLevelInputEvent currentEvent;

		private bool jGKXnVcgAsjySIaJoHPWBeVPdaGL;

		public uint lastProcessedEventId => YCUguhlFMuggVSiWRWFqnfsbBoZr;

		public int count
		{
			get
			{
				lock (wgJztoJCOHVbmqmcBZmzmJQxdSdI)
				{
					return iTndViQCZZJTJretflFctvOultoQ.Count;
				}
			}
		}

		public int capacity
		{
			get
			{
				lock (wgJztoJCOHVbmqmcBZmzmJQxdSdI)
				{
					return iTndViQCZZJTJretflFctvOultoQ.Capacity;
				}
			}
		}

		public int capacityBytes
		{
			get
			{
				lock (wgJztoJCOHVbmqmcBZmzmJQxdSdI)
				{
					return iTndViQCZZJTJretflFctvOultoQ.CapacityBytes;
				}
			}
		}

		public DualThreadLowLevelInputEventQueue(int P_0, int P_1, int P_2, int P_3)
		{
			iTndViQCZZJTJretflFctvOultoQ = new LowLevelInputEventQueue(P_0, P_1, P_2, P_3);
			EdZQAVJhzKbVWDkivorfmjqozjyhA = new LowLevelInputEventQueue(P_0, P_1, P_2, P_3);
			wgJztoJCOHVbmqmcBZmzmJQxdSdI = new object();
			VeQeOCAvlcDeHFeWAbikRYiNOfbub = new BbXmmWmhboIhXGJaSYwGNkOBNSsQ(wgJztoJCOHVbmqmcBZmzmJQxdSdI);
		}

		public INewEventWrapper T_CreateEvent()
		{
			VeQeOCAvlcDeHFeWAbikRYiNOfbub.Lock();
			VeQeOCAvlcDeHFeWAbikRYiNOfbub.item = EdZQAVJhzKbVWDkivorfmjqozjyhA.CreateEvent();
			return VeQeOCAvlcDeHFeWAbikRYiNOfbub;
		}

		public void Update()
		{
			lock (wgJztoJCOHVbmqmcBZmzmJQxdSdI)
			{
				iTndViQCZZJTJretflFctvOultoQ.CopyNewEventsFrom(EdZQAVJhzKbVWDkivorfmjqozjyhA);
			}
		}

		public void Clear()
		{
			lock (wgJztoJCOHVbmqmcBZmzmJQxdSdI)
			{
				StopProcessingEvents();
				iTndViQCZZJTJretflFctvOultoQ.Clear();
				EdZQAVJhzKbVWDkivorfmjqozjyhA.Clear();
			}
		}

		public bool ProcessNewEvents()
		{
			if (NjhCHuDalfSjYMmtFJMwoqGKypvIA == 0)
			{
				Update();
				int num = iTndViQCZZJTJretflFctvOultoQ.FindNextIndex(YCUguhlFMuggVSiWRWFqnfsbBoZr);
				if (num < 0)
				{
					currentEvent = default(LowLevelInputEvent);
					return false;
				}
				NjhCHuDalfSjYMmtFJMwoqGKypvIA = num;
				QwbdeyIaflSPynFksMJKLSGTstvbA = true;
				HtkUnOIGYDRSvOIVSCxDdmbJTsmTA = iTndViQCZZJTJretflFctvOultoQ.Count;
			}
			if (NjhCHuDalfSjYMmtFJMwoqGKypvIA >= HtkUnOIGYDRSvOIVSCxDdmbJTsmTA)
			{
				currentEvent = default(LowLevelInputEvent);
				QwbdeyIaflSPynFksMJKLSGTstvbA = false;
				NjhCHuDalfSjYMmtFJMwoqGKypvIA = 0;
				return false;
			}
			if (iTndViQCZZJTJretflFctvOultoQ.TryGetNext(NjhCHuDalfSjYMmtFJMwoqGKypvIA, out currentEvent))
			{
				YCUguhlFMuggVSiWRWFqnfsbBoZr = currentEvent.GetId();
				NjhCHuDalfSjYMmtFJMwoqGKypvIA++;
				return true;
			}
			currentEvent = default(LowLevelInputEvent);
			QwbdeyIaflSPynFksMJKLSGTstvbA = false;
			NjhCHuDalfSjYMmtFJMwoqGKypvIA = 0;
			return false;
		}

		public void StopProcessingEvents()
		{
			QwbdeyIaflSPynFksMJKLSGTstvbA = false;
			NjhCHuDalfSjYMmtFJMwoqGKypvIA = 0;
		}

		public void ImportAll(DualThreadLowLevelInputEventQueue other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			if (other == this)
			{
				return;
			}
			lock (wgJztoJCOHVbmqmcBZmzmJQxdSdI)
			{
				lock (other.wgJztoJCOHVbmqmcBZmzmJQxdSdI)
				{
					iTndViQCZZJTJretflFctvOultoQ.CopyAllFrom(other.iTndViQCZZJTJretflFctvOultoQ);
					EdZQAVJhzKbVWDkivorfmjqozjyhA.CopyAllFrom(other.EdZQAVJhzKbVWDkivorfmjqozjyhA);
					YCUguhlFMuggVSiWRWFqnfsbBoZr = other.YCUguhlFMuggVSiWRWFqnfsbBoZr;
					QwbdeyIaflSPynFksMJKLSGTstvbA = other.QwbdeyIaflSPynFksMJKLSGTstvbA;
					HtkUnOIGYDRSvOIVSCxDdmbJTsmTA = other.HtkUnOIGYDRSvOIVSCxDdmbJTsmTA;
					NjhCHuDalfSjYMmtFJMwoqGKypvIA = other.NjhCHuDalfSjYMmtFJMwoqGKypvIA;
				}
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		~DualThreadLowLevelInputEventQueue()
		{
			Dispose(disposing: false);
		}

		protected void Dispose(bool disposing)
		{
			if (jGKXnVcgAsjySIaJoHPWBeVPdaGL)
			{
				return;
			}
			if (disposing)
			{
				lock (wgJztoJCOHVbmqmcBZmzmJQxdSdI)
				{
					iTndViQCZZJTJretflFctvOultoQ.Dispose();
					EdZQAVJhzKbVWDkivorfmjqozjyhA.Dispose();
				}
			}
			jGKXnVcgAsjySIaJoHPWBeVPdaGL = true;
		}
	}
}
