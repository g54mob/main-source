using System.Text;
using Crosstales.Common.Util;

namespace Crosstales.FB
{
	public struct ExtensionFilter
	{
		public string Name;

		public string[] Extensions;

		public ExtensionFilter(string filterName, params string[] filterExtensions)
		{
			Name = filterName;
			Extensions = filterExtensions;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(GetType().Name);
			stringBuilder.Append(BaseConstants.TEXT_TOSTRING_START);
			stringBuilder.Append("Name='");
			stringBuilder.Append(Name);
			stringBuilder.Append(BaseConstants.TEXT_TOSTRING_DELIMITER);
			stringBuilder.Append("Extensions='");
			stringBuilder.Append(Extensions.CTDump());
			stringBuilder.Append(BaseConstants.TEXT_TOSTRING_DELIMITER_END);
			stringBuilder.Append(BaseConstants.TEXT_TOSTRING_END);
			return stringBuilder.ToString();
		}
	}
}
