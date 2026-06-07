internal static class _0023_003DqB3GsUNKLbaoHqvlL5G3tf25VUl_OcnzbxLgWUzN_m_0024aMNFAbMpS0niXC7XgnnbGk
{
	public static byte[] _0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(byte[] _0023_003DqCUsNHNBUe3Ijs6Dfwo1zDZqjPG9i1rhG6TqELicUblk_003D, byte[] _0023_003DqYSlFxbqnvBCi_0024sNb3gK5cye5_M9DINLU8ZVucIU1qV8_003D)
	{
		byte num = _0023_003DqCUsNHNBUe3Ijs6Dfwo1zDZqjPG9i1rhG6TqELicUblk_003D[1];
		byte b;
		if (true)
		{
			b = num;
		}
		int num2 = _0023_003DqYSlFxbqnvBCi_0024sNb3gK5cye5_M9DINLU8ZVucIU1qV8_003D.Length;
		int num3;
		if (2u != 0)
		{
			num3 = num2;
		}
		byte num4 = (byte)((num3 + 11) ^ (b + 7));
		byte b2 = default(byte);
		if (0 == 0)
		{
			b2 = num4;
		}
		uint num5 = (uint)((_0023_003DqCUsNHNBUe3Ijs6Dfwo1zDZqjPG9i1rhG6TqELicUblk_003D[0] | (_0023_003DqCUsNHNBUe3Ijs6Dfwo1zDZqjPG9i1rhG6TqELicUblk_003D[2] << 8)) + (b2 << 3));
		ushort num6 = 0;
		for (int i = 0; i < num3; i++)
		{
			if ((i & 1) == 0)
			{
				num5 = num5 * 214013 + 2531011;
				num6 = (ushort)(num5 >> 16);
			}
			byte b3 = (byte)num6;
			num6 >>= 8;
			byte b4 = _0023_003DqYSlFxbqnvBCi_0024sNb3gK5cye5_M9DINLU8ZVucIU1qV8_003D[i];
			_0023_003DqYSlFxbqnvBCi_0024sNb3gK5cye5_M9DINLU8ZVucIU1qV8_003D[i] = (byte)(b4 ^ b ^ (b2 + 3) ^ b3);
			b2 = b4;
		}
		return _0023_003DqYSlFxbqnvBCi_0024sNb3gK5cye5_M9DINLU8ZVucIU1qV8_003D;
	}
}
