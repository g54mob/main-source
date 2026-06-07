using IniParser.Model.Configuration;

namespace IniParser.Model.Formatting
{
	public interface IIniDataFormatter
	{
		IniParserConfiguration Configuration { get; set; }

		string IniDataToString(IniData iniData);
	}
}
