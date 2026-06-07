using System;
using System.Collections.Generic;

namespace kcp2k
{
	public class Kcp
	{
		internal struct AckItem
		{
			internal uint serialNumber;

			internal uint timestamp;
		}

		public const int RTO_NDL = 30;

		public const int RTO_MIN = 100;

		public const int RTO_DEF = 200;

		public const int RTO_MAX = 60000;

		public const int CMD_PUSH = 81;

		public const int CMD_ACK = 82;

		public const int CMD_WASK = 83;

		public const int CMD_WINS = 84;

		public const int ASK_SEND = 1;

		public const int ASK_TELL = 2;

		public const int WND_SND = 32;

		public const int WND_RCV = 128;

		public const int MTU_DEF = 1200;

		public const int ACK_FAST = 3;

		public const int INTERVAL = 100;

		public const int OVERHEAD = 24;

		public const int DEADLINK = 20;

		public const int THRESH_INIT = 2;

		public const int THRESH_MIN = 2;

		public const int PROBE_INIT = 7000;

		public const int PROBE_LIMIT = 120000;

		public const int FASTACK_LIMIT = 5;

		internal int state;

		private readonly uint conv;

		internal uint mtu;

		internal uint mss;

		internal uint snd_una;

		internal uint snd_nxt;

		internal uint rcv_nxt;

		internal uint ssthresh;

		internal int rx_rttval;

		internal int rx_srtt;

		internal int rx_rto;

		internal int rx_minrto;

		internal uint snd_wnd;

		internal uint rcv_wnd;

		internal uint rmt_wnd;

		internal uint cwnd;

		internal uint probe;

		internal uint interval;

		internal uint ts_flush;

		internal uint xmit;

		internal uint nodelay;

		internal bool updated;

		internal uint ts_probe;

		internal uint probe_wait;

		internal uint dead_link;

		internal uint incr;

		internal uint current;

		internal int fastresend;

		internal int fastlimit;

		internal bool nocwnd;

		internal readonly Queue<Segment> snd_queue;

		internal readonly Queue<Segment> rcv_queue;

		internal readonly List<Segment> snd_buf;

		internal readonly List<Segment> rcv_buf;

		internal readonly List<AckItem> acklist;

		internal byte[] buffer;

		private readonly Action<byte[], int> output;

		public int WaitSnd => 0;

		public Kcp(uint conv, Action<byte[], int> output)
		{
		}

		private static Segment SegmentNew()
		{
			return null;
		}

		private static void SegmentDelete(Segment seg)
		{
		}

		public int Receive(byte[] buffer, int len)
		{
			return 0;
		}

		public int PeekSize()
		{
			return 0;
		}

		public int Send(byte[] buffer, int offset, int len)
		{
			return 0;
		}

		private void UpdateAck(int rtt)
		{
		}

		internal void ShrinkBuf()
		{
		}

		internal void ParseAck(uint sn)
		{
		}

		private void ParseUna(uint una)
		{
		}

		private void ParseFastack(uint sn, uint ts)
		{
		}

		private void AckPush(uint sn, uint ts)
		{
		}

		private void ParseData(Segment newseg)
		{
		}

		internal void InsertSegmentInReceiveBuffer(Segment newseg)
		{
		}

		private void MoveReceiveBufferDataToReceiveQueue()
		{
		}

		public int Input(byte[] data, int offset, int size)
		{
			return 0;
		}

		private uint WndUnused()
		{
			return 0u;
		}

		public void Flush()
		{
		}

		public void Update(uint currentTimeMilliSeconds)
		{
		}

		public uint Check(uint current_)
		{
			return 0u;
		}

		public void SetMtu(uint mtu)
		{
		}

		public void SetInterval(uint interval)
		{
		}

		public void SetNoDelay(uint nodelay, uint interval = 100u, int resend = 0, bool nocwnd = false)
		{
		}

		public void SetWindowSize(uint sendWindow, uint receiveWindow)
		{
		}
	}
}
