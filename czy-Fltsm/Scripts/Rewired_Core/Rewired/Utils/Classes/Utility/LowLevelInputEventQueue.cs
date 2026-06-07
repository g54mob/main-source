using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class LowLevelInputEventQueue : IDisposable
	{
		private LowLevelInputEvent hsuifBGBSUAcYGCrDHHFhpYAcfXH;

		private readonly NativeRingBuffer VkfxotCnpdVnAqwbxBvvVzTNHvbV;

		private readonly int SvsfvEdcMSLBJiufNsjOFxiPEyHGA;

		private readonly int PoYxfhyCRwOGFlshWzKZiJOrGRxiA;

		private readonly int BdaVWRrTZjHAduwkWelqVjMlAkIE;

		private readonly int itgWhQUEvcktSuggGoRANzcEoUiL;

		private readonly int oLAaKEKOjkaVrjzjLeDrEPkWmdLP;

		private uint DmwFEcEYCwhVWwaQLthKvumTXPAJ;

		private bool hmBJyCweLFErRSzknddxXDNhcqov;

		public int Count => VkfxotCnpdVnAqwbxBvvVzTNHvbV.BytesInBuffer / itgWhQUEvcktSuggGoRANzcEoUiL;

		public int Capacity => oLAaKEKOjkaVrjzjLeDrEPkWmdLP;

		public int CapacityBytes => oLAaKEKOjkaVrjzjLeDrEPkWmdLP * itgWhQUEvcktSuggGoRANzcEoUiL;

		public LowLevelInputEvent this[int index] => new LowLevelInputEvent(VkfxotCnpdVnAqwbxBvvVzTNHvbV.GetPointerFromReadPosition(index * itgWhQUEvcktSuggGoRANzcEoUiL), SvsfvEdcMSLBJiufNsjOFxiPEyHGA, PoYxfhyCRwOGFlshWzKZiJOrGRxiA, BdaVWRrTZjHAduwkWelqVjMlAkIE);

		public LowLevelInputEventQueue(int P_0, int P_1, int P_2, int P_3)
		{
			oLAaKEKOjkaVrjzjLeDrEPkWmdLP = P_0;
			SvsfvEdcMSLBJiufNsjOFxiPEyHGA = P_1;
			PoYxfhyCRwOGFlshWzKZiJOrGRxiA = P_2;
			BdaVWRrTZjHAduwkWelqVjMlAkIE = P_3;
			itgWhQUEvcktSuggGoRANzcEoUiL = LowLevelInputEvent.GetReportSize(P_1, P_2, P_3);
			VkfxotCnpdVnAqwbxBvvVzTNHvbV = new NativeRingBuffer(oLAaKEKOjkaVrjzjLeDrEPkWmdLP * itgWhQUEvcktSuggGoRANzcEoUiL);
			hsuifBGBSUAcYGCrDHHFhpYAcfXH = new LowLevelInputEvent(IntPtr.Zero, SvsfvEdcMSLBJiufNsjOFxiPEyHGA, PoYxfhyCRwOGFlshWzKZiJOrGRxiA, P_3);
		}

		public LowLevelInputEvent CreateEvent()
		{
			uint passId;
			IntPtr intPtr = VkfxotCnpdVnAqwbxBvvVzTNHvbV.Allocate(itgWhQUEvcktSuggGoRANzcEoUiL, zeroFill: false, out passId);
			LowLevelInputEvent result = new LowLevelInputEvent(intPtr, SvsfvEdcMSLBJiufNsjOFxiPEyHGA, PoYxfhyCRwOGFlshWzKZiJOrGRxiA, BdaVWRrTZjHAduwkWelqVjMlAkIE);
			result.SetId(DmwFEcEYCwhVWwaQLthKvumTXPAJ = MiscTools.Tick(DmwFEcEYCwhVWwaQLthKvumTXPAJ));
			return result;
		}

		public int FindNextIndex(uint id)
		{
			int num = VkfxotCnpdVnAqwbxBvvVzTNHvbV.BytesInBuffer / itgWhQUEvcktSuggGoRANzcEoUiL;
			if (num == 0)
			{
				return -1;
			}
			hsuifBGBSUAcYGCrDHHFhpYAcfXH._buffer = VkfxotCnpdVnAqwbxBvvVzTNHvbV.GetPointerFromReadPosition(0);
			uint num2 = hsuifBGBSUAcYGCrDHHFhpYAcfXH.GetId();
			int num3 = 0;
			if (MiscTools.IsTickNewer(id, num2))
			{
				num3 = (int)MiscTools.TickDifference(id, num2) + 1;
				num2 = MiscTools.Tick(id);
			}
			for (int i = num3; i < num; i++)
			{
				if (!MiscTools.IsTickNewer(num2, id))
				{
					num2 = MiscTools.Tick(num2);
					continue;
				}
				return i;
			}
			return -1;
		}

		public bool TryGetNext(int index, out LowLevelInputEvent @event)
		{
			if (index < 0 || index >= VkfxotCnpdVnAqwbxBvvVzTNHvbV.BytesInBuffer / itgWhQUEvcktSuggGoRANzcEoUiL)
			{
				@event = default(LowLevelInputEvent);
				return false;
			}
			@event = new LowLevelInputEvent(VkfxotCnpdVnAqwbxBvvVzTNHvbV.GetPointerFromReadPosition(index * itgWhQUEvcktSuggGoRANzcEoUiL), SvsfvEdcMSLBJiufNsjOFxiPEyHGA, PoYxfhyCRwOGFlshWzKZiJOrGRxiA, BdaVWRrTZjHAduwkWelqVjMlAkIE);
			return true;
		}

		public void Clear()
		{
			VkfxotCnpdVnAqwbxBvvVzTNHvbV.Reset();
		}

		public void CopyAllFrom(LowLevelInputEventQueue other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			VkfxotCnpdVnAqwbxBvvVzTNHvbV.CopyFrom(other.VkfxotCnpdVnAqwbxBvvVzTNHvbV);
			DmwFEcEYCwhVWwaQLthKvumTXPAJ = other.DmwFEcEYCwhVWwaQLthKvumTXPAJ;
		}

		public void CopyNewEventsFrom(LowLevelInputEventQueue other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			int count = Count;
			int count2 = other.Count;
			if (count2 == 0)
			{
				return;
			}
			if (count == 0)
			{
				CopyAllFrom(other);
				return;
			}
			uint id = new LowLevelInputEvent(VkfxotCnpdVnAqwbxBvvVzTNHvbV.GetPointerFromReadPosition((count - 1) * itgWhQUEvcktSuggGoRANzcEoUiL), SvsfvEdcMSLBJiufNsjOFxiPEyHGA, PoYxfhyCRwOGFlshWzKZiJOrGRxiA, BdaVWRrTZjHAduwkWelqVjMlAkIE).GetId();
			int num = other.FindNextIndex(id);
			if (num < 0)
			{
				return;
			}
			int num2 = count2 - num;
			if (num2 != 0)
			{
				for (int i = 0; i < num2; i++)
				{
					uint passId;
					IntPtr buffer = VkfxotCnpdVnAqwbxBvvVzTNHvbV.Allocate(itgWhQUEvcktSuggGoRANzcEoUiL, zeroFill: false, out passId);
					other.VkfxotCnpdVnAqwbxBvvVzTNHvbV.RandomRead(buffer, itgWhQUEvcktSuggGoRANzcEoUiL, itgWhQUEvcktSuggGoRANzcEoUiL, other.VkfxotCnpdVnAqwbxBvvVzTNHvbV.GetOffsetFromReadPosition((num + i) * itgWhQUEvcktSuggGoRANzcEoUiL));
				}
				DmwFEcEYCwhVWwaQLthKvumTXPAJ = other.DmwFEcEYCwhVWwaQLthKvumTXPAJ;
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

		~LowLevelInputEventQueue()
		{
			Dispose(disposing: false);
		}

		protected void Dispose(bool disposing)
		{
			if (!hmBJyCweLFErRSzknddxXDNhcqov)
			{
				if (disposing)
				{
					VkfxotCnpdVnAqwbxBvvVzTNHvbV.Dispose();
				}
				hmBJyCweLFErRSzknddxXDNhcqov = true;
			}
		}
	}
}
