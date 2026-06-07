using System;

namespace Rewired.Utils.Classes.Data
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class NativeRingBuffer : IDisposable
	{
		private readonly NativeBuffer FxqaDQtsGTghuAnWMgqtsdCZKIZGb;

		private readonly int sePoPlKGxGKaJDGGOLjZQdGAvDPK;

		private long qufarkKblaVBAusMwbeTJTaCEfmS;

		private long oERGRivAPuOKROrdMplxAejujNGU;

		private int ObVfFjOQtPAMGUQFaQhECLnrgoKkA;

		private bool oinKDlkgKQQNTbLiIpRwRCrQymUh;

		private uint NUoSZiLEnjAkaaEogpoyiGoyJuCM;

		private bool IOotYweRBstAacHyGjTroISijmnH;

		public int Capacity => sePoPlKGxGKaJDGGOLjZQdGAvDPK;

		public int BytesInBuffer => ObVfFjOQtPAMGUQFaQhECLnrgoKkA;

		public bool BufferOverrun => oinKDlkgKQQNTbLiIpRwRCrQymUh;

		public int ReadPosition => (int)oERGRivAPuOKROrdMplxAejujNGU;

		public long WritePosition => qufarkKblaVBAusMwbeTJTaCEfmS;

		public NativeRingBuffer(int P_0)
		{
			sePoPlKGxGKaJDGGOLjZQdGAvDPK = P_0;
			if (P_0 <= 0)
			{
				throw new ArgumentOutOfRangeException("sizeInBytes");
			}
			FxqaDQtsGTghuAnWMgqtsdCZKIZGb = new NativeBuffer(P_0);
		}

		public IntPtr Allocate(int bufferLength, bool zeroFill, out uint passId)
		{
			IntPtr pointer = FxqaDQtsGTghuAnWMgqtsdCZKIZGb.GetPointer((int)qufarkKblaVBAusMwbeTJTaCEfmS);
			passId = NUoSZiLEnjAkaaEogpoyiGoyJuCM;
			if (zeroFill)
			{
				int num = 0;
				FxqaDQtsGTghuAnWMgqtsdCZKIZGb.TryFill(0, bufferLength, (int)qufarkKblaVBAusMwbeTJTaCEfmS);
				if (num == 0)
				{
					return IntPtr.Zero;
				}
				if (num < bufferLength)
				{
					num += FxqaDQtsGTghuAnWMgqtsdCZKIZGb.TryFill(0, bufferLength - num, num);
				}
			}
			vZqMrAzwaApyKWAszTrgcFfiMqHI(bufferLength);
			return pointer;
		}

		public int Write(IntPtr buffer, int bufferLength, int numBytesToWrite, out int startOffset, out uint passId)
		{
			startOffset = (int)qufarkKblaVBAusMwbeTJTaCEfmS;
			passId = NUoSZiLEnjAkaaEogpoyiGoyJuCM;
			if (buffer == IntPtr.Zero || bufferLength <= 0 || numBytesToWrite <= 0)
			{
				return 0;
			}
			if (numBytesToWrite > bufferLength)
			{
				numBytesToWrite = bufferLength;
			}
			int num = FxqaDQtsGTghuAnWMgqtsdCZKIZGb.TryWriteBytes(buffer, bufferLength, numBytesToWrite, (int)qufarkKblaVBAusMwbeTJTaCEfmS);
			if (num == 0)
			{
				return 0;
			}
			if (num < numBytesToWrite)
			{
				num += FxqaDQtsGTghuAnWMgqtsdCZKIZGb.TryWriteBytes(buffer, bufferLength, numBytesToWrite - num, 0, num);
			}
			vZqMrAzwaApyKWAszTrgcFfiMqHI(num);
			return num;
		}

		public int Write(byte[] buffer, int numBytesToWrite, out int startOffset, out uint passId)
		{
			startOffset = (int)qufarkKblaVBAusMwbeTJTaCEfmS;
			passId = NUoSZiLEnjAkaaEogpoyiGoyJuCM;
			if (buffer == null)
			{
				return 0;
			}
			int num = buffer.Length;
			if (num <= 0 || numBytesToWrite <= 0)
			{
				return 0;
			}
			if (numBytesToWrite > num)
			{
				numBytesToWrite = num;
			}
			int num2 = FxqaDQtsGTghuAnWMgqtsdCZKIZGb.TryWriteBytes(buffer, numBytesToWrite, (int)qufarkKblaVBAusMwbeTJTaCEfmS);
			if (num2 == 0)
			{
				return 0;
			}
			if (num2 < numBytesToWrite)
			{
				num2 += FxqaDQtsGTghuAnWMgqtsdCZKIZGb.TryWriteBytes(buffer, numBytesToWrite - num2, 0, num2);
			}
			vZqMrAzwaApyKWAszTrgcFfiMqHI(num2);
			return num2;
		}

		public int Write(IntPtr buffer, int bufferLength, int numBytesToWrite)
		{
			int startOffset;
			uint passId;
			return Write(buffer, bufferLength, numBytesToWrite, out startOffset, out passId);
		}

		public int Write(byte[] buffer, int numBytesToWrite)
		{
			int startOffset;
			uint passId;
			return Write(buffer, numBytesToWrite, out startOffset, out passId);
		}

		public int Read(IntPtr buffer, int bufferLength, int numBytesToRead)
		{
			if (buffer == IntPtr.Zero || bufferLength <= 0 || numBytesToRead <= 0 || ObVfFjOQtPAMGUQFaQhECLnrgoKkA == 0)
			{
				return 0;
			}
			if (numBytesToRead > bufferLength)
			{
				numBytesToRead = bufferLength;
			}
			if (numBytesToRead > ObVfFjOQtPAMGUQFaQhECLnrgoKkA)
			{
				numBytesToRead = ObVfFjOQtPAMGUQFaQhECLnrgoKkA;
			}
			int num = FxqaDQtsGTghuAnWMgqtsdCZKIZGb.TryReadBytes(buffer, bufferLength, numBytesToRead, (int)oERGRivAPuOKROrdMplxAejujNGU);
			if (num <= 0)
			{
				return 0;
			}
			if (num < numBytesToRead)
			{
				num += FxqaDQtsGTghuAnWMgqtsdCZKIZGb.TryReadBytes(buffer, bufferLength, numBytesToRead - num, 0, num);
			}
			PuLAeUURqEVEYRLiAUXBrVbSFXPQ(num);
			return num;
		}

		public int Read(byte[] buffer, int numBytesToRead)
		{
			if (buffer == null)
			{
				return 0;
			}
			int num = buffer.Length;
			if (num <= 0 || numBytesToRead <= 0 || ObVfFjOQtPAMGUQFaQhECLnrgoKkA == 0)
			{
				return 0;
			}
			if (numBytesToRead > num)
			{
				numBytesToRead = num;
			}
			if (numBytesToRead > ObVfFjOQtPAMGUQFaQhECLnrgoKkA)
			{
				numBytesToRead = ObVfFjOQtPAMGUQFaQhECLnrgoKkA;
			}
			int num2 = FxqaDQtsGTghuAnWMgqtsdCZKIZGb.TryReadBytes(buffer, numBytesToRead, (int)oERGRivAPuOKROrdMplxAejujNGU);
			if (num2 <= 0)
			{
				return 0;
			}
			if (num2 < numBytesToRead)
			{
				num2 += FxqaDQtsGTghuAnWMgqtsdCZKIZGb.TryReadBytes(buffer, numBytesToRead - num2, 0, num2);
			}
			PuLAeUURqEVEYRLiAUXBrVbSFXPQ(num2);
			return num2;
		}

		public int RandomRead(IntPtr buffer, int bufferLength, int numBytesToRead, int readStartIndex)
		{
			if (buffer == IntPtr.Zero || bufferLength <= 0 || numBytesToRead <= 0 || ObVfFjOQtPAMGUQFaQhECLnrgoKkA == 0 || readStartIndex < 0 || readStartIndex >= sePoPlKGxGKaJDGGOLjZQdGAvDPK)
			{
				return 0;
			}
			if (numBytesToRead > bufferLength)
			{
				numBytesToRead = bufferLength;
			}
			if (numBytesToRead > ObVfFjOQtPAMGUQFaQhECLnrgoKkA)
			{
				numBytesToRead = ObVfFjOQtPAMGUQFaQhECLnrgoKkA;
			}
			int num = FxqaDQtsGTghuAnWMgqtsdCZKIZGb.TryReadBytes(buffer, bufferLength, numBytesToRead, readStartIndex);
			if (num <= 0)
			{
				return 0;
			}
			if (num < numBytesToRead)
			{
				num += FxqaDQtsGTghuAnWMgqtsdCZKIZGb.TryReadBytes(buffer, bufferLength, numBytesToRead - num, 0, num);
			}
			return num;
		}

		public int RandomRead(byte[] buffer, int numBytesToRead, int readStartIndex)
		{
			if (buffer == null)
			{
				return 0;
			}
			int num = buffer.Length;
			if (num <= 0 || numBytesToRead <= 0 || ObVfFjOQtPAMGUQFaQhECLnrgoKkA == 0 || readStartIndex < 0 || readStartIndex >= sePoPlKGxGKaJDGGOLjZQdGAvDPK)
			{
				return 0;
			}
			if (numBytesToRead > num)
			{
				numBytesToRead = num;
			}
			if (numBytesToRead > ObVfFjOQtPAMGUQFaQhECLnrgoKkA)
			{
				numBytesToRead = ObVfFjOQtPAMGUQFaQhECLnrgoKkA;
			}
			int num2 = FxqaDQtsGTghuAnWMgqtsdCZKIZGb.TryReadBytes(buffer, numBytesToRead, readStartIndex);
			if (num2 <= 0)
			{
				return 0;
			}
			if (num2 < numBytesToRead)
			{
				num2 += FxqaDQtsGTghuAnWMgqtsdCZKIZGb.TryReadBytes(buffer, numBytesToRead - num2, 0, num2);
			}
			return num2;
		}

		public IntPtr GetPointerFromReadPosition(int offset)
		{
			int offsetFromReadPosition = GetOffsetFromReadPosition(offset);
			if (offsetFromReadPosition < 0)
			{
				return IntPtr.Zero;
			}
			return FxqaDQtsGTghuAnWMgqtsdCZKIZGb.GetPointer(offsetFromReadPosition);
		}

		public int GetOffsetFromReadPosition(int offset)
		{
			int num = (int)oERGRivAPuOKROrdMplxAejujNGU + offset;
			if (num >= sePoPlKGxGKaJDGGOLjZQdGAvDPK)
			{
				num -= sePoPlKGxGKaJDGGOLjZQdGAvDPK;
			}
			else if (num < 0)
			{
				num += sePoPlKGxGKaJDGGOLjZQdGAvDPK;
			}
			if (num < 0 || num >= sePoPlKGxGKaJDGGOLjZQdGAvDPK)
			{
				return -1;
			}
			return num;
		}

		public bool IsValid(int startIndex, uint passId)
		{
			if (startIndex < 0 || startIndex >= sePoPlKGxGKaJDGGOLjZQdGAvDPK)
			{
				return false;
			}
			if (startIndex < qufarkKblaVBAusMwbeTJTaCEfmS)
			{
				if (passId == NUoSZiLEnjAkaaEogpoyiGoyJuCM)
				{
					return true;
				}
			}
			else if (startIndex >= qufarkKblaVBAusMwbeTJTaCEfmS)
			{
				if (NUoSZiLEnjAkaaEogpoyiGoyJuCM == 0)
				{
					return false;
				}
				if (NUoSZiLEnjAkaaEogpoyiGoyJuCM - 1 == passId)
				{
					return true;
				}
			}
			return false;
		}

		public void CopyFrom(NativeRingBuffer other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			if (sePoPlKGxGKaJDGGOLjZQdGAvDPK != other.sePoPlKGxGKaJDGGOLjZQdGAvDPK)
			{
				throw new Exception("Buffer does not have the same capacity. Cannot copy.");
			}
			qufarkKblaVBAusMwbeTJTaCEfmS = other.qufarkKblaVBAusMwbeTJTaCEfmS;
			oERGRivAPuOKROrdMplxAejujNGU = other.oERGRivAPuOKROrdMplxAejujNGU;
			ObVfFjOQtPAMGUQFaQhECLnrgoKkA = other.ObVfFjOQtPAMGUQFaQhECLnrgoKkA;
			oinKDlkgKQQNTbLiIpRwRCrQymUh = other.oinKDlkgKQQNTbLiIpRwRCrQymUh;
			NUoSZiLEnjAkaaEogpoyiGoyJuCM = other.NUoSZiLEnjAkaaEogpoyiGoyJuCM;
			FxqaDQtsGTghuAnWMgqtsdCZKIZGb.CopyFrom(other.FxqaDQtsGTghuAnWMgqtsdCZKIZGb);
		}

		public void Reset()
		{
			qufarkKblaVBAusMwbeTJTaCEfmS = 0L;
			oERGRivAPuOKROrdMplxAejujNGU = 0L;
			ObVfFjOQtPAMGUQFaQhECLnrgoKkA = 0;
			oinKDlkgKQQNTbLiIpRwRCrQymUh = false;
			NUoSZiLEnjAkaaEogpoyiGoyJuCM = 0u;
		}

		private void vZqMrAzwaApyKWAszTrgcFfiMqHI(int P_0)
		{
			if (P_0 <= 0)
			{
				return;
			}
			int num = (int)qufarkKblaVBAusMwbeTJTaCEfmS;
			qufarkKblaVBAusMwbeTJTaCEfmS += P_0;
			bool flag = false;
			if (num < oERGRivAPuOKROrdMplxAejujNGU)
			{
				if (qufarkKblaVBAusMwbeTJTaCEfmS > oERGRivAPuOKROrdMplxAejujNGU)
				{
					flag = true;
				}
			}
			else if (num > oERGRivAPuOKROrdMplxAejujNGU)
			{
				if (qufarkKblaVBAusMwbeTJTaCEfmS - sePoPlKGxGKaJDGGOLjZQdGAvDPK > oERGRivAPuOKROrdMplxAejujNGU)
				{
					flag = true;
				}
			}
			else if (ObVfFjOQtPAMGUQFaQhECLnrgoKkA > 0)
			{
				flag = true;
			}
			if (flag)
			{
				oinKDlkgKQQNTbLiIpRwRCrQymUh = true;
				oERGRivAPuOKROrdMplxAejujNGU = qufarkKblaVBAusMwbeTJTaCEfmS;
				if (oERGRivAPuOKROrdMplxAejujNGU >= sePoPlKGxGKaJDGGOLjZQdGAvDPK)
				{
					oERGRivAPuOKROrdMplxAejujNGU -= sePoPlKGxGKaJDGGOLjZQdGAvDPK;
				}
			}
			if (qufarkKblaVBAusMwbeTJTaCEfmS >= sePoPlKGxGKaJDGGOLjZQdGAvDPK)
			{
				qufarkKblaVBAusMwbeTJTaCEfmS -= sePoPlKGxGKaJDGGOLjZQdGAvDPK;
				cvfQELlbEodYoClcFPqpZlbWTJBg();
			}
			ObVfFjOQtPAMGUQFaQhECLnrgoKkA = (int)MathTools.Clamp((long)ObVfFjOQtPAMGUQFaQhECLnrgoKkA + (long)P_0, 0L, sePoPlKGxGKaJDGGOLjZQdGAvDPK);
		}

		private void PuLAeUURqEVEYRLiAUXBrVbSFXPQ(int P_0)
		{
			if (P_0 > 0)
			{
				if (oinKDlkgKQQNTbLiIpRwRCrQymUh)
				{
					oinKDlkgKQQNTbLiIpRwRCrQymUh = false;
				}
				oERGRivAPuOKROrdMplxAejujNGU += P_0;
				if (oERGRivAPuOKROrdMplxAejujNGU >= sePoPlKGxGKaJDGGOLjZQdGAvDPK)
				{
					oERGRivAPuOKROrdMplxAejujNGU -= sePoPlKGxGKaJDGGOLjZQdGAvDPK;
				}
				long num = (long)ObVfFjOQtPAMGUQFaQhECLnrgoKkA - (long)P_0;
				ObVfFjOQtPAMGUQFaQhECLnrgoKkA = (int)((num >= 0) ? num : 0);
			}
		}

		private void cvfQELlbEodYoClcFPqpZlbWTJBg()
		{
			if (NUoSZiLEnjAkaaEogpoyiGoyJuCM == uint.MaxValue)
			{
				NUoSZiLEnjAkaaEogpoyiGoyJuCM = 0u;
			}
			else
			{
				NUoSZiLEnjAkaaEogpoyiGoyJuCM++;
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

		~NativeRingBuffer()
		{
			Dispose(disposing: false);
		}

		protected void Dispose(bool disposing)
		{
			if (!IOotYweRBstAacHyGjTroISijmnH)
			{
				if (disposing && FxqaDQtsGTghuAnWMgqtsdCZKIZGb != null)
				{
					FxqaDQtsGTghuAnWMgqtsdCZKIZGb.Dispose();
				}
				IOotYweRBstAacHyGjTroISijmnH = true;
			}
		}
	}
}
