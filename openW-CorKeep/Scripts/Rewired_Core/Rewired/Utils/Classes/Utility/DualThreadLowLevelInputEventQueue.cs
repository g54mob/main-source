using System;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class DualThreadLowLevelInputEventQueue : IDisposable
	{
		private class TfLcuHbEDaTxdEbUDuplUKMclNeOA : LockedObject<LowLevelInputEvent>, INewEventWrapper, IDisposable
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

			public TfLcuHbEDaTxdEbUDuplUKMclNeOA(object P_0)
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

		private readonly LowLevelInputEventQueue sfyHvmunJwLrlSJqHKXjyWZekqAb;

		private readonly LowLevelInputEventQueue UFFUGSzUDEpJcNoMaEaIfgiJMgeGA;

		private readonly object yjRvzltCwRTbQDSEIIJYxuQKshzL;

		private uint ExSkgiNoywaJjpseUDcLswrYhwPe;

		private bool MPvfwrMjPptPAqVSbCEbTBKeRwdq;

		private int VvqovPyfoJDKFfrtPbuklfnaPpefb;

		private int PlfkBnSlVpdRuTxHANFLrsGtmtng;

		private TfLcuHbEDaTxdEbUDuplUKMclNeOA HaEmSHPfDowuzVymwUvLDIoxKkty;

		public LowLevelInputEvent currentEvent;

		private bool xKIBFOCScyxiovghbMTjEcVwsJGk;

		public uint lastProcessedEventId => ExSkgiNoywaJjpseUDcLswrYhwPe;

		public int count
		{
			get
			{
				lock (yjRvzltCwRTbQDSEIIJYxuQKshzL)
				{
					return sfyHvmunJwLrlSJqHKXjyWZekqAb.Count;
				}
			}
		}

		public DualThreadLowLevelInputEventQueue(int P_0, int P_1, int P_2, int P_3)
		{
			sfyHvmunJwLrlSJqHKXjyWZekqAb = new LowLevelInputEventQueue(P_0, P_1, P_2, P_3);
			UFFUGSzUDEpJcNoMaEaIfgiJMgeGA = new LowLevelInputEventQueue(P_0, P_1, P_2, P_3);
			yjRvzltCwRTbQDSEIIJYxuQKshzL = new object();
			HaEmSHPfDowuzVymwUvLDIoxKkty = new TfLcuHbEDaTxdEbUDuplUKMclNeOA(yjRvzltCwRTbQDSEIIJYxuQKshzL);
		}

		public INewEventWrapper T_CreateEvent()
		{
			HaEmSHPfDowuzVymwUvLDIoxKkty.Lock();
			HaEmSHPfDowuzVymwUvLDIoxKkty.item = UFFUGSzUDEpJcNoMaEaIfgiJMgeGA.CreateEvent();
			return HaEmSHPfDowuzVymwUvLDIoxKkty;
		}

		public void Update()
		{
			lock (yjRvzltCwRTbQDSEIIJYxuQKshzL)
			{
				sfyHvmunJwLrlSJqHKXjyWZekqAb.CopyNewEventsFrom(UFFUGSzUDEpJcNoMaEaIfgiJMgeGA);
			}
		}

		public void Clear()
		{
			lock (yjRvzltCwRTbQDSEIIJYxuQKshzL)
			{
				StopProcessingEvents();
				sfyHvmunJwLrlSJqHKXjyWZekqAb.Clear();
				UFFUGSzUDEpJcNoMaEaIfgiJMgeGA.Clear();
			}
		}

		public bool ProcessNewEvents()
		{
			if (PlfkBnSlVpdRuTxHANFLrsGtmtng == 0)
			{
				Update();
				int num = sfyHvmunJwLrlSJqHKXjyWZekqAb.FindNextIndex(ExSkgiNoywaJjpseUDcLswrYhwPe);
				if (num < 0)
				{
					currentEvent = default(LowLevelInputEvent);
					return false;
				}
				PlfkBnSlVpdRuTxHANFLrsGtmtng = num;
				MPvfwrMjPptPAqVSbCEbTBKeRwdq = true;
				VvqovPyfoJDKFfrtPbuklfnaPpefb = sfyHvmunJwLrlSJqHKXjyWZekqAb.Count;
			}
			if (PlfkBnSlVpdRuTxHANFLrsGtmtng >= VvqovPyfoJDKFfrtPbuklfnaPpefb)
			{
				currentEvent = default(LowLevelInputEvent);
				MPvfwrMjPptPAqVSbCEbTBKeRwdq = false;
				PlfkBnSlVpdRuTxHANFLrsGtmtng = 0;
				return false;
			}
			if (sfyHvmunJwLrlSJqHKXjyWZekqAb.TryGetNext(PlfkBnSlVpdRuTxHANFLrsGtmtng, out currentEvent))
			{
				ExSkgiNoywaJjpseUDcLswrYhwPe = currentEvent.GetId();
				PlfkBnSlVpdRuTxHANFLrsGtmtng++;
				return true;
			}
			currentEvent = default(LowLevelInputEvent);
			MPvfwrMjPptPAqVSbCEbTBKeRwdq = false;
			PlfkBnSlVpdRuTxHANFLrsGtmtng = 0;
			return false;
		}

		public void StopProcessingEvents()
		{
			MPvfwrMjPptPAqVSbCEbTBKeRwdq = false;
			PlfkBnSlVpdRuTxHANFLrsGtmtng = 0;
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
			lock (yjRvzltCwRTbQDSEIIJYxuQKshzL)
			{
				lock (other.yjRvzltCwRTbQDSEIIJYxuQKshzL)
				{
					sfyHvmunJwLrlSJqHKXjyWZekqAb.CopyAllFrom(other.sfyHvmunJwLrlSJqHKXjyWZekqAb);
					UFFUGSzUDEpJcNoMaEaIfgiJMgeGA.CopyAllFrom(other.UFFUGSzUDEpJcNoMaEaIfgiJMgeGA);
					ExSkgiNoywaJjpseUDcLswrYhwPe = other.ExSkgiNoywaJjpseUDcLswrYhwPe;
					MPvfwrMjPptPAqVSbCEbTBKeRwdq = other.MPvfwrMjPptPAqVSbCEbTBKeRwdq;
					VvqovPyfoJDKFfrtPbuklfnaPpefb = other.VvqovPyfoJDKFfrtPbuklfnaPpefb;
					PlfkBnSlVpdRuTxHANFLrsGtmtng = other.PlfkBnSlVpdRuTxHANFLrsGtmtng;
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
			if (xKIBFOCScyxiovghbMTjEcVwsJGk)
			{
				return;
			}
			if (disposing)
			{
				lock (yjRvzltCwRTbQDSEIIJYxuQKshzL)
				{
					sfyHvmunJwLrlSJqHKXjyWZekqAb.Dispose();
					UFFUGSzUDEpJcNoMaEaIfgiJMgeGA.Dispose();
				}
			}
			xKIBFOCScyxiovghbMTjEcVwsJGk = true;
		}
	}
}
