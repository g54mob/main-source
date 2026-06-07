using System;

namespace Rewired.Utils.Classes.Data
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class NativeRingBuffer : IDisposable
	{
		private readonly NativeBuffer bqxkjHAQVvpAPAFoTMYIfbENRmFH;

		private readonly int ngsUIyottIhptdyVRpkhbNqZCuLV;

		private long KHUFfLzDKisOvlwqKiKblHNnZGmB;

		private long NjISKMIgprndSdqxkfyVSWmSxapW;

		private int NkrCbsfLPNOagcpaUsjrcpuvHlLqA;

		private bool jeeNgVRsYQUAzyIByhhyDvtBgusc;

		private uint oFoXlPRsHEIPnjFxbuoshJRTmTJR;

		private bool JChPmMbeaoLOGQvosPYqDDInSiCs;

		public int Capacity => ngsUIyottIhptdyVRpkhbNqZCuLV;

		public int BytesInBuffer => NkrCbsfLPNOagcpaUsjrcpuvHlLqA;

		public bool BufferOverrun => jeeNgVRsYQUAzyIByhhyDvtBgusc;

		public int ReadPosition => (int)NjISKMIgprndSdqxkfyVSWmSxapW;

		public long WritePosition => KHUFfLzDKisOvlwqKiKblHNnZGmB;

		public NativeRingBuffer(int P_0)
		{
			ngsUIyottIhptdyVRpkhbNqZCuLV = P_0;
			if (P_0 <= 0)
			{
				throw new ArgumentOutOfRangeException("sizeInBytes");
			}
			bqxkjHAQVvpAPAFoTMYIfbENRmFH = new NativeBuffer(P_0);
		}

		public IntPtr Allocate(int bufferLength, bool zeroFill, out uint passId)
		{
			IntPtr pointer = bqxkjHAQVvpAPAFoTMYIfbENRmFH.GetPointer((int)KHUFfLzDKisOvlwqKiKblHNnZGmB);
			passId = oFoXlPRsHEIPnjFxbuoshJRTmTJR;
			if (zeroFill)
			{
				int num = 0;
				bqxkjHAQVvpAPAFoTMYIfbENRmFH.TryFill(0, bufferLength, (int)KHUFfLzDKisOvlwqKiKblHNnZGmB);
				if (num == 0)
				{
					return IntPtr.Zero;
				}
				if (num < bufferLength)
				{
					num += bqxkjHAQVvpAPAFoTMYIfbENRmFH.TryFill(0, bufferLength - num, num);
				}
			}
			lVqKKfeXHqoMYiyagXiBmLaunrEF(bufferLength);
			return pointer;
		}

		public int Write(IntPtr buffer, int bufferLength, int numBytesToWrite, out int startOffset, out uint passId)
		{
			startOffset = (int)KHUFfLzDKisOvlwqKiKblHNnZGmB;
			passId = oFoXlPRsHEIPnjFxbuoshJRTmTJR;
			if (buffer == IntPtr.Zero || bufferLength <= 0 || numBytesToWrite <= 0)
			{
				return 0;
			}
			if (numBytesToWrite > bufferLength)
			{
				numBytesToWrite = bufferLength;
			}
			int num = bqxkjHAQVvpAPAFoTMYIfbENRmFH.TryWriteBytes(buffer, bufferLength, numBytesToWrite, (int)KHUFfLzDKisOvlwqKiKblHNnZGmB);
			if (num == 0)
			{
				return 0;
			}
			if (num < numBytesToWrite)
			{
				num += bqxkjHAQVvpAPAFoTMYIfbENRmFH.TryWriteBytes(buffer, bufferLength, numBytesToWrite - num, 0, num);
			}
			lVqKKfeXHqoMYiyagXiBmLaunrEF(num);
			return num;
		}

		public int Write(byte[] buffer, int numBytesToWrite, out int startOffset, out uint passId)
		{
			startOffset = (int)KHUFfLzDKisOvlwqKiKblHNnZGmB;
			passId = oFoXlPRsHEIPnjFxbuoshJRTmTJR;
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
			int num2 = bqxkjHAQVvpAPAFoTMYIfbENRmFH.TryWriteBytes(buffer, numBytesToWrite, (int)KHUFfLzDKisOvlwqKiKblHNnZGmB);
			if (num2 == 0)
			{
				return 0;
			}
			if (num2 < numBytesToWrite)
			{
				num2 += bqxkjHAQVvpAPAFoTMYIfbENRmFH.TryWriteBytes(buffer, numBytesToWrite - num2, 0, num2);
			}
			lVqKKfeXHqoMYiyagXiBmLaunrEF(num2);
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
			if (buffer == IntPtr.Zero || bufferLength <= 0 || numBytesToRead <= 0 || NkrCbsfLPNOagcpaUsjrcpuvHlLqA == 0)
			{
				return 0;
			}
			if (numBytesToRead > bufferLength)
			{
				numBytesToRead = bufferLength;
			}
			if (numBytesToRead > NkrCbsfLPNOagcpaUsjrcpuvHlLqA)
			{
				numBytesToRead = NkrCbsfLPNOagcpaUsjrcpuvHlLqA;
			}
			int num = bqxkjHAQVvpAPAFoTMYIfbENRmFH.TryReadBytes(buffer, bufferLength, numBytesToRead, (int)NjISKMIgprndSdqxkfyVSWmSxapW);
			if (num <= 0)
			{
				return 0;
			}
			if (num < numBytesToRead)
			{
				num += bqxkjHAQVvpAPAFoTMYIfbENRmFH.TryReadBytes(buffer, bufferLength, numBytesToRead - num, 0, num);
			}
			BkieBKLtiSAaopePgeytivVnVtVEA(num);
			return num;
		}

		public int Read(byte[] buffer, int numBytesToRead)
		{
			if (buffer == null)
			{
				return 0;
			}
			int num = buffer.Length;
			if (num <= 0 || numBytesToRead <= 0 || NkrCbsfLPNOagcpaUsjrcpuvHlLqA == 0)
			{
				return 0;
			}
			if (numBytesToRead > num)
			{
				numBytesToRead = num;
			}
			if (numBytesToRead > NkrCbsfLPNOagcpaUsjrcpuvHlLqA)
			{
				numBytesToRead = NkrCbsfLPNOagcpaUsjrcpuvHlLqA;
			}
			int num2 = bqxkjHAQVvpAPAFoTMYIfbENRmFH.TryReadBytes(buffer, numBytesToRead, (int)NjISKMIgprndSdqxkfyVSWmSxapW);
			if (num2 <= 0)
			{
				return 0;
			}
			if (num2 < numBytesToRead)
			{
				num2 += bqxkjHAQVvpAPAFoTMYIfbENRmFH.TryReadBytes(buffer, numBytesToRead - num2, 0, num2);
			}
			BkieBKLtiSAaopePgeytivVnVtVEA(num2);
			return num2;
		}

		public int RandomRead(IntPtr buffer, int bufferLength, int numBytesToRead, int readStartIndex)
		{
			if (buffer == IntPtr.Zero || bufferLength <= 0 || numBytesToRead <= 0 || NkrCbsfLPNOagcpaUsjrcpuvHlLqA == 0 || readStartIndex < 0 || readStartIndex >= ngsUIyottIhptdyVRpkhbNqZCuLV)
			{
				return 0;
			}
			if (numBytesToRead > bufferLength)
			{
				numBytesToRead = bufferLength;
			}
			if (numBytesToRead > NkrCbsfLPNOagcpaUsjrcpuvHlLqA)
			{
				numBytesToRead = NkrCbsfLPNOagcpaUsjrcpuvHlLqA;
			}
			int num = bqxkjHAQVvpAPAFoTMYIfbENRmFH.TryReadBytes(buffer, bufferLength, numBytesToRead, readStartIndex);
			if (num <= 0)
			{
				return 0;
			}
			if (num < numBytesToRead)
			{
				num += bqxkjHAQVvpAPAFoTMYIfbENRmFH.TryReadBytes(buffer, bufferLength, numBytesToRead - num, 0, num);
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
			if (num <= 0 || numBytesToRead <= 0 || NkrCbsfLPNOagcpaUsjrcpuvHlLqA == 0 || readStartIndex < 0 || readStartIndex >= ngsUIyottIhptdyVRpkhbNqZCuLV)
			{
				return 0;
			}
			if (numBytesToRead > num)
			{
				numBytesToRead = num;
			}
			if (numBytesToRead > NkrCbsfLPNOagcpaUsjrcpuvHlLqA)
			{
				numBytesToRead = NkrCbsfLPNOagcpaUsjrcpuvHlLqA;
			}
			int num2 = bqxkjHAQVvpAPAFoTMYIfbENRmFH.TryReadBytes(buffer, numBytesToRead, readStartIndex);
			if (num2 <= 0)
			{
				return 0;
			}
			if (num2 < numBytesToRead)
			{
				num2 += bqxkjHAQVvpAPAFoTMYIfbENRmFH.TryReadBytes(buffer, numBytesToRead - num2, 0, num2);
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
			return bqxkjHAQVvpAPAFoTMYIfbENRmFH.GetPointer(offsetFromReadPosition);
		}

		public int GetOffsetFromReadPosition(int offset)
		{
			int num = (int)NjISKMIgprndSdqxkfyVSWmSxapW + offset;
			if (num >= ngsUIyottIhptdyVRpkhbNqZCuLV)
			{
				num -= ngsUIyottIhptdyVRpkhbNqZCuLV;
			}
			else if (num < 0)
			{
				num += ngsUIyottIhptdyVRpkhbNqZCuLV;
			}
			if (num < 0 || num >= ngsUIyottIhptdyVRpkhbNqZCuLV)
			{
				return -1;
			}
			return num;
		}

		public bool IsValid(int startIndex, uint passId)
		{
			if (startIndex < 0 || startIndex >= ngsUIyottIhptdyVRpkhbNqZCuLV)
			{
				return false;
			}
			if (startIndex < KHUFfLzDKisOvlwqKiKblHNnZGmB)
			{
				if (passId == oFoXlPRsHEIPnjFxbuoshJRTmTJR)
				{
					return true;
				}
			}
			else if (startIndex >= KHUFfLzDKisOvlwqKiKblHNnZGmB)
			{
				if (oFoXlPRsHEIPnjFxbuoshJRTmTJR == 0)
				{
					return false;
				}
				if (oFoXlPRsHEIPnjFxbuoshJRTmTJR - 1 == passId)
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
			if (ngsUIyottIhptdyVRpkhbNqZCuLV != other.ngsUIyottIhptdyVRpkhbNqZCuLV)
			{
				throw new Exception("Buffer does not have the same capacity. Cannot copy.");
			}
			KHUFfLzDKisOvlwqKiKblHNnZGmB = other.KHUFfLzDKisOvlwqKiKblHNnZGmB;
			NjISKMIgprndSdqxkfyVSWmSxapW = other.NjISKMIgprndSdqxkfyVSWmSxapW;
			NkrCbsfLPNOagcpaUsjrcpuvHlLqA = other.NkrCbsfLPNOagcpaUsjrcpuvHlLqA;
			jeeNgVRsYQUAzyIByhhyDvtBgusc = other.jeeNgVRsYQUAzyIByhhyDvtBgusc;
			oFoXlPRsHEIPnjFxbuoshJRTmTJR = other.oFoXlPRsHEIPnjFxbuoshJRTmTJR;
			bqxkjHAQVvpAPAFoTMYIfbENRmFH.CopyFrom(other.bqxkjHAQVvpAPAFoTMYIfbENRmFH);
		}

		public void Reset()
		{
			KHUFfLzDKisOvlwqKiKblHNnZGmB = 0L;
			NjISKMIgprndSdqxkfyVSWmSxapW = 0L;
			NkrCbsfLPNOagcpaUsjrcpuvHlLqA = 0;
			jeeNgVRsYQUAzyIByhhyDvtBgusc = false;
			oFoXlPRsHEIPnjFxbuoshJRTmTJR = 0u;
		}

		private void lVqKKfeXHqoMYiyagXiBmLaunrEF(int P_0)
		{
			if (P_0 <= 0)
			{
				return;
			}
			int num = (int)KHUFfLzDKisOvlwqKiKblHNnZGmB;
			KHUFfLzDKisOvlwqKiKblHNnZGmB += P_0;
			bool flag = false;
			if (num < NjISKMIgprndSdqxkfyVSWmSxapW)
			{
				if (KHUFfLzDKisOvlwqKiKblHNnZGmB > NjISKMIgprndSdqxkfyVSWmSxapW)
				{
					flag = true;
				}
			}
			else if (num > NjISKMIgprndSdqxkfyVSWmSxapW)
			{
				if (KHUFfLzDKisOvlwqKiKblHNnZGmB - ngsUIyottIhptdyVRpkhbNqZCuLV > NjISKMIgprndSdqxkfyVSWmSxapW)
				{
					flag = true;
				}
			}
			else if (NkrCbsfLPNOagcpaUsjrcpuvHlLqA > 0)
			{
				flag = true;
			}
			if (flag)
			{
				jeeNgVRsYQUAzyIByhhyDvtBgusc = true;
				NjISKMIgprndSdqxkfyVSWmSxapW = KHUFfLzDKisOvlwqKiKblHNnZGmB;
				if (NjISKMIgprndSdqxkfyVSWmSxapW >= ngsUIyottIhptdyVRpkhbNqZCuLV)
				{
					NjISKMIgprndSdqxkfyVSWmSxapW -= ngsUIyottIhptdyVRpkhbNqZCuLV;
				}
			}
			if (KHUFfLzDKisOvlwqKiKblHNnZGmB >= ngsUIyottIhptdyVRpkhbNqZCuLV)
			{
				KHUFfLzDKisOvlwqKiKblHNnZGmB -= ngsUIyottIhptdyVRpkhbNqZCuLV;
				HnkBGOXVWHCaqhJBprikSoNiHyAe();
			}
			NkrCbsfLPNOagcpaUsjrcpuvHlLqA = (int)MathTools.Clamp((long)NkrCbsfLPNOagcpaUsjrcpuvHlLqA + (long)P_0, 0L, ngsUIyottIhptdyVRpkhbNqZCuLV);
		}

		private void BkieBKLtiSAaopePgeytivVnVtVEA(int P_0)
		{
			if (P_0 > 0)
			{
				if (jeeNgVRsYQUAzyIByhhyDvtBgusc)
				{
					jeeNgVRsYQUAzyIByhhyDvtBgusc = false;
				}
				NjISKMIgprndSdqxkfyVSWmSxapW += P_0;
				if (NjISKMIgprndSdqxkfyVSWmSxapW >= ngsUIyottIhptdyVRpkhbNqZCuLV)
				{
					NjISKMIgprndSdqxkfyVSWmSxapW -= ngsUIyottIhptdyVRpkhbNqZCuLV;
				}
				long num = (long)NkrCbsfLPNOagcpaUsjrcpuvHlLqA - (long)P_0;
				NkrCbsfLPNOagcpaUsjrcpuvHlLqA = (int)((num >= 0) ? num : 0);
			}
		}

		private void HnkBGOXVWHCaqhJBprikSoNiHyAe()
		{
			if (oFoXlPRsHEIPnjFxbuoshJRTmTJR == uint.MaxValue)
			{
				oFoXlPRsHEIPnjFxbuoshJRTmTJR = 0u;
			}
			else
			{
				oFoXlPRsHEIPnjFxbuoshJRTmTJR++;
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		~NativeRingBuffer()
		{
			Dispose(disposing: false);
		}

		protected void Dispose(bool disposing)
		{
			if (!JChPmMbeaoLOGQvosPYqDDInSiCs)
			{
				if (disposing && bqxkjHAQVvpAPAFoTMYIfbENRmFH != null)
				{
					bqxkjHAQVvpAPAFoTMYIfbENRmFH.Dispose();
				}
				JChPmMbeaoLOGQvosPYqDDInSiCs = true;
			}
		}
	}
}
