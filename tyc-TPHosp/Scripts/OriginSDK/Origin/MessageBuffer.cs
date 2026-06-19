using System;

namespace Origin
{
	public class MessageBuffer
	{
		public enum SeparatorMode
		{
			RemoveSeparator = 0,
			InsertSeparator = 1,
			LeaveSeparator = 2
		}

		private byte[] buffer;

		private int rloc;

		private int wloc;

		private object thisLock = new object();

		public bool HasMessages
		{
			get
			{
				if (rloc == wloc)
				{
					return false;
				}
				for (int i = rloc; i < wloc; i++)
				{
					if (buffer[i] == 0)
					{
						return true;
					}
				}
				return false;
			}
		}

		public event MessageAvailableEvent MessageAvailable;

		public MessageBuffer(int initialSize)
		{
			buffer = new byte[initialSize];
		}

		private void Grow(int len)
		{
			int num = buffer.Length << 1;
			while (num - wloc < len)
			{
				num <<= 1;
			}
			byte[] dst = new byte[num];
			Buffer.BlockCopy(buffer, 0, dst, 0, wloc);
			buffer = dst;
		}

		private void Compact()
		{
			if (rloc > 0)
			{
				if (rloc != wloc)
				{
					Buffer.BlockCopy(buffer, rloc, buffer, 0, wloc - rloc);
				}
				wloc -= rloc;
				rloc = 0;
			}
		}

		public void Push(byte[] data, int len, SeparatorMode addSeparator)
		{
			lock (thisLock)
			{
				if (len > data.Length || len == 0)
				{
					len = data.Length;
				}
				if (buffer.Length - wloc < len + ((addSeparator == SeparatorMode.InsertSeparator) ? 1 : 0))
				{
					Compact();
					if (buffer.Length - wloc < len + ((addSeparator == SeparatorMode.InsertSeparator) ? 1 : 0))
					{
						Grow(len + ((addSeparator == SeparatorMode.InsertSeparator) ? 1 : 0));
					}
				}
				Buffer.BlockCopy(data, 0, buffer, wloc, len);
				wloc += len;
				if (addSeparator == SeparatorMode.InsertSeparator)
				{
					buffer[wloc] = 0;
					wloc++;
				}
			}
			if (this.MessageAvailable != null && HasMessages)
			{
				this.MessageAvailable();
			}
		}

		public byte[] Pop(SeparatorMode removeSeparator)
		{
			lock (thisLock)
			{
				for (int i = rloc; i < wloc; i++)
				{
					if (buffer[i] == 0)
					{
						int num = i - rloc + 1;
						byte[] array = new byte[num - ((removeSeparator == SeparatorMode.RemoveSeparator) ? 1 : 0)];
						Buffer.BlockCopy(buffer, rloc, array, 0, num - ((removeSeparator == SeparatorMode.RemoveSeparator) ? 1 : 0));
						rloc += num;
						if (rloc == wloc)
						{
							Compact();
						}
						return array;
					}
				}
			}
			return new byte[0];
		}
	}
}
