using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class LowLevelInputEventQueue : IDisposable
	{
		private LowLevelInputEvent CdJSpSHTUvPMdQXXgjUUfZqNrkI;

		private readonly NativeRingBuffer FzxCwKvrWtjsjnytYJmuFIEdtEC;

		private readonly int bIVKqEWQlcsQuBjQNcfTnhQBcMzH;

		private readonly int HdwDFHEjYnWvNocUPRQUFfWDpFW;

		private readonly int IMVjsgJDDUgoIPWYMCdyoOTQhaG;

		private readonly int gyXGNQgaowErKKOcNUZBCGrVAMHj;

		private readonly int ToxWVXQQLPxjuaFqOGCzdiVpFIc;

		private uint ToLgfCIftjGooEjZckOPcffnRBrZ;

		private bool xRygqjRmTtURDPiwlgMmFcdNBrr;

		public int Count => FzxCwKvrWtjsjnytYJmuFIEdtEC.BytesInBuffer / gyXGNQgaowErKKOcNUZBCGrVAMHj;

		public int Capacity => ToxWVXQQLPxjuaFqOGCzdiVpFIc;

		public LowLevelInputEvent this[int index] => new LowLevelInputEvent(FzxCwKvrWtjsjnytYJmuFIEdtEC.GetPointerFromReadPosition(index * gyXGNQgaowErKKOcNUZBCGrVAMHj), bIVKqEWQlcsQuBjQNcfTnhQBcMzH, HdwDFHEjYnWvNocUPRQUFfWDpFW, IMVjsgJDDUgoIPWYMCdyoOTQhaG);

		public LowLevelInputEventQueue(int capacity, int buttonCount, int axisCount, int hatCount)
		{
			ToxWVXQQLPxjuaFqOGCzdiVpFIc = capacity;
			bIVKqEWQlcsQuBjQNcfTnhQBcMzH = buttonCount;
			HdwDFHEjYnWvNocUPRQUFfWDpFW = axisCount;
			IMVjsgJDDUgoIPWYMCdyoOTQhaG = hatCount;
			gyXGNQgaowErKKOcNUZBCGrVAMHj = LowLevelInputEvent.GetReportSize(buttonCount, axisCount, hatCount);
			FzxCwKvrWtjsjnytYJmuFIEdtEC = new NativeRingBuffer(ToxWVXQQLPxjuaFqOGCzdiVpFIc * gyXGNQgaowErKKOcNUZBCGrVAMHj);
			CdJSpSHTUvPMdQXXgjUUfZqNrkI = new LowLevelInputEvent(IntPtr.Zero, bIVKqEWQlcsQuBjQNcfTnhQBcMzH, HdwDFHEjYnWvNocUPRQUFfWDpFW, hatCount);
		}

		public LowLevelInputEvent CreateEvent()
		{
			uint passId;
			IntPtr buffer = FzxCwKvrWtjsjnytYJmuFIEdtEC.Allocate(gyXGNQgaowErKKOcNUZBCGrVAMHj, zeroFill: false, out passId);
			LowLevelInputEvent result = new LowLevelInputEvent(buffer, bIVKqEWQlcsQuBjQNcfTnhQBcMzH, HdwDFHEjYnWvNocUPRQUFfWDpFW, IMVjsgJDDUgoIPWYMCdyoOTQhaG);
			result.SetId(ToLgfCIftjGooEjZckOPcffnRBrZ = MiscTools.Tick(ToLgfCIftjGooEjZckOPcffnRBrZ));
			return result;
		}

		public int FindNextIndex(uint id)
		{
			int num = FzxCwKvrWtjsjnytYJmuFIEdtEC.BytesInBuffer / gyXGNQgaowErKKOcNUZBCGrVAMHj;
			if (num == 0)
			{
				goto IL_0016;
			}
			CdJSpSHTUvPMdQXXgjUUfZqNrkI._buffer = FzxCwKvrWtjsjnytYJmuFIEdtEC.GetPointerFromReadPosition(0);
			uint num2 = CdJSpSHTUvPMdQXXgjUUfZqNrkI.GetId();
			int num3 = -1473520924;
			goto IL_001b;
			IL_001b:
			int num4 = default(int);
			int num5 = default(int);
			while (true)
			{
				switch (num3 ^ -1473520923)
				{
				case 0:
					break;
				case 3:
					return num4;
				case 7:
					if (!MiscTools.IsTickNewer(num2, id))
					{
						num2 = MiscTools.Tick(num2);
						num4++;
						num3 = -1473520921;
						continue;
					}
					goto case 3;
				case 6:
					return -1;
				case 1:
					num5 = 0;
					if (MiscTools.IsTickNewer(id, num2))
					{
						num5 = (int)MiscTools.TickDifference(id, num2) + 1;
						num2 = MiscTools.Tick(id);
						num3 = -1473520928;
						continue;
					}
					goto case 5;
				case 4:
					num3 = -1473520921;
					continue;
				case 5:
					num4 = num5;
					num3 = -1473520927;
					continue;
				default:
					if (num4 >= num)
					{
						return -1;
					}
					goto case 7;
				}
				break;
			}
			goto IL_0016;
			IL_0016:
			num3 = -1473520925;
			goto IL_001b;
		}

		public bool TryGetNext(int index, out LowLevelInputEvent @event)
		{
			if (index < 0 || index >= FzxCwKvrWtjsjnytYJmuFIEdtEC.BytesInBuffer / gyXGNQgaowErKKOcNUZBCGrVAMHj)
			{
				@event = default(LowLevelInputEvent);
				return false;
			}
			@event = new LowLevelInputEvent(FzxCwKvrWtjsjnytYJmuFIEdtEC.GetPointerFromReadPosition(index * gyXGNQgaowErKKOcNUZBCGrVAMHj), bIVKqEWQlcsQuBjQNcfTnhQBcMzH, HdwDFHEjYnWvNocUPRQUFfWDpFW, IMVjsgJDDUgoIPWYMCdyoOTQhaG);
			return true;
		}

		public void Clear()
		{
			FzxCwKvrWtjsjnytYJmuFIEdtEC.Reset();
		}

		public void CopyAllFrom(LowLevelInputEventQueue other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			FzxCwKvrWtjsjnytYJmuFIEdtEC.CopyFrom(other.FzxCwKvrWtjsjnytYJmuFIEdtEC);
			ToLgfCIftjGooEjZckOPcffnRBrZ = other.ToLgfCIftjGooEjZckOPcffnRBrZ;
		}

		public void CopyNewEventsFrom(LowLevelInputEventQueue other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			int num4 = default(int);
			int num5 = default(int);
			int num3 = default(int);
			while (true)
			{
				int count = Count;
				int count2 = other.Count;
				int num;
				int num2;
				if (count2 == 0)
				{
					num = -1051002536;
					num2 = num;
				}
				else
				{
					num = -1051002530;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1051002536)
					{
					case 2:
						num = -1051002533;
						continue;
					case 3:
						break;
					case 7:
						num4 = count2 - num5;
						num = -1051002541;
						continue;
					case 4:
						return;
					case 8:
						return;
					case 0:
						return;
					case 1:
					{
						uint passId;
						IntPtr buffer = FzxCwKvrWtjsjnytYJmuFIEdtEC.Allocate(gyXGNQgaowErKKOcNUZBCGrVAMHj, zeroFill: false, out passId);
						other.FzxCwKvrWtjsjnytYJmuFIEdtEC.RandomRead(buffer, gyXGNQgaowErKKOcNUZBCGrVAMHj, gyXGNQgaowErKKOcNUZBCGrVAMHj, other.FzxCwKvrWtjsjnytYJmuFIEdtEC.GetOffsetFromReadPosition((num5 + num3) * gyXGNQgaowErKKOcNUZBCGrVAMHj));
						num3++;
						num = -1051002531;
						continue;
					}
					case 12:
						CopyAllFrom(other);
						num = -1051002544;
						continue;
					case 10:
						num3 = 0;
						num = -1051002531;
						continue;
					case 6:
					{
						int num7;
						if (count == 0)
						{
							num = -1051002540;
							num7 = num;
						}
						else
						{
							num = -1051002539;
							num7 = num;
						}
						continue;
					}
					case 9:
					{
						int num6;
						if (num5 >= 0)
						{
							num = -1051002529;
							num6 = num;
						}
						else
						{
							num = -1051002532;
							num6 = num;
						}
						continue;
					}
					case 13:
					{
						uint id = new LowLevelInputEvent(FzxCwKvrWtjsjnytYJmuFIEdtEC.GetPointerFromReadPosition((count - 1) * gyXGNQgaowErKKOcNUZBCGrVAMHj), bIVKqEWQlcsQuBjQNcfTnhQBcMzH, HdwDFHEjYnWvNocUPRQUFfWDpFW, IMVjsgJDDUgoIPWYMCdyoOTQhaG).GetId();
						num5 = other.FindNextIndex(id);
						num = -1051002543;
						continue;
					}
					case 11:
						if (num4 == 0)
						{
							return;
						}
						goto case 10;
					default:
						if (num3 >= num4)
						{
							ToLgfCIftjGooEjZckOPcffnRBrZ = other.ToLgfCIftjGooEjZckOPcffnRBrZ;
							return;
						}
						goto case 1;
					}
					break;
				}
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			while (true)
			{
				int num = -682845065;
				while (true)
				{
					switch (num ^ -682845067)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						goto IL_0025;
					case 1:
						return;
					}
					break;
					IL_0025:
					GC.SuppressFinalize(this);
					num = -682845068;
				}
			}
		}

		~LowLevelInputEventQueue()
		{
			Dispose(disposing: false);
		}

		protected void Dispose(bool disposing)
		{
			if (xRygqjRmTtURDPiwlgMmFcdNBrr)
			{
				return;
			}
			while (disposing)
			{
				FzxCwKvrWtjsjnytYJmuFIEdtEC.Dispose();
				int num = 496138823;
				while (true)
				{
					switch (num ^ 0x1D927A45)
					{
					case 0:
						num = 496138820;
						continue;
					case 1:
						break;
					default:
						goto end_IL_0027;
					}
					break;
				}
				continue;
				end_IL_0027:
				break;
			}
			xRygqjRmTtURDPiwlgMmFcdNBrr = true;
		}
	}
}
