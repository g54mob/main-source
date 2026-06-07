using System.Collections.Generic;
using System.Text;
using IniParser.Configuration;
using IniParser.Format;
using IniParser.Model;

namespace IniParser
{
	public class IniDataFormatter : IIniDataFormatter
	{
		public string Format(IniData iniData, IniFormattingConfiguration format)
		{
			return null;
		}

		protected virtual void WriteSection(Section section, StringBuilder sb, IniScheme scheme, IniFormattingConfiguration format)
		{
		}

		protected virtual void WriteProperties(PropertyCollection properties, StringBuilder sb, IniScheme scheme, IniFormattingConfiguration format)
		{
		}

		protected virtual void WriteComments(List<string> comments, StringBuilder sb, IniScheme scheme, IniFormattingConfiguration format)
		{
		}
	}
}
