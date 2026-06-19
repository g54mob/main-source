using System;

internal struct XEoBfzVrALPXyXfPJRwYkltOwzz : nDrEgNGnTRWwjtbFlemJsFzwuXR
{
	internal int bAPYEfeboQPbkVOmgynwqcsDhlg;

	internal int JeBDgqwIOBAWAOXsVJTHPwQwGVe;

	private int ijHkQHjOcOYoYhIOMWrPdUZbPdN;

	private int kYfAPonGHdWJECUyXlejvMdDNcb;

	public int RawOffset
	{
		get
		{
			return bAPYEfeboQPbkVOmgynwqcsDhlg;
		}
		set
		{
			bAPYEfeboQPbkVOmgynwqcsDhlg = value;
		}
	}

	public int Value
	{
		get
		{
			return JeBDgqwIOBAWAOXsVJTHPwQwGVe;
		}
		set
		{
			JeBDgqwIOBAWAOXsVJTHPwQwGVe = value;
		}
	}

	public int Timestamp
	{
		get
		{
			return ijHkQHjOcOYoYhIOMWrPdUZbPdN;
		}
		set
		{
			ijHkQHjOcOYoYhIOMWrPdUZbPdN = value;
		}
	}

	public int Sequence
	{
		get
		{
			return kYfAPonGHdWJECUyXlejvMdDNcb;
		}
		set
		{
			kYfAPonGHdWJECUyXlejvMdDNcb = value;
		}
	}

	public nZzcNYUOUyZqpeVNDWwJlaIJYit Key => HQJcafcuAgGgomkBmRwjOpNZosE(bAPYEfeboQPbkVOmgynwqcsDhlg);

	public bool IsPressed => (JeBDgqwIOBAWAOXsVJTHPwQwGVe & 0x80) != 0;

	public bool IsReleased => !IsPressed;

	private static nZzcNYUOUyZqpeVNDWwJlaIJYit HQJcafcuAgGgomkBmRwjOpNZosE(int P_0)
	{
		if (Enum.IsDefined(typeof(nZzcNYUOUyZqpeVNDWwJlaIJYit), P_0))
		{
			return (nZzcNYUOUyZqpeVNDWwJlaIJYit)P_0;
		}
		return nZzcNYUOUyZqpeVNDWwJlaIJYit.yoCwpETGhcNpYyDgYCzBcMvXnwF;
	}

	public override string ToString()
	{
		return $"Key: {Key}, IsPressed: {IsPressed} Timestamp: {ijHkQHjOcOYoYhIOMWrPdUZbPdN} Sequence: {kYfAPonGHdWJECUyXlejvMdDNcb}";
	}
}
