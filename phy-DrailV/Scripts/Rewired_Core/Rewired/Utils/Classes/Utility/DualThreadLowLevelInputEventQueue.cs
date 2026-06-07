using System;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class DualThreadLowLevelInputEventQueue : IDisposable
	{
		private class WJvCrhiNiABAhjDxBkQNTSUJpPhJB : LockedObject<LowLevelInputEvent>, IDisposable, INewEventWrapper
		{
			public LowLevelInputEvent Event
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

			public WJvCrhiNiABAhjDxBkQNTSUJpPhJB(object P_0)
				: base(P_0)
			{
			}
		}

		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		public interface INewEventWrapper : IDisposable
		{
			LowLevelInputEvent Event { get; set; }
		}

		private readonly LowLevelInputEventQueue MwGJPfsahVhmAcEZXShKcxcJEPEIA;

		private readonly LowLevelInputEventQueue loDWBxUNMFdAYGxfZZijiNeRDNfo;

		private readonly object TaAIOaJykUTGLFxIypKpkBNPROiwA;

		private uint wqWMCzxGXVBJmsmEfIrGaJAWwVSqA;

		private bool OlYQvBywpljWMyEmYqobOeEHegbs;

		private int aGNdTizNLMZeeDvcaGZcYtshBnMI;

		private int vTZfQGGYiehYlqIlWCvCquUoPNMD;

		private WJvCrhiNiABAhjDxBkQNTSUJpPhJB wHeCPupvGtakLbJIpLiZvJsbJAmuA;

		public LowLevelInputEvent currentEvent;

		private bool wFtxnVROnubhehGUBaPWAtQsiPAD;

		public uint lastProcessedEventId => wqWMCzxGXVBJmsmEfIrGaJAWwVSqA;

		public int count
		{
			get
			{
				lock (TaAIOaJykUTGLFxIypKpkBNPROiwA)
				{
					return MwGJPfsahVhmAcEZXShKcxcJEPEIA.Count;
				}
			}
		}

		public DualThreadLowLevelInputEventQueue(int P_0, int P_1, int P_2, int P_3)
		{
			MwGJPfsahVhmAcEZXShKcxcJEPEIA = new LowLevelInputEventQueue(P_0, P_1, P_2, P_3);
			loDWBxUNMFdAYGxfZZijiNeRDNfo = new LowLevelInputEventQueue(P_0, P_1, P_2, P_3);
			TaAIOaJykUTGLFxIypKpkBNPROiwA = new object();
			wHeCPupvGtakLbJIpLiZvJsbJAmuA = new WJvCrhiNiABAhjDxBkQNTSUJpPhJB(TaAIOaJykUTGLFxIypKpkBNPROiwA);
		}

		public INewEventWrapper T_CreateEvent()
		{
			wHeCPupvGtakLbJIpLiZvJsbJAmuA.Lock();
			wHeCPupvGtakLbJIpLiZvJsbJAmuA.item = loDWBxUNMFdAYGxfZZijiNeRDNfo.CreateEvent();
			return wHeCPupvGtakLbJIpLiZvJsbJAmuA;
		}

		public void Update()
		{
			lock (TaAIOaJykUTGLFxIypKpkBNPROiwA)
			{
				MwGJPfsahVhmAcEZXShKcxcJEPEIA.CopyNewEventsFrom(loDWBxUNMFdAYGxfZZijiNeRDNfo);
			}
		}

		public void Clear()
		{
			lock (TaAIOaJykUTGLFxIypKpkBNPROiwA)
			{
				StopProcessingEvents();
				MwGJPfsahVhmAcEZXShKcxcJEPEIA.Clear();
				loDWBxUNMFdAYGxfZZijiNeRDNfo.Clear();
			}
		}

		public bool ProcessNewEvents()
		{
			if (vTZfQGGYiehYlqIlWCvCquUoPNMD == 0)
			{
				Update();
				int num = MwGJPfsahVhmAcEZXShKcxcJEPEIA.FindNextIndex(wqWMCzxGXVBJmsmEfIrGaJAWwVSqA);
				if (num < 0)
				{
					currentEvent = default(LowLevelInputEvent);
					return false;
				}
				vTZfQGGYiehYlqIlWCvCquUoPNMD = num;
				OlYQvBywpljWMyEmYqobOeEHegbs = true;
				aGNdTizNLMZeeDvcaGZcYtshBnMI = MwGJPfsahVhmAcEZXShKcxcJEPEIA.Count;
			}
			if (vTZfQGGYiehYlqIlWCvCquUoPNMD >= aGNdTizNLMZeeDvcaGZcYtshBnMI)
			{
				currentEvent = default(LowLevelInputEvent);
				OlYQvBywpljWMyEmYqobOeEHegbs = false;
				vTZfQGGYiehYlqIlWCvCquUoPNMD = 0;
				return false;
			}
			if (MwGJPfsahVhmAcEZXShKcxcJEPEIA.TryGetNext(vTZfQGGYiehYlqIlWCvCquUoPNMD, out currentEvent))
			{
				wqWMCzxGXVBJmsmEfIrGaJAWwVSqA = currentEvent.GetId();
				vTZfQGGYiehYlqIlWCvCquUoPNMD++;
				return true;
			}
			currentEvent = default(LowLevelInputEvent);
			OlYQvBywpljWMyEmYqobOeEHegbs = false;
			vTZfQGGYiehYlqIlWCvCquUoPNMD = 0;
			return false;
		}

		public void StopProcessingEvents()
		{
			OlYQvBywpljWMyEmYqobOeEHegbs = false;
			vTZfQGGYiehYlqIlWCvCquUoPNMD = 0;
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
			lock (TaAIOaJykUTGLFxIypKpkBNPROiwA)
			{
				lock (other.TaAIOaJykUTGLFxIypKpkBNPROiwA)
				{
					MwGJPfsahVhmAcEZXShKcxcJEPEIA.CopyAllFrom(other.MwGJPfsahVhmAcEZXShKcxcJEPEIA);
					loDWBxUNMFdAYGxfZZijiNeRDNfo.CopyAllFrom(other.loDWBxUNMFdAYGxfZZijiNeRDNfo);
					wqWMCzxGXVBJmsmEfIrGaJAWwVSqA = other.wqWMCzxGXVBJmsmEfIrGaJAWwVSqA;
					OlYQvBywpljWMyEmYqobOeEHegbs = other.OlYQvBywpljWMyEmYqobOeEHegbs;
					aGNdTizNLMZeeDvcaGZcYtshBnMI = other.aGNdTizNLMZeeDvcaGZcYtshBnMI;
					vTZfQGGYiehYlqIlWCvCquUoPNMD = other.vTZfQGGYiehYlqIlWCvCquUoPNMD;
				}
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		~DualThreadLowLevelInputEventQueue()
		{
			Dispose(disposing: false);
		}

		protected void Dispose(bool disposing)
		{
			if (wFtxnVROnubhehGUBaPWAtQsiPAD)
			{
				return;
			}
			if (disposing)
			{
				lock (TaAIOaJykUTGLFxIypKpkBNPROiwA)
				{
					MwGJPfsahVhmAcEZXShKcxcJEPEIA.Dispose();
					loDWBxUNMFdAYGxfZZijiNeRDNfo.Dispose();
				}
			}
			wFtxnVROnubhehGUBaPWAtQsiPAD = true;
		}
	}
}
