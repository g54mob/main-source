using System.Globalization;

namespace Humanizer
{
	public interface ICulturedStringTransformer : IStringTransformer
	{
		string Transform(string input, CultureInfo culture);
	}
}
