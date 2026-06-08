using System;
using System.Runtime.InteropServices;

namespace Rewired.Utils.Classes.Data
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class NativeMemoryBlock : IDisposable
	{
		private int RGjqcUZOVBhXRGhqYQtyapwJoehc;

		private uint PaiShPkxisTnNoFemPBFzEDsTGM;

		private IntPtr spPTPZKrjhrtklGpCciZrlFZGtn;

		private bool xRygqjRmTtURDPiwlgMmFcdNBrr;

		public uint size => PaiShPkxisTnNoFemPBFzEDsTGM;

		public NativeMemoryBlock(uint size)
		{
			while (true)
			{
				switch (0x64BCE19C ^ 0x64BCE19E)
				{
				case 0:
					continue;
				case 2:
					if (size == 0)
					{
						throw new Exception("size must be > 0!");
					}
					break;
				}
				break;
			}
			PaiShPkxisTnNoFemPBFzEDsTGM = size;
			RGjqcUZOVBhXRGhqYQtyapwJoehc = 0;
			try
			{
				spPTPZKrjhrtklGpCciZrlFZGtn = Marshal.AllocHGlobal((int)size);
				if (spPTPZKrjhrtklGpCciZrlFZGtn == IntPtr.Zero)
				{
					throw new Exception("Could not allocate native memory.");
				}
			}
			catch
			{
				throw;
			}
		}

		public IntPtr Allocate(uint bytes, IntPtr ptrToData)
		{
			if (xRygqjRmTtURDPiwlgMmFcdNBrr)
			{
				goto IL_000b;
			}
			if (bytes == 0)
			{
				return IntPtr.Zero;
			}
			if (bytes > PaiShPkxisTnNoFemPBFzEDsTGM)
			{
				return IntPtr.Zero;
			}
			int num;
			int num2;
			if (RGjqcUZOVBhXRGhqYQtyapwJoehc + bytes < PaiShPkxisTnNoFemPBFzEDsTGM)
			{
				num = 1070146434;
				num2 = num;
			}
			else
			{
				num = 1070146436;
				num2 = num;
			}
			goto IL_0010;
			IL_0010:
			IntPtr intPtr = default(IntPtr);
			while (true)
			{
				switch (num ^ 0x3FC92387)
				{
				case 0:
					break;
				case 5:
				{
					intPtr = new IntPtr(spPTPZKrjhrtklGpCciZrlFZGtn.ToInt64() + RGjqcUZOVBhXRGhqYQtyapwJoehc);
					int num3;
					if (!(ptrToData != IntPtr.Zero))
					{
						num = 1070146438;
						num3 = num;
					}
					else
					{
						num = 1070146437;
						num3 = num;
					}
					continue;
				}
				case 3:
					RGjqcUZOVBhXRGhqYQtyapwJoehc = 0;
					num = 1070146434;
					continue;
				case 2:
					NativeTools.CopyMemory(ptrToData, intPtr, 0, 0, (int)bytes);
					num = 1070146438;
					continue;
				case 4:
					return IntPtr.Zero;
				default:
					RGjqcUZOVBhXRGhqYQtyapwJoehc += (int)bytes;
					return intPtr;
				}
				break;
			}
			goto IL_000b;
			IL_000b:
			num = 1070146435;
			goto IL_0010;
		}

		public IntPtr Allocate(uint bytes)
		{
			return Allocate(bytes, IntPtr.Zero);
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		~NativeMemoryBlock()
		{
			Dispose(disposing: false);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (xRygqjRmTtURDPiwlgMmFcdNBrr)
			{
				return;
			}
			while (true)
			{
				xRygqjRmTtURDPiwlgMmFcdNBrr = true;
				int num;
				int num2;
				if (!(spPTPZKrjhrtklGpCciZrlFZGtn != IntPtr.Zero))
				{
					num = -1233828097;
					num2 = num;
				}
				else
				{
					num = -1233828100;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1233828100)
					{
					case 2:
						num = -1233828099;
						continue;
					default:
						return;
					case 1:
						break;
					case 0:
						Marshal.FreeHGlobal(spPTPZKrjhrtklGpCciZrlFZGtn);
						spPTPZKrjhrtklGpCciZrlFZGtn = IntPtr.Zero;
						num = -1233828097;
						continue;
					case 3:
						return;
					}
					break;
				}
			}
		}
	}
}
