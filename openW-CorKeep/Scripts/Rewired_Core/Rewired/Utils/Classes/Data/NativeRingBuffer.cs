using System;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class NativeRingBuffer : IDisposable
	{
		private readonly NativeBuffer BllOSlIhbELnpscrgEpoHevuRJkL;

		private readonly int qDIjxOAhlFjqIEOrkkfAAadlpcwlB;

		private long mqiNuPrkGbpbPjhtQOUWrzVltqPX;

		private long sAYCLPfOqdleSDVYurPqNqARMYxz;

		private int UGELQAdvOUPmNFKeCcXRdiOOndpEA;

		private bool scqEZObDnVhkAYcHwWXjinKbWdfBA;

		private uint TonKBJuJWkRqjleNATNdElLBphhu;

		private bool EOpDuBcTulxFpjsVuvVqAMtNLoYm;

		public int Capacity => qDIjxOAhlFjqIEOrkkfAAadlpcwlB;

		public int BytesInBuffer => UGELQAdvOUPmNFKeCcXRdiOOndpEA;

		public bool BufferOverrun => scqEZObDnVhkAYcHwWXjinKbWdfBA;

		public int ReadPosition => (int)sAYCLPfOqdleSDVYurPqNqARMYxz;

		public long WritePosition => mqiNuPrkGbpbPjhtQOUWrzVltqPX;

		public NativeRingBuffer(int P_0)
		{
			qDIjxOAhlFjqIEOrkkfAAadlpcwlB = P_0;
			if (P_0 <= 0)
			{
				throw new ArgumentOutOfRangeException("sizeInBytes");
			}
			BllOSlIhbELnpscrgEpoHevuRJkL = new NativeBuffer(P_0);
		}

		public IntPtr Allocate(int bufferLength, bool zeroFill, out uint passId)
		{
			IntPtr pointer = BllOSlIhbELnpscrgEpoHevuRJkL.GetPointer((int)mqiNuPrkGbpbPjhtQOUWrzVltqPX);
			passId = TonKBJuJWkRqjleNATNdElLBphhu;
			if (zeroFill)
			{
				int num = 0;
				BllOSlIhbELnpscrgEpoHevuRJkL.TryFill(0, bufferLength, (int)mqiNuPrkGbpbPjhtQOUWrzVltqPX);
				if (num == 0)
				{
					return IntPtr.Zero;
				}
				if (num < bufferLength)
				{
					num += BllOSlIhbELnpscrgEpoHevuRJkL.TryFill(0, bufferLength - num, num);
				}
			}
			rBvGJrQLJPsVTVpHLLddQEUDhTmHA(bufferLength);
			return pointer;
		}

		public int Write(IntPtr buffer, int bufferLength, int numBytesToWrite, out int startOffset, out uint passId)
		{
			startOffset = (int)mqiNuPrkGbpbPjhtQOUWrzVltqPX;
			passId = TonKBJuJWkRqjleNATNdElLBphhu;
			if (buffer == IntPtr.Zero || bufferLength <= 0 || numBytesToWrite <= 0)
			{
				return 0;
			}
			if (numBytesToWrite > bufferLength)
			{
				numBytesToWrite = bufferLength;
			}
			int num = BllOSlIhbELnpscrgEpoHevuRJkL.TryWriteBytes(buffer, bufferLength, numBytesToWrite, (int)mqiNuPrkGbpbPjhtQOUWrzVltqPX);
			if (num == 0)
			{
				return 0;
			}
			if (num < numBytesToWrite)
			{
				num += BllOSlIhbELnpscrgEpoHevuRJkL.TryWriteBytes(buffer, bufferLength, numBytesToWrite - num, 0, num);
			}
			rBvGJrQLJPsVTVpHLLddQEUDhTmHA(num);
			return num;
		}

		public int Write(byte[] buffer, int numBytesToWrite, out int startOffset, out uint passId)
		{
			startOffset = (int)mqiNuPrkGbpbPjhtQOUWrzVltqPX;
			passId = TonKBJuJWkRqjleNATNdElLBphhu;
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
			int num2 = BllOSlIhbELnpscrgEpoHevuRJkL.TryWriteBytes(buffer, numBytesToWrite, (int)mqiNuPrkGbpbPjhtQOUWrzVltqPX);
			if (num2 == 0)
			{
				return 0;
			}
			if (num2 < numBytesToWrite)
			{
				num2 += BllOSlIhbELnpscrgEpoHevuRJkL.TryWriteBytes(buffer, numBytesToWrite - num2, 0, num2);
			}
			rBvGJrQLJPsVTVpHLLddQEUDhTmHA(num2);
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
			if (buffer == IntPtr.Zero || bufferLength <= 0 || numBytesToRead <= 0 || UGELQAdvOUPmNFKeCcXRdiOOndpEA == 0)
			{
				return 0;
			}
			if (numBytesToRead > bufferLength)
			{
				numBytesToRead = bufferLength;
			}
			if (numBytesToRead > UGELQAdvOUPmNFKeCcXRdiOOndpEA)
			{
				numBytesToRead = UGELQAdvOUPmNFKeCcXRdiOOndpEA;
			}
			int num = BllOSlIhbELnpscrgEpoHevuRJkL.TryReadBytes(buffer, bufferLength, numBytesToRead, (int)sAYCLPfOqdleSDVYurPqNqARMYxz);
			if (num <= 0)
			{
				return 0;
			}
			if (num < numBytesToRead)
			{
				num += BllOSlIhbELnpscrgEpoHevuRJkL.TryReadBytes(buffer, bufferLength, numBytesToRead - num, 0, num);
			}
			TqOonxbvBFpmRMKNsenMJxUluIsy(num);
			return num;
		}

		public int Read(byte[] buffer, int numBytesToRead)
		{
			if (buffer == null)
			{
				return 0;
			}
			int num = buffer.Length;
			if (num <= 0 || numBytesToRead <= 0 || UGELQAdvOUPmNFKeCcXRdiOOndpEA == 0)
			{
				return 0;
			}
			if (numBytesToRead > num)
			{
				numBytesToRead = num;
			}
			if (numBytesToRead > UGELQAdvOUPmNFKeCcXRdiOOndpEA)
			{
				numBytesToRead = UGELQAdvOUPmNFKeCcXRdiOOndpEA;
			}
			int num2 = BllOSlIhbELnpscrgEpoHevuRJkL.TryReadBytes(buffer, numBytesToRead, (int)sAYCLPfOqdleSDVYurPqNqARMYxz);
			if (num2 <= 0)
			{
				return 0;
			}
			if (num2 < numBytesToRead)
			{
				num2 += BllOSlIhbELnpscrgEpoHevuRJkL.TryReadBytes(buffer, numBytesToRead - num2, 0, num2);
			}
			TqOonxbvBFpmRMKNsenMJxUluIsy(num2);
			return num2;
		}

		public int RandomRead(IntPtr buffer, int bufferLength, int numBytesToRead, int readStartIndex)
		{
			if (buffer == IntPtr.Zero || bufferLength <= 0 || numBytesToRead <= 0 || UGELQAdvOUPmNFKeCcXRdiOOndpEA == 0 || readStartIndex < 0 || readStartIndex >= qDIjxOAhlFjqIEOrkkfAAadlpcwlB)
			{
				return 0;
			}
			if (numBytesToRead > bufferLength)
			{
				numBytesToRead = bufferLength;
			}
			if (numBytesToRead > UGELQAdvOUPmNFKeCcXRdiOOndpEA)
			{
				numBytesToRead = UGELQAdvOUPmNFKeCcXRdiOOndpEA;
			}
			int num = BllOSlIhbELnpscrgEpoHevuRJkL.TryReadBytes(buffer, bufferLength, numBytesToRead, readStartIndex);
			if (num <= 0)
			{
				return 0;
			}
			if (num < numBytesToRead)
			{
				num += BllOSlIhbELnpscrgEpoHevuRJkL.TryReadBytes(buffer, bufferLength, numBytesToRead - num, 0, num);
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
			if (num <= 0 || numBytesToRead <= 0 || UGELQAdvOUPmNFKeCcXRdiOOndpEA == 0 || readStartIndex < 0 || readStartIndex >= qDIjxOAhlFjqIEOrkkfAAadlpcwlB)
			{
				return 0;
			}
			if (numBytesToRead > num)
			{
				numBytesToRead = num;
			}
			if (numBytesToRead > UGELQAdvOUPmNFKeCcXRdiOOndpEA)
			{
				numBytesToRead = UGELQAdvOUPmNFKeCcXRdiOOndpEA;
			}
			int num2 = BllOSlIhbELnpscrgEpoHevuRJkL.TryReadBytes(buffer, numBytesToRead, readStartIndex);
			if (num2 <= 0)
			{
				return 0;
			}
			if (num2 < numBytesToRead)
			{
				num2 += BllOSlIhbELnpscrgEpoHevuRJkL.TryReadBytes(buffer, numBytesToRead - num2, 0, num2);
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
			return BllOSlIhbELnpscrgEpoHevuRJkL.GetPointer(offsetFromReadPosition);
		}

		public int GetOffsetFromReadPosition(int offset)
		{
			int num = (int)sAYCLPfOqdleSDVYurPqNqARMYxz + offset;
			if (num >= qDIjxOAhlFjqIEOrkkfAAadlpcwlB)
			{
				num -= qDIjxOAhlFjqIEOrkkfAAadlpcwlB;
			}
			else if (num < 0)
			{
				num += qDIjxOAhlFjqIEOrkkfAAadlpcwlB;
			}
			if (num < 0 || num >= qDIjxOAhlFjqIEOrkkfAAadlpcwlB)
			{
				return -1;
			}
			return num;
		}

		public bool IsValid(int startIndex, uint passId)
		{
			if (startIndex < 0 || startIndex >= qDIjxOAhlFjqIEOrkkfAAadlpcwlB)
			{
				return false;
			}
			if (startIndex < mqiNuPrkGbpbPjhtQOUWrzVltqPX)
			{
				if (passId == TonKBJuJWkRqjleNATNdElLBphhu)
				{
					return true;
				}
			}
			else if (startIndex >= mqiNuPrkGbpbPjhtQOUWrzVltqPX)
			{
				if (TonKBJuJWkRqjleNATNdElLBphhu == 0)
				{
					return false;
				}
				if (TonKBJuJWkRqjleNATNdElLBphhu - 1 == passId)
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
			if (qDIjxOAhlFjqIEOrkkfAAadlpcwlB != other.qDIjxOAhlFjqIEOrkkfAAadlpcwlB)
			{
				throw new Exception("Buffer does not have the same capacity. Cannot copy.");
			}
			mqiNuPrkGbpbPjhtQOUWrzVltqPX = other.mqiNuPrkGbpbPjhtQOUWrzVltqPX;
			sAYCLPfOqdleSDVYurPqNqARMYxz = other.sAYCLPfOqdleSDVYurPqNqARMYxz;
			UGELQAdvOUPmNFKeCcXRdiOOndpEA = other.UGELQAdvOUPmNFKeCcXRdiOOndpEA;
			scqEZObDnVhkAYcHwWXjinKbWdfBA = other.scqEZObDnVhkAYcHwWXjinKbWdfBA;
			TonKBJuJWkRqjleNATNdElLBphhu = other.TonKBJuJWkRqjleNATNdElLBphhu;
			BllOSlIhbELnpscrgEpoHevuRJkL.CopyFrom(other.BllOSlIhbELnpscrgEpoHevuRJkL);
		}

		public void Reset()
		{
			mqiNuPrkGbpbPjhtQOUWrzVltqPX = 0L;
			sAYCLPfOqdleSDVYurPqNqARMYxz = 0L;
			UGELQAdvOUPmNFKeCcXRdiOOndpEA = 0;
			scqEZObDnVhkAYcHwWXjinKbWdfBA = false;
			TonKBJuJWkRqjleNATNdElLBphhu = 0u;
		}

		private void rBvGJrQLJPsVTVpHLLddQEUDhTmHA(int P_0)
		{
			if (P_0 <= 0)
			{
				return;
			}
			int num = (int)mqiNuPrkGbpbPjhtQOUWrzVltqPX;
			mqiNuPrkGbpbPjhtQOUWrzVltqPX += P_0;
			bool flag = false;
			if (num < sAYCLPfOqdleSDVYurPqNqARMYxz)
			{
				if (mqiNuPrkGbpbPjhtQOUWrzVltqPX > sAYCLPfOqdleSDVYurPqNqARMYxz)
				{
					flag = true;
				}
			}
			else if (num > sAYCLPfOqdleSDVYurPqNqARMYxz)
			{
				if (mqiNuPrkGbpbPjhtQOUWrzVltqPX - qDIjxOAhlFjqIEOrkkfAAadlpcwlB > sAYCLPfOqdleSDVYurPqNqARMYxz)
				{
					flag = true;
				}
			}
			else if (UGELQAdvOUPmNFKeCcXRdiOOndpEA > 0)
			{
				flag = true;
			}
			if (flag)
			{
				scqEZObDnVhkAYcHwWXjinKbWdfBA = true;
				sAYCLPfOqdleSDVYurPqNqARMYxz = mqiNuPrkGbpbPjhtQOUWrzVltqPX;
				if (sAYCLPfOqdleSDVYurPqNqARMYxz >= qDIjxOAhlFjqIEOrkkfAAadlpcwlB)
				{
					sAYCLPfOqdleSDVYurPqNqARMYxz -= qDIjxOAhlFjqIEOrkkfAAadlpcwlB;
				}
			}
			if (mqiNuPrkGbpbPjhtQOUWrzVltqPX >= qDIjxOAhlFjqIEOrkkfAAadlpcwlB)
			{
				mqiNuPrkGbpbPjhtQOUWrzVltqPX -= qDIjxOAhlFjqIEOrkkfAAadlpcwlB;
				iKgCBuKQvxtNrTFXhKrcHfMrMUqCb();
			}
			UGELQAdvOUPmNFKeCcXRdiOOndpEA = (int)MathTools.Clamp((long)UGELQAdvOUPmNFKeCcXRdiOOndpEA + (long)P_0, 0L, qDIjxOAhlFjqIEOrkkfAAadlpcwlB);
		}

		private void TqOonxbvBFpmRMKNsenMJxUluIsy(int P_0)
		{
			if (P_0 > 0)
			{
				if (scqEZObDnVhkAYcHwWXjinKbWdfBA)
				{
					scqEZObDnVhkAYcHwWXjinKbWdfBA = false;
				}
				sAYCLPfOqdleSDVYurPqNqARMYxz += P_0;
				if (sAYCLPfOqdleSDVYurPqNqARMYxz >= qDIjxOAhlFjqIEOrkkfAAadlpcwlB)
				{
					sAYCLPfOqdleSDVYurPqNqARMYxz -= qDIjxOAhlFjqIEOrkkfAAadlpcwlB;
				}
				long num = (long)UGELQAdvOUPmNFKeCcXRdiOOndpEA - (long)P_0;
				UGELQAdvOUPmNFKeCcXRdiOOndpEA = (int)((num >= 0) ? num : 0);
			}
		}

		private void iKgCBuKQvxtNrTFXhKrcHfMrMUqCb()
		{
			if (TonKBJuJWkRqjleNATNdElLBphhu == uint.MaxValue)
			{
				TonKBJuJWkRqjleNATNdElLBphhu = 0u;
			}
			else
			{
				TonKBJuJWkRqjleNATNdElLBphhu++;
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
			if (!EOpDuBcTulxFpjsVuvVqAMtNLoYm)
			{
				if (disposing && BllOSlIhbELnpscrgEpoHevuRJkL != null)
				{
					BllOSlIhbELnpscrgEpoHevuRJkL.Dispose();
				}
				EOpDuBcTulxFpjsVuvVqAMtNLoYm = true;
			}
		}
	}
}
