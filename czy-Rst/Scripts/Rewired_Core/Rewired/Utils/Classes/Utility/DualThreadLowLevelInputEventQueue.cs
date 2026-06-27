using System;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class DualThreadLowLevelInputEventQueue : IDisposable
	{
		private class OccizTlfksTwagtcfHoWqhBmeKJJ : LockedObject<LowLevelInputEvent>, INewEventWrapper, IDisposable
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

			public OccizTlfksTwagtcfHoWqhBmeKJJ(object P_0)
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

		private readonly LowLevelInputEventQueue dKSlRvFiUZdhyJPpInmoOoFRxVTy;

		private readonly LowLevelInputEventQueue FBuaSOYQgQnpnWumWQYbAbpPoJZN;

		private readonly object xDkCjxCKTPLvJbMisKgzeZRiOPKpb;

		private uint LBtrsgaLXmGYiwLIsAniWGhUZSmM;

		private bool VNOmDfbiwjrjNbliVcGAztRuXOEH;

		private int CPXzaZRZrXwuUwDCfMSZTctsEEBe;

		private int QUOHHnpgafJlpIxrqfYsHDJpNRIf;

		private OccizTlfksTwagtcfHoWqhBmeKJJ QZpIyNugawKTgQCAQLrkhzJjTKuc;

		public LowLevelInputEvent currentEvent;

		private bool kBdDXQGnBoXXrsePNfwKyuIkhFhwA;

		public uint lastProcessedEventId => LBtrsgaLXmGYiwLIsAniWGhUZSmM;

		public int count
		{
			get
			{
				lock (xDkCjxCKTPLvJbMisKgzeZRiOPKpb)
				{
					return dKSlRvFiUZdhyJPpInmoOoFRxVTy.Count;
				}
			}
		}

		public DualThreadLowLevelInputEventQueue(int P_0, int P_1, int P_2, int P_3)
		{
			dKSlRvFiUZdhyJPpInmoOoFRxVTy = new LowLevelInputEventQueue(P_0, P_1, P_2, P_3);
			FBuaSOYQgQnpnWumWQYbAbpPoJZN = new LowLevelInputEventQueue(P_0, P_1, P_2, P_3);
			xDkCjxCKTPLvJbMisKgzeZRiOPKpb = new object();
			QZpIyNugawKTgQCAQLrkhzJjTKuc = new OccizTlfksTwagtcfHoWqhBmeKJJ(xDkCjxCKTPLvJbMisKgzeZRiOPKpb);
		}

		public INewEventWrapper T_CreateEvent()
		{
			QZpIyNugawKTgQCAQLrkhzJjTKuc.Lock();
			QZpIyNugawKTgQCAQLrkhzJjTKuc.item = FBuaSOYQgQnpnWumWQYbAbpPoJZN.CreateEvent();
			return QZpIyNugawKTgQCAQLrkhzJjTKuc;
		}

		public void Update()
		{
			lock (xDkCjxCKTPLvJbMisKgzeZRiOPKpb)
			{
				dKSlRvFiUZdhyJPpInmoOoFRxVTy.CopyNewEventsFrom(FBuaSOYQgQnpnWumWQYbAbpPoJZN);
			}
		}

		public void Clear()
		{
			lock (xDkCjxCKTPLvJbMisKgzeZRiOPKpb)
			{
				StopProcessingEvents();
				dKSlRvFiUZdhyJPpInmoOoFRxVTy.Clear();
				FBuaSOYQgQnpnWumWQYbAbpPoJZN.Clear();
			}
		}

		public bool ProcessNewEvents()
		{
			if (QUOHHnpgafJlpIxrqfYsHDJpNRIf == 0)
			{
				Update();
				int num = dKSlRvFiUZdhyJPpInmoOoFRxVTy.FindNextIndex(LBtrsgaLXmGYiwLIsAniWGhUZSmM);
				if (num < 0)
				{
					currentEvent = default(LowLevelInputEvent);
					return false;
				}
				QUOHHnpgafJlpIxrqfYsHDJpNRIf = num;
				VNOmDfbiwjrjNbliVcGAztRuXOEH = true;
				CPXzaZRZrXwuUwDCfMSZTctsEEBe = dKSlRvFiUZdhyJPpInmoOoFRxVTy.Count;
			}
			if (QUOHHnpgafJlpIxrqfYsHDJpNRIf >= CPXzaZRZrXwuUwDCfMSZTctsEEBe)
			{
				currentEvent = default(LowLevelInputEvent);
				VNOmDfbiwjrjNbliVcGAztRuXOEH = false;
				QUOHHnpgafJlpIxrqfYsHDJpNRIf = 0;
				return false;
			}
			if (dKSlRvFiUZdhyJPpInmoOoFRxVTy.TryGetNext(QUOHHnpgafJlpIxrqfYsHDJpNRIf, out currentEvent))
			{
				LBtrsgaLXmGYiwLIsAniWGhUZSmM = currentEvent.GetId();
				QUOHHnpgafJlpIxrqfYsHDJpNRIf++;
				return true;
			}
			currentEvent = default(LowLevelInputEvent);
			VNOmDfbiwjrjNbliVcGAztRuXOEH = false;
			QUOHHnpgafJlpIxrqfYsHDJpNRIf = 0;
			return false;
		}

		public void StopProcessingEvents()
		{
			VNOmDfbiwjrjNbliVcGAztRuXOEH = false;
			QUOHHnpgafJlpIxrqfYsHDJpNRIf = 0;
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
			lock (xDkCjxCKTPLvJbMisKgzeZRiOPKpb)
			{
				lock (other.xDkCjxCKTPLvJbMisKgzeZRiOPKpb)
				{
					dKSlRvFiUZdhyJPpInmoOoFRxVTy.CopyAllFrom(other.dKSlRvFiUZdhyJPpInmoOoFRxVTy);
					FBuaSOYQgQnpnWumWQYbAbpPoJZN.CopyAllFrom(other.FBuaSOYQgQnpnWumWQYbAbpPoJZN);
					LBtrsgaLXmGYiwLIsAniWGhUZSmM = other.LBtrsgaLXmGYiwLIsAniWGhUZSmM;
					VNOmDfbiwjrjNbliVcGAztRuXOEH = other.VNOmDfbiwjrjNbliVcGAztRuXOEH;
					CPXzaZRZrXwuUwDCfMSZTctsEEBe = other.CPXzaZRZrXwuUwDCfMSZTctsEEBe;
					QUOHHnpgafJlpIxrqfYsHDJpNRIf = other.QUOHHnpgafJlpIxrqfYsHDJpNRIf;
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
			if (kBdDXQGnBoXXrsePNfwKyuIkhFhwA)
			{
				return;
			}
			if (disposing)
			{
				lock (xDkCjxCKTPLvJbMisKgzeZRiOPKpb)
				{
					dKSlRvFiUZdhyJPpInmoOoFRxVTy.Dispose();
					FBuaSOYQgQnpnWumWQYbAbpPoJZN.Dispose();
				}
			}
			kBdDXQGnBoXXrsePNfwKyuIkhFhwA = true;
		}
	}
}
