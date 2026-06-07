namespace LiteNetLib
{
	internal sealed class NetPacket
	{
		private static readonly int PropertiesCount;

		private static readonly int[] HeaderSizes;

		public byte[] RawData;

		public int Size;

		public object UserData;

		public NetPacket Next;

		public PacketProperty Property
		{
			get
			{
				return default(PacketProperty);
			}
			set
			{
			}
		}

		public byte ConnectionNumber
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public ushort Sequence
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public bool IsFragmented => false;

		public byte ChannelId
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public ushort FragmentId
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public ushort FragmentPart
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public ushort FragmentsTotal
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		static NetPacket()
		{
		}

		public void MarkFragmented()
		{
		}

		public NetPacket(int size)
		{
		}

		public NetPacket(PacketProperty property, int size)
		{
		}

		public static int GetHeaderSize(PacketProperty property)
		{
			return 0;
		}

		public int GetHeaderSize()
		{
			return 0;
		}

		public bool Verify()
		{
			return false;
		}
	}
}
