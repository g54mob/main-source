using System;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class NativeRingBuffer : IDisposable
	{
		private readonly NativeBuffer aiXbtGmsIGAPUkbERDpeKzCxbUxS;

		private readonly int LucgYrZqYTtdnGyWHFESvWGwgvbW;

		private long NhIuDoRufbGykvjWxKfAkKuecrIdA;

		private long RssEuiaqZbgpxDhhHtigtgnExTeR;

		private int prmwzbJXbAfnyZKFdmWRtydZwgim;

		private bool BXUkshrvAVWbtcmaTeqdGwlgQigjA;

		private uint eKFfqkgYxwkdQijmrpolrNaQFwsjA;

		private bool zEJEXcdzXbqGAdIkNBiifDCKBjFdb;

		public int Capacity => LucgYrZqYTtdnGyWHFESvWGwgvbW;

		public int BytesInBuffer => prmwzbJXbAfnyZKFdmWRtydZwgim;

		public bool BufferOverrun => BXUkshrvAVWbtcmaTeqdGwlgQigjA;

		public int ReadPosition => (int)RssEuiaqZbgpxDhhHtigtgnExTeR;

		public long WritePosition => NhIuDoRufbGykvjWxKfAkKuecrIdA;

		public NativeRingBuffer(int P_0)
		{
			LucgYrZqYTtdnGyWHFESvWGwgvbW = P_0;
			if (P_0 <= 0)
			{
				throw new ArgumentOutOfRangeException("sizeInBytes");
			}
			aiXbtGmsIGAPUkbERDpeKzCxbUxS = new NativeBuffer(P_0);
		}

		public IntPtr Allocate(int bufferLength, bool zeroFill, out uint passId)
		{
			IntPtr pointer = aiXbtGmsIGAPUkbERDpeKzCxbUxS.GetPointer((int)NhIuDoRufbGykvjWxKfAkKuecrIdA);
			passId = eKFfqkgYxwkdQijmrpolrNaQFwsjA;
			if (zeroFill)
			{
				int num = 0;
				aiXbtGmsIGAPUkbERDpeKzCxbUxS.TryFill(0, bufferLength, (int)NhIuDoRufbGykvjWxKfAkKuecrIdA);
				if (num == 0)
				{
					return IntPtr.Zero;
				}
				if (num < bufferLength)
				{
					num += aiXbtGmsIGAPUkbERDpeKzCxbUxS.TryFill(0, bufferLength - num, num);
				}
			}
			AQXAyKGugJkQkbJgjsUrZLvoQKlaB(bufferLength);
			return pointer;
		}

		public int Write(IntPtr buffer, int bufferLength, int numBytesToWrite, out int startOffset, out uint passId)
		{
			startOffset = (int)NhIuDoRufbGykvjWxKfAkKuecrIdA;
			passId = eKFfqkgYxwkdQijmrpolrNaQFwsjA;
			if (buffer == IntPtr.Zero || bufferLength <= 0 || numBytesToWrite <= 0)
			{
				return 0;
			}
			if (numBytesToWrite > bufferLength)
			{
				numBytesToWrite = bufferLength;
			}
			int num = aiXbtGmsIGAPUkbERDpeKzCxbUxS.TryWriteBytes(buffer, bufferLength, numBytesToWrite, (int)NhIuDoRufbGykvjWxKfAkKuecrIdA);
			if (num == 0)
			{
				return 0;
			}
			if (num < numBytesToWrite)
			{
				num += aiXbtGmsIGAPUkbERDpeKzCxbUxS.TryWriteBytes(buffer, bufferLength, numBytesToWrite - num, 0, num);
			}
			AQXAyKGugJkQkbJgjsUrZLvoQKlaB(num);
			return num;
		}

		public int Write(byte[] buffer, int numBytesToWrite, out int startOffset, out uint passId)
		{
			startOffset = (int)NhIuDoRufbGykvjWxKfAkKuecrIdA;
			passId = eKFfqkgYxwkdQijmrpolrNaQFwsjA;
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
			int num2 = aiXbtGmsIGAPUkbERDpeKzCxbUxS.TryWriteBytes(buffer, numBytesToWrite, (int)NhIuDoRufbGykvjWxKfAkKuecrIdA);
			if (num2 == 0)
			{
				return 0;
			}
			if (num2 < numBytesToWrite)
			{
				num2 += aiXbtGmsIGAPUkbERDpeKzCxbUxS.TryWriteBytes(buffer, numBytesToWrite - num2, 0, num2);
			}
			AQXAyKGugJkQkbJgjsUrZLvoQKlaB(num2);
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
			if (buffer == IntPtr.Zero || bufferLength <= 0 || numBytesToRead <= 0 || prmwzbJXbAfnyZKFdmWRtydZwgim == 0)
			{
				return 0;
			}
			if (numBytesToRead > bufferLength)
			{
				numBytesToRead = bufferLength;
			}
			if (numBytesToRead > prmwzbJXbAfnyZKFdmWRtydZwgim)
			{
				numBytesToRead = prmwzbJXbAfnyZKFdmWRtydZwgim;
			}
			int num = aiXbtGmsIGAPUkbERDpeKzCxbUxS.TryReadBytes(buffer, bufferLength, numBytesToRead, (int)RssEuiaqZbgpxDhhHtigtgnExTeR);
			if (num <= 0)
			{
				return 0;
			}
			if (num < numBytesToRead)
			{
				num += aiXbtGmsIGAPUkbERDpeKzCxbUxS.TryReadBytes(buffer, bufferLength, numBytesToRead - num, 0, num);
			}
			aHcTGWPNyZDniOfuZgEMHGpcLHrOA(num);
			return num;
		}

		public int Read(byte[] buffer, int numBytesToRead)
		{
			if (buffer == null)
			{
				return 0;
			}
			int num = buffer.Length;
			if (num <= 0 || numBytesToRead <= 0 || prmwzbJXbAfnyZKFdmWRtydZwgim == 0)
			{
				return 0;
			}
			if (numBytesToRead > num)
			{
				numBytesToRead = num;
			}
			if (numBytesToRead > prmwzbJXbAfnyZKFdmWRtydZwgim)
			{
				numBytesToRead = prmwzbJXbAfnyZKFdmWRtydZwgim;
			}
			int num2 = aiXbtGmsIGAPUkbERDpeKzCxbUxS.TryReadBytes(buffer, numBytesToRead, (int)RssEuiaqZbgpxDhhHtigtgnExTeR);
			if (num2 <= 0)
			{
				return 0;
			}
			if (num2 < numBytesToRead)
			{
				num2 += aiXbtGmsIGAPUkbERDpeKzCxbUxS.TryReadBytes(buffer, numBytesToRead - num2, 0, num2);
			}
			aHcTGWPNyZDniOfuZgEMHGpcLHrOA(num2);
			return num2;
		}

		public int RandomRead(IntPtr buffer, int bufferLength, int numBytesToRead, int readStartIndex)
		{
			if (buffer == IntPtr.Zero || bufferLength <= 0 || numBytesToRead <= 0 || prmwzbJXbAfnyZKFdmWRtydZwgim == 0 || readStartIndex < 0 || readStartIndex >= LucgYrZqYTtdnGyWHFESvWGwgvbW)
			{
				return 0;
			}
			if (numBytesToRead > bufferLength)
			{
				numBytesToRead = bufferLength;
			}
			if (numBytesToRead > prmwzbJXbAfnyZKFdmWRtydZwgim)
			{
				numBytesToRead = prmwzbJXbAfnyZKFdmWRtydZwgim;
			}
			int num = aiXbtGmsIGAPUkbERDpeKzCxbUxS.TryReadBytes(buffer, bufferLength, numBytesToRead, readStartIndex);
			if (num <= 0)
			{
				return 0;
			}
			if (num < numBytesToRead)
			{
				num += aiXbtGmsIGAPUkbERDpeKzCxbUxS.TryReadBytes(buffer, bufferLength, numBytesToRead - num, 0, num);
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
			if (num <= 0 || numBytesToRead <= 0 || prmwzbJXbAfnyZKFdmWRtydZwgim == 0 || readStartIndex < 0 || readStartIndex >= LucgYrZqYTtdnGyWHFESvWGwgvbW)
			{
				return 0;
			}
			if (numBytesToRead > num)
			{
				numBytesToRead = num;
			}
			if (numBytesToRead > prmwzbJXbAfnyZKFdmWRtydZwgim)
			{
				numBytesToRead = prmwzbJXbAfnyZKFdmWRtydZwgim;
			}
			int num2 = aiXbtGmsIGAPUkbERDpeKzCxbUxS.TryReadBytes(buffer, numBytesToRead, readStartIndex);
			if (num2 <= 0)
			{
				return 0;
			}
			if (num2 < numBytesToRead)
			{
				num2 += aiXbtGmsIGAPUkbERDpeKzCxbUxS.TryReadBytes(buffer, numBytesToRead - num2, 0, num2);
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
			return aiXbtGmsIGAPUkbERDpeKzCxbUxS.GetPointer(offsetFromReadPosition);
		}

		public int GetOffsetFromReadPosition(int offset)
		{
			int num = (int)RssEuiaqZbgpxDhhHtigtgnExTeR + offset;
			if (num >= LucgYrZqYTtdnGyWHFESvWGwgvbW)
			{
				num -= LucgYrZqYTtdnGyWHFESvWGwgvbW;
			}
			else if (num < 0)
			{
				num += LucgYrZqYTtdnGyWHFESvWGwgvbW;
			}
			if (num < 0 || num >= LucgYrZqYTtdnGyWHFESvWGwgvbW)
			{
				return -1;
			}
			return num;
		}

		public bool IsValid(int startIndex, uint passId)
		{
			if (startIndex < 0 || startIndex >= LucgYrZqYTtdnGyWHFESvWGwgvbW)
			{
				return false;
			}
			if (startIndex < NhIuDoRufbGykvjWxKfAkKuecrIdA)
			{
				if (passId == eKFfqkgYxwkdQijmrpolrNaQFwsjA)
				{
					return true;
				}
			}
			else if (startIndex >= NhIuDoRufbGykvjWxKfAkKuecrIdA)
			{
				if (eKFfqkgYxwkdQijmrpolrNaQFwsjA == 0)
				{
					return false;
				}
				if (eKFfqkgYxwkdQijmrpolrNaQFwsjA - 1 == passId)
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
			if (LucgYrZqYTtdnGyWHFESvWGwgvbW != other.LucgYrZqYTtdnGyWHFESvWGwgvbW)
			{
				throw new Exception("Buffer does not have the same capacity. Cannot copy.");
			}
			NhIuDoRufbGykvjWxKfAkKuecrIdA = other.NhIuDoRufbGykvjWxKfAkKuecrIdA;
			RssEuiaqZbgpxDhhHtigtgnExTeR = other.RssEuiaqZbgpxDhhHtigtgnExTeR;
			prmwzbJXbAfnyZKFdmWRtydZwgim = other.prmwzbJXbAfnyZKFdmWRtydZwgim;
			BXUkshrvAVWbtcmaTeqdGwlgQigjA = other.BXUkshrvAVWbtcmaTeqdGwlgQigjA;
			eKFfqkgYxwkdQijmrpolrNaQFwsjA = other.eKFfqkgYxwkdQijmrpolrNaQFwsjA;
			aiXbtGmsIGAPUkbERDpeKzCxbUxS.CopyFrom(other.aiXbtGmsIGAPUkbERDpeKzCxbUxS);
		}

		public void Reset()
		{
			NhIuDoRufbGykvjWxKfAkKuecrIdA = 0L;
			RssEuiaqZbgpxDhhHtigtgnExTeR = 0L;
			prmwzbJXbAfnyZKFdmWRtydZwgim = 0;
			BXUkshrvAVWbtcmaTeqdGwlgQigjA = false;
			eKFfqkgYxwkdQijmrpolrNaQFwsjA = 0u;
		}

		private void AQXAyKGugJkQkbJgjsUrZLvoQKlaB(int P_0)
		{
			if (P_0 <= 0)
			{
				return;
			}
			int num = (int)NhIuDoRufbGykvjWxKfAkKuecrIdA;
			NhIuDoRufbGykvjWxKfAkKuecrIdA += P_0;
			bool flag = false;
			if (num < RssEuiaqZbgpxDhhHtigtgnExTeR)
			{
				if (NhIuDoRufbGykvjWxKfAkKuecrIdA > RssEuiaqZbgpxDhhHtigtgnExTeR)
				{
					flag = true;
				}
			}
			else if (num > RssEuiaqZbgpxDhhHtigtgnExTeR)
			{
				if (NhIuDoRufbGykvjWxKfAkKuecrIdA - LucgYrZqYTtdnGyWHFESvWGwgvbW > RssEuiaqZbgpxDhhHtigtgnExTeR)
				{
					flag = true;
				}
			}
			else if (prmwzbJXbAfnyZKFdmWRtydZwgim > 0)
			{
				flag = true;
			}
			if (flag)
			{
				BXUkshrvAVWbtcmaTeqdGwlgQigjA = true;
				RssEuiaqZbgpxDhhHtigtgnExTeR = NhIuDoRufbGykvjWxKfAkKuecrIdA;
				if (RssEuiaqZbgpxDhhHtigtgnExTeR >= LucgYrZqYTtdnGyWHFESvWGwgvbW)
				{
					RssEuiaqZbgpxDhhHtigtgnExTeR -= LucgYrZqYTtdnGyWHFESvWGwgvbW;
				}
			}
			if (NhIuDoRufbGykvjWxKfAkKuecrIdA >= LucgYrZqYTtdnGyWHFESvWGwgvbW)
			{
				NhIuDoRufbGykvjWxKfAkKuecrIdA -= LucgYrZqYTtdnGyWHFESvWGwgvbW;
				FIQFcHiqMtUWWJOkQAYsmYhwMDrM();
			}
			prmwzbJXbAfnyZKFdmWRtydZwgim = (int)MathTools.Clamp((long)prmwzbJXbAfnyZKFdmWRtydZwgim + (long)P_0, 0L, LucgYrZqYTtdnGyWHFESvWGwgvbW);
		}

		private void aHcTGWPNyZDniOfuZgEMHGpcLHrOA(int P_0)
		{
			if (P_0 > 0)
			{
				if (BXUkshrvAVWbtcmaTeqdGwlgQigjA)
				{
					BXUkshrvAVWbtcmaTeqdGwlgQigjA = false;
				}
				RssEuiaqZbgpxDhhHtigtgnExTeR += P_0;
				if (RssEuiaqZbgpxDhhHtigtgnExTeR >= LucgYrZqYTtdnGyWHFESvWGwgvbW)
				{
					RssEuiaqZbgpxDhhHtigtgnExTeR -= LucgYrZqYTtdnGyWHFESvWGwgvbW;
				}
				long num = (long)prmwzbJXbAfnyZKFdmWRtydZwgim - (long)P_0;
				prmwzbJXbAfnyZKFdmWRtydZwgim = (int)((num >= 0) ? num : 0);
			}
		}

		private void FIQFcHiqMtUWWJOkQAYsmYhwMDrM()
		{
			if (eKFfqkgYxwkdQijmrpolrNaQFwsjA == uint.MaxValue)
			{
				eKFfqkgYxwkdQijmrpolrNaQFwsjA = 0u;
			}
			else
			{
				eKFfqkgYxwkdQijmrpolrNaQFwsjA++;
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
			if (!zEJEXcdzXbqGAdIkNBiifDCKBjFdb)
			{
				if (disposing && aiXbtGmsIGAPUkbERDpeKzCxbUxS != null)
				{
					aiXbtGmsIGAPUkbERDpeKzCxbUxS.Dispose();
				}
				zEJEXcdzXbqGAdIkNBiifDCKBjFdb = true;
			}
		}
	}
}
