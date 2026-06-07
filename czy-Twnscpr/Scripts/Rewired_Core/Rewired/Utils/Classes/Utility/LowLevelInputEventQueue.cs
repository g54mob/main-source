using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation]
	[CustomClassObfuscation]
	internal class LowLevelInputEventQueue : IDisposable
	{
		private LowLevelInputEvent dlrCdoRmIobSbJVdauUhpTwHXvWR;

		private readonly NativeRingBuffer agTZZUvNowzCoqNBGPPqpndjMaT;

		private readonly int MPfcFHBAqdEVRKAwFPIsRPrJOKNM;

		private readonly int qKQydGYzZiFdavuuXkrbxuGVdee;

		private readonly int zUjGnWTEZHttaOsuYYZUSwPEsuh;

		private readonly int FGjAaReifxmyrELQePiuGcMyVIbY;

		private readonly int ckVfvSAHJIaaTnVdYdQGXoorBaQ;

		private uint mFdHSHbUgcCnXuqnkXtmJTKDlZZ;

		private bool CGIHxiLUHgNfmOBOdViTruIZZWF;

		public int Count => 0;

		public int Capacity => 0;

		public LowLevelInputEvent Item => default(LowLevelInputEvent);

		public LowLevelInputEventQueue(int capacity, int buttonCount, int axisCount, int hatCount)
		{
		}

		public LowLevelInputEvent CreateEvent()
		{
			return default(LowLevelInputEvent);
		}

		public int FindNextIndex(uint id)
		{
			return 0;
		}

		public bool TryGetNext(int index, out LowLevelInputEvent @event)
		{
			@event = default(LowLevelInputEvent);
			return false;
		}

		public void Clear()
		{
		}

		public void CopyAllFrom(LowLevelInputEventQueue other)
		{
		}

		public void CopyNewEventsFrom(LowLevelInputEventQueue other)
		{
		}

		public void Dispose()
		{
		}

		~LowLevelInputEventQueue()
		{
		}

		protected void Dispose(bool disposing)
		{
		}
	}
}
