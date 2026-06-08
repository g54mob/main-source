using System;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class DualThreadLowLevelInputEventQueue : IDisposable
	{
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		public interface INewEventWrapper : IDisposable
		{
			LowLevelInputEvent Event { get; set; }
		}

		private class FcoMuXPOtHznKvpBWCUpFVSEMiAc : LockedObject<LowLevelInputEvent>, IDisposable, INewEventWrapper
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

			public FcoMuXPOtHznKvpBWCUpFVSEMiAc(object lockObject)
				: base(lockObject)
			{
			}
		}

		private readonly LowLevelInputEventQueue NsBEKFfysKINrowdrDjyDjoBiwpz;

		private readonly LowLevelInputEventQueue cySqMZAJXUybjwpZfboJpogyryU;

		private readonly object QMNgXEuYlRNduTRcWtCRWmPqLrN;

		private uint fUTToNnKgEwBBOhuXjYiQoCrylr;

		private bool VZBLVnsijsEypCEMigwLRMtkZPE;

		private int jKKqrUjUfXiTJpWpOWdSLCyAchb;

		private int yAEeVuMuNrEIIMkksCFsfbyNisz;

		private FcoMuXPOtHznKvpBWCUpFVSEMiAc xLbkMMpmTsjTulvcDccbMOiSSfH;

		public LowLevelInputEvent currentEvent;

		private bool xRygqjRmTtURDPiwlgMmFcdNBrr;

		public uint lastProcessedEventId => fUTToNnKgEwBBOhuXjYiQoCrylr;

		public int count
		{
			get
			{
				lock (QMNgXEuYlRNduTRcWtCRWmPqLrN)
				{
					return NsBEKFfysKINrowdrDjyDjoBiwpz.Count;
				}
			}
		}

		public DualThreadLowLevelInputEventQueue(int capacity, int buttonCount, int axisCount, int hatCount)
		{
			NsBEKFfysKINrowdrDjyDjoBiwpz = new LowLevelInputEventQueue(capacity, buttonCount, axisCount, hatCount);
			cySqMZAJXUybjwpZfboJpogyryU = new LowLevelInputEventQueue(capacity, buttonCount, axisCount, hatCount);
			QMNgXEuYlRNduTRcWtCRWmPqLrN = new object();
			xLbkMMpmTsjTulvcDccbMOiSSfH = new FcoMuXPOtHznKvpBWCUpFVSEMiAc(QMNgXEuYlRNduTRcWtCRWmPqLrN);
		}

		public INewEventWrapper T_CreateEvent()
		{
			xLbkMMpmTsjTulvcDccbMOiSSfH.Lock();
			xLbkMMpmTsjTulvcDccbMOiSSfH.item = cySqMZAJXUybjwpZfboJpogyryU.CreateEvent();
			return xLbkMMpmTsjTulvcDccbMOiSSfH;
		}

		public void Update()
		{
			lock (QMNgXEuYlRNduTRcWtCRWmPqLrN)
			{
				NsBEKFfysKINrowdrDjyDjoBiwpz.CopyNewEventsFrom(cySqMZAJXUybjwpZfboJpogyryU);
			}
		}

		public void Clear()
		{
			lock (QMNgXEuYlRNduTRcWtCRWmPqLrN)
			{
				StopProcessingEvents();
				while (true)
				{
					int num = 1280535674;
					while (true)
					{
						switch (num ^ 0x4C536C78)
						{
						case 0:
							break;
						default:
							return;
						case 2:
							goto IL_0031;
						case 1:
							return;
						}
						break;
						IL_0031:
						NsBEKFfysKINrowdrDjyDjoBiwpz.Clear();
						cySqMZAJXUybjwpZfboJpogyryU.Clear();
						num = 1280535673;
					}
				}
			}
		}

		public bool ProcessNewEvents()
		{
			int num = default(int);
			if (yAEeVuMuNrEIIMkksCFsfbyNisz == 0)
			{
				Update();
				num = NsBEKFfysKINrowdrDjyDjoBiwpz.FindNextIndex(fUTToNnKgEwBBOhuXjYiQoCrylr);
				goto IL_0020;
			}
			goto IL_0085;
			IL_0085:
			int num2;
			if (yAEeVuMuNrEIIMkksCFsfbyNisz >= jKKqrUjUfXiTJpWpOWdSLCyAchb)
			{
				currentEvent = default(LowLevelInputEvent);
				VZBLVnsijsEypCEMigwLRMtkZPE = false;
				yAEeVuMuNrEIIMkksCFsfbyNisz = 0;
				num2 = -102792958;
				goto IL_0025;
			}
			if (NsBEKFfysKINrowdrDjyDjoBiwpz.TryGetNext(yAEeVuMuNrEIIMkksCFsfbyNisz, out currentEvent))
			{
				fUTToNnKgEwBBOhuXjYiQoCrylr = currentEvent.GetId();
				yAEeVuMuNrEIIMkksCFsfbyNisz++;
				return true;
			}
			currentEvent = default(LowLevelInputEvent);
			VZBLVnsijsEypCEMigwLRMtkZPE = false;
			yAEeVuMuNrEIIMkksCFsfbyNisz = 0;
			return false;
			IL_0020:
			num2 = -102792960;
			goto IL_0025;
			IL_0025:
			while (true)
			{
				switch (num2 ^ -102792958)
				{
				case 3:
					break;
				case 2:
					goto IL_0046;
				case 1:
					currentEvent = default(LowLevelInputEvent);
					return false;
				case 4:
					goto IL_0085;
				default:
					return false;
				}
				break;
				IL_0046:
				if (num < 0)
				{
					num2 = -102792957;
					continue;
				}
				yAEeVuMuNrEIIMkksCFsfbyNisz = num;
				VZBLVnsijsEypCEMigwLRMtkZPE = true;
				jKKqrUjUfXiTJpWpOWdSLCyAchb = NsBEKFfysKINrowdrDjyDjoBiwpz.Count;
				num2 = -102792954;
			}
			goto IL_0020;
		}

		public void StopProcessingEvents()
		{
			VZBLVnsijsEypCEMigwLRMtkZPE = false;
			yAEeVuMuNrEIIMkksCFsfbyNisz = 0;
		}

		public void ImportAll(DualThreadLowLevelInputEventQueue other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			while (true)
			{
				int num;
				int num2;
				if (other == this)
				{
					num = -1110157416;
					num2 = num;
				}
				else
				{
					num = -1110157413;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1110157413)
					{
					case 2:
						goto IL_000e;
					case 1:
						break;
					case 3:
						return;
					default:
						lock (QMNgXEuYlRNduTRcWtCRWmPqLrN)
						{
							lock (other.QMNgXEuYlRNduTRcWtCRWmPqLrN)
							{
								NsBEKFfysKINrowdrDjyDjoBiwpz.CopyAllFrom(other.NsBEKFfysKINrowdrDjyDjoBiwpz);
								cySqMZAJXUybjwpZfboJpogyryU.CopyAllFrom(other.cySqMZAJXUybjwpZfboJpogyryU);
								fUTToNnKgEwBBOhuXjYiQoCrylr = other.fUTToNnKgEwBBOhuXjYiQoCrylr;
								VZBLVnsijsEypCEMigwLRMtkZPE = other.VZBLVnsijsEypCEMigwLRMtkZPE;
								jKKqrUjUfXiTJpWpOWdSLCyAchb = other.jKKqrUjUfXiTJpWpOWdSLCyAchb;
								yAEeVuMuNrEIIMkksCFsfbyNisz = other.yAEeVuMuNrEIIMkksCFsfbyNisz;
								return;
							}
						}
					}
					break;
					IL_000e:
					num = -1110157414;
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
			if (xRygqjRmTtURDPiwlgMmFcdNBrr)
			{
				return;
			}
			if (disposing)
			{
				lock (QMNgXEuYlRNduTRcWtCRWmPqLrN)
				{
					NsBEKFfysKINrowdrDjyDjoBiwpz.Dispose();
					cySqMZAJXUybjwpZfboJpogyryU.Dispose();
				}
			}
			xRygqjRmTtURDPiwlgMmFcdNBrr = true;
		}
	}
}
