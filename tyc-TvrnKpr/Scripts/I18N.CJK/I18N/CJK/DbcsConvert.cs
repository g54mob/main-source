namespace I18N.CJK
{
	internal class DbcsConvert
	{
		public byte[] n2u;

		public byte[] u2n;

		internal static readonly DbcsConvert Gb2312;

		internal static readonly DbcsConvert Big5;

		internal static readonly DbcsConvert KS;

		internal DbcsConvert(string fileName)
		{
		}
	}
}
