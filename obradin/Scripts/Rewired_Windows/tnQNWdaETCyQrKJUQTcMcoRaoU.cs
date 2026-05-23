using System;
using System.Globalization;
using System.Runtime.CompilerServices;

internal class tnQNWdaETCyQrKJUQTcMcoRaoU : global::kmHpGQwmXoEcVBHxRtFhghtsGww<JosktCWocUzRUmUrWIEPKYkHnXb, IQHJelRbFpHrzcNBHIDddajzJhzx>
{
	[CompilerGenerated]
	private int NwduCokoogvTtbYjySDeCEvkvbg;

	[CompilerGenerated]
	private int MEtHwDUhkSFRaHhTjogcAOZguvt;

	[CompilerGenerated]
	private int cRguGUbYPWSitKkadDkNAJpeKdp;

	[CompilerGenerated]
	private bool[] WjasxJULyytfsOUkUjYSAhNHsQg;

	public int X
	{
		[CompilerGenerated]
		get
		{
			return NwduCokoogvTtbYjySDeCEvkvbg;
		}
		[CompilerGenerated]
		set
		{
			NwduCokoogvTtbYjySDeCEvkvbg = value;
		}
	}

	public int Y
	{
		[CompilerGenerated]
		get
		{
			return MEtHwDUhkSFRaHhTjogcAOZguvt;
		}
		[CompilerGenerated]
		set
		{
			MEtHwDUhkSFRaHhTjogcAOZguvt = value;
		}
	}

	public int Z
	{
		[CompilerGenerated]
		get
		{
			return cRguGUbYPWSitKkadDkNAJpeKdp;
		}
		[CompilerGenerated]
		set
		{
			cRguGUbYPWSitKkadDkNAJpeKdp = value;
		}
	}

	public bool[] Buttons
	{
		[CompilerGenerated]
		get
		{
			return WjasxJULyytfsOUkUjYSAhNHsQg;
		}
		[CompilerGenerated]
		private set
		{
			WjasxJULyytfsOUkUjYSAhNHsQg = value;
		}
	}

	public tnQNWdaETCyQrKJUQTcMcoRaoU()
	{
		Buttons = new bool[8];
	}

	public void Update(IQHJelRbFpHrzcNBHIDddajzJhzx P_0)
	{
		int value = P_0.Value;
		switch (P_0.Offset)
		{
		case MZHUBDTHdehqtjgZrEaaHlgyrAO.xIuDTKizXrGdQWHryFwOfDhIWfYh:
			X = value;
			return;
		case MZHUBDTHdehqtjgZrEaaHlgyrAO.BnoOLWClHLapgAPysAHqWqcOkax:
			Y = value;
			return;
		case MZHUBDTHdehqtjgZrEaaHlgyrAO.XwerGHKXYLmpNFPiVHEnFgJJJrXm:
			Z = value;
			return;
		}
		int num = (int)(P_0.Offset - 12);
		if (num >= 0 && num < 8)
		{
			Buttons[num] = (value & 0x80) != 0;
		}
	}

	public unsafe void MarshalFrom(IntPtr P_0)
	{
		JosktCWocUzRUmUrWIEPKYkHnXb* ptr = (JosktCWocUzRUmUrWIEPKYkHnXb*)(void*)P_0;
		X = ptr->xIuDTKizXrGdQWHryFwOfDhIWfYh;
		Y = ptr->BnoOLWClHLapgAPysAHqWqcOkax;
		Z = ptr->XwerGHKXYLmpNFPiVHEnFgJJJrXm;
		void* ptr2 = &ptr->njZmHLdfhhWLZoHDYycECbArNY;
		fixed (bool* buttons = Buttons)
		{
			for (int i = 0; i < 8; i++)
			{
				buttons[i] = (((byte*)ptr2)[i] & 0x80) != 0;
			}
		}
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "X: {0}, Y: {1}, Z: {2}, Buttons: {3}", X, Y, Z, WISJwItoxlmpVJIyUeIxBJGahMp.TkivIiwenPObKhVpNcJOpmJrSiH(";", Buttons));
	}
}
