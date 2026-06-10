using System;

namespace Rewired.HID
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class HIDLight
	{
		private byte TqZuvUHPjcgVDdbtrcBaLFZJPQZ;

		private byte nnQOIEpLAhlGxjvPetPKRqlrLJL;

		private byte WcORGkjXSUbDuYwMkiUsaEiZaYv;

		private Action lMPFZBHgTGcdGhUHHgudRWbakozM;

		public float ColorR
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float ColorG
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float ColorB
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public byte ColorRRaw
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public byte ColorGRaw
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public byte ColorBRaw
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public event Action ValueChangedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		public HIDLight()
		{
		}

		public HIDLight(byte colorRRaw, byte colorGRaw, byte colorBRaw)
		{
		}
	}
}
