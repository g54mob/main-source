using System.Globalization;
using System.Runtime.CompilerServices;

namespace ModApi
{
	public static class Culture
	{
		public static readonly CultureInfo EnglishUS;

		public static readonly CultureInfo Invariant;

		public static readonly CultureInfo Original;

		public static CultureInfo Current
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return CultureInfo.CurrentCulture;
			}
		}

		static Culture()
		{
			Original = CultureInfo.CurrentCulture;
			Invariant = CultureInfo.InvariantCulture;
			EnglishUS = CultureInfo.GetCultureInfo("en-US");
			CultureInfo.CurrentCulture = EnglishUS;
			CultureInfo.DefaultThreadCurrentCulture = EnglishUS;
		}
	}
}
