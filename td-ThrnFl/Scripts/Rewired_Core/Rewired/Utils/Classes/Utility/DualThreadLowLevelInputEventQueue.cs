using System;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class DualThreadLowLevelInputEventQueue : IDisposable
	{
		private class yMhFXoqVysJaGvmfaoYbHWxhTOpw : LockedObject<LowLevelInputEvent>, INewEventWrapper, IDisposable
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

			public yMhFXoqVysJaGvmfaoYbHWxhTOpw(object P_0)
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

		private readonly LowLevelInputEventQueue VtNunUSCAVIYYIuuPPhFnHvUDnbIA;

		private readonly LowLevelInputEventQueue xmtNbbLqaWgIHDTvXGXSvzHGKldn;

		private readonly object ZidKGWHBNRGkrPUtfnsWyvmTfDeG;

		private uint pPqXsJxeZcCzMnPNpPgDrpFLIoEAA;

		private bool hiXcVIwSkhZYlcexMxphYyxpfSkm;

		private int ydABMeBSPNjZgbdYdaBswkOttmhMb;

		private int yJNFeKgcofEoZPJcnKeFywbkFpydA;

		private yMhFXoqVysJaGvmfaoYbHWxhTOpw gvmDpsKpoutzQaLTToGFsILscbqOA;

		public LowLevelInputEvent currentEvent;

		private bool GHeuXvgXNksdPxIKSpYtHDeffyZF;

		public uint lastProcessedEventId => pPqXsJxeZcCzMnPNpPgDrpFLIoEAA;

		public int count
		{
			get
			{
				lock (ZidKGWHBNRGkrPUtfnsWyvmTfDeG)
				{
					return VtNunUSCAVIYYIuuPPhFnHvUDnbIA.Count;
				}
			}
		}

		public DualThreadLowLevelInputEventQueue(int P_0, int P_1, int P_2, int P_3)
		{
			VtNunUSCAVIYYIuuPPhFnHvUDnbIA = new LowLevelInputEventQueue(P_0, P_1, P_2, P_3);
			xmtNbbLqaWgIHDTvXGXSvzHGKldn = new LowLevelInputEventQueue(P_0, P_1, P_2, P_3);
			ZidKGWHBNRGkrPUtfnsWyvmTfDeG = new object();
			gvmDpsKpoutzQaLTToGFsILscbqOA = new yMhFXoqVysJaGvmfaoYbHWxhTOpw(ZidKGWHBNRGkrPUtfnsWyvmTfDeG);
		}

		public INewEventWrapper T_CreateEvent()
		{
			gvmDpsKpoutzQaLTToGFsILscbqOA.Lock();
			gvmDpsKpoutzQaLTToGFsILscbqOA.item = xmtNbbLqaWgIHDTvXGXSvzHGKldn.CreateEvent();
			return gvmDpsKpoutzQaLTToGFsILscbqOA;
		}

		public void Update()
		{
			lock (ZidKGWHBNRGkrPUtfnsWyvmTfDeG)
			{
				VtNunUSCAVIYYIuuPPhFnHvUDnbIA.CopyNewEventsFrom(xmtNbbLqaWgIHDTvXGXSvzHGKldn);
			}
		}

		public void Clear()
		{
			lock (ZidKGWHBNRGkrPUtfnsWyvmTfDeG)
			{
				StopProcessingEvents();
				VtNunUSCAVIYYIuuPPhFnHvUDnbIA.Clear();
				xmtNbbLqaWgIHDTvXGXSvzHGKldn.Clear();
			}
		}

		public bool ProcessNewEvents()
		{
			if (yJNFeKgcofEoZPJcnKeFywbkFpydA == 0)
			{
				Update();
				int num = VtNunUSCAVIYYIuuPPhFnHvUDnbIA.FindNextIndex(pPqXsJxeZcCzMnPNpPgDrpFLIoEAA);
				if (num < 0)
				{
					currentEvent = default(LowLevelInputEvent);
					return false;
				}
				yJNFeKgcofEoZPJcnKeFywbkFpydA = num;
				hiXcVIwSkhZYlcexMxphYyxpfSkm = true;
				ydABMeBSPNjZgbdYdaBswkOttmhMb = VtNunUSCAVIYYIuuPPhFnHvUDnbIA.Count;
			}
			if (yJNFeKgcofEoZPJcnKeFywbkFpydA >= ydABMeBSPNjZgbdYdaBswkOttmhMb)
			{
				currentEvent = default(LowLevelInputEvent);
				hiXcVIwSkhZYlcexMxphYyxpfSkm = false;
				yJNFeKgcofEoZPJcnKeFywbkFpydA = 0;
				return false;
			}
			if (VtNunUSCAVIYYIuuPPhFnHvUDnbIA.TryGetNext(yJNFeKgcofEoZPJcnKeFywbkFpydA, out currentEvent))
			{
				pPqXsJxeZcCzMnPNpPgDrpFLIoEAA = currentEvent.GetId();
				yJNFeKgcofEoZPJcnKeFywbkFpydA++;
				return true;
			}
			currentEvent = default(LowLevelInputEvent);
			hiXcVIwSkhZYlcexMxphYyxpfSkm = false;
			yJNFeKgcofEoZPJcnKeFywbkFpydA = 0;
			return false;
		}

		public void StopProcessingEvents()
		{
			hiXcVIwSkhZYlcexMxphYyxpfSkm = false;
			yJNFeKgcofEoZPJcnKeFywbkFpydA = 0;
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
			lock (ZidKGWHBNRGkrPUtfnsWyvmTfDeG)
			{
				lock (other.ZidKGWHBNRGkrPUtfnsWyvmTfDeG)
				{
					VtNunUSCAVIYYIuuPPhFnHvUDnbIA.CopyAllFrom(other.VtNunUSCAVIYYIuuPPhFnHvUDnbIA);
					xmtNbbLqaWgIHDTvXGXSvzHGKldn.CopyAllFrom(other.xmtNbbLqaWgIHDTvXGXSvzHGKldn);
					pPqXsJxeZcCzMnPNpPgDrpFLIoEAA = other.pPqXsJxeZcCzMnPNpPgDrpFLIoEAA;
					hiXcVIwSkhZYlcexMxphYyxpfSkm = other.hiXcVIwSkhZYlcexMxphYyxpfSkm;
					ydABMeBSPNjZgbdYdaBswkOttmhMb = other.ydABMeBSPNjZgbdYdaBswkOttmhMb;
					yJNFeKgcofEoZPJcnKeFywbkFpydA = other.yJNFeKgcofEoZPJcnKeFywbkFpydA;
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
			if (GHeuXvgXNksdPxIKSpYtHDeffyZF)
			{
				return;
			}
			if (disposing)
			{
				lock (ZidKGWHBNRGkrPUtfnsWyvmTfDeG)
				{
					VtNunUSCAVIYYIuuPPhFnHvUDnbIA.Dispose();
					xmtNbbLqaWgIHDTvXGXSvzHGKldn.Dispose();
				}
			}
			GHeuXvgXNksdPxIKSpYtHDeffyZF = true;
		}
	}
}
